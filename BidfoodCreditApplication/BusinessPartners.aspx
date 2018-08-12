<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BusinessPartners.aspx.cs" Inherits="BidfoodCreditApplication.BusinessPartners" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<form id="BusinessPartners" runat="server">
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
            Business Members
        </div>
        <div id="centeredDiv" style="width: 60%; margin: auto; text-align: left; height: 334px;">
            <div style="height: 19px">
                <div style="float: left; width: 30%; height: 19px;">
                    <asp:Label runat="server" Text="Name:" Font-Names="Open Sans" Font-Size="Small"></asp:Label>
                </div>
                <div style="float: left; width: 70%">
                    <asp:TextBox ID="txtName" runat="server" Width="100%" Font-Names="Open Sans" Font-Size="Small"></asp:TextBox>
                </div>
            </div>
            <div style="height: 19px; margin-top: 15px;">
                <div style="float: left; width: 30%; height: 19px;">
                    <asp:Label runat="server" Text="Home Physical Address:" Font-Names="Open Sans" Font-Size="Small"></asp:Label>
                </div>
                <div style="float: left; width: 70%">
                    <asp:TextBox ID="txtAddress" runat="server" Width="100%" Font-Names="Open Sans" Font-Size="Small"></asp:TextBox>
                </div>
            </div>
            <div style="height: 19px; margin-top: 15px;">
                <div style="float: left; width: 30%; height: 19px;">
                    <asp:Label runat="server" Text="ID Type:" Font-Names="Open Sans" Font-Size="Small"></asp:Label>
                </div>

                <div style="float: left; width: 70%">
                    <div>
                        <div style="float: left; width: 30%; height: 19px;">
                            <asp:DropDownList ID="ddlIdType" runat="server" Width="100%" Height="19px" Font-Names="Open Sans" Font-Size="Small" OnSelectedIndexChanged="ddlIdType_SelectedIndexChanged" AutoPostBack="True">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem>SA ID</asp:ListItem>
                                <asp:ListItem>Passport</asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <div style="float: left; width: 5%; height: 19px;">
                        </div>
                        <div style="float: left; width: 30%; height: 19px;">
                            <asp:Label runat="server" Font-Names="Open Sans" Font-Size="Small" ID="lblIDType" Width="100%"></asp:Label>
                        </div>
                        <div style="float: left; width: 35%; height: 19px;">
                            <asp:TextBox ID="txtID" runat="server" Width="100%" Font-Names="Open Sans" Font-Size="Small"></asp:TextBox>
                        </div>

                    </div>
                </div>

            </div>
            <div style="height: 19px; margin-top: 15px;">
                <div style="float: left; width: 30%; height: 19px;">
                    <asp:Label runat="server" Text="Tel No:" Font-Names="Open Sans" Font-Size="Small"></asp:Label>
                </div>

                <div style="float: left; width: 70%; height: 19px;">
                    <div>
                        <div style="float: left; width: 30%; height: 19px;">
                            <asp:TextBox ID="txtTel" runat="server" Width="100%" Font-Names="Open Sans" Font-Size="Small"></asp:TextBox>
                        </div>
                        <div style="float: left; width: 5%; height: 19px;">
                        </div>
                        <div style="float: left; width: 50%; height: 19px;">
                            <asp:Label runat="server" Text="Married in/Out Communinity of Property" Font-Names="Open Sans" Font-Size="Small" ID="Label1"></asp:Label>
                        </div>
                        <div style="float: left; width: 15%; height: 19px;">
                            <asp:DropDownList ID="ddlCommunityOfProperty" runat="server" Width="100%" Height="19px" Font-Names="Open Sans" Font-Size="Small">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem>No</asp:ListItem>
                                <asp:ListItem>Yes</asp:ListItem>
                            </asp:DropDownList>
                        </div>
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
            <div>
                
                <div style="height: 33%; width: 100%; margin-top: 10px;">
                    <asp:ListBox ID="lstMembers" runat="server" Height="103px" Width="100%" OnSelectedIndexChanged="LstMembers_SelectedIndexChanged" AutoPostBack="True" Font-Names="Open Sans" Font-Size="Medium" Rows="3"></asp:ListBox>
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
