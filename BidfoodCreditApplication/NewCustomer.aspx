<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewCustomer.aspx.cs" Inherits="BidfoodCreditApplication.NewCustomer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<form id="NewCustomer" runat="server">
    <div>
        <img src="Images/BidfoodLogo.png" width ="100%"/>
    </div>
    <div style="background-color: #11014C; color: #FFFFFF; font-family: Dax-Regular; font-size: 28px; line-height: normal; padding-bottom: 25px; padding-top: 25px; text-align: center; vertical-align: inherit; width: inherit;">
        Bidfood Credit Application
    </div>
    <div>

        <hr/>

    </div>
    <div id="containerDiv" style="text-align: center;">
        <div style="background-color: #11014C; color: #FFFFFF; font-family: 'Open Sans'; font-size: 20px; margin: auto auto 10px auto; padding-bottom: 8px; padding-top: 8px; text-align: center; width: 60%;">
            New Customer Registation
        </div>
        <div id="centeredDiv" style="height: 340px; margin: auto; text-align: left; width: 60%;">
            <div style="height: 410px">
                <div style="height: 19px">
                    <div style="float: left; height: 19px; width: 30%;">
                        <asp:Label runat="server" Text="Purchasers Registered/Legal Name:" Font-Names="Open Sans" Font-Size="Small"></asp:Label>
                    </div>
                    <div style="float: left; width: 70%">
                        <asp:TextBox ID="txtPurchasersname" runat="server" Width="100%" Font-Names="Open Sans" Font-Size="Small" MaxLength="15"></asp:TextBox>
                    </div>
                </div>
                <div style="height: 19px; margin-top: 10px;">
                    <div style="float: left; height: 19px; width: 30%;">
                        <asp:Label runat="server" Text="Credit Application for Legal Entity?:" Font-Names="Open Sans" Font-Size="Small"></asp:Label>

                    </div>
                    <div style="float: left; width: 70%">
                        <asp:CheckBox ID="chkLegalEntity" runat="server" Font-Names="Open Sans" Font-Size="Small" AutoPostBack="True" OnCheckedChanged="ChkLegalEntity_CheckedChanged"/>
                    </div>
                </div>
                <div style="height: 19px; margin-top: 10px;">
                    <div style="float: left; height: 19px; width: 30%;">
                        <asp:Label runat="server" Text="Type of Busness:" Font-Names="Open Sans" Font-Size="Small" ID="lblTypeOfBusiness"></asp:Label>
                    </div>
                    <div style="float: left; width: 70%">
                        <asp:DropDownList ID="ddlTypeOfBusiness" runat="server" Font-Names="Open Sans" Font-Size="Small" AutoPostBack="True">
                        </asp:DropDownList>
                    </div>
                </div>
                <div style="height: 19px; margin-top: 10px;">
                    <div style="float: left; height: 19px; width: 30%;">
                        <asp:Label runat="server" Text="First Name:" Font-Names="Open Sans" Font-Size="Small"></asp:Label>
                    </div>
                    <div style="float: left; width: 70%">
                        <asp:TextBox ID="txtFirstName" runat="server" Width="210px" Font-Names="open sans" Font-Size="Small"></asp:TextBox>
                    </div>
                </div>
                <div style="height: 19px; margin-top: 10px;">
                    <div style="float: left; height: 19px; width: 30%;">
                        <asp:Label runat="server" Text="Last Name:" Font-Names="Open Sans" Font-Size="Small"></asp:Label>
                    </div>
                    <div style="float: left; width: 70%">
                        <asp:TextBox ID="txtLastName" runat="server" Width="210px" Font-Names="Open Sans" Font-Size="Small"></asp:TextBox>
                    </div>
                </div>
                <div style="height: 19px; margin-top: 10px;">
                    <div style="float: left; height: 19px; width: 30%;">
                        <asp:Label runat="server" Text="Full Name" Font-Names="Open Sans" Font-Size="Small"></asp:Label>
                    </div>
                    <div style="float: left; width: 70%">
                        <asp:TextBox ID="txtFullName" runat="server" Width="210px" Font-Names="Open Sans" Font-Size="Small"></asp:TextBox>
                    </div>
                </div>
                <div style="height: 19px; margin-top: 10px;">
                    <div style="float: left; height: 19px; width: 30%;">
                        <asp:Label runat="server" Text="E-mail Address:" Font-Names="Open Sans" Font-Size="Small"></asp:Label>
                    </div>
                    <div style="float: left; width: 70%">
                        <asp:TextBox ID="txtEmail" runat="server" Width="100%" Font-Names="Open Sans" Font-Size="Small" TextMode="Email"></asp:TextBox>
                    </div>
                </div>
                <div style="height: 19px; margin-top: 10px;">
                    <div style="float: left; height: 19px; width: 30%;">
                        <asp:Label runat="server" Text="Phone Number:" Font-Names="Open Sans" Font-Size="Small"></asp:Label>
                    </div>
                    <div style="float: left; width: 70%">
                        <asp:TextBox ID="txtPhone" runat="server" Width="210px" Font-Names="open sans" Font-Size="Small" TextMode="Phone"></asp:TextBox>
                    </div>
                </div>
                <div style="height: 19px; margin-top: 15px;">
                    <div style="float: left; height: 19px; width: 30%;">
                        <asp:Label runat="server" Text="Cell Phone:" Font-Names="Open Sans" Font-Size="Small"></asp:Label>
                    </div>
                    <div style="float: left; width: 210px">
                        <asp:TextBox ID="txtCellPhone" runat="server" Width="100%" Font-Names="Open Sans" Font-Size="Small" TextMode="Phone"></asp:TextBox>
                    </div>
                    <div style="float: left; height: 19px; width: 10px;">
                    </div>
                    <div style="float: left; height: 19px; width: 12%;">
                        <asp:Label runat="server" Text="Fax Number:" Font-Names="Open Sans" Font-Size="Small"></asp:Label>
                    </div>
                    <div style="float: left; width: 210px">
                        <asp:TextBox ID="txtfax" runat="server" Width="100%" Font-Names="Open Sans" Font-Size="Small" TextMode="Phone"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
        <div style="height: 18px; margin: auto; padding: 10px; text-align: center; vertical-align: middle; width: 184px;">
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="BtnSubmit_Click" Font-Names="Dax-Regular" Font-Size="Medium"/>
        </div>
    </div>
</form>
</body>
</html>