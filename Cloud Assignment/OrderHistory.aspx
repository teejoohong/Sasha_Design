<%@ Page Title="" Language="C#" MasterPageFile="~/SyaSyaDesign.Master" AutoEventWireup="true" CodeBehind="OrderHistory.aspx.cs" Inherits="Cloud_Assignment.OrderHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/OrderHistory.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <% if (Session["Value"] == "0" || Session["Value"] == null)
          { %>
                 <div ID="loginView">
              <table id="loginForm" class="inputForm">
                <tr>
                    <th colspan="2"><h2>Order History</h2></th>
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
                        <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="buttonLogin" OnClick="btnRegister_Click"  />
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
                    <td class="width1">
                        Order ID
                    </td>
                    <td class="width1">
                        Delivery Address
                    </td>
                    <td class="width1">
                        Date
                    </td>
                    
                    <td class="width1">
                        Price
                    </td>
                    <td class="width1">
                        Detail
                    </td>
                </tr>
    </table>
    <div style=" text-align:center">
        <asp:Label ID="Label3" runat="server" Text="" style="font-size:x-large;"></asp:Label>

    </div>
    <asp:DataList runat="server" DataKeyField="OrderID" DataSourceID="SqlDataSource1" Height="16px" Width="100%" OnItemCommand="Unnamed_ItemCommand">
        <ItemTemplate>     
            <br/>
            <table class="table table-bordered" style="background-color:white; width: 100%; border: 2px solid lightpink;">
                <tr>
                    <td class="width1">
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("OrderID") %>'></asp:Label>
                    </td>
                    <td class="width1">
                        <asp:Label ID="Label5" runat="server" Text='<%# Eval("DeliveryAddress") %>'></asp:Label>
                    </td>
                    <td class="width1">
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("Date") %>'></asp:Label>
                    </td>
                    <td class="width1">
                        <asp:Label ID="Label4" runat="server" Text='<%# String.Format("RM {0:0.00}",Eval("TotalPrice")) %>'></asp:Label>
                    </td>

                    <td class="width1">
                        <asp:Button ID="btnDetails" CssClass="btnView" runat="server" Text="View Details" CommandName="ViewDetails" CommandArgument='<%# Eval("OrderID") %>'/>
                    </td>
                </tr>
            </table>    
        
        </ItemTemplate>

    </asp:DataList>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Order] WHERE ([CustomerID] = @CustomerID) ORDER BY Date DESC">
        <SelectParameters>
            <asp:SessionParameter Name="CustomerID" SessionField="Value" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
        <br/>
     </div>
     <%} %>
</asp:Content>
