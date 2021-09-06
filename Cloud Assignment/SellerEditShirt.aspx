<%@ Page Title="" Language="C#" MasterPageFile="~/SyaSyaDesign.Master" AutoEventWireup="true" CodeBehind="SellerEditShirt.aspx.cs" Inherits="Cloud_Assignment.SellerEditShirt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/StaffEditShirt.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="text-align:center;">Edit Clothing</h1>
    <br />
    <div style="text-align: center">
        Edit the details of the clothing posted in the website.
    </div>
    <br />
    <div style="width:600px; margin-left: auto; margin-right: auto; height:400px">
        <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1" OnItemCommand="DataList1_ItemCommand" Width="280px" >
            <ItemTemplate>
                <table style="width: 100%;">
                    <tr>
                        <td>
                            Image:
                        </td>
                        <td>
                            
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Image ID="Image1" runat="server" Width="100px" Height="75px" ImageUrl='<%# Eval("Image") %>' />
                        </td>
                        <td >
                            <asp:Button ID="Button1" class="btnView" runat="server" Text="Confirm" CommandName="ConfirmEdit" CommandArgument='<%# Eval("DrawID") %>' ValidationGroup="valid1"/>
                        </td>
                        <td>
                            <asp:Button ID="Button2" class="btnView" runat="server" Text="Cancel" CommandName="CancelEdit" />
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:DataList>
        <br />
        <table>
            <tr>
                <td>
                    Name:
                </td>
                <td>
                    Description:
                </td>
                <td>
                    Quantity:
                </td>
                <td>
                    Price:
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="NameTxt" runat="server" ValidationGroup="valid1"></asp:TextBox>
                <td>
                    <asp:TextBox ID="DescriptionTxt" runat="server" ValidationGroup="valid1"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="QuantityTxt" runat="server" ValidationGroup="valid1"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="PriceTxt" runat="server" ValidationGroup="valid1"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*This field is required." ControlToValidate="NameTxt" SetFocusOnError="True" ForeColor="Red" Font-Size="Small" ValidationGroup="valid1"></asp:RequiredFieldValidator>
                    <br />
                    <br />
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*This field is required." ControlToValidate="DescriptionTxt" SetFocusOnError="True" ForeColor="Red" Font-Size="Small" ValidationGroup="valid1"></asp:RequiredFieldValidator>
                    <br />
                    <br />
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*This field is required." ControlToValidate="QuantityTxt" SetFocusOnError="true" ForeColor="Red" Font-Size="Small" ValidationGroup="valid1"></asp:RequiredFieldValidator>
                    <br />
                    <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Insert between 0-10." ControlToValidate="QuantityTxt" MaximumValue="300" MinimumValue="0" Type="Integer" SetFocusOnError="true" ForeColor="Red" Font-Size="Small" ValidationGroup="valid1"></asp:RangeValidator>
                </td>
                <td>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*This field is required." ControlToValidate="PriceTxt" SetFocusOnError="True" ForeColor="Red" Font-Size="Small" ValidationGroup="valid1"></asp:RequiredFieldValidator>
                    <br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*Please Enter Your Correct Product Price" ControlToValidate="PriceTxt" ValidationExpression="^\d{0,8}(\.\d{1,2})?$" SetFocusOnError="True" ForeColor="Red" Font-Size="Small" ValidationGroup="valid1"></asp:RegularExpressionValidator>
                </td>
            </tr>
        </table>
    </div>
    <br/>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT Gallery.* FROM Gallery WHERE (Gallery.DrawID=@DrawID)" >
        <SelectParameters>
            <asp:QueryStringParameter Name="DrawID" QueryStringField="id" Type="String"/>
        </SelectParameters>
    </asp:SqlDataSource>

</asp:Content>
