using System;
using System.Web.UI;
using BidfoodCreditApplication.Helpers;
using BidfoodCreditApplication.Models;
using System.Linq;
using System.Web;

namespace BidfoodCreditApplication
{
    public partial class BusinessDetails : Page
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

                var test = _newUser.ToXmlString();

                if (IsPostBack) return;

                if (_newUser.FieldList.Fields[122].Value == "True")
                    Response.Redirect("~/ApplicationCompleted.aspx?RECID=" + _newUserRecordId);

                var natureOfBusiness =
                    Details.GetListCherwellBusinessObjects("Nature of Business", "Status", "Active", "Record");
                ddlNatureOfBusiness.Items.Clear();
                ddlNatureOfBusiness.Items.Add("");

                foreach (var item in natureOfBusiness) ddlNatureOfBusiness.Items.Add(item.FieldList.Fields[8].Value);

                GetCustomerDetails();
                ChkPremisesLeased_CheckedChanged(null, null);

                if (_newUser.FieldList.Fields[117].Value != "False") return;
                lblRegNumber.Text = "SA ID Number";
                txtReg1.Width = 100;
                txtReg2.Visible = false;
                txtReg2.Text = string.Empty;
                txtReg3.Visible = false;
                txtReg3.Text = string.Empty;
                lblslash1.Visible = false;
                lblslash2.Visible = false;
            }
            else
            {
                Response.Redirect("~/LoadFailure.aspx?RECID=" + _newUserRecordId + "&PAGE=BusinessDetails.aspx");
            }
        }

        protected void BtnNext_Click(object sender, ImageClickEventArgs e)
        {
            if (!Global.ConfirmLogin()) Response.Redirect("~/LoadFailure.aspx?RECID=" + _newUserRecordId + "&PAGE=" + HttpContext.Current.Request.ApplicationPath);
            if (!CheckDetails(_newUser)) return;
            SetCustomerDetails();
            Details.UpdateDetails("Customer - External", _newUserRecordId, _newUser);
            Response.Redirect("~/BusinessAddress.aspx?RECID=" + _newUserRecordId);
        }

        protected void BtnBack_Click(object sender, ImageClickEventArgs e)
        {
            if (!Global.ConfirmLogin()) Response.Redirect("~/LoadFailure.aspx?RECID=" + _newUserRecordId + "&PAGE=" + HttpContext.Current.Request.ApplicationPath);
            if (!CheckDetails(_newUser)) return;
            SetCustomerDetails();
            Details.UpdateDetails("Customer - External", _newUserRecordId, _newUser);
            Response.Redirect("~/ContactDetails.aspx?RECID=" + _newUserRecordId);
        }

        protected void ChkPremisesLeased_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPremisesLeased.Checked)
            {
                txtLandlordDetails.Visible = true;
                lblLandlord.Visible = true;
                return;
            }
            txtLandlordDetails.Visible = false;
            lblLandlord.Visible = false;
        }

        protected void GetCustomerDetails()
        {
            txtReg1.Text = _newUser.FieldList.Fields[82].Value;
            txtReg2.Text = _newUser.FieldList.Fields[123].Value;
            txtReg3.Text = _newUser.FieldList.Fields[124].Value;
            txtvatNumber.Text = _newUser.FieldList.Fields[83].Value;
            txtTradingNames.Text = _newUser.FieldList.Fields[84].Value;
            if (!string.IsNullOrEmpty(_newUser.FieldList.Fields[86].Value))
            {
                ddlNatureOfBusiness.ClearSelection();
                ddlNatureOfBusiness.Items.FindByValue(_newUser.FieldList.Fields[86].Value).Selected = true;
            }
            chkOrderNumbers.Checked = Convert.ToBoolean(_newUser.FieldList.Fields[88].Value);
            if (!string.IsNullOrEmpty(_newUser.FieldList.Fields[89].Value))
                chkPremisesLeased.Checked = Convert.ToBoolean(_newUser.FieldList.Fields[89].Value);
            txtLandlordDetails.Text = _newUser.FieldList.Fields[90].Value;
            txtHoldingCompany.Text = _newUser.FieldList.Fields[87].Value;
        }

        protected void SetCustomerDetails()
        {
            if (bool.Parse(_newUser.FieldList.Fields[117].Value))
            {
                _newUser.FieldList.Fields[82].Value = txtReg1.Text;
                _newUser.FieldList.Fields[123].Value = txtReg2.Text;
                _newUser.FieldList.Fields[124].Value = txtReg3.Text;
                _newUser.FieldList.Fields[125].Value = string.Empty;
            }
            else
            {
                _newUser.FieldList.Fields[82].Value = string.Empty;
                _newUser.FieldList.Fields[123].Value = string.Empty;
                _newUser.FieldList.Fields[124].Value = string.Empty;
                _newUser.FieldList.Fields[125].Value = txtReg1.Text;
            }
           
            _newUser.FieldList.Fields[83].Value = txtvatNumber.Text;
            _newUser.FieldList.Fields[84].Value = txtTradingNames.Text;
            _newUser.FieldList.Fields[86].Value = ddlNatureOfBusiness.Text;
            _newUser.FieldList.Fields[88].Value = Convert.ToString(chkOrderNumbers.Checked);
            _newUser.FieldList.Fields[89].Value = Convert.ToString(chkPremisesLeased.Checked);
            _newUser.FieldList.Fields[90].Value = txtLandlordDetails.Text;
            _newUser.FieldList.Fields[87].Value = txtHoldingCompany.Text;
        }


        private bool CheckDetails(CherwellBusinessObject checkUser)
        {

                if (!Isnumber(txtReg1.Text) || !Isnumber(txtReg2.Text) || !Isnumber(txtReg3.Text))
                {
                    Response.Write(
                        "<script LANGUAGE='JavaScript' >alert('Your company registration number can only contain numbers. Please change your registration number accordingly.')</script>");
                    return false;
                }

                if (!Isnumber(txtvatNumber.Text))
                {
                    Response.Write(
                        "<script LANGUAGE='JavaScript' >alert('Your VAT can only contain numbers. Please Change your VAT Number accordingly.')</script>");
                    return false;
                }
            if (bool.Parse(_newUser.FieldList.Fields[117].Value))
            {
                var dnumber = txtReg1.Text;
                if (dnumber.Length > 4)
                {
                    Response.Write(
                        "<script LANGUAGE='JavaScript' >alert('Your company registration is to long. Please change your registration number accordingly.')</script>");
                    return false;
                }
                
            }
            if (bool.Parse(_newUser.FieldList.Fields[117].Value))
            {
                var dnumber = txtReg2.Text;
                if (dnumber.Length > 7)
                {
                    Response.Write(
                        "<script LANGUAGE='JavaScript' >alert('Your company registration is to long. Please change your registration number accordingly.')</script>");
                    return false;
                }

            }
            if (bool.Parse(_newUser.FieldList.Fields[117].Value ))
            {
                var dnumber = txtReg3.Text;
                if (dnumber.Length > 2)
                {
                    Response.Write(
                        "<script LANGUAGE='JavaScript' >alert('Your company registrationis to long. Please change your registration number accordingly.')</script>");
                    return false;
                }

            }




            if (!chkPremisesLeased.Checked || !string.IsNullOrEmpty(txtLandlordDetails.Text)) return true;
            Response.Write(
                "<script LANGUAGE='JavaScript' >alert('Please fill in your landlord details as this is mandatory when you are leasing the premises.')</script>");
            return false;
        }

        private bool Isnumber(string str)
        {
            return str.All(c => c >= '0' && c <= '9');
        }
    }
}