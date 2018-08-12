using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using BidfoodCreditApplication.Helpers;
using BidfoodCreditApplication.Models;

namespace BidfoodCreditApplication
{
    public partial class BusinessUnits : Page
    {
        private CherwellBusinessObject _newUser;
        private string _newUserRecordId;
        private List<CherwellBusinessObject> _businessUnits;

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

                if (_newUser.FieldList.Fields[122].Value == "True") Response.Redirect("~/ApplicationCompleted.aspx?RECID=" + _newUserRecordId);

                var country = Details.GetListCherwellBusinessObjects("Country", "Status", "Active", "Record");
                ddlCountry.Items.Clear();
                ddlCountry.Items.Add("");
                foreach (var item in country) ddlCountry.Items.Add(item.FieldList.Fields[1].Value);

                btnDelete.Visible = false;
                RetrieveMembers();
                SetMemberDetails();
            }
            else
            {
                Response.Redirect("~/LoadFailure.aspx?RECID=" + _newUserRecordId + "&PAGE=BusinessUnits.aspx");
            }
        }

        protected void BtnNext_Click(object sender, ImageClickEventArgs e)
        {
            if (_newUser.FieldList.Fields[104].Value == "True")
            {
                Response.Redirect("~/FinancialDetails.aspx?RECID=" + _newUserRecordId);
                return;
            }
            Response.Redirect("~/PostalAddress.aspx?RECID=" + _newUserRecordId);
        }

        protected void BtnBack_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/BusinessAddress.aspx?RECID=" + _newUserRecordId);
        }

        private void RetrieveMembers()
        {
            _businessUnits = new List<CherwellBusinessObject>();
            _businessUnits = Details.GetListCherwellBusinessObjects("Customer Business Unit", "Parent ID", _newUserRecordId, "Record");
        }

        private void SetMemberDetails() 
        {
            if (lstUnits.Items.Count > 0) lstUnits.Items.Clear();

            foreach (var item in _businessUnits) lstUnits.Items.Add(item.FieldList.Fields[8].Value);

        }

        protected void BtnAction_Click(object sender, EventArgs e)
        {
            if (!CheckField()) return;
            if (!Global.ConfirmLogin()) Response.Redirect("~/LoadFailure.aspx?RECID=" + _newUserRecordId + "&PAGE=" + HttpContext.Current.Request.ApplicationPath);
            RetrieveMembers();
            var root = Server.MapPath("~");
            var path = Path.Combine(root, "XMLFiles\\BusinessUnit.xml");
            var xmlString = File.ReadAllText(path);
            var newBusinessUnit = CherwellBusinessObject.FromXmlString(xmlString);
            newBusinessUnit.FieldList.Fields[8].Value = txtName.Text;
            newBusinessUnit.FieldList.Fields[10].Value = txtStreetName.Text;
            newBusinessUnit.FieldList.Fields[11].Value = txtSuburb.Text;
            newBusinessUnit.FieldList.Fields[12].Value = txtBuildingNr.Text;
            newBusinessUnit.FieldList.Fields[13].Value = txtBuildingName.Text;
            newBusinessUnit.FieldList.Fields[14].Value = txtCity.Text;
            newBusinessUnit.FieldList.Fields[15].Value = ddlCountry.Text;
            newBusinessUnit.FieldList.Fields[16].Value = txtPostal.Text;
            newBusinessUnit.FieldList.Fields[17].Value = _newUserRecordId;
            if (btnAction.Text == "Add")
            {
                if (_businessUnits.Any(item => item.FieldList.Fields[8].Value == txtName.Text))
                {
                    Response.Write("<script LANGUAGE='JavaScript' >alert('You Cannot have multiple members with the same Name. Please review your input.')</script>");
                    return;
                }
                newBusinessUnit.FieldList.Fields[0].Value = Details.CreateCherwellBusinessObject("Customer Business Unit", newBusinessUnit);
                _businessUnits.Add(newBusinessUnit);
            }
            else
            {
                foreach (var item in _businessUnits)
                    if (lstUnits.SelectedItem.Text == item.FieldList.Fields[8].Value)
                        Details.UpdateDetails("Customer Business Unit", item.FieldList.Fields[0].Value, newBusinessUnit);
            }
            RetrieveMembers();
            SetMemberDetails();
            BtnClear_Click(null, null);
        }

        protected void LstMembers_SelectedIndexChanged(object sender, EventArgs e)
        {
            RetrieveMembers();
            btnAction.Text = "Update";
            btnDelete.Visible = true;
            foreach (var item in _businessUnits)
            {
                if (lstUnits.SelectedItem.Text != item.FieldList.Fields[8].Value) continue;
                txtName.Text = item.FieldList.Fields[8].Value;
                txtStreetName.Text = item.FieldList.Fields[10].Value;
                txtSuburb.Text = item.FieldList.Fields[11].Value;
                txtBuildingNr.Text = item.FieldList.Fields[12].Value;
                txtBuildingName.Text = item.FieldList.Fields[13].Value;
                txtCity.Text = item.FieldList.Fields[14].Value;
                ddlCountry.ClearSelection();
                if (!string.IsNullOrEmpty(item.FieldList.Fields[15].Value))
                {
                    ddlCountry.Items.FindByValue(item.FieldList.Fields[15].Value).Selected = true;
                }
                txtPostal.Text = item.FieldList.Fields[16].Value;
            }
        }

        protected void BtnClear_Click(object sender, EventArgs e)
        {
            lstUnits.ClearSelection();
            btnDelete.Visible = false;
            btnAction.Text = "Add";
            txtName.Text = "";
            txtStreetName.Text = "";
            txtSuburb.Text = "";
            txtBuildingNr.Text = "";
            txtBuildingName.Text = "";
            txtCity.Text = "";
            ddlCountry.ClearSelection();
            txtPostal.Text = "";
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            RetrieveMembers();
            foreach (var item in _businessUnits)
            {
                if (lstUnits == null || lstUnits.SelectedItem.Text != item.FieldList.Fields[8].Value) continue;
                item.FieldList.Fields[17].Value = "0";
                Details.UpdateDetails("Customer Business Unit", item.FieldList.Fields[0].Value, item);
                _businessUnits.Remove(item);
                break;
            }
            BtnClear_Click(null, null);
            RetrieveMembers();
            SetMemberDetails();
        }

        protected bool CheckField()
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('No Name has been Provided. Please add Name of the Business Unit')</script>");
                return false;
            }
            if (string.IsNullOrEmpty(txtStreetName.Text))
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('No Street Name has been Provided. Please provide Street name and number')</script>");
                return false;
            }
            if (string.IsNullOrEmpty(txtSuburb.Text))
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('No Suburb has been Provided. Please provide the suburb for the business unit')</script>");
                return false;
            }
            if (string.IsNullOrEmpty(txtCity.Text))
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('No Name has been Provided. Please add a Valid Phone number or CellPhone Number of the BusinessMember')</script>");
                return false;
            }
            if (string.IsNullOrEmpty(ddlCountry.Text))
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('No Country has been selected. Please select the country for the business Unit')</script>");
                return false;
            }
            if (!string.IsNullOrEmpty(txtPostal.Text)) return true;
            Response.Write("<script LANGUAGE='JavaScript' >alert('No Postal Code has been Provided . Please provide a postal code for the Business unit')</script>");
            return false;
        }
    }
}