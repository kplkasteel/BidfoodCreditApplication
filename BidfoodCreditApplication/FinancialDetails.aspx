<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FinancialDetails.aspx.cs" Inherits="BidfoodCreditApplication.FinancialDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<form id="FinancialDetails" runat="server">
    <div id="wrapper">
        <img src="Images/BidfoodLogo.png" width="100%" />
    </div>
    <div style="width: inherit; text-align: center; vertical-align: inherit; background-color: #11014C; line-height: normal; font-size: 28px; color: #FFFFFF; padding-top: 25px; padding-bottom: 25px; font-family: Dax-Regular;">
        Bidfood Credit Application
    </div>
    <div>

        <hr />

    </div>
    <div id="containerDiv" style="text-align: center; height: 340px;">
        <div style="width: 60%; margin: auto auto 10px auto; text-align: center; padding-bottom: 8px; color: #FFFFFF; background-color: #11014C; padding-top: 8px; font-size: 20px; font-family: 'Open Sans';">
            Financial Details
        </div>
        <div id="centeredDiv" style="width: 60%; margin: auto; text-align: left; height: 334px;">
            <div style="height: 19px">
                <div style="float: left; width: 30%; height: 19px;">
                    <asp:Label runat="server" Text="Auditors:" Font-Names="Open Sans" Font-Size="Small"></asp:Label>
                </div>
                <div style="float: left; width: 70%">
                    <asp:TextBox ID="txtAuditors" runat="server" Width="100%" Font-Names="Open Sans" Font-Size="Small"></asp:TextBox>
                </div>
            </div>
            <div style="height: 19px; margin-top: 15px;">
                <div style="float: left; width: 30%; height: 19px;">
                    <asp:Label runat="server" Text="Year Purchaser Commenced Business:" Font-Names="Open Sans" Font-Size="Small"></asp:Label>
                </div>
                <div style="float: left; width: 70%">
                    <asp:DropDownList ID="ddlYear" runat="server" Font-Names="Open Sans" Font-Size="Small">
                    </asp:DropDownList>
                </div>
            </div>
            <div style="height: 19px; margin-top: 15px;">
                <div style="float: left; width: 30%; height: 19px;">
                    <asp:Label runat="server" Text="Person Responsible for Paying Accounts:" Font-Names="Open Sans" Font-Size="Small"></asp:Label>
                </div>
                <div style="float: left; width: 70%">
                    <asp:TextBox ID="txtPersonAccounts" runat="server" Width="100%" Font-Names="Open Sans" Font-Size="Small"></asp:TextBox>
                </div>
            </div>
            <div style="height: 19px; margin-top: 15px;">
                <div style="float: left; width: 30%; height: 19px;">
                    <asp:Label runat="server" Font-Names="Open Sans" Font-Size="Small" Text="Tel:" Width="100%" ID="Label7"></asp:Label>
                </div>
                <div style="float: left; width: 70%; height: 19px;">
                    <div style="float: left; width: 25%">
                        <asp:TextBox ID="txtAccountsTel" runat="server" TextMode="Phone" Width="90%"></asp:TextBox>
                    </div>
                    <div style="float: left; width: 10%">
                        <asp:Label runat="server" Font-Names="Open Sans" Font-Size="Small" Text="E-mail:" Width="100%"></asp:Label>
                    </div>
                    <div style="float: left; width: 65%">
                        <asp:TextBox ID="txtAcountsEmail" runat="server" Width="100%" TextMode="Email"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div style="height: 19px; margin-top: 15px;">
                <div style="float: left; width: 30%; height: 19px;">
                    <asp:Label runat="server" Text="Person Responsible for Ordering:" Font-Names="Open Sans" Font-Size="Small"></asp:Label>
                </div>
                <div style="float: left; width: 70%">
                    <asp:TextBox ID="txtPersonOrdering" runat="server" Width="100%" Font-Names="Open Sans" Font-Size="Small"></asp:TextBox>
                </div>
            </div>
            <div style="height: 19px; margin-top: 15px;">
                <div style="float: left; width: 30%; height: 19px;">
                    <asp:Label runat="server" Font-Names="Open Sans" Font-Size="Small" Text="Tel:" Width="100%" ID="Label8"></asp:Label>
                </div>
                <div style="float: left; width: 70%; height: 19px;">
                    <div style="float: left; width: 25%">
                        <asp:TextBox ID="txtOrderingTel" runat="server" TextMode="Phone" Width="90%"></asp:TextBox>
                    </div>
                    <div style="float: left; width: 10%">
                        <asp:Label runat="server" Font-Names="Open Sans" Font-Size="Small" Text="E-mail:" Width="100%"></asp:Label>
                    </div>
                    <div style="float: left; width: 65%">
                        <asp:TextBox ID="txtOrderingEmail" runat="server" Width="100%" TextMode="Email"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div style="margin: 10px auto auto auto; height: 29px; width: 136px;">
        <div style="float: left; width: 33%; height: 29px;">
            <asp:ImageButton ID="btnBack" runat="server" Height="100%" ImageUrl="~/Images/Back.png" OnClick="BtnBack_Click" ImageAlign="Left" />
        </div>
        <div style="float: left; width: 33%; height: 29px;">
        </div>
        <div style="float: left; width: 33%; height: 29px;">
            <asp:ImageButton ID="btnNext" runat="server" Height="100%" ImageUrl="~/Images/Next.png" OnClick="BtnNext_Click" ImageAlign="Right" />
        </div>
    </div>
</form>
</body>
</html>

