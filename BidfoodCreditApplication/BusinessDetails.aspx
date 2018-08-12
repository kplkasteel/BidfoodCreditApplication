<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BusinessDetails.aspx.cs" Inherits="BidfoodCreditApplication.BusinessDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<form id="BusinessDetails" runat="server">
    <div id="wrapper">
        <img src="Images/BidfoodLogo.png" width="100%"/>
    </div>
    <div style="background-color: #11014C; color: #FFFFFF; font-family: Dax-Regular; font-size: 28px; line-height: normal; padding-bottom: 25px; padding-top: 25px; text-align: center; vertical-align: inherit; width: inherit;">
        Bidfood Credit Application
    </div>
    <div>

        <hr/>

    </div>
    <div id="containerDiv" style="height: 340px; text-align: center;">
        <div style="background-color: #11014C; color: #FFFFFF; font-family: 'Open Sans'; font-size: 20px; margin: auto auto 10px auto; padding-bottom: 8px; padding-top: 8px; text-align: center; width: 60%;">
            Business Details
        </div>
        <div id="centeredDiv" style="height: 340px; margin: auto; text-align: left; width: 60%;">
            <div style="height: 340px">
                <div style="height: 19px">
                    <div style="float: left; height: 19px; width: 30%;">
                        <asp:Label runat="server" Text="Registration Number:" Font-Names="Open Sans" Font-Size="Small" ID="lblRegNumber"></asp:Label>
                    </div>
                    <div style="float: left; width: 50px">
                        <asp:TextBox ID="txtReg1" runat="server" Width="100%" Font-Names="Open Sans" Font-Size="Small"></asp:TextBox>
                    </div>
                    <div runat="server" style="float: left; font-family: 'Open Sans'; font-size: Small; font-weight: bold; text-align: center; width: 2%;" id="lblslash1">
                        &nbsp;/</div>
                    <div style="float: left; width: 86px">
                        <asp:TextBox ID="txtReg2" runat="server" Width="100%" Font-Names="Open Sans" Font-Size="Small"></asp:TextBox>
                    </div>
                    <div runat="server" style="float: left; font-family: 'Open Sans'; font-size: Small; font-weight: bold; margin: auto; text-align: center; width: 2%; " id="lblslash2">
                        &nbsp;/</div>
                    <div style="float: left; width: 26px">
                        <asp:TextBox ID="txtReg3" runat="server" Width="100%" Font-Names="Open Sans" Font-Size="Small"></asp:TextBox>
                    </div>
                </div>
                <div style="height: 19px; margin-top: 15px;">
                    <div style="float: left; height: 19px; width: 30%;">
                        <asp:Label runat="server" Text="VAT Number:" Font-Names="Open Sans" Font-Size="Small"></asp:Label>
                    </div>
                    <div style="float: left; width: 70%">
                        <asp:TextBox ID="txtvatNumber" runat="server" Width="30%" Font-Names="Open Sans" Font-Size="Small"></asp:TextBox>
                    </div>
                </div>
                <div style="height: 19px; margin-top: 15px;">
                    <div style="float: left; height: 19px; width: 30%;">
                        <asp:Label runat="server" Text="Trading Names:" Font-Names="Open Sans" Font-Size="Small"></asp:Label>
                    </div>
                    <div style="float: left; width: 70%">
                        <asp:TextBox ID="txtTradingNames" runat="server" Width="100%" Font-Names="Open Sans" Font-Size="Small"></asp:TextBox>
                    </div>
                </div>
                <div style="height: 19px; margin-top: 15px;">
                    <div style="float: left; height: 19px; width: 30%;">
                        <asp:Label runat="server" Text="Nature Of Business:" Font-Names="Open Sans" Font-Size="Small"></asp:Label>
                    </div>
                    <div style="float: left; width: 70%">
                        <asp:DropDownList ID="ddlNatureOfBusiness" runat="server" Font-Names="Open Sans" Font-Size="Small">
                        </asp:DropDownList>
                    </div>
                </div>
                <div style="height: 19px; margin-top: 15px;">
                    <div style="float: left; height: 19px; width: 30%;">
                        <asp:Label runat="server" Text="Name Of Holding Company:" Font-Names="Open Sans" Font-Size="Small"></asp:Label>
                    </div>
                    <div style="float: left; width: 70%">
                        <asp:TextBox ID="txtHoldingCompany" runat="server" Width="100%" Font-Names="Open Sans" Font-Size="Small"></asp:TextBox>
                    </div>
                </div>
                <div style="height: 19px; margin-top: 15px;">
                    <div style="float: left; height: 19px; width: 45%;">
                        <asp:Label runat="server" Text="Does the Purchaser use Purchase Order Numbers?" Font-Names="Open Sans" Font-Size="Small"></asp:Label>
                    </div>
                    <div style="float: left; width: 5%">
                        <asp:CheckBox ID="chkOrderNumbers" runat="server"/>
                    </div>
                    <div style="float: left; width: 30%">
                        <asp:Label runat="server" Text="Is The Business Premises Leased?" Font-Names="Open Sans" Font-Size="Small" ID="Label1"></asp:Label>
                    </div>
                    <asp:CheckBox ID="chkPremisesLeased" runat="server" OnCheckedChanged="ChkPremisesLeased_CheckedChanged" AutoPostBack="True"/>
                </div>
                <div style="height: 19px; margin-top: 15px;">
                    <div style="float: left; height: 19px; width: 30%;">
                        <asp:Label runat="server" Text="Land Lord Details:" Font-Names="Open Sans" Font-Size="Small" ID="lblLandlord"></asp:Label>
                    </div>
                    <div style="float: left; width: 70%">
                        <asp:TextBox ID="txtLandlordDetails" runat="server" Width="100%" Font-Names="Open Sans" Font-Size="Small" Height="28px" TextMode="MultiLine"></asp:TextBox>
                    </div>
                </div>
                <div style="height: 19px; margin-top: 15px;">
                    <div style="float: left; height: 19px; width: 30%;">
                    </div>
                    <div style="float: left; width: 70%">
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div style="height: 29px; margin: 10px auto auto auto; width: 136px;">
        <div style="float: left; height: 29px; width: 33%;">
            <asp:ImageButton ID="btnBack" runat="server" Height="100%" ImageUrl="~/Images/Back.png" OnClick="BtnBack_Click" ImageAlign="Left"/>
        </div>
        <div style="float: left; height: 29px; width: 33%;">
        </div>
        <div style="float: left; height: 29px; width: 33%;">
            <asp:ImageButton ID="btnNext" runat="server" Height="100%" ImageUrl="~/Images/Next.png" OnClick="BtnNext_Click" ImageAlign="Right"/>
        </div>
    </div>
</form>
</body>
</html>