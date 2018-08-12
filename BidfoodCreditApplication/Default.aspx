<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BidfoodCreditApplication.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<form id="form1" runat="server">
    <div>
        <p>
            <span>
                <img src="Images/BidfoodLogo.png" width ="100%"/>
            </span>

        </p>
        <br/>
        <br/>
        <br/>
        <div style="color: #11014C; font-family: Dax-Regular; font-size: larger; text-align: center;">
            <asp:Label ID="Label1" runat="server" Text="CREDIT APPLICATION, TERMS AND CONDITIONS AND GUARANTEE BIDFOOD (PTY) LTD" ForeColor="#11014C" Font-Size="X-Large" Font-Names="Dax-Regular" Font-Bold="True"></asp:Label>
            <br/>
            Reg. No. 1964/002063/07&nbsp;&nbsp; Vat. No. 4560266209<br/>
            <br/>
            <span style="-webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); color: rgb(17, 1, 76); display: inline !important; float: none; font-family: 'Open Sans'; font-size: medium; font-style: normal; font-variant-caps: normal; font-variant-ligatures: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: left; text-decoration-color: initial; text-decoration-style: initial; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px;" dir="ltr">
                &nbsp;Welcome to the BidFood Credit Application.<br/>
                <br/>Within the next few steps you will be requested to provide some mandatory information regarding your Credit Application and we ask you to complete all relevant fields.<br/>Please be advised that providing partial or incorrect information could lead to your application being cancelled or rejected.<br/>Therefore make sure you complete all required fields as accurately as possible
                to ensure a speedy and effortless process.<br/>
                <br/>After the first page you will receive an automated e-mail with a direct link to your online application.<br/>At any stage you can stop completing the application and
                if you whish you can<br/>return at a later stage to continue to complete the application.<br/>You can do so by clicking on the link that will be sent to your e-mail address.<br/>
                <br/>
            </span>
        </div>
        <div style="text-align: center;">
            <asp:Label ID="Label2" runat="server" Text="Please click below to start you application" ForeColor="Black" BorderStyle="None" Font-Size="Large" Font-Names="Dax-Regular"></asp:Label>
            <br/>
            <br/>
            <asp:ImageButton ID="BidfoodImage" runat="server" Height="72px" ImageUrl="~/Images/Foodservice Made Easy.png" OnClick="BidfoodImage_Click"/>
            <br/>
        </div>

    </div>
</form>
<div>
</div>
</body>
</html>