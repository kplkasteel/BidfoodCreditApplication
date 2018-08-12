<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TermsAndConditions.aspx.cs" Inherits="BidfoodCreditApplication.TermsAndConditions" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<form id="TermsAndConditions" runat="server">
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
    Standard
    Terms and Conditions
</div>
<div id="centeredDiv" style="width: 60%; margin: auto; text-align: left; height: 310px;">
<asp:TextBox ID="txtTerms" runat="server" Font-Names="Open Sans" Font-Overline="False" Font-Size="Small" Height="92%" ReadOnly="True" TextMode="MultiLine" Width="100%"></asp:TextBox>

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


