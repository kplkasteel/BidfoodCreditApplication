using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using BidfoodCreditApplication.Helpers;
using BidfoodCreditApplication.Models;

namespace BidfoodCreditApplication
{
    public partial class CreditAct : Page
    {
        private CherwellBusinessObject _newUser;
        private string _newUserRecordId;
        private List<CherwellBusinessObject> _shareHolders;

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.Now);
            Response.Cache.SetNoServerCaching();
            Response.Cache.SetNoStore();
            _newUserRecordId = Request.QueryString["RECID"];
            Page.EnableViewState = true;
            if (!Global.ConfirmLogin())
            {
                Response.Redirect("~/LoadFailure.aspx?RECID=" + _newUserRecordId + "&PAGE=CreditAct.aspx");
                return;
            }
            _newUser = new CherwellBusinessObject();

            if (string.IsNullOrEmpty(_newUserRecordId))
            {
                Response.Redirect(Global.Redirect);
            }
            _newUser = Details.GetDetails("Customer - External", _newUserRecordId);
            if (IsPostBack)
            {
                return;
            }
            if (_newUser.FieldList.Fields[122].Value == "True")
            {
                Response.Redirect("~/ApplicationCompleted.aspx?RECID=" + _newUserRecordId);
            }
            btnDelete.Visible = false;
            GetCustomerdetails();
            DdlCreditAct_SelectedIndexChanged(null, null);
            RetrieveMembers();
            SetMemberDetails();
        }

        protected void BtnNext_Click(object sender, ImageClickEventArgs e)
        {
            if (string.IsNullOrEmpty(ddlCreditAct.Text))
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('Credit Act not set to YES or No. Please set the appropriate value.')</script>");
                return;
            }
            RetrieveMembers();
            if (_shareHolders.Count <= 0 && ddlCreditAct.Text == "Yes")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('You Cannot select that you fall under the Credit act and have no Directors/Shareholders Submitted.')</script>");
                return;
            }
            if (_shareHolders.Count > 0 && ddlCreditAct.Text == "No")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('If the Credit act does not apply there is no reason for any Director or ShareHolders to be listed. Please remove the director Shareholders.')</script>");
                return;
            }
            if (!Global.ConfirmLogin()) Response.Redirect("~/LoadFailure.aspx?RECID=" + _newUserRecordId + "&PAGE=" + HttpContext.Current.Request.ApplicationPath);
            SetCustomerdetails();
            Details.UpdateDetails("Customer - External", _newUserRecordId, _newUser);
            Response.Redirect("~/AssetValueAndTurnover.aspx?RECID=" + _newUserRecordId);
        }

        protected void BtnBack_Click(object sender, ImageClickEventArgs e)
        {
            if (string.IsNullOrEmpty(ddlCreditAct.Text))
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('Credit Act not set to YES or No. Please set the appropriate value.')</script>");
                return;
            }
            RetrieveMembers();
            if (_shareHolders.Count == 0 && ddlCreditAct.Text == "Yes")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('You Cannot select that you fall under the Credit act and have no Directors/Shareholders Submitted.')</script>");
                return;
            }
            if (_shareHolders.Count > 0 && ddlCreditAct.Text == "No")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('If the Credit act does not apply there is no reason for any Director or ShareHolders to be listed. Please remove the director Shareholders.')</script>");
                return;
            }
            if (!Global.ConfirmLogin()) Response.Redirect("~/LoadFailure.aspx?RECID=" + _newUserRecordId + "&PAGE=" + HttpContext.Current.Request.ApplicationPath);
            SetCustomerdetails();
            Details.UpdateDetails("Customer - External", _newUserRecordId, _newUser);
            Response.Redirect("~/TradeReference.aspx?RECID=" + _newUserRecordId);
        }

        private void RetrieveMembers()
        {
            _shareHolders = new List<CherwellBusinessObject>();
            _shareHolders = Details.GetListCherwellBusinessObjects("Director_Shareholder", "Parent ID", _newUserRecordId, "Record");
        }

        private void SetMemberDetails()
        {
            if (lstMembers.Items.Count > 0) lstMembers.Items.Clear();
            foreach (var item in _shareHolders) lstMembers.Items.Add(item.FieldList.Fields[8].Value);

        }

        protected void BtnAction_Click(object sender, EventArgs e)
        {
            if (!CheckField()) return;
            if (!Global.ConfirmLogin()) Response.Redirect("~/LoadFailure.aspx?RECID=" + _newUserRecordId + "&PAGE=" + HttpContext.Current.Request.ApplicationPath);
            var root = Server.MapPath("~");
            var path = Path.Combine(root, "XMLFiles\\ShareHolders.xml");
            var xmlString = File.ReadAllText(path);
            RetrieveMembers();
            var newDirectorShareholder = CherwellBusinessObject.FromXmlString(xmlString);
            newDirectorShareholder.FieldList.Fields[8].Value = txtName.Text;
            newDirectorShareholder.FieldList.Fields[9].Value = txtCompany.Text;
            newDirectorShareholder.FieldList.Fields[10].Value = txtRegNo.Text;
            newDirectorShareholder.FieldList.Fields[11].Value = _newUserRecordId;
            if (btnAction.Text == "Add")
            {
                RetrieveMembers();
                if (_shareHolders.Any(item => txtName.Text == item.FieldList.Fields[8].Value))
                {
                    Response.Write("<script LANGUAGE='JavaScript' >alert('You Cannot have multiple Director/Shareholders with the same Name. Please review your input.')</script>");
                    return;
                }
                newDirectorShareholder.FieldList.Fields[0].Value = Details.CreateCherwellBusinessObject("Director_Shareholder", newDirectorShareholder);
                _shareHolders.Add(newDirectorShareholder);
            }
            else foreach (var item in _shareHolders) if (lstMembers.SelectedItem.Text == item.FieldList.Fields[8].Value) Details.UpdateDetails("Director_Shareholder", item.FieldList.Fields[0].Value, newDirectorShareholder);
                    
                
            
            BtnClear_Click(null, null);
            RetrieveMembers();
            SetMemberDetails();
        }

        protected void LstMembers_SelectedIndexChanged(object sender, EventArgs e)
        {
            RetrieveMembers();
            btnDelete.Visible = true;
            btnAction.Text = "Update";
            foreach (var item in _shareHolders)
            {
                if (lstMembers.SelectedItem.Text != item.FieldList.Fields[8].Value) continue;
                txtName.Text = item.FieldList.Fields[8].Value;
                txtRegNo.Text = item.FieldList.Fields[10].Value;
                txtCompany.Text = item.FieldList.Fields[9].Value;
                btnAction.Visible = true;
            }
        }

        protected void BtnClear_Click(object sender, EventArgs e)
        {
            lstMembers.ClearSelection();
            btnDelete.Visible = false;
            btnAction.Text = "Add";
            txtName.Text = "";
            txtRegNo.Text = "";
            txtCompany.Text = "";
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            RetrieveMembers();
            foreach (var item in _shareHolders)
            {
                if (lstMembers.SelectedItem.Text != item.FieldList.Fields[8].Value) continue;
                item.FieldList.Fields[11].Value = "0";
                Details.UpdateDetails("Director_Shareholder", item.FieldList.Fields[0].Value, item);
                _shareHolders.Remove(item);
                break;
            }
            RetrieveMembers();
            SetMemberDetails();
            btnDelete.Visible = false;
            BtnClear_Click(null, null);
        }

        protected bool CheckField()
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('No Name has been Provided. Please add Name of the Director/Shareholder')</script>");
                return false;
            }
            if (string.IsNullOrEmpty(txtCompany.Text))
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('No Company Name has been Provided. Please add a valid Company/CC Name')</script>");
                return false;
            }
            if (string.IsNullOrEmpty(txtRegNo.Text))
            {
                Response.Write(
                    "<script LANGUAGE='JavaScript' >alert('No Company/CC Reg name has been Provided. Please add a valid Company/CC Reg No')</script>");
                return false;
            }
            if (!IsNumber(txtRegNo.Text))
            {
                Response.Write(
                    "<script LANGUAGE='JavaScript' >alert('The registration number can only contain numbers. Please change your registration number accordingly.')</script>");
                return false;
            }
            return true;
        }

        protected void DdlCreditAct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCreditAct.Text == "Yes")
            {
                txtCompany.Enabled = true;
                txtName.Enabled = true;
                txtRegNo.Enabled = true;
                btnAction.Enabled = true;
                btnClear.Enabled = true;
                btnDelete.Enabled = true;
                lstMembers.Enabled = true;
                lstMembers.Visible = true;
                return;
            }
            txtCompany.Enabled = false;
            txtName.Enabled = false;
            txtRegNo.Enabled = false;
            btnAction.Enabled = false;
            btnClear.Enabled = false;
            btnDelete.Enabled = false;
            lstMembers.Enabled = false;
            lstMembers.Visible = false;
        }

        private void GetCustomerdetails()
        {
            ddlCreditAct.ClearSelection();
            if (string.IsNullOrEmpty(_newUser.FieldList.Fields[99].Value)) return;

            if (_newUser.FieldList.Fields[99].Value == "True")
            {
                ddlCreditAct.Items.FindByValue("Yes").Selected = true;
                return;
            }
            ddlCreditAct.Items.FindByValue("No").Selected = true;
        }
        private void SetCustomerdetails()
        {
            _newUser.FieldList.Fields[99].Value = ((ddlCreditAct.Text == "Yes") ? "True" : "False");
        }

        private static bool IsNumber(string str)
        {
            return str.All(c => c >= '0' && c <= '9' || c== '/');
        }
    }
}