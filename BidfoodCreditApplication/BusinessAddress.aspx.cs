using System;
using System.Web;
using System.Web.UI;
using BidfoodCreditApplication.Helpers;
using BidfoodCreditApplication.Models;

namespace BidfoodCreditApplication
{
    public partial class BusinessAddress : Page
    {
        //Declaring private Variables
        private CherwellBusinessObject _newUser;
        private string _newUserRecordId;

        protected void Page_Load(object sender, EventArgs e)
        {

            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.Now);
            Response.Cache.SetNoServerCaching();
            Response.Cache.SetNoStore();

            _newUserRecordId = Request.QueryString["RECID"]; //setting recordIf from URL

            Page.EnableViewState = true;
            if (Global.ConfirmLogin()) // Check for Cherwell Webservices connection
            {
                _newUser = new CherwellBusinessObject(); //New instance of Cherwell Object by Reference

                if (string.IsNullOrEmpty(_newUserRecordId))
                    Response.Redirect(Global.Redirect); // If recordId is empty then redirect to new Customer

                _newUser = Details.GetDetails("Customer - External", _newUserRecordId); // Getting current user details
                if (IsPostBack) return; // if postback then do not reset user details

                if (_newUser.FieldList.Fields[122].Value == "True")
                    Response.Redirect("~/ApplicationCompleted.aspx?RECID=" + _newUserRecordId);

                var country = Details.GetListCherwellBusinessObjects("Country", "Status", "Active", "Record");
                ddlCountry.Items.Clear();
                ddlCountry.Items.Add("");
                foreach (var item in country)
                    ddlCountry.Items.Add(item.FieldList.Fields[1].Value);
                GetCustomerDetails();
            }
            else
            {
                Response.Redirect("~/LoadFailure.aspx?RECID=" + _newUserRecordId + "&PAGE=BusinessAddress.aspx");
            }
        }

        protected void BtnNext_Click(object sender, ImageClickEventArgs e)
        {
            if (!CheckValues()) return;
            if (!Global.ConfirmLogin()) Response.Redirect("~/LoadFailure.aspx?RECID=" + _newUserRecordId + "&PAGE=" + HttpContext.Current.Request.ApplicationPath);
            SetCustomerDetails();
            Details.UpdateDetails("Customer - External", _newUserRecordId, _newUser);
            //Response.Redirect("~/BusinessUnits.aspx?RECID=" + _newUserRecordId);
            if (_newUser.FieldList.Fields[104].Value == "True")
            {
                Response.Redirect("~/FinancialDetails.aspx?RECID=" + _newUserRecordId);
                return;
            }
            Response.Redirect("~/PostalAddress.aspx?RECID=" + _newUserRecordId);

        }

        protected void BtnBack_Click(object sender, ImageClickEventArgs e)
        {
            if (!Global.ConfirmLogin()) Response.Redirect("~/LoadFailure.aspx?RECID=" + _newUserRecordId + "&PAGE=" + HttpContext.Current.Request.ApplicationPath);
            SetCustomerDetails();
            Details.UpdateDetails("Customer - External", _newUserRecordId, _newUser);
            Response.Redirect("~/BusinessDetails.aspx?RECID=" + _newUserRecordId);
        }

        protected void GetCustomerDetails()
        {
            txtBuildingComplex.Text = _newUser.FieldList.Fields[105].Value;
            txtBuildingNumber.Text = _newUser.FieldList.Fields[106].Value;
            txtStreetName.Text = _newUser.FieldList.Fields[107].Value;
            txtSuburb.Text = _newUser.FieldList.Fields[108].Value;
            txtCity.Text = _newUser.FieldList.Fields[21].Value;
            if (!string.IsNullOrEmpty(_newUser.FieldList.Fields[45].Value))
            {
                ddlCountry.ClearSelection();
                ddlCountry.Items.FindByValue(_newUser.FieldList.Fields[45].Value).Selected = true;
            }
            if (!string.IsNullOrEmpty(ddlCountry.Text))
            {
                DdlCountry_SelectedIndexChanged(null, null);
                ddlProvince.ClearSelection();
                if (!string.IsNullOrEmpty(_newUser.FieldList.Fields[48].Value))
                    try
                    {
                        ddlProvince.Items.FindByValue(_newUser.FieldList.Fields[48].Value).Selected = true;
                    }
                    catch (Exception)
                    {
                        Response.Redirect("~/LoadFailure.aspx");
                    }
            }
            if (!string.IsNullOrEmpty(_newUser.FieldList.Fields[48].Value))
            {
                ddlProvince.ClearSelection();
                try
                {
                    ddlProvince.Items.FindByValue(_newUser.FieldList.Fields[48].Value).Selected = true;
                }
                catch (Exception)
                {
                    Response.Redirect("~/LoadFailure.aspx");
                }
            }
            if (string.IsNullOrEmpty(_newUser.FieldList.Fields[104].Value) ||
                _newUser.FieldList.Fields[104].Value == "True")
            {
                rdbYes.Checked = true;
                rdbNo.Checked = false;
            }
            else
            {
                rdbNo.Checked = true;
                rdbYes.Checked = false;
            }
            txtPostalCode.Text = _newUser.FieldList.Fields[103].Value;
        }

        protected void SetCustomerDetails()
        {
            _newUser.FieldList.Fields[105].Value = txtBuildingComplex.Text;
            _newUser.FieldList.Fields[106].Value = txtBuildingNumber.Text;
            _newUser.FieldList.Fields[107].Value = txtStreetName.Text;
            _newUser.FieldList.Fields[108].Value = txtSuburb.Text;
            _newUser.FieldList.Fields[21].Value = txtCity.Text;
            _newUser.FieldList.Fields[48].Value = ddlProvince.Text;
            _newUser.FieldList.Fields[45].Value = ddlCountry.Text;
            _newUser.FieldList.Fields[104].Value = rdbNo.Checked ? "False" : "True";
            _newUser.FieldList.Fields[103].Value = txtPostalCode.Text;
        }

        protected void RdbNo_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbNo.Checked)
                rdbYes.Checked = false;
        }

        protected void RdbYes_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbYes.Checked)
                rdbNo.Checked = false;
        }

        protected void DdlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlProvince?.ClearSelection();
                var province =
                    Details.GetListCherwellBusinessObjects("Province State", "Country Name", ddlCountry.Text, "Record");
                ddlProvince?.Items.Clear();
                ddlProvince?.Items.Add("");
                foreach (var item in province)
                    ddlProvince?.Items.Add(item.FieldList.Fields[4].Value);
            }
            catch (Exception)
            {
                Response.Redirect("~/LoadFailure.aspx");
            }
        }

        protected bool CheckValues()
        {
            if (string.IsNullOrEmpty(ddlCountry.Text))
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('Please select your Country before advancing.')</script>");
                return false;
            }
            if (string.IsNullOrEmpty(ddlProvince.Text))
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('Please select your Province before advancing.')</script>");
                return false;
            }
            return true;
        }
    }
}