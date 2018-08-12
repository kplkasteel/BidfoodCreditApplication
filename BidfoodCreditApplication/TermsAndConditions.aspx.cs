using System;
using System.IO;
using System.Web;
using System.Web.UI;
using BidfoodCreditApplication.Helpers;
using BidfoodCreditApplication.Models;

namespace BidfoodCreditApplication
{
    public partial class TermsAndConditions : Page
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

                if (string.IsNullOrEmpty(this._newUserRecordId)) Response.Redirect(Global.Redirect);
                _newUser = Details.GetDetails("Customer - External", _newUserRecordId);
                if (IsPostBack) return;

                if (_newUser.FieldList.Fields[122].Value == "True") Response.Redirect("~/ApplicationCompleted.aspx?RECID=" + _newUserRecordId);
                var root = Server.MapPath("~");
                var path = Path.Combine(root, "Resources\\TermsAndConditions.txt");
                var termsAllText = File.ReadAllText(path);
                txtTerms.Text = termsAllText;
            }
            else Response.Redirect("~/LoadFailure.aspx?RECID=" + _newUserRecordId + "&PAGE=TermsAndConditions.aspx");

        }

        protected void BtnNext_Click(object sender, ImageClickEventArgs e)
        {
            base.Response.Redirect("~/Guarantee.aspx?RECID=" + this._newUserRecordId);
        }

        protected void BtnBack_Click(object sender, ImageClickEventArgs e)
        {
            base.Response.Redirect("~/PurchaseLiquor.aspx?RECID=" + this._newUserRecordId);
        }
    }
}