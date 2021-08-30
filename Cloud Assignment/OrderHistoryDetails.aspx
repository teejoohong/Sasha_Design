<%@ Page Title="" Language="C#" MasterPageFile="~/SyaSyaDesign.Master" AutoEventWireup="true" CodeBehind="OrderHistoryDetails.aspx.cs" Inherits="Cloud_Assignment.OrderHistoryDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/OrderHistoryDetails.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="text-align:center">Details</h1><hr />
    <div style="margin-left: 8%; margin-right: 8%;">
     <table class="table table-bordered" style="width: 100%; background-color: pink">
                <tr>
                    <th class="title">
                        DrawID
                    </th>

                    <th class="title">
                        OrderID
                    </th>

                    <th class="title">
                        Quantity
                    </th>
                    <th class="title">
                        Price
                    </th>
                    <th class="title">
                        Name
                    </th>
                    <th class="title">
                        Image
                    </th>
                    <th class="title">
                        Status
                    </th>
                </tr>
        </table>

    <asp:DataList ID="DataList1" runat="server" CssStyle="Display : flex"  DataSourceID="SqlDataSource1" Width="100%">
        <ItemTemplate>
            <table class="table table-bordered" style="width: 100%; background-color: white">
            <tr>
            <td class="width1">
            <asp:Label ID="DrawIDLabel" CssClass="title" runat="server" Text='<%# Eval("DrawID") %>' />
            </td>
            <td class="width1">
            <asp:Label ID="OrderIDLabel" runat="server" Text='<%# Eval("OrderID") %>' />
            </td>
            <td class="width1" >
            <asp:Label ID="QuantityLabel" runat="server" Text='<%# Eval("Quantity") %>' />
            </td>
            <td class="width1">
            <asp:Label ID="PriceLabel" runat="server" Text='<%# String.Format("RM {0:0.00}",Eval("Price")) %>' />
            </td>
            <td class="width1">
            <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
            </td>
            <td class="width1">
            <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("Image") %>'  Height="100px" Width="100px"/>
            </td>
            <td class="width1">
            <asp:Label ID="StatusLabel" runat="server" Text='<%# Eval("Status") %>' />
            </td>
            </tr> 
            </table>
            <br />
            <br />
        </ItemTemplate>
    </asp:DataList>
    </div>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT Gallery.DrawID, OrderDetails.OrderID, OrderDetails.[Quantity], OrderDetails.Price, Gallery.Name, Gallery.Image, OrderDetails.Status FROM Gallery INNER JOIN OrderDetails ON Gallery.DrawID = OrderDetails.DrawID WHERE (OrderDetails.OrderID = @OrderID)">
        <SelectParameters>
            <asp:QueryStringParameter Name="OrderID" QueryStringField="id" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
