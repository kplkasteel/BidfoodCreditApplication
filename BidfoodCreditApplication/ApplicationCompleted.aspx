<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApplicationCompleted.aspx.cs" Inherits="BidfoodCreditApplication.ApplicationCompleted"  %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<form id="ApplicationCompleted" runat="server">
    <div id ="wrapper">
        <img  src="Images/BidfoodLogo.png" width ="100%" />
    </div>
    <div style="width: inherit; text-align: center; vertical-align: inherit; background-color: #11014C; line-height: normal; font-size: 28px; color: #FFFFFF; padding-top: 25px; padding-bottom: 25px; font-family: Dax-Regular;">
        Bidfood Credit Application
    </div>
    <div>

        <hr />

    </div>
    <div id="containerDiv" style="text-align: center; height: 340px;">
        <div style="width: 60%; margin: auto auto 10px auto; text-align: center; padding-bottom: 8px; color: #FFFFFF; background-color: #11014C; padding-top: 8px; font-size: 20px; font-family: 'Open Sans';">

            Application Completed</div>
        <div id="centeredDiv" style="width: 60%; margin: auto; text-align: left; height: 334px;">
            <asp:TextBox ID="txtSorryText" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="open sans" Font-Size="Medium" Height="100%" ReadOnly="True" TextMode="MultiLine" Width="100%"></asp:TextBox>
        </div>
    </div>
</form>
</body>
</html>
