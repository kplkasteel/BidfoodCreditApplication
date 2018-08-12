using System;
using System.IO;
using System.Web;
using System.Web.UI;
using BidfoodCreditApplication.Helpers;
using BidfoodCreditApplication.Models;

namespace BidfoodCreditApplication
{
    public partial class NewCustomer : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.Now);
            Response.Cache.SetNoServerCaching();
            Response.Cache.SetNoStore();

            Page.EnableViewState = true;

            //Login to CherwellService
            if (Global.ConfirmLogin())
            {
                if (IsPostBack) return;
                // Gets the type of business from Cherwell and fills a dropdown list

                var typeOfBusiness =
                    Details.GetListCherwellBusinessObjects("Type of Business", "Status", "Active", "Record");
                ddlTypeOfBusiness.Items.Clear(); // clear current list
                ddlTypeOfBusiness.Items.Add(""); // Add empty item

                foreach (var item in typeOfBusiness) //loop through list of type of business and add them to the list
                    ddlTypeOfBusiness.Items.Add(item.FieldList.Fields[8].Value);

                //Sets initial Check to true on checkbox
                chkLegalEntity.Checked = true;
                ChkLegalEntity_CheckedChanged(null, null);
            }
            else
                //If login failed goto loadFailure page    
            {
                Response.Redirect("~/LoadFailure.aspx");
            }
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (!CheckFields()) return;
            if (!Global.ConfirmLogin()) Response.Write(
                    "<script LANGUAGE='JavaScript' >alert('Something must have gone wrong. Please reload the page and try again. If you keep getting this message please contact Bidfood Pty Ltd.')</script>");
            var root = Server.MapPath("~"); //setting root path of server
            var path = Path.Combine(root,
                "XMLFiles\\Customer - External - new.xml"); // setting path and file to newuser XML
            var newUser =
                CherwellBusinessObject.FromXmlString(File.ReadAllText(path)); //Creating empty instance of object
            //Populating all required field in object

            newUser.FieldList.Fields[19].Value = txtPurchasersname.Text;
            newUser.FieldList.Fields[20].Value = ddlTypeOfBusiness.Text;
            newUser.FieldList.Fields[51].Value = Convert.ToString(chkLegalEntity.Checked);
            newUser.FieldList.Fields[1].Value = txtFirstName.Text;
            newUser.FieldList.Fields[2].Value = txtLastName.Text;
            newUser.FieldList.Fields[0].Value = txtFullName.Text;
            newUser.FieldList.Fields[5].Value = txtEmail.Text;
            newUser.FieldList.Fields[4].Value = txtPhone.Text;
            newUser.FieldList.Fields[11].Value = txtCellPhone.Text;
            newUser.FieldList.Fields[10].Value = txtfax.Text;
            var newRecordId = Details.CreateCherwellBusinessObject("Customer - External", newUser); // Creating new Customer 

            Response.Redirect("~/BusinessDetails.aspx?RECID=" + newRecordId); // redirecting to next page
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

        protected void ChkLegalEntity_CheckedChanged(object sender, EventArgs e)
        {
            //Checks the tickebox of legal entity if true displays the type of business. If false defaults to Sole Ownership end siabled type of business
            if (chkLegalEntity.Checked)
            {
                ddlTypeOfBusiness.ClearSelection();
                ddlTypeOfBusiness.Visible = true;
                lblTypeOfBusiness.Visible = true;
                ddlTypeOfBusiness.Enabled = true;
                ddlTypeOfBusiness.Items.FindByValue("Sole Ownership").Enabled = false;
                return;
            }
            ddlTypeOfBusiness.ClearSelection();
            ddlTypeOfBusiness.Visible = false;
            lblTypeOfBusiness.Visible = false;
            ddlTypeOfBusiness.Items.FindByValue("Sole Ownership").Enabled = true;
            ddlTypeOfBusiness.Items.FindByValue("Sole Ownership").Selected = true;
            ddlTypeOfBusiness.Enabled = false;
        }

        private static bool Isphonenumber(string str)
        {
            foreach (var c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }
    }
}