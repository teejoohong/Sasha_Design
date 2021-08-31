<%@ Page Title="" Language="C#" MasterPageFile="~/SyaSyaDesign.Master" AutoEventWireup="true" CodeBehind="SellerViewShirt.aspx.cs" Inherits="Cloud_Assignment.SellerViewShirt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/OrderHistory.css" rel="stylesheet" type="text/css" />
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

    <div >
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>   
    </div>
    <div  style="width:75%; margin:0 auto; min-height:400px">
        <table class="tableTitle " >
                <tr>
                    <th class="width2">
                        Item ID
                    </th>
                    <th class="width2"> 
                        Name
                    </th>
                    <th class="width2"> 
                        Category
                    </th>
                    <th class="width2">
                        Image
                    </th>
                    <th class="width2">
                        Quantity
                    </th>
                    <th  class="width2">
                        Price
                    </th>
                    <th  class="width2">
                        Edit
                    </th>
                    <th  class="width2">
                        Delete
                    </th>
                </tr>
             </table>
            <div >
        Manage Item at below list
    </div>
        <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1" Height="16px" Width="100%" OnItemCommand="DataList1_ItemCommand">
        <ItemTemplate>
            <table class="table table-bordered" style="background-color:white; width: 100%; border: 2px solid lightpink;">
                
                <tr>
                    <td class="width2">
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("DrawID") %>'></asp:Label>
                    </td>
                    <td class="width2">
                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                    </td>
                    <td class="width2">
                        <asp:Label ID="Label7" runat="server" Text='<%# Eval("Category") %>'></asp:Label>
                    </td>
                    <td class="width2">
                        <%--<asp:Image CssClass="width2" ID="Image1" runat="server" ImageUrl='<%# Eval("Image") %>' Height="75px" Width="100px"/>--%>
                        <asp:ImageButton ID="Image1" runat="server" ImageUrl='<%# Eval("Image") %>' Height="75px" Width="100px" CommandName="ClickImage" CommandArgument='<%# Eval("DrawID") %>'/>
                    </td>
                    <td class="width2">
                        <asp:Label ID="Label6" runat="server" Text='<%# Eval("Total") %>'></asp:Label>
                    </td>
                    <td class="width2">
                        <asp:Label ID="Label5" runat="server" Text='<%# String.Format("{0:0.00}", Eval("Price")) %>'></asp:Label>
                    </td>
                    <td class="width2">                        
                        <asp:Button ID="Button1" class="button" runat="server" Text="Edit" CommandName="Edit" CommandArgument='<%# Eval("DrawID") %>'/>
                    </td>
                    <td class="width2">
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
