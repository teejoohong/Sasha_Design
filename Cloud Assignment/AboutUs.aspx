<%@ Page Title="" Language="C#" MasterPageFile="~/SyaSyaDesign.Master" AutoEventWireup="true" CodeBehind="AboutUs.aspx.cs" Inherits="Cloud_Assignment.AboutUs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <!--CSS -->
    <link href="CSS/AboutUs.css" rel="stylesheet" type="text/css" />
    <h1 style="text-align:center">About Us</h1> <br />
    <p class="imgLogo"> <asp:Image ID="Image1" runat="server" ImageUrl="~/BuildInPictures/logoSya.png" AlternateText="Smart Personal Scheduler" Height="200px" Width="500px" /></p>
    <div class="aboutUs">
       
        
        <article><br />
 
            <p>SyasyaDesign is an online shop that provding plus size apparel for woman.
            </p>
            <p>
                We aimed to assist users in changing from the suffer of finding suitable 
                clothing from various of clothing in the market. 
                Each woman should have their own choice of their wear and use!
            </p>
            <p> Try it out now! Demostration of clothing is also available to let
                you have a look before you purchase!
            </p><br /><br /><br /><br /><br />
           
        </article>
    </div>

  <div class="row">
      <div class="column">
        <h2>Contacts</h2>
        <hr />
        <p>+6018-319 9792 (TEE)</p>
        <p>+6019-358 9809 (YONG)</p>
      </div>
      <div class="column" >
        <h2>Emails</h2>
        <hr />
        <p>teejh-wp18@student.tarc.edu.my</p>
        <p>yongwh-wp18@student.tarc.edu.my</p>
      </div>
</div>

   
</asp:Content>
