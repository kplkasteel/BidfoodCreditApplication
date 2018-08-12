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
    public partial class BusinessPartners : Page
    {
        private CherwellBusinessObject _newUser;
        private string _newUserRecordId;
        private List<CherwellBusinessObject> _businessMembers;

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
                if (_newUser.FieldList.Fields[122].Value == "True")
                    Response.Redirect("~/ApplicationCompleted.aspx?RECID=" + _newUserRecordId);
                RetrieveMembers();
                SetMemberDetails();
                ddlIdType_SelectedIndexChanged(null, null);
            }
            else
            {
                Response.Redirect("~/LoadFailure.aspx?RECID=" + _newUserRecordId + "&PAGE=BusinessPartners.aspx");
            }
        }

        protected void BtnNext_Click(object sender, ImageClickEventArgs e)
        {

            Response.Redirect("~/TradeReference.aspx?RECID=" + _newUserRecordId);
        }

        protected void BtnBack_Click(object sender, ImageClickEventArgs e)
        {

            Response.Redirect("~/FinancialDetails.aspx?RECID=" + _newUserRecordId);
        }

        private void RetrieveMembers()
        {
            _businessMembers = new List<CherwellBusinessObject>();
            _businessMembers =
                Details.GetListCherwellBusinessObjects("Name of Business Member", "Parent ID", _newUserRecordId,
                    "Record");
        }

        private void SetMemberDetails()
        {
            if (lstMembers.Items.Count > 0) lstMembers.Items.Clear();
            foreach (var item in _businessMembers) lstMembers.Items.Add(item.FieldList.Fields[8].Value);
        }

        protected void BtnAction_Click(object sender, EventArgs e)
        {
            if (!CheckField()) return;

            if (!Global.ConfirmLogin()) Response.Redirect("~/LoadFailure.aspx?RECID=" + _newUserRecordId + "&PAGE=" + HttpContext.Current.Request.ApplicationPath);
            var root = Server.MapPath("~");
            var path = Path.Combine(root, "XMLFiles\\BusinessPartners.xml");
            var xmlString = File.ReadAllText(path);
            var newBusinesMember = CherwellBusinessObject.FromXmlString(xmlString);
            RetrieveMembers();
            newBusinesMember.FieldList.Fields[8].Value = txtName.Text;
            newBusinesMember.FieldList.Fields[9].Value = txtAddress.Text;
            newBusinesMember.FieldList.Fields[10].Value = ddlIdType.Text;
            if (ddlIdType.Text == "SA ID") newBusinesMember.FieldList.Fields[11].Value = txtID.Text;
            else newBusinesMember.FieldList.Fields[12].Value = txtID.Text;

            newBusinesMember.FieldList.Fields[14].Value = txtTel.Text;
            newBusinesMember.FieldList.Fields[15].Value = ddlCommunityOfProperty.Text == "Yes" ? "True" : "False";
            newBusinesMember.FieldList.Fields[17].Value = _newUserRecordId;
            if (btnAction.Text == "Add")
            {
                if (_businessMembers.Any(item => txtName.Text == item.FieldList.Fields[8].Value))
                {
                    Response.Write(
                        "<script LANGUAGE='JavaScript' >alert('You Cannot have multiple members with the same Name. Please review your input.')</script>");
                    return;
                }
                newBusinesMember.FieldList.Fields[0].Value =
                    Details.CreateCherwellBusinessObject("Name of Business Member", newBusinesMember);
                _businessMembers.Add(newBusinesMember);
            }
            else
            {
                foreach (var current in _businessMembers)
                {
                    if (lstMembers.SelectedItem.Text != current.FieldList.Fields[8].Value) continue;
                    Details.UpdateDetails("Name of Business Member", current.FieldList.Fields[0].Value,
                        newBusinesMember);
                    break;
                }
            }
            RetrieveMembers();
            SetMemberDetails();
            BtnClear_Click(null, null);
        }

        protected void LstMembers_SelectedIndexChanged(object sender, EventArgs e)
        {
            RetrieveMembers();
            btnAction.Text = "Update";
            btnDelete.Visible = true;
            foreach (var item in _businessMembers)
                if (lstMembers.SelectedItem.Text == item.FieldList.Fields[8].Value)
                {
                    txtName.Text = item.FieldList.Fields[8].Value;
                    txtAddress.Text = item.FieldList.Fields[9].Value;
                    ddlIdType.ClearSelection();
                    ddlIdType.Items.FindByValue(item.FieldList.Fields[10].Value).Selected = true;
                    txtID.Text = ddlIdType.Text == "SA ID"
                        ? item.FieldList.Fields[11].Value
                        : item.FieldList.Fields[12].Value;
                    txtTel.Text = item.FieldList.Fields[14].Value;
                    ddlCommunityOfProperty.ClearSelection();
                    if (item.FieldList.Fields[15].Value == "True")
                        ddlCommunityOfProperty.Items.FindByValue("Yes").Selected = true;
                    if (item.FieldList.Fields[15].Value == "False")
                        ddlCommunityOfProperty.Items.FindByValue("No").Selected = true;
                }
        }

        protected void BtnClear_Click(object sender, EventArgs e)
        {
            lstMembers.ClearSelection();
            btnDelete.Visible = false;
            btnAction.Text = "Add";
            txtName.Text = "";
            txtAddress.Text = "";
            txtName.Text = "";
            txtID.Text = "";
            txtTel.Text = "";
            ddlCommunityOfProperty.ClearSelection();
            ddlIdType.ClearSelection();
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            RetrieveMembers();
            foreach (var item in _businessMembers)
            {
                if (lstMembers.SelectedItem.Text != item.FieldList.Fields[8].Value) continue;
                item.FieldList.Fields[17].Value = "0";
                Details.UpdateDetails("Name of Business Member", item.FieldList.Fields[0].Value, item);
                _businessMembers.Remove(item);
                break;
            }
            RetrieveMembers();
            BtnClear_Click(null, null);
            SetMemberDetails();
        }

        protected bool CheckField()
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                Response.Write(
                    "<script LANGUAGE='JavaScript' >alert('No Name has been Provided. Please add Name of the BusinessMember')</script>");
                return false;
            }
            if (string.IsNullOrEmpty(txtAddress.Text))
            {
                Response.Write(
                    "<script LANGUAGE='JavaScript' >alert('No address has been Provided. Please add the Full Address of the BusinessMember')</script>");
                return false;
            }
            if (string.IsNullOrEmpty(txtID.Text))
            {
                Response.Write(
                    "<script LANGUAGE='JavaScript' >alert('No ID or passport number has been Provided. Please add SA ID number or Passport Number of the BusinessMember')</script>");
                return false;
            }
            if (string.IsNullOrEmpty(txtTel.Text))
            {
                Response.Write(
                    "<script LANGUAGE='JavaScript' >alert('No phone number has been Provided. Please add a Valid Phone nunber or CellPhone Numnber of the BusinessMember')</script>");
                return false;
            }
            if (string.IsNullOrEmpty(ddlIdType.Text))
            {
                Response.Write(
                    "<script LANGUAGE='JavaScript' >alert('No ID type has been Provided. Please select the correct ID type of the BusinessMember')</script>");
                return false;
            }
            if (ddlIdType.Text == "SA ID")
            {
                if (!IsNumber(txtID.Text))
                {
                    Response.Write(
                        "<script LANGUAGE='JavaScript' >alert('The SA ID can only contain numbers. Please addust accordingly')</script>");
                    return false;
                }
                if (txtID.Text.Length != 13)
                {
                    Response.Write(
                        "<script LANGUAGE='JavaScript' >alert('The SA ID cannot be longer or shorter as 13 digits. Please adjust accordingly')</script>");
                    return false;
                }
            }

            return true;
        }

        protected void ddlIdType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ddlIdType.Text))
            {
                txtID.Visible = false;
                lblIDType.Visible = false;
                return;
            }
            lblIDType.Text = ddlIdType.SelectedIndex == 1 ? "SA ID Number:" : "Passport Number:";
            txtID.Visible = true;
            lblIDType.Visible = true;
        }

        private static bool IsNumber(string str)
        {
            return str.All(c => c >= '0' && c <= '9');
        }
    }
}