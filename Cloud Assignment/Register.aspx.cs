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
    public partial class Register : System.Web.UI.Page
    {


        Boolean duplicate = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            //create connection
            SqlConnection con;
            string strcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            con = new SqlConnection(strcon);

            con.Open();

            //retrieve data
            string strSelect = "SELECT CustomerID, Username FROM [Customer]";
            //specify what is the command , what is the connection string
            SqlCommand cmdSelect = new SqlCommand(strSelect, con);

            SqlDataReader dtr = cmdSelect.ExecuteReader();

            if (dtr.HasRows)
            {
                while (dtr.Read())
                {
                    if (txtUsername.Text.Equals(dtr["Username"]))
                    {
                        duplicate = true;
                        lblDuplicate.Text = "Username existed.";
                        //response redirect
                    }
                }
            }


            con.Close();



            if (!duplicate) //no repeated username
            {
                SqlConnection newCon;
                string newStrCon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

                newCon = new SqlConnection(newStrCon);


                newCon.Open();

                string strSelect2 = "Select count(CustomerID) from Customer";
                SqlCommand cmdSelect2 = new SqlCommand(strSelect2, newCon);

                int total = (int)cmdSelect2.ExecuteScalar() + 1;
                newCon.Close();

                string customerID = "CS" + total.ToString();
                newCon.Open();

                string strInsert = "INSERT INTO [Customer] (CustomerID, Username, Password, Email) VALUES (@CustomerID, @Username, @Password, @Email)";

                SqlCommand cmdInsert = new SqlCommand(strInsert, newCon);
                cmdInsert.Parameters.AddWithValue("@CustomerID", customerID);
                cmdInsert.Parameters.AddWithValue("@Username", txtUsername.Text.ToString());
                cmdInsert.Parameters.AddWithValue("@Password", txtPassword.Text.ToString());
                cmdInsert.Parameters.AddWithValue("@Email", txtEmail.Text.ToString());
                int n = cmdInsert.ExecuteNonQuery();

                if (n > 0) // Use to check whether the value have been insert into the database
                {

                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Customer Account Successfully Created!" + "');", true);
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Failed!" + "');", true);
                }

                newCon.Close();

            }
        }
    }
}