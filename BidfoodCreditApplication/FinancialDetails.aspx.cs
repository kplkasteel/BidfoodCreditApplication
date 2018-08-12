using BidfoodCreditApplication.Helpers;
using BidfoodCreditApplication.Models;
using System;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace BidfoodCreditApplication
{
    public partial class FinancialDetails : Page
    {
        private CherwellBusinessObject _newUser;
        private string _newUserRecordId;

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.Now);
            Response.Cache.SetNoServerCaching();
            Response.Cache.SetNoStore();

            _newUserRecordId = base.Request.QueryString["RECID"];

            Page.EnableViewState = true;
            if (Global.ConfirmLogin())
            {
                _newUser = new CherwellBusinessObject();

                if (string.IsNullOrEmpty(_newUserRecordId)) Response.Redirect(Global.Redirect);

                _newUser = Details.GetDetails("Customer - External", _newUserRecordId);
                if (base.IsPostBack) return;

                if (_newUser.FieldList.Fields[122].Value == "True") Response.Redirect("~/ApplicationCompleted.aspx?RECID=" + _newUserRecordId);
                var year = DateTime.Today.Year;
                ddlYear?.Items.Clear();
                for (var i = year; i >=1900; i--) ddlYear?.Items.Add(i.ToString());
                if (ddlYear != null) ddlYear.Items.FindByValue("2000").Selected = true;
                GetCustomerdetails();
            }
            else Response.Redirect("~/LoadFailure.aspx?RECID=" + _newUserRecordId + "&PAGE=FinancialDetails.aspx");

        }
        protected void BtnNext_Click(object sender, ImageClickEventArgs e)
        {
            if (!checkValues()) return;
            if (!Global.ConfirmLogin()) Response.Redirect("~/LoadFailure.aspx?RECID=" + _newUserRecordId + "&PAGE=" + HttpContext.Current.Request.ApplicationPath);
            SetCustomerDetails();
            Details.UpdateDetails("Customer - External", _newUserRecordId, _newUser);
            if (_newUser.FieldList.Fields[104].Value == "True")
            {
                Response.Redirect("~/TradeReference.aspx?RECID=" + _newUserRecordId);
            }
            Response.Redirect("~/BusinessPartners.aspx?RECID=" + _newUserRecordId);
        }

        protected void BtnBack_Click(object sender, ImageClickEventArgs e)
        {
            if (!checkValues()) return;
            if (!Global.ConfirmLogin()) Response.Redirect("~/LoadFailure.aspx?RECID=" + _newUserRecordId + "&PAGE=" + HttpContext.Current.Request.ApplicationPath);
            SetCustomerDetails();
            Details.UpdateDetails("Customer - External", _newUserRecordId, _newUser);
            if (_newUser.FieldList.Fields[104].Value == "True")
            {
                Response.Redirect("~/BusinessAddress.aspx.aspx?RECID=" + _newUserRecordId);
                
            }
            Response.Redirect("~/PostalAddress.aspx?RECID=" + _newUserRecordId);
        }

        private void GetCustomerdetails()
        {
            txtAuditors.Text = _newUser.FieldList.Fields[91].Value;
            if (!string.IsNullOrEmpty(_newUser.FieldList.Fields[92].Value))
            {
                ddlYear.ClearSelection();
                if (!string.IsNullOrEmpty(_newUser.FieldList.Fields[92].Value) && _newUser.FieldList.Fields[92].Value != "--Ye")
                {
                    ddlYear.Items.FindByValue(_newUser.FieldList.Fields[92].Value).Selected = true;
                }
            }
            txtPersonAccounts.Text = _newUser.FieldList.Fields[97].Value;
            txtPersonOrdering.Text = _newUser.FieldList.Fields[98].Value;
            txtAccountsTel.Text = _newUser.FieldList.Fields[113].Value;
            txtAcountsEmail.Text = _newUser.FieldList.Fields[114].Value;
            txtOrderingTel.Text = _newUser.FieldList.Fields[115].Value;
            txtOrderingEmail.Text = _newUser.FieldList.Fields[116].Value;
        }

        private void SetCustomerDetails()
        {
            _newUser.FieldList.Fields[91].Value = txtAuditors.Text;
            if (ddlYear.Text != "--Ye")
            {
                _newUser.FieldList.Fields[92].Value = ddlYear.Text;
            }
            _newUser.FieldList.Fields[97].Value = txtPersonAccounts.Text;
            _newUser.FieldList.Fields[98].Value = txtPersonOrdering.Text;
            _newUser.FieldList.Fields[113].Value = txtAccountsTel.Text;
            _newUser.FieldList.Fields[114].Value = txtAcountsEmail.Text;
            _newUser.FieldList.Fields[115].Value = txtOrderingTel.Text;
            _newUser.FieldList.Fields[116].Value = txtOrderingEmail.Text;
        }
    

        private bool checkValues()
        {
            if (!Isphonenumber(txtAccountsTel.Text) || !Isphonenumber(txtOrderingTel.Text))
            {
                Response.Write(
                    "<script LANGUAGE='JavaScript' >alert('Phone numbers can only contain numbers. Please adjust accordingly')</script>");
                return false;
            }

            return true;
        }

        private static bool Isphonenumber(string str)
        {
            return str.All(c => c >= '0' && c <= '9');
        }
    }
}