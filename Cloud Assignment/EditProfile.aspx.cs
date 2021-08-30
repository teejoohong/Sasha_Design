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
    public partial class EditProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con;
            string strcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            con = new SqlConnection(strcon);
            if (!IsPostBack) {

                if (Global.accountType == "a")
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
                            txtEmail.Text = dtr["Email"].ToString();
                            txtContactNumber.Text = dtr["PhoneNumber"].ToString();
                            txtAddress.Text = dtr["Address"].ToString();

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
                            txtEmail.Text = dtr["Email"].ToString();
                            txtContactNumber.Text = dtr["PhoneNumber"].ToString();
                            txtAddress.Text = dtr["Address"].ToString();

                        }
                    }
                    con.Close();
                }
            }
            
        }

        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {

            DataRowView datarow = (DataRowView)e.Item.DataItem;
            string imageUrl = (datarow["ProfilePicture"]).ToString();
            (e.Item.FindControl("Image1") as Image).ImageUrl = imageUrl;

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection con;
            string strcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            con = new SqlConnection(strcon);

            if (Session["Bar"] == "S")
            {
                con.Open();
                string strUpdate = "UPDATE [Staff]  Email = @Email, PhoneNumber = @PhoneNumber WHERE StaffID = @StaffID";

                SqlCommand cmdUpdate = new SqlCommand(strUpdate, con);

                cmdUpdate.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmdUpdate.Parameters.AddWithValue("@PhoneNumber", txtContactNumber.Text);
                cmdUpdate.Parameters.AddWithValue("@StaffID", Session["Value"]);

                int n = cmdUpdate.ExecuteNonQuery();
                if (n > 0) // Use to check whether the value have been insert into the database
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Edit Account Successfully Created!" + "');", true);
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Failed!" + "');", true);
                }
                con.Close();
            }
            else
            {
                if (Session["Bar"] == "C")
                {
                    con.Open();
                    string strUpdate = "UPDATE [Customer] SET  Email = @Email, PhoneNumber = @PhoneNumber, Address = @Address WHERE CustomerID = @CustomerID";

                    SqlCommand cmdUpdate = new SqlCommand(strUpdate, con);

                   
                    cmdUpdate.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmdUpdate.Parameters.AddWithValue("@PhoneNumber", txtContactNumber.Text);
                    cmdUpdate.Parameters.AddWithValue("@Address", txtAddress.Text);
                    cmdUpdate.Parameters.AddWithValue("@CustomerID", Session["Value"]);

                    int n = cmdUpdate.ExecuteNonQuery();

                    if (n > 0) // Use to check whether the value have been insert into the database
                    {

                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Customer Account Successfully Created!" + "');", true);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Failed!" + "');", true);
                    }

                    con.Close();
                }
            }
            Response.Redirect("Profile.aspx");
        }
    }
}