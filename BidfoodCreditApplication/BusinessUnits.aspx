<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BusinessUnits.aspx.cs" Inherits="BidfoodCreditApplication.BusinessUnits" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<form id="BusinessUnitss" runat="server">
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
            Additional
            Business Units</div>
        <div id="centeredDiv" style="width: 60%; margin: auto; text-align: left; height: 340px;">
            <div style="height: 19px; font-family: 'open sans'; font-size: small; font-weight: bold;">
                Only required if there is more than one business unit.</div>
            <div style="height: 19px; margin-top: 15px;">
                <div style="float: left; width: 30%; height: 19px;">
                    <asp:Label runat="server" Text="Name:" Font-Names="Open Sans" Font-Size="Small"></asp:Label>
                </div>
                <div style="float: left; width: 70%">
                    <asp:TextBox ID="txtName" runat="server" Width="100%" Font-Names="Open Sans" Font-Size="Small"></asp:TextBox>
                </div>
            </div>
            <div style="height: 19px; margin-top: 15px;">
                <div style="float: left; width: 30%; height: 19px;">
                    <asp:Label runat="server" Text="Delivery Address;" Font-Names="Open Sans" Font-Size="Small"></asp:Label>
                </div>
                <div style="float: left; width: 70%; height: 19px;">
                    <div style="float: left; width: 50%; height: 19px;">
                        <asp:TextBox ID="txtBuildingName" runat="server" Width="100%"></asp:TextBox>
                    </div>
                    <div style="float: left; width: 5%; height: 19px;">
                    </div>
                    <div style="float: left; width: 20%; height: 19px;">
                        <asp:Label runat="server" Text="Buliding Number:" Font-Names="Open Sans" Font-Size="Small" ID="Label5" Width="100%"></asp:Label>
                    </div>
                    <div style="float: left; width: 5%; height: 19px;">
                    </div>
                    <div style="float: left; width: 20%; height: 19px;">
                        <asp:TextBox ID="txtBuildingNr" runat="server" Width="100%"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div style="height: 19px; margin-top: 15px;">
                <div style="float: left; width: 30%; height: 19px;">
                    <asp:Label runat="server" Text="Street name &amp; Number:" Font-Names="Open Sans" Font-Size="Small"></asp:Label>
                </div>

                <div style="float: left; width: 70%">
                    <div>
                        <div style="float: left; width: 40%; height: 19px;">
                            <asp:TextBox ID="txtStreetName" runat="server" Width="100%" Font-Names="Open Sans" Font-Size="Small"></asp:TextBox>
                        </div>
                        <div style="float: left; width: 5%; height: 19px;">
                        </div>
                        <div style="float: left; width: 20%; height: 19px;">
                            <asp:Label runat="server" Text="Suburb:" Font-Names="Open Sans" Font-Size="Small" ID="ctl37" Width="100%"></asp:Label>
                        </div>
                        <div style="float: left; width: 35%; height: 19px;">
                            <asp:TextBox ID="txtSuburb" runat="server" Width="100%" Font-Names="Open Sans" Font-Size="Small"></asp:TextBox>
                        </div>
                    </div>
                </div>

            </div>
            <div style="height: 19px; margin-top: 15px;">
                <div style="float: left; width: 30%; height: 19px;">
                    <asp:Label runat="server" Text="City:" Font-Names="Open Sans" Font-Size="Small"></asp:Label>
                </div>

                <div style="float: left; width: 70%; height: 19px;">
                    <div style="float: left; width: 30%; height: 19px;">
                        <asp:TextBox ID="txtCity" runat="server" Width="100%" Font-Names="Open Sans" Font-Size="Small"></asp:TextBox>
                    </div>
                    <div style="float: left; width: 5%; height: 19px;">
                    </div>
                    <div style="float: left; width: 15%; height: 19px;">
                        <asp:Label runat="server" Text="Postal Code:" Font-Names="Open Sans" Font-Size="Small" ID="Label1" Width="100%"></asp:Label>
                    </div>
                    <div style="float: left; width: 10%; height: 19px;">
                        <asp:TextBox ID="txtPostal" runat="server" Width="100%" Font-Names="Open Sans" Font-Size="Small"></asp:TextBox>
                    </div>
                    <div style="float: left; width: 5%; height: 19px;">
                    </div>
                    <div style="float: left; width: 15%; height: 19px;">
                        <asp:Label runat="server" Text="Country:" Font-Names="Open Sans" Font-Size="Small" ID="Label4" Width="100%"></asp:Label>
                    </div>
                    <div style="float: left; width: 20%; height: 19px;">
                        <asp:DropDownList ID="ddlCountry" runat="server" Width="100%" Font-Names="Open Sans" Font-Size="Small">
                        </asp:DropDownList>
                    </div>
                </div>
            </div>

            <div style="height: 25px; margin-top: 15px; margin-right: auto; margin-left: auto; width: 200px;">
                <div style="float: left; width: 30%; height: 23px;">
                    <asp:Button ID="btnAction" runat="server" Text="Add" Width="100%" OnClick="BtnAction_Click" Font-Names="Open Sans" Font-Size="Small" />
                </div>

                <div style="float: left; width: 3%; height: 19px;">
                </div>


                <div style="float: left; width: 30%; height: 24px;">
                    <asp:Button ID="btnClear" runat="server" Text="Clear" Width="100%" Font-Names="Open Sans" Font-Size="Small" OnClick="BtnClear_Click" />
                </div>


                <div style="float: left; width: 3%; height: 19px;">
                </div>

                <div style="float: left; width: 30%; height: 24px;">
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" Width="100%" Font-Names="Open Sans" Font-Size="Small" OnClick="BtnDelete_Click" />
                </div>
            </div>
            <div style="height: 33%; margin-top: 15px; width: 100%;">

                <asp:ListBox ID="lstUnits" runat="server" Height="69%" Width="100%" OnSelectedIndexChanged="LstMembers_SelectedIndexChanged" AutoPostBack="True" Font-Names="Open Sans" Font-Size="Medium" Rows="6"></asp:ListBox>

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
