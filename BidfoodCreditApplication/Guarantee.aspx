<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Guarantee.aspx.cs" Inherits="BidfoodCreditApplication.Guarantee" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
    </style>
</head>
<body>
<form id="Guarantee" runat="server">
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
            Guarantee</div>
        <div id="centeredDiv" style="width: 60%; margin: auto; text-align: left; height: 310px;">
            <asp:TextBox ID="txtGuarantee" runat="server" Font-Names="Open Sans" Font-Overline="False" Font-Size="Small" Height="75%" ReadOnly="True" TextMode="MultiLine" Width="100%"></asp:TextBox>

            <div class="auto-style1" style="border: thin double #000000; margin-top: 10px; height: 38px; font-family: 'Open Sans'; font-size: small; font-weight: bold;">
                Your attention is drawn to the fact that this Guarantee contains provisions that: impose liability upon you; limit our liability; and exclude certain of your rights, benefits and defences as a Guarantor.</div>

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


