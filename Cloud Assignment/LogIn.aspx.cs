using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cloud_Assignment
{
    public partial class LogIn : System.Web.UI.Page
    {
        public class Global // Global variable
        {
            public static string accountType;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            SignInMultiView.ActiveViewIndex = 0;
            if (!IsPostBack)
            {
                if (Request.Cookies["Username"] != null)
                {
                    txtUsername.Text = Request.Cookies["Username"].Value;
                }
            }
        }

        protected void changeView()
        {
            SignInMultiView.ActiveViewIndex = 1; // Use to change the view to register form
        }


        protected void btnCustomer_Click(object sender, EventArgs e)
        {
            Global.accountType = "c";
            lblSignIn.Text = "Sign In as Customer";
            changeView();
        }

        protected void btnStaff_Click(object sender, EventArgs e)
        {
            Global.accountType = "s";
            lblSignIn.Text = "Sign In as Staff";
            changeView();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection con;
            string strcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            con = new SqlConnection(strcon);


            if (Global.accountType == "s")
            {

                con.Open();
                string strSelect = "SELECT * FROM [Staff] WHERE Username = @Username";

                SqlCommand cmdSelect = new SqlCommand(strSelect, con);
                cmdSelect.Parameters.AddWithValue("@Username", txtUsername.Text); //supply value to @Username

                SqlDataReader dtr = cmdSelect.ExecuteReader();

                if (dtr.HasRows)
                {
                    while (dtr.Read())
                    {
                        if (txtUsername.Text.Equals(dtr["Username"]))
                        {
                            if (dtr["Password"].ToString().Equals(txtPassword.Text))
                            {

                                Session["Bar"] = "S";
                                Session["Value"] = dtr["StaffID"].ToString();
                                Session["UserName"] = dtr["Username"].ToString();
                                //---cookie
                                if (chkBoxRememberMe.Checked)
                                {
                                    Response.Cookies["Username"].Value = txtUsername.Text;
                                    Response.Cookies["Username"].Expires = DateTime.Now.AddDays(7);
                                }
                                else
                                {
                                    Response.Cookies["Username"].Expires = DateTime.Now.AddMinutes(-1);
                                }

                                Response.Redirect("HomePage.aspx");

                            }
                            else
                            {
                                txtPassword.Text = "";
                                lblError.Text = "Incorrect Password";
                                SignInMultiView.ActiveViewIndex = 1; //stay in current view

                            }
                        }
                    }
                }
                else
                {
                    txtPassword.Text = "";
                    txtUsername.Text = "";
                    lblError.Text = "Username not existed.";
                    SignInMultiView.ActiveViewIndex = 1; //stay in current view

                }
                con.Close();
            }
            else
            {
                con.Open();
                string strSelect = "SELECT * FROM [Customer] WHERE Username = @Username";

                SqlCommand cmdSelect = new SqlCommand(strSelect, con);
                cmdSelect.Parameters.AddWithValue("@Username", txtUsername.Text); //supply value to @Username

                SqlDataReader dtr = cmdSelect.ExecuteReader();

                if (dtr.HasRows)
                {
                    while (dtr.Read())
                    {
                        if (txtUsername.Text.Equals(dtr["Username"]))
                        {
                            if (dtr["Password"].Equals(txtPassword.Text))
                            {
                                Session["Bar"] = "C";
                                Session["Value"] = dtr["CustomerID"].ToString();
                                Session["UserName"] = dtr["Username"].ToString();
                                //---cookie
                                if (chkBoxRememberMe.Checked)
                                {
                                    Response.Cookies["Username"].Value = txtUsername.Text;
                                    Response.Cookies["Username"].Expires = DateTime.Now.AddDays(7);
                                }
                                else
                                {
                                    Response.Cookies["Username"].Expires = DateTime.Now.AddMinutes(-1);
                                }

                                Response.Redirect("HomePage.aspx");
                            }
                            else
                            {
                                txtPassword.Text = "";
                                lblError.Text = "Incorrect Password";
                                SignInMultiView.ActiveViewIndex = 1; //stay in current view

                            }
                        }

                    }
                }
                else
                {
                    txtPassword.Text = "";
                    txtUsername.Text = "";
                    lblError.Text = "Username not existed.";
                    SignInMultiView.ActiveViewIndex = 1; //stay in current view
                }
                con.Close();
            }
        }
    }
}