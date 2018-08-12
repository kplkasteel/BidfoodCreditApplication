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
    public partial class TradeReference : Page
    {
        private CherwellBusinessObject _newUser;
        private string _newUserRecordId;
        private List<CherwellBusinessObject> _tradeReference;

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
                Retrievetradereferences();
                SetTradeReferences();
            }
            else Response.Redirect("~/LoadFailure.aspx?RECID=" + _newUserRecordId + "&PAGE=TradeReference.aspx");

        }

        protected void BtnNext_Click(object sender, ImageClickEventArgs e)

        {
            if (_newUser.FieldList.Fields[117].Value == "False")
            {
                Response.Redirect("~/PurchaseLiquor.aspx?RECID=" + _newUserRecordId);
            }
            else
            {
                Response.Redirect("~/CreditAct.aspx?RECID=" + _newUserRecordId);
            }
            
        }

        protected void BtnBack_Click(object sender, ImageClickEventArgs e)

        {
            if (_newUser.FieldList.Fields[117].Value == "False")
            {
                Response.Redirect("~/FinancialDetails.aspx?RECID=" + _newUserRecordId);
            }
            else
            {
                Response.Redirect("~/BusinessPartners.aspx?RECID=" + _newUserRecordId);
            }
        }

        private void Retrievetradereferences()
        {
            _tradeReference = new List<CherwellBusinessObject>();
            _tradeReference =
                Details.GetListCherwellBusinessObjects("Trade Reference", "Parent ID", _newUserRecordId, "Record");
        }

        private void SetTradeReferences()
        {
            if (lstMembers != null && lstMembers.Items.Count > 0) lstMembers.Items.Clear();
            foreach (var item in _tradeReference) lstMembers?.Items.Add(item.FieldList.Fields[8].Value);
            btnNext.Visible = lstMembers?.Items.Count >= 3;


        }

        protected void BtnAction_Click(object sender, EventArgs e)
        {
            if (!CheckField()) return;
            if (!Global.ConfirmLogin()) Response.Redirect("~/LoadFailure.aspx?RECID=" + _newUserRecordId + "&PAGE=" + HttpContext.Current.Request.ApplicationPath);
            var root = Server.MapPath("~");
            var path = Path.Combine(root, "XMLFiles\\TradeReference.xml");
            var xmlString = File.ReadAllText(path);
            var newTradeMember = CherwellBusinessObject.FromXmlString(xmlString);
            Retrievetradereferences();
            newTradeMember.FieldList.Fields[8].Value = txtName.Text;
            newTradeMember.FieldList.Fields[9].Value = txtContactName.Text;
            newTradeMember.FieldList.Fields[10].Value = txtTel.Text;
            newTradeMember.FieldList.Fields[12].Value = _newUserRecordId;
            if (btnAction.Text == "Add")
            {
                if (_tradeReference.Any(item => txtName.Text == item.FieldList.Fields[8].Value))
                {
                    Response.Write(
                        "<script LANGUAGE='JavaScript' >alert('You Cannot have multiple Members with the same Name. Please review your input.')</script>");
                    return;
                }
                newTradeMember.FieldList.Fields[0].Value =
                    Details.CreateCherwellBusinessObject("Trade Reference", newTradeMember);
                _tradeReference.Add(newTradeMember);
            }
            else
            {
                foreach (var item in _tradeReference)
                    if (lstMembers.SelectedItem.Text == item.FieldList.Fields[8].Value)
                        Details.UpdateDetails("Trade Reference", item.FieldList.Fields[0].Value, newTradeMember);
            }
            Retrievetradereferences();
            SetTradeReferences();
            BtnClear_Click(null, null);
        }

        protected void LstMembers_SelectedIndexChanged(object sender, EventArgs e)
        {
            Retrievetradereferences();
            btnDelete.Visible = true;
            foreach (var item in _tradeReference)
            {
                if (lstMembers != null && lstMembers.SelectedItem.Text != item.FieldList.Fields[8].Value) continue;
                btnAction.Text = "Update";
                txtName.Text = item.FieldList.Fields[8].Value;
                txtContactName.Text = item.FieldList.Fields[9].Value;
                txtTel.Text = item.FieldList.Fields[10].Value;
                break;
            }
        }

        protected void BtnClear_Click(object sender, EventArgs e)
        {
            lstMembers.ClearSelection();
            btnDelete.Visible = false;
            btnAction.Text = "Add";
            txtContactName.Text = "";
            txtName.Text = "";
            txtTel.Text = "";
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            Retrievetradereferences();
            foreach (var item in _tradeReference)
            {
                if (lstMembers != null && lstMembers.SelectedItem.Text != item.FieldList.Fields[8].Value) continue;
                item.FieldList.Fields[12].Value = "0";
                Details.UpdateDetails("Trade Reference", item.FieldList.Fields[0].Value, item);
                break;
            }
            btnDelete.Visible = false;
            Retrievetradereferences();
            SetTradeReferences();
            BtnClear_Click(null, null);
        }

        protected bool CheckField()
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                Response.Write(
                    "<script LANGUAGE='JavaScript' >alert('No businessname has been Provided. Please add Name of the BusinessMember')</script>");
                return false;
            }
            if (string.IsNullOrEmpty(txtContactName.Text))
            {
                Response.Write(
                    "<script LANGUAGE='JavaScript' >alert('No Name has been Provided. Please add the Full Address of the BusinessMember')</script>");
                return false;
            }
            if (string.IsNullOrEmpty(txtTel.Text))
            {
                Response.Write(
                    "<script LANGUAGE='JavaScript' >alert('No Phoen number has been provided. Please adjust accordingly.')</script>");
                return false;
            }

            if (!Isphonenumber(txtTel.Text))
            {
                Response.Write(
                    "<script LANGUAGE='JavaScript' >alert('Phone numbers can only contain numbers. Please adjust accordingly')</script>");
                return false;
            }
            return true;
        }

        private static bool Isphonenumber(string str)
        {
            return str.All(c => c >= '0' && c <= '9');
        }
    }
}