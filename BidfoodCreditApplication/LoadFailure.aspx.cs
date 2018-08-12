using System;
using System.Web.UI;


namespace BidfoodCreditApplication
{
    public partial class LoadFailure : Page
    {
        private string _newUserRecordId;
        private string _page;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Global.Cherwelllogout();
            }
           
        }

        protected void btnRetry_Click(object sender, EventArgs e)
        {

            _newUserRecordId = Request.QueryString["RECID"];
            _page = Request.QueryString["PAGE"];
            Global.ConfirmLogin();
            if (string.IsNullOrEmpty(_newUserRecordId))
            {
                Response.Redirect("~/");
            }

            Response.Redirect("~/" + _page +"?RECID=" + _newUserRecordId);
        }
    }
}