<%@ Page Title="" Language="C#" MasterPageFile="~/SyaSyaDesign.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Cloud_Assignment.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/Register.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<%--                <asp:View ID="View1" runat="server">

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
                        <asp:Button ID="btnArtist" runat="server" Text="Staff" CssClass="btnView" OnClick="btnArtist_Click"   />
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
                        <asp:Button ID="btnCustomer" runat="server" CssClass="btnView" Text="Customer" OnClick="btnCustomer_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="btnType">&nbsp;</td>
                </tr>
                <tr>
                    <td class="btnType">Already have an account?  <a href="SignIn.aspx">Sign In</a></td>
                   
                </tr>
                <tr>
                    <td class="btnType">&nbsp;</td>
                </tr>
            </table>
        </asp:View>--%>


               <link href="CSS/Register.css" rel="stylesheet" type="text/css" />
    <table class="registerTable" style="width: 50%; margin: 50px auto 100px auto; border:2px solid lightpink;">
        <tr style="background-color:lightpink; color:black; text-align:center; height: 80px;font-size:18px;">
            <td  colspan="2"><h2>Register</h2> 
            </td>

        </tr>
        <tr><td style="text-align:center" colspan="2"><asp:Label ID="lblSignUp" runat="server" ForeColor="black"></asp:Label>&nbsp;</td></tr>
       <tr class="rowInput">
            <td class="text" >Username :</td>
            <td class="rowInput">
                <asp:TextBox id="txtUsername" runat="server" CssClass="inputBox"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Username Required" ControlToValidate="txtUsername" Font-Size="Small" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
            </td>
        </tr>
                <tr class="rowInput">
            <td class="text">Email &nbsp:</td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server" Cssclass="form inputBox" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="emailRequired" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email can not be empty." Font-Size="Small" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                
                
            </td>
        </tr>
        <tr style="text-align:center">
            <td colspan="2"><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="Please enter a valid email address" Font-Size="Small" ForeColor="Red" ValidationExpression="^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" SetFocusOnError="True"></asp:RegularExpressionValidator></td>
        </tr>
          
        <tr class="rowInput">
            <td class="text">Password &nbsp:</td>
            <td class="rowInput">
                <asp:TextBox id="txtPassword" TextMode="Password" runat="server" CssClass="inputBox" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Password Required" ControlToValidate="txtPassword" Font-Size="Small" ForeColor="Red" SetFocusOnError="True" ></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr class="rowInput">
            <td class="text">Confirm Password &nbsp:</td>
            <td>
                <asp:TextBox id="txtConfirmPassword" TextMode="Password" runat="server" CssClass="inputBox"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Confirm Password Required" ControlToValidate="txtConfirmPassword" Font-Size="Small" ForeColor="Red" SetFocusOnError="True" ></asp:RequiredFieldValidator><br />
                  
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align:center"><asp:CompareValidator ID="comparePass" runat="server" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword" ErrorMessage="Password miss-match, please re-enter the password" Font-Size="Small" ForeColor="Red" Operator="Equal" SetFocusOnError="True"></asp:CompareValidator></td>

        </tr>
        <tr >
            <td  colspan="2" class="rowButtonLogin">
                <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="buttonLogin" OnClick="btnRegister_Click" />
                
            </td>
        </tr>
       
        <tr >
            <td  colspan="2" class="rowButtonLogin">
               <asp:Label ID="lblDuplicate" runat="server" Font-Size="Small" ForeColor="Red" Text=""></asp:Label></td>
        </tr>
       
        <tr class="rowLink">
            <td>
                <asp:HyperLink ID="linkLogIn" runat="server" NavigateUrl="~/LogIn.aspx">Log In</asp:HyperLink>
            </td>
            <td class="linkForgetPassword" >
                <a href="ForgetPassword.aspx?view=0">Forget Password</a>
            </td>
        </tr>
    </table>



</asp:Content>
