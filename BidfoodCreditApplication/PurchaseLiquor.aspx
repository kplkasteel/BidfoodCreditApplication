<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PurchaseLiquor.aspx.cs" Inherits="BidfoodCreditApplication.PurchaseLiquor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<form id="PurchaseLiquor" runat="server">
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
            Liquor License
        </div>
        <div id="centeredDiv" style="width: 60%; margin: auto; text-align: left; height: 334px;">

            <div>
                <asp:Label runat="server" Font-Names="Open Sans" Font-Size="Small" Text="Will you be purchasing goods or products that require a valid SA Liquor License?" Width="100%"></asp:Label>
            </div>
            <div style="margin-top: 25px">
                <asp:CheckBox ID="chkPurchaseYes" runat="server" AutoPostBack="True" Font-Names="Open Sans" Font-Size="Small" OnCheckedChanged="chkPurchaseYes_CheckedChanged" Text="Liquor Licence Required?" />
            </div>
            <div style="margin-top: 25px; font-family: 'open sans'; font-size: small; height: 79px;">

                <asp:Label ID="lblUploadtext" runat="server" Text="Please, if available upload a digital copy of your valid Liquor license and/or any other documentation related to the liquor License. Once uploaded you will receive a reference number and Bidfood will confirm if the license is valid and applies to the Purchasers legal or registered name.  All popular image and office formats are supported but if possible only upload PDF, JPG or PNG and the total size sould not exceed 20MB"></asp:Label>
                <br />
                <br />

            </div>
            <div style="margin-top: 15px">
                <asp:FileUpload ID="fileUploadSelector" runat="server" AllowMultiple="True" Font-Names="Open Sans" Font-Size="Small" Width="100%" />
            </div>
            <div style="margin: 10px auto auto auto; width: 184px; height: 25px; vertical-align: middle; text-align: center;">
                <asp:Button ID="btnUpload" runat="server" Font-Names="Open Sans" Font-Size="Small" Height="25px" Style="margin-bottom: 0px" Text="Upload Documents" Width="150px" OnClick="btnUpload_Click" />
            </div>
            <div style="margin: 15px auto auto auto; width: 100%; height: 29px; vertical-align: middle; text-align: center;">
                <asp:Label ID="lblUploadCompleted" runat="server" Font-Names="Open Sans" Font-Size="Small" Height="100%" Width="100%"></asp:Label>
            </div>
            &nbsp;
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

