<%@ Page Title="" Language="C#" MasterPageFile="~/SyaSyaDesign.Master" AutoEventWireup="true" CodeBehind="Wishlist.aspx.cs" Inherits="Cloud_Assignment.Wishlist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/OrderHistory.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        .auto-style {
            width: 100%;
            background-color: pink;
        }

        .auto-style1 {
            text-align: center;
            background-color: white;
        }
        .buttonLogin {
            background-color: white;
            color: black;
            width: 26%;
            height: 30px;
            font-size: 12px;
            border: 2px solid lightpink;
        }

        .buttonLogin:hover {
            cursor: pointer;
            background-color: lightpink;
        }
        .width1 {
            width: 15.8%;
            padding : 5%;
            
        }
        .tableFormat {
            border-collapse: collapse;
            border: 5px solid lightpink;
            height: auto;
            width :700px;
            margin-left: auto;
            margin-right: auto;
            margin-bottom:200px;
            margin-top:100px;
            background-color: lightgray;
        }
        .auto-style2 {
            width: 16%;
            height: 38px;
            background-color : darkgray;
            padding:5%;
        }

        .auto-style3 {
            height: 29px;
        }
    </style>

     <% if (Session["Value"] == "0" || Session["Value"] == null)
          { %>
               <div >
             <table id="loginForm" class="inputForm">
                <tr>
                    <th colspan="2"><h2>Wishlist</h2></th>
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
            </div>

     <%}
          else{ %>
    <div style="width:75%; margin:0 auto; min-height:400px">
    <table class="tableTitle ">
                <tr>      

                    <td class="width2">
                        Name
                    </td>

                    <td class="width2">
                        Image
                    </td>
                    <td class="width2">
                        Description
                    </td>
                    <td class="width2">
                        Price
                    </td>
                    <td class="width2">
                        Delete
                    </td>
                </tr>
            </table>
    <div style=" text-align:center">
        <asp:Label ID="Label3" runat="server" Text="" style="font-size:x-large;"></asp:Label>
    </div>
    
        <asp:DataList ID="DataList1" runat="server" DataKeyField="CustomerID" DataSourceID="SqlDataSource1" OnItemCommand="DataList1_ItemCommand" Height="16px" Width="100%">
            <ItemTemplate>
                <br />
                <table class="table table-bordered" style="width: 100%; background-color: white; border: 2px solid lightpink;">
                    <tr>
                        
                        <td class="width2">
                            
                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                        </td>
                        <td class="width2">
                            
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("Image") %>' Height="100px" Width="100px" />
                        </td>
                        <td class="width2">
                            
                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("Description") %>'></asp:Label>
                        </td>
                        <td class="width2">
                            
                            <asp:Label ID="Label4" runat="server" Text='<%# String.Format("RM {0:0.00}",Eval("Price")) %>'></asp:Label>
                        </td>
                        <td class="width2">
                            <asp:Button ID="Button1" runat="server" CssClass="btnDelete" Text="Delete" CommandName="Delete" CommandArgument='<%# Eval("DrawID") %>'/>
                        </td>
                    </tr>
                </table>

            </ItemTemplate>
        </asp:DataList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT Gallery.Name, Gallery.Price, Gallery.Description, WishlistGallery.CustomerID, WishlistGallery.DrawID, Gallery.Image FROM WishlistGallery INNER JOIN Gallery ON WishlistGallery.DrawID = Gallery.DrawID WHERE (WishlistGallery.CustomerID = @CustomerID)">
            <SelectParameters>
                <asp:SessionParameter Name="CustomerID" SessionField="Value" />
            </SelectParameters>
        </asp:SqlDataSource>
    <br />
    </div>
    <%} %>
</asp:Content>
