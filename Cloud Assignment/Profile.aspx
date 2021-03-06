<%@ Page Title="" Language="C#" MasterPageFile="~/SyaSyaDesign.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Cloud_Assignment.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/Profile.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <asp:MultiView ID="MultiView1" runat="server">
         <asp:View ID="profileView" runat="server">
                 <table class="profileTable">
        <tr>
            <th colspan="3"><h1>Profile</h1></th>
        </tr>
        <tr>
            <td class="sideColumn leftCss"  onclick="location.href='Profile.aspx';" >
                <asp:HyperLink ID="linkProfile" runat="server" NavigateUrl="~/Profile.aspx">Profile</asp:HyperLink>
            </td>
            <td class="middleColumn" rowspan="3">

                            <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1" OnItemDataBound="DataList1_ItemDataBound" CssClass="item">
                                <ItemTemplate>

                                    <asp:Image ID="Image1" Width="200"  Height="250" CssClass="profilePic" runat="server" ImageUrl='<%# Eval("ProfilePicture") %>' />
                                    
                                    <br />
                                    <br />

                                </ItemTemplate>

                            </asp:DataList>
                <br /><asp:Label ID="lblUsername" runat="server" Text="" CssClass="lblUsername"></asp:Label><br />
            </td>
            <td class="sideColumn2">
                <span class="lbl" style="font-weight:bold">Email : &nbsp</span><br /><br />
                <asp:Label ID="lblEmail" runat="server" Text="Label" CssClass="lbl"></asp:Label></td>

        </tr>
        <tr>
            <td class="sideColumn leftCss"  onclick="location.href='EditProfile.aspx';">
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/EditProfile.aspx">Edit Profile</asp:HyperLink>
            </td>
            <td class="sideColumn2">
                <span class="lbl" style="font-weight:bold">Address : &nbsp</span><br /><br />
                <asp:Label ID="lblAddress" runat="server" Text="" CssClass="lbl"></asp:Label>
            </td>
            <td class="sideColumn">&nbsp;</td>
        </tr>
        <tr>
            <td class="sideColumn leftCss" onclick="location.href='EditProfilePicture.aspx';">
                 <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/EditProfilePicture.aspx">Edit Profile Picture</asp:HyperLink>
            </td>
            <td class="sideColumn2">
                <span class="lbl" style="font-weight:bold">Contact Number : &nbsp</span><br /><br />
                <asp:Label ID="lblContactNumber" runat="server" Text="" CssClass="lbl"></asp:Label>
            </td>
            <td class="sideColumn">
                
            </td>
        </tr>

        <tr>
            <td class="sideColumn ">
                
            </td>
            <td class="middleColumn" style="text-align:center">
                
                
            </td>
            <td class="sideColumn">&nbsp;</td>
        </tr>
    </table>
             </asp:View>

          <asp:View ID="loginView" runat="server">
              <table id="loginForm" class="inputForm">
                <tr>
                    <th colspan="2"><h2>Profile</h2></th>
                </tr>
                <tr>
                    <td colspan="2">&nbsp;</td>
                </tr>
                <tr style="text-align:center">
                    <td colspan="2">
                        <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="buttonLogin" OnClick="btnLogin_Click"/>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">&nbsp;</td>
                </tr>
                <tr style="text-align:center">
                    <td colspan="2">
                        <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="buttonLogin" OnClick="btnRegister_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">&nbsp;</td>
                </tr>
            </table>
          </asp:View>
    </asp:MultiView>
                 <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>">
                         <SelectParameters>
                             <asp:SessionParameter Name="StaffID" SessionField="Value" />
                             <asp:SessionParameter Name="CustomerID" SessionField="Value" />
                        </SelectParameters>
                            </asp:SqlDataSource>
</asp:Content>
