using System;
using System.IO;
using System.Web;
using System.Web.UI;
using BidfoodCreditApplication.Helpers;
using BidfoodCreditApplication.Models;
using System.Linq;

namespace BidfoodCreditApplication
{
    public partial class ConfirmationAndSubmit : Page
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

                if (_newUser.FieldList.Fields[122].Value == "True") Response.Redirect("/BidfoodCreditApplication/ApplicationCompleted.aspx?RECID=" + _newUserRecordId);

                chkCorrectAndAccurate.Visible = true;
                chkCorrectAndAccurate.Checked = false;
                chkTermsandConditions.Visible = false;
                chkTermsandConditions.Checked = false;
                chkAuthorisation.Visible = false;
                chkAuthorisation.Checked = false;
                chkGaurantee.Visible = false;
                chkGaurantee.Checked = false;
                btnSubmit.Visible = false;
                chkCorrectAndAccurate.Text = string.Concat("I ", _newUser.FieldList.Fields[9].Value , " ",
                    _newUser.FieldList.Fields[11].Value,
                    " confirm that all information provided is correct and accurate.");
                chkTermsandConditions.Text = string.Concat("I ", _newUser.FieldList.Fields[9].Value, " ",
                    _newUser.FieldList.Fields[11].Value,
                    " confirm that I have read, understood and agree with the standard terms and Conditions.");
                chkGaurantee.Text = string.Concat("I ", _newUser.FieldList.Fields[9].Value, " ",
                    _newUser.FieldList.Fields[11].Value,
                    " confirm that I have read, understood and agree with the Gaurantee.");
                chkAuthorisation.Text = string.Concat("I ", _newUser.FieldList.Fields[9].Value, " ",
                    _newUser.FieldList.Fields[11].Value,
                    " confirm that I am authorised to allow  Bidfood  to do such credit rating processes as deemed necessary to evaluate this application");
            }
            else Response.Redirect("~/LoadFailure.aspx?RECID=" + _newUserRecordId + "&PAGE=ConfirmationAndSubmit.aspx");
        }
    
        

        protected void BtnBack_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Guarantee.aspx?RECID=" + _newUserRecordId);
        }

        protected bool CheckField()
        {
            _newUserRecordId = Request.QueryString["RECID"];
            _newUser = Details.GetDetails("Customer - External", _newUserRecordId);

            if (int.Parse(txtCreditLimit.Text) <= 0 || IsNumber(txtCreditLimit.Text))
                Response.Write(
                    "<script LANGUAGE='JavaScript' >alert('You have not set the amount of credit limit you are applying for. Please set a credit limit. Default is R20000')</script>");
            if (string.IsNullOrEmpty(txtCreditLimit.Text))
            { 
                Response.Write(
                    "<script LANGUAGE='JavaScript' >alert('You have not set the amount of credit limit you are applying for. Please set a credit limit. Default is R20000')</script>");
                txtCreditLimit.Text = "20000";
                return false;
            }
            if (string.IsNullOrEmpty(ddlTerms.Text))
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('Please select the repayment terms')</script>");
                return false;
            }
            if (string.IsNullOrEmpty(_newUser.FieldList.Fields[45].Value))
            {
                Response.Write(
                    "<script LANGUAGE='JavaScript' >alert('You have not selected a country in your business address. This way it will be impossible to determine who should evaluate your Application.')</script>");
                Response.Redirect("~/BusinessAddress.aspx?RECID=" + _newUserRecordId);
            }
            if (!string.IsNullOrEmpty(_newUser.FieldList.Fields[48].Value)) return true;
            Response.Write(
                "<script LANGUAGE='JavaScript' >alert('You have not selected a province in your business address. This way it will be impossible to determine who should evaluate your Application.')</script>");
            Response.Redirect("~/BusinessAddress.aspx?RECID=" + _newUserRecordId);
            return true;
        }

        protected void ChkCorrectAndAccurate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCorrectAndAccurate.Checked) chkTermsandConditions.Visible = true;
            if (chkCorrectAndAccurate.Checked) return;
            chkTermsandConditions.Visible = false;
            chkTermsandConditions.Checked = false;
            chkAuthorisation.Visible = false;
            chkAuthorisation.Checked = false;
            chkGaurantee.Visible = false;
            chkGaurantee.Checked = false;
            btnSubmit.Visible = false;
        }

        protected void ChkTermsandConditions_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTermsandConditions.Checked) chkGaurantee.Visible = true;
            if (chkTermsandConditions.Checked) return;
            chkGaurantee.Visible = false;
            chkGaurantee.Checked = false;
            chkAuthorisation.Visible = false;
            chkAuthorisation.Checked = false;
            btnSubmit.Visible = false;
        }

        protected void ChkGaurantee_CheckedChanged(object sender, EventArgs e)
        {
            if (chkGaurantee.Checked) chkAuthorisation.Visible = true;
            if (chkGaurantee.Checked) return;
            chkAuthorisation.Visible = false;
            chkAuthorisation.Checked = false;
            btnSubmit.Visible = false;
        }

        protected void chkAuthorisation_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAuthorisation.Checked) btnSubmit.Visible = true;
            if (chkAuthorisation.Checked) return;
            btnSubmit.Visible = false;
        }

        protected string CreateApplication()
        {
            if (!Global.ConfirmLogin()) Response.Redirect("~/LoadFailure.aspx?RECID=" + _newUserRecordId + "&PAGE=" + HttpContext.Current.Request.ApplicationPath);
            var root = Server.MapPath("~");
            var path = Path.Combine(root, "XMLFiles\\BidfoodCreditApplication.xml");
            var xmlString = File.ReadAllText(path);
            var newCreditApplication = CherwellBusinessObject.FromXmlString(xmlString);
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


            newCreditApplication.FieldList.Fields[0].Value = actualIncidentOwner.FieldList.Fields[14].Value;
            newCreditApplication.FieldList.Fields[1].Value = actualIncidentOwner.FieldList.Fields[15].Value;
            newCreditApplication.FieldList.Fields[2].Value = actualIncidentOwner.FieldList.Fields[16].Value;
            newCreditApplication.FieldList.Fields[3].Value = _newUser.FieldList.Fields[7].Value;
            newCreditApplication.FieldList.Fields[4].Value = _newUser.FieldList.Fields[0].Value;
            newCreditApplication.FieldList.Fields[5].Value = "Submitted";
            newCreditApplication.FieldList.Fields[6].Value = txtCreditLimit.Text;
            newCreditApplication.FieldList.Fields[7].Value = chkCorrectAndAccurate.Checked.ToString();
            newCreditApplication.FieldList.Fields[8].Value = chkTermsandConditions.Checked.ToString();
            newCreditApplication.FieldList.Fields[9].Value = chkGaurantee.Checked.ToString();
            newCreditApplication.FieldList.Fields[10].Value = chkAuthorisation.Checked.ToString();
            newCreditApplication.FieldList.Fields[11].Value = "True";
            newCreditApplication.FieldList.Fields[12].Value = ddlTerms.Text;
            return Details.CreateCherwellBusinessObject("Bidfood Credit Application", newCreditApplication);
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (!CheckField()) return;
            if (!Global.ConfirmLogin()) Response.Redirect("~/LoadFailure.aspx?RECID=" + _newUserRecordId + "&PAGE=" + HttpContext.Current.Request.ApplicationPath);
            var text = CreateApplication();
            if (!string.IsNullOrEmpty(text))
            {
                try
                {
                    _newUser.FieldList.Fields[122].Value = "True";
                    Details.UpdateDetails("Customer - External", _newUserRecordId, _newUser);
                }
                catch (Exception)
                {
                    Response.Write(
                        "<script LANGUAGE='JavaScript' >alert('Something went wrong with submitting your application. Please try again after you have checked all the fields. You can restart the apllication by using the link that was sent to you via mail.')</script>");
                }
                Response.Redirect("~/ApplicationTicketNumber.aspx?RECID=" + _newUserRecordId +
                                  "&REFID=" + text);
                return;
            }
            Response.Write(
                "<script LANGUAGE='JavaScript' >alert('Something went wrong with submitting your application. Please try again after you have checked all the fields. You can restart the apllication by using the link that was sent to you via mail.')</script>");
        }
        private static bool IsNumber(string str)
        {
            return str.All(c => c >= '0' && c <= '9');
        }
    }
}