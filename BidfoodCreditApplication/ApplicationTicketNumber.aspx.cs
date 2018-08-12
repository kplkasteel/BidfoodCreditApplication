using System;
using System.Text;
using System.Web;
using System.Web.UI;
using BidfoodCreditApplication.Helpers;
using BidfoodCreditApplication.Models;

namespace BidfoodCreditApplication
{
    public partial class ApplicationTicketNumber : Page
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
                
                var recId = Request.QueryString["REFID"];
                if (string.IsNullOrEmpty(_newUserRecordId)) Response.Redirect(Global.Redirect);
                _newUser = Details.GetDetails("Customer - External", _newUserRecordId);
                if (IsPostBack) return;

                var stringBuilder = new StringBuilder();
                var cherwellBusinessObject = Details.GetDetails("Bidfood Credit Application", recId);
                stringBuilder.Append("Dear " + _newUser.FieldList.Fields[9].Value + ",\n");
                stringBuilder.Append("\n");
                stringBuilder.Append(
                    "Thank you for completing the online registration form for Bidfood’s Credit Application.\n");
                stringBuilder.Append(
                    "By now you should have received an e-mail containing your reference number to the application.\n");
                stringBuilder.Append(cherwellBusinessObject.FieldList.Fields[45].Value + "\n\n");
                stringBuilder.Append(
                    "You can use this e-mail in the event you would like to add or disclose any other information that might be of value to the application.\n");
                stringBuilder.Append(
                    "When replying please make sure that you keep the reference number in the subject line so that it can be identified and added to the correct application.\n");
                stringBuilder.Append("\n");
                stringBuilder.Append("Thank you for your patience and understanding,\n");
                stringBuilder.Append("Bidfood Pty Ltd\n");
                txtcompleted.Text = stringBuilder.ToString();
            }
            else Response.Redirect("~/LoadFailure.aspx?RECID=" + _newUserRecordId + "&PAGE=ApplicationTicketNumber.aspx");
        }
    }
}