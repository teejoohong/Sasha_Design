<%@ Page Title="" Language="C#" MasterPageFile="~/SyaSyaDesign.Master" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="Cloud_Assignment.LogIn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/LogIn.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:MultiView ID="SignInMultiView" runat="server">
        <asp:View ID="View1" runat="server">

            <table class="viewChoose">
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="btnType">
                        <asp:Button ID="btnCustomer" runat="server" CssClass="btnView" Text="Customer" OnClick="btnCustomer_Click" />
                        
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">
                       </td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                </tr>
                <tr>
                    <td class="btnType">
                        <asp:Button ID="btnStaff" runat="server" Text="Staff" CssClass="btnView" OnClick="btnStaff_Click"  />
                    </td>
                </tr>
                <tr>
                    <td class="btnType">&nbsp;</td>
                </tr>
                <tr>
                    <td class="btnType">Don't have an account?  <a href="Register.aspx">Register</a></td>
                   
                </tr>
                <tr>
                    <td class="btnType">&nbsp;</td>
                </tr>
            </table>
        </asp:View>

        <asp:View ID="View2" runat="server">

    <table class="loginTable" >
        <tr class="loginTitle">
            <td colspan="2"><h2>Login</h2></td>
        </tr>
        <tr style="text-align:center"><td colspan="2"><asp:Label ID="lblSignIn" runat="server" ForeColor="black"></asp:Label>&nbsp;</td></tr>
        <tr>
            <td colspan="2" style="text-align:center">
                <img alt="person" src="BuildInPictures/baseline_person_black_48dp.png" style="width:20%;height:140px; margin-top:5px"/></td>
        </tr>
        <tr class="rowInput">
            <td class="text">Username :</td>
            <td class="rowInput">
                <asp:TextBox id="txtUsername" runat="server" CssClass="inputBox"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Username Required" ControlToValidate="txtUsername" Font-Size="Small" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr class="rowInput">
            <td class="text">Password &nbsp:</td>
            <td>
                <asp:TextBox id="txtPassword" runat="server" TextMode="Password" CssClass="inputBox"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Password Required" ControlToValidate="txtPassword" Font-Size="Small" ForeColor="Red" SetFocusOnError="True" ></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr >
            <td  colspan="2" class="rowButtonLogin">
                <asp:Button ID="btnLogin" runat="server" Text="Log in" CssClass="buttonLogin" OnClick="btnLogin_Click" />

            </td>
        </tr>
        <tr class="rowLink">
            <td>
                <asp:CheckBox ID="chkBoxRememberMe" Text="Remember Me" runat="server" />
            </td>
            <td>
                <asp:Label ID="lblError" runat="server" Font-Size="Small" ForeColor="red" Text="" ></asp:Label>
                </td>
        </tr>
        <tr class="rowLink">
            <td>
                <asp:HyperLink ID="linkRegister" runat="server" NavigateUrl="~/Register.aspx">Register</asp:HyperLink>
            </td>
            <td class="linkForgetPassword" >
                <a href="ForgetPassword.aspx?view=0">Forget Password</a>
            </td>
        </tr>
    </table>
        </asp:View>
    </asp:MultiView>


</asp:Content>
