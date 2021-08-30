using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static Cloud_Assignment.LogIn;

namespace Cloud_Assignment
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (Session["Value"] != "0" && Session["Value"] != null )
            {
                MultiView1.ActiveViewIndex = 0;
                SqlConnection con;
                string strcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                con = new SqlConnection(strcon);
                if (Session["Bar"] == "S")
                {
                    //profile pic command
                    SqlDataSource1.SelectCommand = "SELECT [ProfilePicture] FROM [Staff] WHERE StaffID = @StaffID";

                    con.Open();
                    string strSelect = "SELECT * FROM [Staff] WHERE StaffID = @StaffID";

                    SqlCommand cmdSelect = new SqlCommand(strSelect, con);
                    cmdSelect.Parameters.AddWithValue("@StaffID", Session["Value"]);
                    SqlDataReader dtr = cmdSelect.ExecuteReader();

                    if (dtr.HasRows)
                    {
                        while (dtr.Read())
                        {
                            lblUsername.Text = dtr["Username"].ToString();
                            lblEmail.Text = dtr["Email"].ToString();
                            lblContactNumber.Text = dtr["PhoneNumber"].ToString();
                            lblAddress.Text = "";

                        }
                    }
                    con.Close();
                }
                else
                {
                    //profile pic command
                    SqlDataSource1.SelectCommand = "SELECT [ProfilePicture] FROM [Customer] WHERE CustomerID = @CustomerID";

                    con.Open();
                    string strSelect = "SELECT * FROM [Customer] WHERE CustomerID = @CustomerID";

                    SqlCommand cmdSelect = new SqlCommand(strSelect, con);
                    cmdSelect.Parameters.AddWithValue("@CustomerID", Session["Value"]);
                    SqlDataReader dtr = cmdSelect.ExecuteReader();

                    if (dtr.HasRows)
                    {
                        while (dtr.Read())
                        {
                            lblUsername.Text = dtr["Username"].ToString();
                            lblEmail.Text = dtr["Email"].ToString();
                            lblContactNumber.Text = dtr["PhoneNumber"].ToString();
                            lblAddress.Text = dtr["Address"].ToString();
                        }
                    }
                    con.Close();
                }
            }
            else {
                MultiView1.ActiveViewIndex = 1;
            }
        }

        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {

            DataRowView datarow = (DataRowView)e.Item.DataItem;
            string imageUrl = (datarow["ProfilePicture"]).ToString();
            (e.Item.FindControl("Image1") as Image).ImageUrl = imageUrl;

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogIn.aspx");
        }
    }
}