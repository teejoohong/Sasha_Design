<%@ Page Title="" Language="C#" MasterPageFile="~/SyaSyaDesign.Master" AutoEventWireup="true" CodeBehind="StaffOrderHistory.aspx.cs" Inherits="Cloud_Assignment.StaffOrderHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style type="text/css">
        .OrderID {
            width: 10%;
        }
        .Name {
            width: 10%;
        }
        .Email {
            width: 20%;
        }
        .Date {
            width: 10%;
        }
        .Address {
            width: 1000px;
        }
        .ContactNo {
            width: 13%;
        }
        .Quantity{
            width:7%;
        }
        .Price {
            width: 7%;
        }
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h1 style="text-align: center">Order management</h1><hr/>
    
    <div style="margin-left: 3%; margin-right: 3%; min-height:400px">
    <table class="table table-bordered" style="width: 100%; background-color: pink">
                <tr>
                    <td class ="OrderID">
                        Order ID
                    </td>
                    <td class ="Name">
                        Name
                    </td>
                    <td class ="Email">
                        Email
                    </td>
                    <td class ="Date">
                        Buying Date
                    </td>
                    <td class ="Address">
                        Delivery Address
                    </td>
                    <td class ="ContactNo">                       
                        Contact No                    
                    </td>
                    <td class ="Quantity">                                                  
                        Quantity
                    </td>
                    <td class ="Price">                                                  
                        Price
                    </td>
                </tr>
            </table>

        <div style=" text-align:center">
            <asp:Label ID="Label3" runat="server" Text="" style="font-size:x-large;"></asp:Label>
        </div>

    <asp:DataList ID="DataList1" runat="server" DataKeyField="OrderID" DataSourceID="SqlDataSource1" CssClass="auto-style1">
        <ItemTemplate>
            <table class="table table-bordered" style="width: 100%; background-color: white">
                <tr>
                    <th class ="OrderID">
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("OrderID") %>'></asp:Label>
                    </th>
                    <th class ="Name">
                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("Username") %>'></asp:Label>
                    </th>
                    <th class ="Email">
                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("Email") %>'></asp:Label>
                    </th>
                    <th class ="Date">
                        <asp:Label ID="Label8" runat="server" Text='<%# Eval("Date", "{0:G}") %>'></asp:Label>
                    </th>
                    <th class ="Address">
                        <asp:Label ID="Label5" runat="server" Text='<%# Eval("DeliveryAddress") %>'></asp:Label>
                    </th>
                    <th class ="ContactNo">                       
                        <asp:Label ID="Label6" runat="server" Text='<%# Eval("PhoneNumber") %>'></asp:Label>                       
                    </th>
                    <th class ="Quantity">                                                  
                        <asp:Label ID="Label7" runat="server" Text='<%# Eval("Quantity") %>'></asp:Label>
                    </th>
                    <th class ="Price">                                                  
                        <asp:Label ID="Label9" runat="server" Text='<%# String.Format("RM {0:0.00}",Eval("Price")) %>'></asp:Label>
                    </th>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>
    </div>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT Customer.Username, Customer.PhoneNumber, Customer.Email, [Order].CustomerID, [Order].Date, OrderDetails.DrawID, OrderDetails.OrderID, OrderDetails.Quantity, OrderDetails.Price, [Order].DeliveryAddress FROM [Order] INNER JOIN Customer ON [Order].CustomerID = Customer.CustomerID INNER JOIN OrderDetails ON [Order].OrderID = OrderDetails.OrderID WHERE (OrderDetails.DrawID = @DrawID)">
        <SelectParameters>
            <asp:QueryStringParameter Name="DrawID" QueryStringField="id" />
        </SelectParameters>
    </asp:SqlDataSource>
    
</asp:Content>
