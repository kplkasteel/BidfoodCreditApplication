using System;
using System.Linq;
using System.Web.UI;
using BidfoodCreditApplication.Helpers;
using BidfoodCreditApplication.Models;
using System.Web;

namespace BidfoodCreditApplication
{
    public partial class AssetValueAndTurnover : Page
    {
        private string _newUserRecordId;
        private CherwellBusinessObject _newUser;

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

                SetControlDetails();
            }
            else Response.Redirect("~/LoadFailure.aspx?RECID=" + _newUserRecordId + "&PAGE=AssetValueAndTurnover.aspx");


        }

        protected void BtnNext_Click(object sender, ImageClickEventArgs e)
        {
            if (!Global.ConfirmLogin()) Response.Redirect("~/LoadFailure.aspx?RECID=" + _newUserRecordId + "&PAGE="+ HttpContext.Current.Request.ApplicationPath);

            if (!CheckField()) return;
            GetControlDetails();
            Details.UpdateDetails("Customer - External", _newUserRecordId, _newUser);
            Response.Redirect("~/PurchaseLiquor.aspx?RECID=" + _newUserRecordId);
        }

        protected void BtnBack_Click(object sender, ImageClickEventArgs e)
        {
            if (!Global.ConfirmLogin()) Response.Redirect("~/LoadFailure.aspx?RECID=" + _newUserRecordId + "&PAGE=" + HttpContext.Current.Request.ApplicationPath);
            GetControlDetails();
            Details.UpdateDetails("Customer - External", _newUserRecordId, _newUser);
            Response.Redirect("~/CreditAct.aspx?RECID=" + _newUserRecordId);
        }

        private void SetControlDetails()
        {
            txtAssetValue.Text = _newUser.FieldList.Fields[100].Value;
            txtTurnOver.Text = _newUser.FieldList.Fields[101].Value;
        }

        private void GetControlDetails()
        {
            _newUser.FieldList.Fields[100].Value = txtAssetValue.Text;
            _newUser.FieldList.Fields[101].Value = txtTurnOver.Text;
        }

        protected bool CheckField()
        {
            if (string.IsNullOrEmpty(txtAssetValue.Text) && string.IsNullOrEmpty(txtTurnOver.Text))
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('No Asset Value or Annual turnover provided. Please provide correct statements regarding your Asses Values and Annual Turnover.')</script>");
                return false;
            }
            if (Convert.ToBoolean(_newUser.FieldList.Fields[117].Value))
            {
                if ((!Isnumber(txtAssetValue.Text) || int.Parse(txtAssetValue.Text) <= 0) && (!Isnumber(txtTurnOver.Text) || int.Parse(txtTurnOver.Text) <= 0))
                {
                    Response.Write(
                        "<script LANGUAGE='JavaScript' >alert('AssetValue and turnover cannot be 0 and can only be numbers. Please provide correct statements regarding your Asses Values and Annual Turnover.')</script>");
                    return false;
                }
            }
           
            return true;

        }
        private static bool Isnumber(string str)
        {
            return str.All(c => c >= '0' && c <= '9');
        }
    }
}