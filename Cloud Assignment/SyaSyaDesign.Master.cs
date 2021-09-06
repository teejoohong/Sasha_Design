using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static Cloud_Assignment.LogIn;

namespace Cloud_Assignment
{
    public partial class SyaSyaDesign : System.Web.UI.MasterPage
    {
        String pageName;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                foreach (MenuItem item in menuNav2.Items)
                {
                    if (item.NavigateUrl.Equals(Request.AppRelativeCurrentExecutionFilePath))
                    {
                        item.Selected = true;
                        //Label1.Text = HttpContext.Current.Request.Url.AbsolutePath; /HomePage.aspx
                        //Label1.Text = item.Text.ToString(); Home
                        //Label1.Text = item.NavigateUrl.ToString(); ~/Calories.aspx
                    }
                    pageName = HttpContext.Current.Request.Url.AbsolutePath;
                    if (pageName == "/EditProfile.aspx" || pageName == "/EditProfilePicture.aspx" || pageName == "/UserPreference.aspx")
                    {
                        menuNav2.FindItem("Profile").Selected = true;
                    }
                }

                foreach (MenuItem item in menuNav.Items)
                {
                    if (item.NavigateUrl.Equals(Request.AppRelativeCurrentExecutionFilePath))
                    {
                        item.Selected = true;
                        //Label1.Text = HttpContext.Current.Request.Url.AbsolutePath; /HomePage.aspx
                        //Label1.Text = item.Text.ToString(); Home
                        //Label1.Text = item.NavigateUrl.ToString(); ~/Calories.aspx
                    }
                    pageName = HttpContext.Current.Request.Url.AbsolutePath;
                    if (pageName == "/EditProfile.aspx" || pageName == "/EditProfilePicture.aspx" || pageName == "/UserPreference.aspx")
                    {
                        menuNav.FindItem("Profile").Selected = true;
                    }
                }

                if (Session["Value"] != null && Session["Value"] != "0")
                {
                    SqlConnection con;
                    string strcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                    con = new SqlConnection(strcon);

                    if (Global.accountType == "s")
                    {

                        con.Open();
                        string strSelect = "SELECT * FROM [Staff] WHERE StaffID = @StaffID";

                        SqlCommand cmdSelect = new SqlCommand(strSelect, con);
                        cmdSelect.Parameters.AddWithValue("@StaffID", Session["Value"]);

                        SqlDataReader dtr = cmdSelect.ExecuteReader();

                        if (dtr.HasRows)
                        {
                            while (dtr.Read())
                            {
                                StaffUsername.Text = dtr["Username"].ToString();
                            }
                        }
                        con.Close();

                        
                    }
                    else
                    {
                        con.Open();
                        string strSelect = "SELECT * FROM [Customer] WHERE CustomerID = @CustomerID";

                        SqlCommand cmdSelect = new SqlCommand(strSelect, con);
                        cmdSelect.Parameters.AddWithValue("@CustomerID", Session["Value"]);

                        SqlDataReader dtr = cmdSelect.ExecuteReader();

                        if (dtr.HasRows)
                        {
                            while (dtr.Read())
                            {
                                CustomerUsername.Text = dtr["Username"].ToString();
                            }
                        }
                        con.Close();


                    }
                }
            }

        }


        protected void ltnButton1_Click(object sender, EventArgs e)
        {
            Session["Value"] = null;
            Session["Bar"] = null;
            Response.Redirect("LogIn.aspx");
        }
    }
}