<%@ Page Title="" Language="C#" MasterPageFile="~/SyaSyaDesign.Master" AutoEventWireup="true" CodeBehind="StaffOrderHistory.aspx.cs" Inherits="Cloud_Assignment.StaffOrderHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="CSS/StaffOrderHistory.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h1 style="text-align: center">Order management</h1><hr/>
    
    <div style="width:90%; margin:0 auto; min-height:400px">
    <table class="table table-bordered" style="width: 100%; background-color: pink; color:black; font-size: 18px; ">
                <tr>
                    <td class ="width1">
                        Order ID
                    </td>
                    <td class ="width1">
                        Name
                    </td>
                    <td class ="width1">
                        Email
                    </td>
                    <td class ="width1">
                        Buying Date
                    </td>
                    <td class ="width1">
                        Delivery Address
                    </td>
                    <td class ="width1">                       
                        Contact No                    
                    </td>
                    <td class ="width1">                                                  
                        Quantity
                    </td>
                    <td class ="width1">                                                  
                        Price
                    </td>
                    <td class ="width1">                                                  
                        Status
                    </td>
                </tr>
            </table>

        <div style=" text-align:center">
            <asp:Label ID="Label10" runat="server" Text="" style="font-size:x-large;"></asp:Label>
        </div>

    <asp:DataList ID="DataList1" runat="server" DataKeyField="OrderID" DataSourceID="SqlDataSource1" Width="100%">
        <ItemTemplate>
            <br />
            <table class="table table-bordered" style="background-color:white; width: 100%; border: 2px solid lightpink;"">
                <tr>
                    <td class ="width2">
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("OrderID") %>'></asp:Label>
                    </td>
                    <td class ="width2">
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("Username") %>'></asp:Label>
                    </td>
                    <td class ="width2">
                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("Email") %>'></asp:Label>
                    </td>
                    <td class ="width2">
                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("Date", "{0:G}") %>'></asp:Label>
                    </td>
                    <td class ="width2">
                        <asp:Label ID="Label5" runat="server" Text='<%# Eval("DeliveryAddress") %>'></asp:Label>
                    </td>
                    <td class ="width2">                       
                        <asp:Label ID="Label6" runat="server" Text='<%# Eval("PhoneNumber") %>'></asp:Label>                       
                    </td>
                    <td class ="width2">                                                  
                        <asp:Label ID="Label7" runat="server" Text='<%# Eval("Quantity") %>'></asp:Label>
                    </td>
                    <td class ="width2">                                                  
                        <asp:Label ID="Label8" runat="server" Text='<%# String.Format("RM {0:0.00}",Eval("Price")) %>'></asp:Label>
                    </td>
                    <td class ="width2">                                                  
                        <asp:Label ID="Label9" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT Customer.Username, Customer.PhoneNumber, Customer.Email, [Order].CustomerID, [Order].Date, OrderDetails.DrawID, OrderDetails.OrderID, OrderDetails.Quantity, OrderDetails.Price, [Order].DeliveryAddress, OrderDetails.Status FROM [Order] INNER JOIN Customer ON [Order].CustomerID = Customer.CustomerID INNER JOIN OrderDetails ON [Order].OrderID = OrderDetails.OrderID">
        <%--<SelectParameters>
            <asp:QueryStringParameter Name="DrawID" QueryStringField="id" />
        </SelectParameters>--%>
    </asp:SqlDataSource>
        <br />
    </div>
</asp:Content>
