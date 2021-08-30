<%@ Page Title="" Language="C#" MasterPageFile="~/SyaSyaDesign.Master" AutoEventWireup="true" CodeBehind="OrderHistory.aspx.cs" Inherits="Cloud_Assignment.OrderHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/OrderHistory.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="text-align:center">Order History</h1><hr />
    <% if (Session["Value"] == "0" || Session["Value"] == null)
          { %>
        <div style="height:400px">
            <table class="tableFormat">
                <tr>
                    <td class="auto-style">
                        <p style="text-align:center; font-size:x-large">Please log in to view your order history.</p>
                     </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                            &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">
                          
                            <asp:Button ID="btnSignIn" runat="server" Text="Sign In"  CssClass="buttonLogin" OnClick="btnSignIn_Click"/>
                
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                           &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">
                           &nbsp;</td>
                </tr>
               
            </table>
            </div>

     <%}
         else{ %>
    <div style="width:75%; margin:0 auto; min-height:400px">
    <table class="tableTitle ">
                <tr>
                    <th class="width1">
                        Order ID
                    </th>
                    <th class="width1">
                        Delivery Address
                    </th>
                    <th class="width1">
                        Date
                    </th>
                    
                    <th class="width1">
                        Price
                    </th>
                    <th class="width1">
                        Detail
                    </th>
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
