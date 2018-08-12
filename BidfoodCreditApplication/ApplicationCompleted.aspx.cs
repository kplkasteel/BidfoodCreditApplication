using System;
using System.Text;
using System.Web;
using System.Web.UI;
using BidfoodCreditApplication.Helpers;
using BidfoodCreditApplication.Models;

namespace BidfoodCreditApplication
{
    public partial class ApplicationCompleted : Page
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
                var stringBuilder = new StringBuilder();
                stringBuilder.Append("Dear " + _newUser.FieldList.Fields[9].Value + ",\n");
                stringBuilder.Append("\n");
                stringBuilder.Append(
                    "You have already completed the On-line Credit Application Form and as mentioned during the application. Once completed you cannot reuse the application URL.\n");
                stringBuilder.Append("\n");
                stringBuilder.Append(
                    "Please be so kind to await the outcome of your initial application. You should be notified with the result via phone or e-mail once this application has been completed.\n");
                stringBuilder.Append(
                    "Should you have any queries regarding the outstanding application please feel free to contact BidFood Pty Ltd via phone or e-mail.\n");
                stringBuilder.Append("\n");
                stringBuilder.Append("Thank you for your patience and understanding.\n\n");
                stringBuilder.Append("BidFood Pty Ltd.");
                txtSorryText.Text = stringBuilder.ToString();
            }
            else Response.Redirect("~/LoadFailure.aspx");
        }
    }

    
}