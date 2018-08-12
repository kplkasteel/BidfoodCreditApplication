using System;
using System.Web;
using System.Web.UI;
using BidfoodCreditApplication.Helpers;
using BidfoodCreditApplication.Models;

namespace BidfoodCreditApplication
{
    public partial class PostalAddress : Page
    {
        private CherwellBusinessObject _newUser;
        private string _newUserRecordId;

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.Now);
            Response.Cache.SetNoServerCaching();
            Response.Cache.SetNoStore();
            _newUserRecordId = Request.QueryString["RECID"];

            Page.EnableViewState = true;
            if (Global.ConfirmLogin())
            {
                _newUser = new CherwellBusinessObject();
                

                if (string.IsNullOrEmpty(_newUserRecordId)) Response.Redirect(Global.Redirect);
                _newUser = Details.GetDetails("Customer - External", _newUserRecordId);
                if (IsPostBack) return;

                if (_newUser.FieldList.Fields[122].Value == "True") Response.Redirect("~/ApplicationCompleted.aspx?RECID=" + _newUserRecordId);

                GetCustomerDetails();
            }
            else Response.Redirect("~/LoadFailure.aspx?RECID=" + _newUserRecordId + "&PAGE=PostalAddress.aspx");
        }

        protected void BtnNext_Click(object sender, ImageClickEventArgs e)
        {
            if (!Global.ConfirmLogin()) Response.Redirect("~/LoadFailure.aspx?RECID=" + _newUserRecordId + "&PAGE=" + HttpContext.Current.Request.ApplicationPath);
            SetCustomerDetails();
            Details.UpdateDetails("Customer - External", _newUserRecordId, _newUser);
            Response.Redirect("~/FinancialDetails.aspx?RECID=" + _newUserRecordId);
        }

        protected void BtnBack_Click(object sender, ImageClickEventArgs e)
        {
            if (!Global.ConfirmLogin()) Response.Redirect("~/LoadFailure.aspx?RECID=" + _newUserRecordId + "&PAGE=" + HttpContext.Current.Request.ApplicationPath);
            SetCustomerDetails();
            Details.UpdateDetails("Customer - External", _newUserRecordId, _newUser);
            Response.Redirect("~/BusinessAddress.aspx?RECID=" + _newUserRecordId);
        }

        protected void GetCustomerDetails()
        {
            txtPostalAddress.Text = _newUser.FieldList.Fields[47].Value;
            txtStreetName.Text = _newUser.FieldList.Fields[109].Value;
            txtSuburb.Text = _newUser.FieldList.Fields[110].Value;
            txtCity.Text = _newUser.FieldList.Fields[111].Value;
            txtPostalCode.Text = _newUser.FieldList.Fields[26].Value;
        }

        protected void SetCustomerDetails()
        {
            _newUser.FieldList.Fields[47].Value = txtPostalAddress.Text;
            _newUser.FieldList.Fields[109].Value = txtStreetName.Text;
            _newUser.FieldList.Fields[110].Value = txtSuburb.Text;
            _newUser.FieldList.Fields[111].Value = txtCity.Text;
            _newUser.FieldList.Fields[26].Value = txtPostalCode.Text;
        }
    }
}