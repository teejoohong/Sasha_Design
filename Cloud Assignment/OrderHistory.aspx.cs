using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Cloud_Assignment
{
    public partial class OrderHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["Value"] = "CS1"; //test data
            if (Session["Value"] != "0" && Session["Value"] != null)
            {

                SqlConnection con;
                string strcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                con = new SqlConnection(strcon);

                con.Open();
                // string strSelect = "SELECT count([Order].CustomerID) FROM [Order] INNER JOIN Gallery ON [Order].DrawID = Gallery.DrawID WHERE ([Order].CustomerID = @CustomerID)";
                string strSelect = "Select count(*) From [Order] Where CustomerID= @CustomerID";
                SqlCommand cmdSelect = new SqlCommand(strSelect, con);

                cmdSelect.Parameters.AddWithValue("@CustomerID", Session["Value"]);

                int numRowAffected = (int)cmdSelect.ExecuteScalar();

                if (numRowAffected > 0)
                {
                    // return insert success
                    // ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Delete successfully! " + "');", true);

                }
                else
                {
                    Label3.Text = "No record found";
                }
            }
        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogIn.aspx");
        }



        protected void Unnamed_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "ViewDetails")
            {
                Response.Redirect("OrderHistoryDetails.aspx?id=" + e.CommandArgument.ToString());
            }
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogIn.aspx");
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
    }
}