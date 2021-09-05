<%@ Page Title="" Language="C#" MasterPageFile="~/SyaSyaDesign.Master" AutoEventWireup="true" CodeBehind="Gallery.aspx.cs" Inherits="Cloud_Assignment.Gallery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <link href="CSS/Gallery.css" rel="stylesheet" type="text/css" />

            <div class="container">
            <asp:LinkButton ID="ShowAll" runat="server" OnClick="ShowAll_Click" CssClass="linkBtn">Show All</asp:LinkButton><br />
            <asp:LinkButton ID="DrawingFilter" runat="server" OnClick="LinkButton1_Click" CssClass="linkBtn">T-shirt</asp:LinkButton><br />
            <asp:LinkButton ID="SculptureFilter" runat="server" OnClick="SculptureFilter_Click" CssClass="linkBtn">Dress</asp:LinkButton><br />
            <asp:LinkButton ID="Painting" runat="server" OnClick="Painting_Click" CssClass="linkBtn">Sport</asp:LinkButton>
            </div>
    <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Center" CssClass="dataList">
         <asp:DataList ID="DataList1" runat="server" DataKeyField="DrawID" DataSourceID="SqlDataSource1" CellPadding="20" RepeatColumns="4" RepeatDirection="Horizontal" OnItemCommand="DataList1_ItemCommand"  AllowPaging="true" PageSize ="2">
            <ItemTemplate>
                  
                    <asp:Image ID="Image1" CssClass="Img" runat="server" ImageUrl='<%# Eval("Image") %>' />
                            
                    <div class="frame" >
                    <a style="margin-left: 10px">Name:</a><asp:Label ID="Label3" runat="server" Text='<%# Eval("Name") %>' ></asp:Label>
                    <br />
                    <a style="margin-left: 10px">Description:</a><asp:Label ID="Label1" runat="server" Text='<%# Eval("Description") %>'></asp:Label>
                    <br/>
                    <a style="margin-left: 10px">Price: RM</a><asp:Label ID="Label2" runat="server"  Text='<%# String.Format("{0:0.00}",Eval("Price")) %>'></asp:Label>
                    <br />
                    <a style="margin-left: 10px">Quantity: </a><asp:Label ID="Label4" runat="server"  Text='<%#Eval("Total") %>'></asp:Label>
                    <br/><br />
                           
                    <asp:Button CssClass="Button" ID="Button1" runat="server" Text="Add to cart" CommandName="AddToCart" CommandArgument='<%# Eval("DrawID") %>'/>&nbsp<br /> <br />
                    <asp:Button CssClass="Button" ID="Button15" runat="server" Text="Add to Wishlist" CommandName="Wishlist" CommandArgument='<%# Eval("DrawID") %>'/>
                    <br />
                    </div>
                </ItemTemplate>
        </asp:DataList>

    </asp:Panel>
       
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Gallery]"></asp:SqlDataSource>

  

</asp:Content>