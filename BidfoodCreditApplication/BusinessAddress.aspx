<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BusinessAddress.aspx.cs" Inherits="BidfoodCreditApplication.BusinessAddress" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<form id="BusinessAddress" runat="server">
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
            Physical Address
        </div>
        <div id="centeredDiv" style="width: 60%; margin: auto; text-align: left; height: 340px;">
            <div style="height: 19px">
                <div style="float: left; width: 30%; height: 19px;">
                    <asp:Label runat="server" Text="Building/Complex:" Font-Names="Open Sans" Font-Size="Small"></asp:Label>
                </div>
                <div style="float: left; width: 70%">
                    <asp:TextBox ID="txtBuildingComplex" runat="server" Width="100%" Font-Names="Open Sans" Font-Size="Small"></asp:TextBox>
                </div>
            </div>
            <div style="height: 19px; margin-top: 15px;">
                <div style="float: left; width: 30%; height: 19px;">
                    <asp:Label runat="server" Text="Building Number:" Font-Names="Open Sans" Font-Size="Small"></asp:Label>
                </div>
                <div style="float: left; width: 70%">
                    <asp:TextBox ID="txtBuildingNumber" runat="server" Width="100px" Font-Names="Open Sans" Font-Size="Small"></asp:TextBox>
                </div>
            </div>
            <div style="height: 19px; margin-top: 15px;">
                <div style="float: left; width: 30%; height: 19px;">
                    <asp:Label runat="server" Text="Street Name:" Font-Names="Open Sans" Font-Size="Small"></asp:Label>
                </div>
                <div style="float: left; width: 70%">
                    <asp:TextBox ID="txtStreetName" runat="server" Width="100%" Font-Names="Open Sans" Font-Size="Small"></asp:TextBox>
                </div>
            </div>
            <div style="height: 19px; margin-top: 15px;">
                <div style="float: left; width: 30%; height: 19px;">
                    <asp:Label runat="server" Text="Suburb:" Font-Names="Open Sans" Font-Size="Small"></asp:Label>
                </div>
                <div style="float: left; width: 70%">
                    <asp:TextBox ID="txtSuburb" runat="server" Width="100%" Font-Names="Open Sans" Font-Size="Small"></asp:TextBox>
                </div>
            </div>
            <div style="height: 19px; margin-top: 15px;">
                <div style="float: left; width: 30%; height: 19px;">
                    <asp:Label runat="server" Text="City:" Font-Names="Open Sans" Font-Size="Small"></asp:Label>
                </div>
                <div style="float: left; width: 70%">
                    <asp:TextBox ID="txtCity" runat="server" Width="100%" Font-Names="Open Sans" Font-Size="Small"></asp:TextBox>
                </div>
            </div>
            <div style="height: 19px; margin-top: 15px;">
                <div style="float: left; width: 30%; height: 19px;">
                    <asp:Label runat="server" Text="Country:" Font-Names="Open Sans" Font-Size="Small"></asp:Label>
                </div>
                <div style="float: left; width: 70%">
                    <asp:DropDownList ID="ddlCountry" runat="server" AutoPostBack="True" OnTextChanged="DdlCountry_SelectedIndexChanged" Font-Names="Open Sans" Font-Size="Small">
                    </asp:DropDownList>
                </div>
            </div>
            <div style="height: 19px; margin-top: 15px;">
                <div style="float: left; width: 30%; height: 19px;">
                    <asp:Label runat="server" Text="Postal Code:" Font-Names="Open Sans" Font-Size="Small"></asp:Label>
                </div>
                <div style="float: left; width: 20%">
                    <asp:TextBox ID="txtPostalCode" runat="server" Width="100%" Font-Names="Open Sans" Font-Size="Small"></asp:TextBox>
                </div>
            </div>
            <div style="height: 19px; margin-top: 15px;">
                <div style="float: left; width: 30%; height: 19px;">
                    <asp:Label runat="server" Text="Province or State:" Font-Names="Open Sans" Font-Size="Small"></asp:Label>
                </div>
                <div style="float: left; width: 70%">
                    <asp:DropDownList ID="ddlProvince" runat="server" AutoPostBack="True" Font-Names="Open Sans" Font-Size="Small">
                    </asp:DropDownList>
                </div>
            </div>

            <div style="height: 19px; margin-top: 15px;">
                <div style="float: left; width: 50%; height: 19px;">
                    <asp:Label runat="server" Text="Physical Address same as Postal Address?" Font-Names="Open Sans" Font-Size="Small"></asp:Label>
                </div>
                <div style="float: left; width: 20%">
                    <asp:RadioButton ID="rdbYes" runat="server" Font-Names="Open Sans" Font-Size="Small" Text="Yes" Checked="True" AutoPostBack="True" OnCheckedChanged="RdbYes_CheckedChanged"/>
                </div>
                <div style="float: left; width: 20%">
                    <asp:RadioButton ID="rdbNo" runat="server" Font-Names="Open Sans" Font-Size="Small" Text="No" AutoPostBack="True" OnCheckedChanged="RdbNo_CheckedChanged"/>
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
