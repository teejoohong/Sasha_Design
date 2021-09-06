<%@ Page Title="" Language="C#" MasterPageFile="~/SyaSyaDesign.Master" AutoEventWireup="true" CodeBehind="SellerUploadShirt.aspx.cs" Inherits="Cloud_Assignment.SellerUploadShirt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/SellerUploadShirt.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h2 style="text-align:center">Clothing Selling</h2><hr />
    <div style="width:75%; margin:0 auto; min-height:410px">
            <style type="text/css">

        .auto-style2 {
            height: 29px;
            width: 118px;
        }
        .auto-style3 {
            width: 279px;
        }
        .auto-style4 {
            height: 29px;
            width: 279px;
        }
        .auto-style5 {
            height: 24px;
            width: 118px;
            font-weight:bold;
        }
        .auto-style6 {
            width: 279px;
            height: 24px;
        }
        .auto-style7 {
            width: 118px;
            margin-left:10px;

        }
        .auto-style8 {
            border-collapse: collapse;            
            height: auto;
            width: 873px;
            background-color: lightgray;
            margin-bottom : 1%;
            height: 300px;
        }
        .button{
            border-color: #4D94FF; 
            background-color: white; 
            color: #284E98;"
        }
    </style>

     <% if (Session["Value"] == "0" || Session["Value"] == null || Session["Bar"] == "C")
          { %>
             <p>Please <a href="LogIn.aspx" > log in</a> as seller before accessing this page.</p>
             <p>OR<a href="Register.aspx" > register</a> as seller before accessing this page.</p>
      <%}
          else{ %>
            <h1 style="text-align:center;">Post Art</h1><hr />   
            
            <h1>Welcome to Syasya Design Clothing Gallery , select upload to post the clothing</h1>
            
            <br />
                
    <table class ="auto-style8">

        <tr>
            <td class="auto-style5">Clothing Details</td>
            <td class="auto-style6">
                </td>
        </tr>   

        <tr>
            <td class="auto-style7">Clothing name : </td>
            <td class="auto-style3">
                <asp:TextBox ID="ArtName" runat="server" Width="267px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*This field is required." SetFocusOnError="True" ControlToValidate="ArtName" ForeColor="Red" ValidationGroup="postArt"></asp:RequiredFieldValidator>
            </td>
        </tr>   

        <tr>
            <td class="auto-style7">
                Clothing Description :
            </td>
            <td class="auto-style3">
                <asp:TextBox runat="server" ID="ArtDescription" TextMode="Multiline" Columns="20" Name="S1" Rows="2" Height="95px" Width="591px" style="resize:none;"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*This field is required." SetFocusOnError="True" ControlToValidate="ArtDescription" ForeColor="Red" ValidationGroup="postArt"></asp:RequiredFieldValidator>
            </td>
        </tr>

        <tr>
            <td class="auto-style7">
                Price :
            </td>
            <td class="auto-style3">
                <asp:TextBox ID="Price" runat="server" Width="265px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*This field id required." ControlToValidate="Price" SetFocusOnError="True" ForeColor="Red" ValidationGroup="postArt"></asp:RequiredFieldValidator>
                <br />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Please Enter Your Correct Product Price" ControlToValidate="Price" ValidationExpression="^\d{0,8}(\.\d{1,2})?$" SetFocusOnError="True" ForeColor="Red" ValidationGroup="postArt"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>Category :</td>
            <td>
                <asp:DropDownList ID="CategoryList" runat="server">
                    <asp:ListItem>T-shirt</asp:ListItem>
                    <asp:ListItem>Dress</asp:ListItem>
                    <asp:ListItem>Sport</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td class="auto-style2">
                Total Clothing :
            </td>
            <td class="auto-style4">
                <asp:TextBox ID="TotalArt" runat="server"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td class="auto-style7">Clothing Image :</td>
            <td class="auto-style3">
                <asp:FileUpload ID="Picture" runat="server" accept="image/*" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*This field id required." ControlToValidate="Picture" SetFocusOnError="True" ForeColor="Red" ValidationGroup="postArt"></asp:RequiredFieldValidator>
                </td>
        </tr>

        <tr>
            <td class="auto-style7">&nbsp;</td>
            <td class="auto-style3">
                &nbsp;</td>
        </tr>

        <tr>
            <td class="auto-style7" style="text-align:center">
         <asp:Button ID="Cancel" class="btnView" runat="server" Text="Cancel" Width="140px" OnClick="Cancel_Click"  />
            </td>
            <td class="auto-style3">
        <asp:Button ID="Submit" class="btnView" runat="server" Text="Submit" OnClick="Submit_Click" Width="139px" ValidationGroup="postArt"/>
                
            </td>        
        </tr>       
        <tr>
            <td>
            <br/>
            </td>
            <td>
            <br/>
            </td>
        </tr>

        </table>
     
        
          <%} %>
    <br />
            &nbsp;
    <div >
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </div>
    </div>
</asp:Content>
