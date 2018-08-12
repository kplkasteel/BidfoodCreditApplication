<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssetValueAndTurnover.aspx.cs" Inherits="BidfoodCreditApplication.AssetValueAndTurnover" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<form id="AssetValueAndTurnover" runat="server">
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
            Asset Values And Annual Turnover
        </div>
        <div id="centeredDiv" style="width: 60%; margin: auto; text-align: left; height: 334px;">
            <div style="height: 19px;">
                <div style="float: left; width: 30%; height: 19px;">
                    <asp:Label runat="server" Text="Asset Value of Purchaser:" Font-Names="Open Sans" Font-Size="Small"></asp:Label>
                </div>

                <div style="float: left; width: 70%">
                    <div style="float: left; width: 2%">
                        <asp:Label runat="server" Text="R" Font-Names="Open Sans" Font-Size="Small" ID="Label5"></asp:Label>
                    </div>
                    <div>
                        <asp:TextBox ID="txtAssetValue" runat="server" Width="25%" Font-Names="Open Sans" Font-Size="Small" TextMode="Number"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div style="height: 19px; margin-top: 15px;">
                <div style="float: left; width: 30%; height: 19px;">
                    <asp:Label runat="server" Text="Annual Turnover of Purchaser:" Font-Names="Open Sans" Font-Size="Small"></asp:Label>
                </div>

                <div style="float: left; width: 70%">
                    <div style="float: left; width: 2%">
                        <asp:Label runat="server" Text="R" Font-Names="Open Sans" Font-Size="Small" ID="Label6"></asp:Label>
                    </div>
                    <div>
                        <asp:TextBox ID="txtTurnOver" runat="server" Width="25%" Font-Names="Open Sans" Font-Size="Small" TextMode="Number"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div style="height: 142px; margin-top: 15px; font-family: 'Open Sans'; font-size: small;">
                By answering the above questions as being Above R2 000 000 and between R 1 000 000 and R 2 000 000 the Purchaser warrants to the Seller that the Asset Value and/or the Turnover of the Purchaser, as the case may be, exceeds R1 000 000 per annum. The Purchaser agrees that any security previously given by the Purchaser to the Seller pursuant to any credit application or otherwise shall remain of full force and effect from the date such security was provided and the execution by the Purchaser of this Credit Application, Standard Terms and Conditions and Guarantee shall not in any way affect the rights of the Purchaser in terms of any such security. The Purchaser agrees that the Seller shall be entitled, at any time to cede all or any of its rights and/or delegate all or any of its obligations in terms of this Credit Application, to any other subsidiary of The Bidcorp Group Limited (registration number 1995/008615/06). The purchaser agrees to the standard terms and conditions contained 
                herein and which terms and conditions incorporate a deed of cession.
            </div>
            <div style="height: 19px; margin-top: 15px; font-family: 'Open Sans'; font-size: small; font-weight: bold;">
                THE SIGNATORIES WARRANT THAT THEY ARE AUTHORISED TO SIGN THIS DOCUMENT (INCLUDING WITHOUT LIMITATION THE STANDARD TERMS AND CONDITIONS CONTAINED HEREIN AND WHICH TERMS AND CONDITIONS INCORPORATE A DEED OF CESSION) ON BEHALF OF THE PURCHASER AND THAT THE INFORMATION DISCLOSED IN THIS APPLICATION IS TRUE AND CORRECT.
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
