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
    public partial class Gallery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (Session["Bar"] == "C")
            {
               
                if (e.CommandName == "AddToCart")
                {
                    if (Session["Value"] != null && Session["Value"] != "0")
                    {
                        SqlConnection con;
                        string strcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                        con = new SqlConnection(strcon);
                        string addedDraw = e.CommandArgument.ToString();
                        Boolean duplicate = false;
                        //checking value
                        con.Open();
                        string strSelectChecking = "Select * from CartGallery Where DrawID=@DrawID and CustomerID = @CustomerID";
                        SqlCommand cmdSelect = new SqlCommand(strSelectChecking, con);

                        cmdSelect.Parameters.AddWithValue("@CustomerID", Session["Value"]);
                        cmdSelect.Parameters.AddWithValue("@DrawID", addedDraw);

                        SqlDataReader dtr = cmdSelect.ExecuteReader();

                        if (dtr.HasRows)
                        {
                            while (dtr.Read())
                            {
                                if (addedDraw.Equals(dtr["DrawID"]) && Session["Value"].Equals(dtr["CustomerID"]))
                                {
                                    duplicate = true;
                                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Already added! " + "');", true);
                                }
                            }
                        }

                        con.Close();


                        //insert value
                        if (!duplicate)
                        {
                            con.Open();
                            string strSelect1 = "Select Price from Gallery Where DrawID=@DrawID";
                            SqlCommand cmdSelect1 = new SqlCommand(strSelect1, con);

                            cmdSelect1.Parameters.AddWithValue("@DrawID", addedDraw);
                            System.Decimal totalPrice = (System.Decimal)cmdSelect1.ExecuteScalar();

                            con.Close();

                            con.Open();

                            string strInsert = "Insert into CartGallery (CustomerID, DrawID,TotalPrice) Values (@CustomerID, @DrawID,@TotalPrice)";

                            SqlCommand cmdInsert = new SqlCommand(strInsert, con);
                            cmdInsert.Parameters.AddWithValue("@CustomerID", Session["Value"]);
                            cmdInsert.Parameters.AddWithValue("@DrawID", addedDraw);
                            cmdInsert.Parameters.AddWithValue("@TotalPrice", totalPrice);
                            //cmdInsert.Parameters.AddWithValue("@Name", "Name");
                            //cmdInsert.Parameters.AddWithValue("@Price", "Price");
                            //cmdInsert.Parameters.AddWithValue("@Image", "Image");

                            int numRowAffected1 = cmdInsert.ExecuteNonQuery();
                            if (numRowAffected1 > 0)
                            {
                                // return insert success
                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Added successfully! " + "');", true);
                            }
                            else
                            {
                                // return insert failed
                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "update failed! " + "');", true);
                            }
                            con.Close();
                        }
                    }
                    else
                    {
                        // not allow to add, please sign in first
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "log in first! " + "');", true);
                    }
                }
                else
                {
                    if (Session["Value"] != null && Session["Value"] != "0")
                    {
                        SqlConnection con;
                        string strcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                        con = new SqlConnection(strcon);
                        string addedDraw = e.CommandArgument.ToString();
                        Boolean duplicate = false;
                        //checking value
                        con.Open();
                        string strSelectChecking = "Select * from WishlistGallery Where DrawID=@DrawID and CustomerID = @CustomerID";
                        SqlCommand cmdSelect = new SqlCommand(strSelectChecking, con);

                        cmdSelect.Parameters.AddWithValue("@CustomerID", Session["Value"]);
                        cmdSelect.Parameters.AddWithValue("@DrawID", addedDraw);

                        SqlDataReader dtr = cmdSelect.ExecuteReader();

                        if (dtr.HasRows)
                        {
                            while (dtr.Read())
                            {
                                if (addedDraw.Equals(dtr["DrawID"]) && Session["Value"].Equals(dtr["CustomerID"]))
                                {
                                    duplicate = true;
                                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Already added! " + "');", true);
                                }
                            }
                        }

                        con.Close();

                        //insert value
                        if (!duplicate)
                        {
                            con.Open();

                            string strInsert = "Insert into WishlistGallery (CustomerID, DrawID, Date) Values (@CustomerID, @DrawID,@Date)";

                            SqlCommand cmdInsert = new SqlCommand(strInsert, con);
                            cmdInsert.Parameters.AddWithValue("@CustomerID", Session["Value"]);
                            cmdInsert.Parameters.AddWithValue("@DrawID", addedDraw);
                            cmdInsert.Parameters.AddWithValue("@Date", DateTime.Now);

                            int numRowAffected = cmdInsert.ExecuteNonQuery();
                            if (numRowAffected > 0)
                            {
                                // return insert success
                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Added successfully! " + "');", true);
                            }
                            else
                            {
                                // return insert failed
                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "update failed! " + "');", true);
                            }
                            con.Close();
                        }
                    }
                    else
                    {
                        // not allow to add, please sign in first
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "log in first! " + "');", true);
                    }
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Please log in as a customer first before making any purchase! " + "');", true);
            }

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            SqlDataSource1.SelectCommand = "SELECT * FROM [Gallery] Where [Total] > 0 and Category='T-shirt'";
        }

        protected void ShowAll_Click(object sender, EventArgs e)
        {
            SqlDataSource1.SelectCommand = "SELECT * FROM [Gallery] Where [Total] > 0";
        }

        protected void SculptureFilter_Click(object sender, EventArgs e)
        {
            SqlDataSource1.SelectCommand = "SELECT * FROM [Gallery] Where [Total] > 0 and Category='Collar'";
        }

        protected void Painting_Click(object sender, EventArgs e)
        {
            SqlDataSource1.SelectCommand = "SELECT * FROM [Gallery] Where [Total] > 0 and Category='Painting'";
        }
    }
}