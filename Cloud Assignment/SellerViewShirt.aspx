<%@ Page Title="" Language="C#" MasterPageFile="~/SyaSyaDesign.Master" AutoEventWireup="true" CodeBehind="SellerViewShirt.aspx.cs" Inherits="Cloud_Assignment.SellerViewShirt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/SellerViewShirt.css" rel="stylesheet" type="text/css" />
    <!--<style type="text/css">
        .DrawID {
            width: 10%;            
        }
        .Name{
            width: 15%;
        }
        .Category{
            width: 10%;
        }
        .Image{
            width: 20%;
        }
        .Quantity{
            width: 8%;
        }
        .Price {
            width: 7%;
        }
        .Edit{
            width: 7%;
        }
        .Delete{
            width: 8%;
        }
        .button{
            border-color: #4D94FF; 
            background-color: white; 
            color: #284E98;
        }
        .datatable{
            margin:0 auto; 
            width:75%; 
            min-height:400px
        }
      
        
    </style>
        -->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="text-align: center;">Manage Item</h1>
    <br />
    <div style="margin:0 auto; width:75%;">
        Manage Item at below list
    </div>
    <div style="text-align: center">
        <asp:Label ID="Label1" runat="server" Text="" style="font-size: x-large;"></asp:Label>   
    </div>
    <div class="datatable">
        <table class="desptable" >
                <tr>
                    <th Class="DrawID">
                        Item ID
                    </th>
                    <th Class="Name"> 
                        Name
                    </th>
                    <th Class="Category"> 
                        Category
                    </th>
                    <th Class="Image">
                        Image
                    </th>
                    <th class="Quantity">
                        Quantity
                    </th>
                    <th Class="Price">
                        Price
                    </th>
                    <th Class="Edit">
                        Edit
                    </th>
                    <th Class="Delete">
                        Delete
                    </th>
                </tr>
             </table>
        <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1" OnItemCommand="DataList1_ItemCommand" CssClass="datatable">
        <ItemTemplate>
            <table class="datalist">
                
                <tr>
                    <td Class="DrawID">
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("DrawID") %>'></asp:Label>
                    </td>
                    <td Class="Name">
                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                    </td>
                    <td Class="Category">
                        <asp:Label ID="Label7" runat="server" Text='<%# Eval("Category") %>'></asp:Label>
                    </td>
                    <td Class="Image">
                        <%--<asp:Image CssClass="width1" ID="Image1" runat="server" ImageUrl='<%# Eval("Image") %>' Height="75px" Width="100px"/>--%>
                        <asp:ImageButton ID="Image1" runat="server" ImageUrl='<%# Eval("Image") %>' Height="75px" Width="100px" CommandName="ClickImage" CommandArgument='<%# Eval("DrawID") %>'/>
                    </td>
                    <td Class="Quantity">
                        <asp:Label ID="Label6" runat="server" Text='<%# Eval("Total") %>'></asp:Label>
                    </td>
                    <td Class="Price">
                        <asp:Label ID="Label5" runat="server" Text='<%# String.Format("{0:0.00}", Eval("Price")) %>'></asp:Label>
                    </td>
                    <td Class="Edit">                        
                        <asp:Button ID="Button1" class="button" runat="server" Text="Edit" CommandName="Edit" CommandArgument='<%# Eval("DrawID") %>'/>
                    </td>
                    <td Class="Delete">
                        <asp:Button ID="Button2" class="button" runat="server" Text="Delete" CommandName="Delete" CommandArgument='<%# Eval("DrawID") %>' />
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>
    </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT Gallery.DrawID, Gallery.Name, Gallery.Description, Gallery.Total, Gallery.Price, Gallery.Image, Gallery.StaffID, Gallery.Category FROM Gallery">
        
    </asp:SqlDataSource>



</asp:Content>
