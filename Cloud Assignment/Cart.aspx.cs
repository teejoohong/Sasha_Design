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
    public partial class Cart : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
           

        }

        protected void check_Out_Click(object sender, EventArgs e)
        {

            SqlConnection con;
            string strcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            con = new SqlConnection(strcon);
            con.Open();
            string strSelect1 = "Select Count(*) from CheckOut";
            SqlCommand cmdSelect1 = new SqlCommand(strSelect1, con);

            int totalRow = (int)cmdSelect1.ExecuteScalar();
            con.Close();
            if (totalRow > 0)
            {
                Response.Redirect("CheckOut.aspx");
            }
            else
            {
                //javescript 
            }
        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {

        }

        protected void Chk_Empty_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = sender as CheckBox;
            DataListItem item = chk.NamingContainer as DataListItem;
            HiddenField hdn = item.FindControl("HiddenField1") as HiddenField;

            CheckBox chkrow = (CheckBox)item.FindControl("chkEmpty");

            if (hdn != null)
            {
                SqlConnection con;
                string strcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                con = new SqlConnection(strcon);

                con.Open();
                string strSelect2 = "DELETE from CheckOut Where DrawID=@DrawID and CustomerID = @CustomerID";
                SqlCommand cmdSelect2 = new SqlCommand(strSelect2, con);

                cmdSelect2.Parameters.AddWithValue("@CustomerID", Session["Value"]);
                cmdSelect2.Parameters.AddWithValue("@DrawID", hdn.Value.ToString());

                int numRowAffected2 = cmdSelect2.ExecuteNonQuery();
                con.Close();

                if (chkrow.Checked == true)
                {
                    //extract quantity
                    con.Open();
                    string strSelect = "SELECT Quantity from CartGallery Where DrawID = @DrawID1  AND CustomerID = @CustomerID1";
                    SqlCommand cmdSelect = new SqlCommand(strSelect, con);

                    cmdSelect.Parameters.AddWithValue("@DrawID1", hdn.Value.ToString());
                    cmdSelect.Parameters.AddWithValue("@CustomerID1", Session["Value"]);
                    int quantity = (int)cmdSelect.ExecuteScalar();
                    con.Close();

                    if (quantity > 0)
                    {
                        //Extract totalprice
                        con.Open();
                        string strSelect1 = "SELECT TotalPrice from CartGallery Where DrawID = @DrawID2  AND CustomerID = @CustomerID2";
                        SqlCommand cmdSelect1 = new SqlCommand(strSelect1, con);

                        cmdSelect1.Parameters.AddWithValue("@DrawID2", hdn.Value.ToString());
                        cmdSelect1.Parameters.AddWithValue("@CustomerID2", Session["Value"]);
                        System.Decimal totalPrice = (System.Decimal)cmdSelect1.ExecuteScalar();
                        con.Close();

                        //add into checkout 
                        con.Open();
                        string strInsert = "Insert into CheckOut (CustomerID, DrawID,TotalPrice, Quantity) Values (@CustomerID3, @DrawID3,@TotalPrice3, @Quantity3)";
                        SqlCommand cmdInsert = new SqlCommand(strInsert, con);

                        cmdInsert.Parameters.AddWithValue("@CustomerID3", Session["Value"]);
                        cmdInsert.Parameters.AddWithValue("@DrawID3", hdn.Value.ToString());
                        cmdInsert.Parameters.AddWithValue("@TotalPrice3", totalPrice);
                        cmdInsert.Parameters.AddWithValue("@Quantity3", quantity);

                        int numRowAffected = cmdInsert.ExecuteNonQuery();
                        con.Close();
                    }
                    else
                    {
                        //javascript
                        chkrow.Checked = false;
                    }

                }
                else
                {
                    //uncheck the checkbox
                    con.Open();
                    string strSelect = "DELETE from CheckOut Where DrawID=@DrawID and CustomerID = @CustomerID";
                    SqlCommand cmdSelect = new SqlCommand(strSelect, con);

                    cmdSelect.Parameters.AddWithValue("@CustomerID", Session["Value"]);
                    cmdSelect.Parameters.AddWithValue("@DrawID", hdn.Value.ToString());

                    int numRowAffected = cmdSelect.ExecuteNonQuery();
                    con.Close();
                }

                //check for any record inside the checkout 
                con.Open();
                string strSelect6 = "SELECT count(*) from CheckOut Where CustomerID = @CustomerID6";
                SqlCommand cmdSelect6 = new SqlCommand(strSelect6, con);

                cmdSelect6.Parameters.AddWithValue("@CustomerID6", Session["Value"]);

                int numRowAffected6 = (int)cmdSelect6.ExecuteScalar();

                if (numRowAffected6 > 0)
                {
                    //output the total price

                    SqlConnection conn;
                    string strconn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                    conn = new SqlConnection(strconn);

                    conn.Open();
                    string strSelect5 = "Select SUM(TotalPrice) From CheckOut Where CustomerID = @CustomerID5";
                    SqlCommand cmdSelect5 = new SqlCommand(strSelect5, conn);

                    cmdSelect5.Parameters.AddWithValue("@CustomerID5", Session["Value"]);
                    System.Decimal totalPriceCheckOut = (System.Decimal)cmdSelect5.ExecuteScalar();
                    conn.Close();

                    totalPrice1.Text = String.Format("{0:0.00}", totalPriceCheckOut).ToString();
                }
                else
                {
                    totalPrice1.Text = "0.0";
                }
                con.Close();
            }
        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                SqlConnection con;
                string strcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                con = new SqlConnection(strcon);
                string selectedDraw = e.CommandArgument.ToString();
                con.Open();
                string strSelect = "DELETE from CartGallery Where DrawID=@DrawID and CustomerID = @CustomerID";
                SqlCommand cmdSelect = new SqlCommand(strSelect, con);

                cmdSelect.Parameters.AddWithValue("@CustomerID", Session["Value"]);
                cmdSelect.Parameters.AddWithValue("@DrawID", selectedDraw);

                int numRowAffected = cmdSelect.ExecuteNonQuery();


                if (numRowAffected > 0)
                {
                    SqlConnection conn;
                    string strconn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                    conn = new SqlConnection(strconn);

                    conn.Open();
                    string strSelect2 = "DELETE  from CheckOut Where CustomerID = @CustomerID";
                    SqlCommand cmdSelect2 = new SqlCommand(strSelect2, conn);

                    cmdSelect2.Parameters.AddWithValue("@CustomerID", Session["Value"]);
                    int numRowAffected2 = cmdSelect2.ExecuteNonQuery();
                    conn.Close();

                    Response.Redirect("Cart.aspx");
                }
                else
                {
                    // return insert failed
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Delete failed! " + "');", true);
                }
                con.Close();

            }
            else if (e.CommandName == "Adding")
            {
                // extract quantity value
                SqlConnection con;
                string strcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                con = new SqlConnection(strcon);
                con.Open();
                string strSelect = "SELECT Quantity from CartGallery Where DrawID = @DrawID1  AND CustomerID = @CustomerID1";
                SqlCommand cmdSelect = new SqlCommand(strSelect, con);

                cmdSelect.Parameters.AddWithValue("@DrawID1", e.CommandArgument.ToString());
                cmdSelect.Parameters.AddWithValue("@CustomerID1", Session["Value"]);
                int quantity = (int)cmdSelect.ExecuteScalar() + 1;
                con.Close();

                //extract the quantity of the total from gallery 
                con.Open();
                string strSelectTotal = "SELECT Total from Gallery Where DrawID = @DrawID2";
                SqlCommand cmdSelectTotal = new SqlCommand(strSelectTotal, con);

                cmdSelectTotal.Parameters.AddWithValue("@DrawID2", e.CommandArgument.ToString());

                int total = (int)cmdSelectTotal.ExecuteScalar();
                con.Close();

                if (quantity <= total)
                {
                    //extract price
                    con.Open();
                    string strSelectPrice = "SELECT Price from Gallery Where DrawID = @DrawID3";
                    SqlCommand cmdSelectPrice = new SqlCommand(strSelectPrice, con);

                    cmdSelectPrice.Parameters.AddWithValue("@DrawID3", e.CommandArgument.ToString());

                    System.Decimal price = (System.Decimal)cmdSelectPrice.ExecuteScalar();
                    con.Close();


                    // add the quantity
                    con.Open();
                    string strUpdate = "UPDATE [CartGallery] SET Quantity = @Quantity WHERE DrawID = @DrawID4 AND CustomerID = @CustomerID4";
                    SqlCommand cmdUpdate = new SqlCommand(strUpdate, con);

                    cmdUpdate.Parameters.AddWithValue("@DrawID4", e.CommandArgument.ToString());
                    cmdUpdate.Parameters.AddWithValue("@CustomerID4", Session["Value"]);
                    cmdUpdate.Parameters.AddWithValue("@Quantity", quantity);
                    int numRowAffected = cmdUpdate.ExecuteNonQuery();
                    con.Close();

                    //update the total price value
                    con.Open();
                    double totalPrice = (double)price * quantity;
                    //totalPrice = totalPrice * quantity;
                    string strUpdate1 = "UPDATE [CartGallery] SET TotalPrice= @TotalPrice WHERE DrawID = @DrawID5 AND CustomerID = @CustomerID5";
                    SqlCommand cmdUpdate1 = new SqlCommand(strUpdate1, con);

                    cmdUpdate1.Parameters.AddWithValue("@DrawID5", e.CommandArgument.ToString());
                    cmdUpdate1.Parameters.AddWithValue("@CustomerID5", Session["Value"]);
                    cmdUpdate1.Parameters.AddWithValue("@TotalPrice", (System.Decimal)totalPrice);
                    int numRowAffected1 = cmdUpdate1.ExecuteNonQuery();
                    con.Close();

                    con.Open();
                    string strSelect2 = "DELETE  from CheckOut Where CustomerID = @CustomerID";
                    SqlCommand cmdSelect2 = new SqlCommand(strSelect2, con);

                    cmdSelect2.Parameters.AddWithValue("@CustomerID", Session["Value"]);
                    int numRowAffected2 = cmdSelect2.ExecuteNonQuery();
                    con.Close();
                }
                Response.Redirect("Cart.aspx");

            }
            else if (e.CommandName == "Subtract")
            {
                // extract quantity value
                SqlConnection con;
                string strcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                con = new SqlConnection(strcon);
                con.Open();
                string strSelect = "SELECT Quantity from CartGallery Where DrawID = @DrawID  AND CustomerID = @CustomerID1";
                SqlCommand cmdSelect = new SqlCommand(strSelect, con);

                cmdSelect.Parameters.AddWithValue("@DrawID", e.CommandArgument.ToString());
                cmdSelect.Parameters.AddWithValue("@CustomerID1", Session["Value"]);
                int quantity = (int)cmdSelect.ExecuteScalar() - 1;
                con.Close();

                if (quantity > 0)
                {
                    // subtract the quantity
                    con.Open();
                    string strUpdate = "UPDATE [CartGallery] SET Quantity = @Quantity WHERE DrawID = @DrawID AND CustomerID = @CustomerID";
                    SqlCommand cmdUpdate = new SqlCommand(strUpdate, con);

                    cmdUpdate.Parameters.AddWithValue("@DrawID", e.CommandArgument.ToString());
                    cmdUpdate.Parameters.AddWithValue("@CustomerID", Session["Value"]);
                    cmdUpdate.Parameters.AddWithValue("@Quantity", quantity);
                    int numRowAffected = cmdUpdate.ExecuteNonQuery();
                    con.Close();

                    //extract price
                    con.Open();
                    string strSelectPrice = "SELECT Price from Gallery Where DrawID = @DrawID3";
                    SqlCommand cmdSelectPrice = new SqlCommand(strSelectPrice, con);

                    cmdSelectPrice.Parameters.AddWithValue("@DrawID3", e.CommandArgument.ToString());

                    System.Decimal price = (System.Decimal)cmdSelectPrice.ExecuteScalar();

                    con.Close();

                    con.Open();
                    double totalPrice = (double)price * quantity;
                    //totalPrice = totalPrice * quantity;
                    string strUpdate1 = "UPDATE [CartGallery] SET TotalPrice= @TotalPrice WHERE DrawID = @DrawID5 AND CustomerID = @CustomerID5";
                    SqlCommand cmdUpdate1 = new SqlCommand(strUpdate1, con);

                    cmdUpdate1.Parameters.AddWithValue("@DrawID5", e.CommandArgument.ToString());
                    cmdUpdate1.Parameters.AddWithValue("@CustomerID5", Session["Value"]);
                    cmdUpdate1.Parameters.AddWithValue("@TotalPrice", (System.Decimal)totalPrice);
                    int numRowAffected1 = cmdUpdate1.ExecuteNonQuery();
                    con.Close();

                    con.Open();
                    string strSelect2 = "DELETE  from CheckOut Where CustomerID = @CustomerID6";
                    SqlCommand cmdSelect2 = new SqlCommand(strSelect2, con);

                    cmdSelect2.Parameters.AddWithValue("@CustomerID6", Session["Value"]);
                    int numRowAffected2 = cmdSelect2.ExecuteNonQuery();
                    con.Close();


                }
                Response.Redirect("Cart.aspx");
            }
        }
    }
}