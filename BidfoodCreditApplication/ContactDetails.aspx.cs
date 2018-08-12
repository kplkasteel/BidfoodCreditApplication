using System;
using System.Linq;
using System.Web.UI;
using BidfoodCreditApplication.Helpers;
using BidfoodCreditApplication.Models;
using System.Web;

namespace BidfoodCreditApplication
{
    public partial class ContactDetails : Page
    {
        //Declaring private Variables
        private CherwellBusinessObject _newUser;

        private string _newUserRecordId;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.EnableViewState = true;
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.Now);
            Response.Cache.SetNoServerCaching();
            Response.Cache.SetNoStore();

            _newUserRecordId = Request.QueryString["RECID"]; //setting recordIf from URL
            if (Global.ConfirmLogin()) // Check for Cherwell Webservices connection
            {
                _newUser = new CherwellBusinessObject(); //New instance of Cherwell Object by Reference

                if (string.IsNullOrEmpty(_newUserRecordId))
                    Response.Redirect(Global.Redirect); // If recordId is empty then redirect to new Customer

                _newUser = Details.GetDetails("Customer - External", _newUserRecordId); // Getting current user details
                if (IsPostBack) return; // if ostback then do not reset user details
                if (_newUser.FieldList.Fields[122].Value == "True")
                    Response.Redirect("~/ApplicationCompleted.aspx?RECID=" + _newUserRecordId);

                var typeOfBusiness =
                    Details.GetListCherwellBusinessObjects("Type of Business", "Status", "Active", "Record");
                ddlTypeOfBusiness.Items.Clear(); // clear current list
                ddlTypeOfBusiness.Items.Add(""); // Add empty item

                foreach (var item in typeOfBusiness) //loop through list of type of business and add them to the list
                    ddlTypeOfBusiness.Items.Add(item.FieldList.Fields[8].Value);

                SetControlDetails(); // Call method
                chkLegalEntity_CheckedChanged(null, null); //Call method
            }
            else
            {
                Response.Redirect("~/LoadFailure.aspx?RECID=" + _newUserRecordId + "&PAGE=ContactDetails.aspx"); //If connection fails got fail page
            }
        }

        protected void BtnNext_Click(object sender, ImageClickEventArgs e)
        {
            if (!CheckFields()) return;
            if (!Global.ConfirmLogin()) Response.Redirect("~/LoadFailure.aspx?RECID=" + _newUserRecordId + "&PAGE=" + HttpContext.Current.Request.ApplicationPath);// check if field are populated
            GetControlDetails(); //set control data to _newUser object
            Details.UpdateDetails("Customer - External", _newUserRecordId, _newUser); // update cherwell object
            Response.Redirect("~/BusinessDetails.aspx?RECID=" + _newUserRecordId);
        }

        protected void SetControlDetails()
        {
            //Setting control Values
            txtPurchasersname.Text = _newUser.FieldList.Fields[80].Value;
            ddlTypeOfBusiness.ClearSelection();
            ddlTypeOfBusiness.Items.FindByValue(_newUser.FieldList.Fields[81].Value).Selected = true;
            chkLegalEntity.Checked = Convert.ToBoolean(_newUser.FieldList.Fields[117].Value);
            txtFirstName.Text = _newUser.FieldList.Fields[9].Value;
            txtLastName.Text = _newUser.FieldList.Fields[11].Value;
            txtFullName.Text = _newUser.FieldList.Fields[7].Value;
            txtEmail.Text = _newUser.FieldList.Fields[15].Value;
            txtPhone.Text = _newUser.FieldList.Fields[14].Value;
            txtCellPhone.Text = _newUser.FieldList.Fields[28].Value;
            txtfax.Text = _newUser.FieldList.Fields[27].Value;
        }

        protected void GetControlDetails()
        {
            //Setting _newUser
            _newUser.FieldList.Fields[80].Value = txtPurchasersname.Text;
            _newUser.FieldList.Fields[81].Value = ddlTypeOfBusiness.Text;
            _newUser.FieldList.Fields[117].Value = Convert.ToString(chkLegalEntity.Checked);
            _newUser.FieldList.Fields[9].Value = txtFirstName.Text;
            _newUser.FieldList.Fields[11].Value = txtLastName.Text;
            _newUser.FieldList.Fields[7].Value = txtFullName.Text;
            _newUser.FieldList.Fields[15].Value = txtEmail.Text;
            _newUser.FieldList.Fields[14].Value = txtPhone.Text;
            _newUser.FieldList.Fields[28].Value = txtCellPhone.Text;
            _newUser.FieldList.Fields[27].Value = txtfax.Text;
        }

        protected bool CheckFields()
        {
            foreach (var item in txtPurchasersname.Text)
            {
                if (!char.IsLetterOrDigit(item) && !char.IsWhiteSpace(item))
                {
                    Response.Write(
                    "<script LANGUAGE='JavaScript' >alert('No special Characters are allowed.')</script>");
                    return false;
                }
            }
            //Checking of fields are populated

            if (ddlTypeOfBusiness.Text == "Sole Ownership" && chkLegalEntity.Checked)
            {
                Response.Write(
                    "<script LANGUAGE='JavaScript' >alert('You cannot select Sole Ownership and select that the application is for a legal Entity.')</script>");
                return false;
            }
            if (string.IsNullOrEmpty(txtPurchasersname.Text))
            {
                Response.Write(
                    "<script LANGUAGE='JavaScript' >alert('Purchasers or Legal name has not been Provided.')</script>");
                return false;
            }
            if (string.IsNullOrEmpty(txtFirstName.Text))
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('First Name has not been provided.')</script>");
                return false;
            }
            if (string.IsNullOrEmpty(txtLastName.Text))
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('Last name has not been provided.')</script>");
                return false;
            }
            if (string.IsNullOrEmpty(txtFullName.Text))
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('Full Name has not been provided.')</script>");
                return false;
            }
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('E-mail Address has not been provided')</script>");
                return false;
            }

            if (string.IsNullOrEmpty(txtPhone.Text) && string.IsNullOrEmpty(txtCellPhone.Text))
            {
                Response.Write(
                    "<script LANGUAGE='JavaScript' >alert('No Phone Number has been provided. Please provide at least 1 phone number to continue the application')</script>");
                return false;
            }

            if (!Isphonenumber(txtCellPhone.Text))
            {
                Response.Write(
                    "<script LANGUAGE='JavaScript' >alert('Please only use numbers in your cellphone number.')</script>");
                return false;
            }
            if (!Isphonenumber(txtPhone.Text))
            {
                Response.Write(
                    "<script LANGUAGE='JavaScript' >alert('Please only use numbers in your fixed landline number.')</script>");
                return false;
            }
            if (!Isphonenumber(txtfax.Text))
            {
                Response.Write(
                    "<script LANGUAGE='JavaScript' >alert('Please only use numbers in your fax number.')</script>");
                return false;
            }


            if (txtPurchasersname.Text.Length > 15)
            {
                Response.Write(
                    "<script LANGUAGE='JavaScript' >alert('Purchasers name should not be more than 15 Characters')</script>");
                return false;
            }
            return true;

        }

        protected void chkLegalEntity_CheckedChanged(object sender, EventArgs e)
        {
            // checking and setting tickebox and fields
            if (chkLegalEntity.Checked)
            {
                ddlTypeOfBusiness.ClearSelection();
                ddlTypeOfBusiness.Items.FindByValue("Sole Proprietor / Other").Enabled = false;
                ddlTypeOfBusiness.Enabled = true;
                ddlTypeOfBusiness.Visible = true;
                lblTypeOfBusiness.Visible = true;
                ddlTypeOfBusiness.Items.FindByValue(_newUser.FieldList.Fields[81].Value).Selected = true;
                return;
            }
            ddlTypeOfBusiness.ClearSelection();
            ddlTypeOfBusiness.Items.FindByValue("Sole Proprietor / Other").Enabled = true;
            ddlTypeOfBusiness.Items.FindByValue("Sole Proprietor / Other").Selected = true;
            ddlTypeOfBusiness.Enabled = false;
            ddlTypeOfBusiness.Visible = false;
            lblTypeOfBusiness.Visible = false;
        }
        private static bool Isphonenumber(string str)
        {
            return str.All(c => c >= '0' && c <= '9');
        }
    }
    
}