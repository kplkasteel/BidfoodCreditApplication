using System;
using System.IO;
using System.Web;
using System.Web.UI;
using BidfoodCreditApplication.Helpers;
using BidfoodCreditApplication.Models;

namespace BidfoodCreditApplication
{
    public partial class PurchaseLiquor : Page
    {
        private CherwellBusinessObject _newUser;
        private string _newUserRecordId;
        private string _excistingLiqourLicense;

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

                var excistingLicense  = Details.GetListCherwellBusinessObjects("Liquor License", "Customer ID", _newUserRecordId, "Record");
                if (excistingLicense != null && excistingLicense.Count > 0)
                {
                    foreach (var item in excistingLicense)
                    {
                        _excistingLiqourLicense = item.FieldList.Fields[0].Value;
                        break;
                    }
                }
                if (IsPostBack) return;
                if (_newUser.FieldList.Fields[122].Value == "True") Response.Redirect("~/ApplicationCompleted.aspx?RECID=" + _newUserRecordId);

                chkPurchaseYes.Checked = !string.IsNullOrEmpty(_excistingLiqourLicense);
                chkPurchaseYes_CheckedChanged(null, null);
            }
            else Response.Redirect("~/LoadFailure.aspx?RECID=" + _newUserRecordId + "&PAGE=PurchaseLiquor.aspx");
        }

        protected void BtnNext_Click(object sender, ImageClickEventArgs e)
        {
            if (chkPurchaseYes.Checked && string.IsNullOrEmpty(_excistingLiqourLicense))
            {
                CreateLiquorLicense();
            }
            Response.Redirect("~/TermsAndConditions.aspx?RECID=" + _newUserRecordId);
        }

        protected void BtnBack_Click(object sender, ImageClickEventArgs e)
        {
            if (chkPurchaseYes.Checked && string.IsNullOrEmpty(_excistingLiqourLicense))
            {
                CreateLiquorLicense();
            }
            if (_newUser.FieldList.Fields[117].Value == "False")
            {
                Response.Redirect("~/TradeReference.aspx?RECID=" + _newUserRecordId);
            }
            else
            {
                Response.Redirect("~/AssetValueAndTurnover.aspx?RECID=" + _newUserRecordId);
            }
        }

        protected void chkPurchaseYes_CheckedChanged(object sender, EventArgs e)
        {
            lblUploadtext.Visible = chkPurchaseYes.Checked;
            fileUploadSelector.Visible = chkPurchaseYes.Checked;
            btnUpload.Visible = chkPurchaseYes.Checked;
            lblUploadCompleted.Visible = chkPurchaseYes.Checked;
        }

        protected void CreateLiquorLicense()
        {
            if (!Global.ConfirmLogin()) Response.Redirect("~/LoadFailure.aspx?RECID=" + _newUserRecordId + "&PAGE=" + HttpContext.Current.Request.ApplicationPath);
            var root = Server.MapPath("~");
            var path = Path.Combine(root, "XMLFiles\\LiquorLicense.xml");
            var xmlString = File.ReadAllText(path);
            var newLiqourLicense = CherwellBusinessObject.FromXmlString(xmlString);
            var incidentOwners = Details.GetListCherwellBusinessObjects("BFS_CreditApp_Branches", "Region", _newUser.FieldList.Fields[45].Value == "South Africa" ? _newUser.FieldList.Fields[48].Value : _newUser.FieldList.Fields[45].Value, "Record");
            var actualIncidentOwner = new CherwellBusinessObject();
            foreach (var item in incidentOwners)
            {
                if (item.FieldList.Fields[13].Value == "Default Financial Manager")
                {
                    actualIncidentOwner = item;

                }
            }
            if (string.IsNullOrEmpty(actualIncidentOwner.Name))
            {
                incidentOwners = Details.GetListCherwellBusinessObjects("BFS_CreditApp_Branches", "Branch", "Head Office", "Record");
                foreach (var item in incidentOwners)
                {
                    if (item.FieldList.Fields[9].Value == "Head Office")
                    {
                        actualIncidentOwner = item;
                    }
                }
            }

            newLiqourLicense.FieldList.Fields[4].Value = "Submitted";
            newLiqourLicense.FieldList.Fields[0].Value = actualIncidentOwner.FieldList.Fields[14].Value;
            newLiqourLicense.FieldList.Fields[1].Value = actualIncidentOwner.FieldList.Fields[16].Value;
            newLiqourLicense.FieldList.Fields[2].Value = _newUser.FieldList.Fields[7].Value;
            newLiqourLicense.FieldList.Fields[3].Value = _newUser.FieldList.Fields[0].Value;
            newLiqourLicense.FieldList.Fields[5].Value = "False";
            _excistingLiqourLicense = Details.CreateCherwellBusinessObject("Liquor License", newLiqourLicense);

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            lblUploadCompleted.Text = string.Empty;
            if (string.IsNullOrEmpty(_excistingLiqourLicense))
            {
                CreateLiquorLicense();
            }
            if (fileUploadSelector.HasFile)
            {
                var attachementData = Convert.ToBase64String(fileUploadSelector.FileBytes);
                var flag = Global.CherwellConnection.AttachFile("Liquor License", _excistingLiqourLicense, fileUploadSelector.FileName, attachementData);
                if (flag)
                {
                    lblUploadCompleted.Text = "Succesfully uploaded Document " + fileUploadSelector.FileName + ".";
                    return;
                }
                lblUploadCompleted.Text = "Something went wrong while uploading you document. Please try again or reply to the Liquor license e-mail";
            }
            lblUploadCompleted.Text = "No Files Selected to Upload.... Select a file first then press upload documents";


        }
    }
}