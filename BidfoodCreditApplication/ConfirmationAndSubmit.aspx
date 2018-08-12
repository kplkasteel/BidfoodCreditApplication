<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConfirmationAndSubmit.aspx.cs" Inherits="BidfoodCreditApplication.ConfirmationAndSubmit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<form id="ConfirmationAndSubmit" runat="server">
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
        <div style="width: 70%; margin: auto auto 10px auto; text-align: center; padding-bottom: 8px; color: #FFFFFF; background-color: #11014C; padding-top: 8px; font-size: 20px; font-family: 'Open Sans';">
            Confirmation and submit Application
        </div>
        <div id="centeredDiv" style="width: 70%; margin: auto; text-align: left; height: 334px;">
            <div style="height: 125px; font-family: 'Open Sans'; font-size: small;">
                Thank you for taking the time to complete the online Credit application form and please make sure all that needed to be provided has been provide correctly and accurately. 
                <br />
                <br />
                Please be aware that after submitting this application you will not be able to return to the application form and will have to await the outcome of the current application approval process.<br />
                <br />
                At this point you can still go back to each and every page to make sure everything is 100% completed and correct. Once you have assured yourselfs you can complete the application by confirming the below:<br />
            </div>
            <div style="height: 19px; margin-top: 15px; margin-bottom: 0px;">
                <div style="float: left; width: 30%">
                    <asp:Label runat="server" Font-Bold="True" Font-Names="open sans" Font-Size="Small" Text="Requested Credit Limit:"></asp:Label>
                </div>
                <div style="float: left; width: 2%">
                    <asp:Label runat="server" Font-Bold="True" Font-Names="open sans" Font-Size="Small" Text="R"></asp:Label>
                </div>
                <div style="float: left; width: 150px; height: 24px;">
                    <asp:TextBox ID="txtCreditLimit" runat="server" TextMode="Number" Font-Bold="True" Font-Names="open sans" Font-Size="Small" Width="100px">20000</asp:TextBox>
                </div>
                <div style="float: left; width: 10%">
                </div>
                <div style="float: left; width: 20%">
                    <asp:Label runat="server" Font-Names="Open Sans" Font-Size="Small" Text="Repayment Terms" Width="100%" Font-Bold="True"></asp:Label>
                </div>
                <div style="float: left; width: 10%">
                    <asp:DropDownList ID="ddlTerms" runat="server" Font-Names="Open Sans" Font-Size="Small" Width="100%" Font-Bold="True">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>COD</asp:ListItem>
                        <asp:ListItem>7 Days</asp:ListItem>
                        <asp:ListItem>25 Days</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>

            <div style="height: 19px; margin-top: 10px;">
                <asp:CheckBox ID="chkCorrectAndAccurate" runat="server" Font-Names="Open Sans" Font-Size="Small" Text="I ... confirm that all information provided is correct and accurate." AutoPostBack="True" OnCheckedChanged="ChkCorrectAndAccurate_CheckedChanged" />
            </div>
            <div style="height: 19px; margin-top: 10px;">
                <asp:CheckBox ID="chkTermsandConditions" runat="server" Font-Names="Open Sans" Font-Size="Small" Text="I ... confirm that I have read, understood and agree with the standard terms and Conditions." AutoPostBack="True" OnCheckedChanged="ChkTermsandConditions_CheckedChanged" />
            </div>
                
            <div style="height: 19px; margin-top: 10px;">
                <asp:CheckBox ID="chkGaurantee" runat="server" Font-Names="Open Sans" Font-Size="Small" Text="I ... confim that I have read, understood and agree with the Guarantee." AutoPostBack="True" OnCheckedChanged="ChkGaurantee_CheckedChanged" />
            </div>
            <div style="height: 19px; margin-top: 10px;">
                    
                <asp:CheckBox ID="chkAuthorisation" runat="server" Font-Names="open sans" Font-Size="Small" Text="I ... confirm that I am authorised to allow  Bidfood  to do such credit rating processes as deemed necessary to evaluate this application" AutoPostBack="True" OnCheckedChanged="chkAuthorisation_CheckedChanged" />
                    
            </div>

        </div>
    </div>
    <div style="margin: 10px auto auto auto; height: 29px; width: 136px;">
        <div style="float: left; width: 33%; height: 29px;">
            <asp:ImageButton ID="ImageButton1" runat="server" Height="100%" ImageUrl="~/Images/Back.png" OnClick="BtnBack_Click" ImageAlign="Left" />
        </div>
        <div style="float: left; width: 66%; height: 29px;">
            <asp:Button ID="btnSubmit" runat="server" Font-Bold="True" Font-Names="Open Sans" Font-Size="Small" Height="32px" Text="Submit Application" OnClick="BtnSubmit_Click" Width="151px" />
        </div>
    </div>
</form>
</body>
</html>

