<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoadFailure.aspx.cs" Inherits="BidfoodCreditApplication.LoadFailure" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<form id="LoadFailure" runat="server">
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
        <div id="centeredDiv" style="height: 334px; margin: auto; text-align: left; width: 60%;">
            <div style="height: 150px; margin: 25px auto auto auto; width: 150px;">
                <asp:Image runat="server" BorderStyle="None" Height="100%" ImageUrl="~/Images/Wrong.png" Width="100%"/>
            </div>
            <div aria-busy="False" style="font-family: 'open Sans'; font-size: medium; height: 39%; margin-top: 25px;">
                <asp:TextBox runat="server" BorderStyle="None" Font-Names="open sans" Font-Overline="False" Font-Size="Medium" Height="100%" ReadOnly="True" TextMode="MultiLine" Width="100%">We are really sorry for the inconveniance. Something must have gone horibly wrong. Please return to the previous page and try again. Alternatively you can restart the application by using the link received in your mail. If you keep on getting this error please contact Bidfood Pty Ltd via e-mail or phone. </asp:TextBox>
            </div>

        </div>
    </div>
    <div style="height: 18px; margin: auto; padding: 10px; text-align: center; vertical-align: middle; width: 184px;">
            <asp:Button ID="btnRetry" runat="server" Text="Back/Retry" Font-Names="Dax-Regular" Font-Size="Medium" OnClick="btnRetry_Click"/>
        </div>
</form>
</body>
</html>