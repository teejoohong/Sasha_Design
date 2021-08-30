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
    public partial class CheckOut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loadAddress();
        }

        protected void EditAddress_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditProfile.aspx");
        }

        private void loadAddress()
        {
            SqlConnection con;
            string strcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            con = new SqlConnection(strcon);

            try
            {
                con.Open();
                string strSelect = "SELECT Address from Customer Where CustomerID = @CustomerID";
                SqlCommand cmdSelect = new SqlCommand(strSelect, con);
                cmdSelect.Parameters.AddWithValue("@CustomerID", Session["Value"]);
                string address = cmdSelect.ExecuteScalar().ToString();
                con.Close();

                Label1.Text = address.ToString();
            }
            catch (Exception ex)
            {
                Label1.Text = "";
            }

        }
        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            string drawIDMessage = "";
            string messageContent = "";
            SqlConnection con;
            string strcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            con = new SqlConnection(strcon);
            con.Open();
            string strSelectAddress = "SELECT Address FROM [Customer] Where CustomerID = @CustomerIDAddress";
            SqlCommand cmdSelectAddress = new SqlCommand(strSelectAddress, con);
            cmdSelectAddress.Parameters.AddWithValue("@CustomerIDAddress", Session["Value"]);
            string address = cmdSelectAddress.ExecuteScalar().ToString();
            con.Close();

            if (address != null && address != "")
            {
                if (RadioButtonList1.SelectedValue.Equals("Master/Visa Card") || RadioButtonList1.SelectedValue.Equals("Online Banking"))
                {
                    DateTime now = DateTime.Now;
                    int numRowAffected = 0, numRowAffected1 = 0, numRowAffected2 = 0, numRowAffected3 = 0;

                    con.Open();
                    //extract the total row of order 
                    string strSelect = "SELECT count(OrderID) FROM [Order]";
                    SqlCommand cmdSelect = new SqlCommand(strSelect, con);

                    //int total = (int)cmdSelect.ExecuteScalar() + 1;
                    int total = (int)cmdSelect.ExecuteScalar();
                    con.Close();

                    //the new data order id
                    int newIndex = total + 1;
                    string orderID = "OR" + newIndex.ToString();

                    //Extarct totalPrice
                    con.Open();
                    string strSelect5 = "Select SUM(TotalPrice) From CheckOut Where CustomerID = @CustomerID5";
                    SqlCommand cmdSelect5 = new SqlCommand(strSelect5, con);

                    cmdSelect5.Parameters.AddWithValue("@CustomerID5", Session["Value"]);
                    System.Decimal totalPriceCheckOut = (System.Decimal)cmdSelect5.ExecuteScalar();
                    con.Close();

                    //Insert into order
                    con.Open();
                    string strInsert1 = "Insert into [Order] (OrderID,CustomerID,PaymentType,Date,TotalPrice, DeliveryAddress) Values (@OrderID,@CustomerID,@PaymentType,@Date,@TotalPrice,@DeliveryAddress)";
                    SqlCommand cmdInsert1 = new SqlCommand(strInsert1, con);

                    cmdInsert1.Parameters.AddWithValue("@OrderID", orderID);
                    cmdInsert1.Parameters.AddWithValue("@CustomerID", Session["Value"]);
                    cmdInsert1.Parameters.AddWithValue("@PaymentType", RadioButtonList1.SelectedValue.ToString());
                    cmdInsert1.Parameters.AddWithValue("@Date", now);
                    cmdInsert1.Parameters.AddWithValue("@TotalPrice", totalPriceCheckOut);
                    cmdInsert1.Parameters.AddWithValue("@DeliveryAddress", address);
                    int numRowAffected5 = cmdInsert1.ExecuteNonQuery();
                    con.Close();

                    //get the total row in the checkout
                    con.Open();
                    string strSelect1 = "Select Count(*) from CheckOut";
                    SqlCommand cmdSelect1 = new SqlCommand(strSelect1, con);

                    int totalRow = (int)cmdSelect1.ExecuteScalar();
                    con.Close();

                    //insert, update, delete
                    for (int i = 0; i < totalRow; i++)
                    {
                        string draw = "";
                        string totalBought = "";
                        string totalPrice = "";
                        //get the draw id 
                        con.Open();
                        string strSelect2 = "Select MAX(DrawID) from CheckOut";
                        SqlCommand cmdSelect2 = new SqlCommand(strSelect2, con);
                        draw = (string)cmdSelect2.ExecuteScalar();
                        con.Close();
                        //if (!(i == totalRow - 1))
                        //{
                        //    drawIDMessage = drawIDMessage + draw + ", ";
                        //}
                        //else
                        //{
                        //    drawIDMessage = drawIDMessage + draw;
                        //}

                        //get all the data of the id 
                        con.Open();
                        string strSelect3 = "Select * from CheckOut Where DrawID = @DrawID";
                        SqlCommand cmdSelect3 = new SqlCommand(strSelect3, con);
                        cmdSelect3.Parameters.AddWithValue("@DrawID", draw);
                        SqlDataReader dtr = cmdSelect3.ExecuteReader();

                        if (dtr.HasRows)
                        {
                            while (dtr.Read())
                            {
                                totalBought = dtr["Quantity"].ToString();
                                totalPrice = dtr["TotalPrice"].ToString();
                            }
                        }
                        con.Close();
                        //Label1.Text = totalBought.ToString();
                        //insert into order
                        con.Open();
                        string strInsert = "Insert into [OrderDetails] (OrderID,DrawID,Quantity,Price) Values (@OrderID,@DrawID,@Quantity,@Price)";
                        SqlCommand cmdInsert = new SqlCommand(strInsert, con);

                        cmdInsert.Parameters.AddWithValue("@OrderID", orderID);
                        cmdInsert.Parameters.AddWithValue("@DrawID", draw.ToString());
                        cmdInsert.Parameters.AddWithValue("@Quantity", int.Parse(totalBought));
                        cmdInsert.Parameters.AddWithValue("@Price", totalPrice);
                        numRowAffected = cmdInsert.ExecuteNonQuery();
                        con.Close();

                        // delete check out
                        con.Open();
                        string strDelete = "DELETE from CheckOut Where DrawID = @DrawID and CustomerID = @CustomerID";
                        SqlCommand cmdDelete = new SqlCommand(strDelete, con);
                        cmdDelete.Parameters.AddWithValue("@CustomerID", Session["Value"]);
                        cmdDelete.Parameters.AddWithValue("@DrawID", draw.ToString());
                        numRowAffected1 = cmdDelete.ExecuteNonQuery();
                        con.Close();

                        //delete cart
                        con.Open();
                        string strDelete1 = "DELETE from CartGallery Where DrawID=@DrawID and CustomerID = @CustomerID";
                        SqlCommand cmdDelete1 = new SqlCommand(strDelete1, con);
                        cmdDelete1.Parameters.AddWithValue("@CustomerID", Session["Value"]);
                        cmdDelete1.Parameters.AddWithValue("@DrawID", draw.ToString());
                        numRowAffected2 = cmdDelete1.ExecuteNonQuery();
                        con.Close();

                        //Update the quanity of item
                        //extract the value first 
                        con.Open();
                        string strSelect4 = "Select Total from Gallery Where DrawID = @DrawID";
                        SqlCommand cmdSelect4 = new SqlCommand(strSelect4, con);
                        cmdSelect4.Parameters.AddWithValue("@DrawID", draw);
                        int quantity = (int)cmdSelect4.ExecuteScalar();
                        con.Close();
                        quantity = quantity - int.Parse(totalBought);

                        //update the quantity
                        con.Open();
                        string strUpdate = "UPDATE [Gallery] SET Total = @Total WHERE DrawID = @DrawID";
                        SqlCommand cmdUpdate = new SqlCommand(strUpdate, con);

                        cmdUpdate.Parameters.AddWithValue("@DrawID", draw.ToString());
                        cmdUpdate.Parameters.AddWithValue("@Total", quantity);
                        numRowAffected3 = cmdUpdate.ExecuteNonQuery();
                        con.Close();
                    }

                    if (numRowAffected > 0 && numRowAffected1 > 0 && numRowAffected2 > 0 && numRowAffected3 > 0)
                    {
                        //messageContent = messageContent + "<img src='https://i.ibb.co/H25fgMF/Alzenda-Logo.png' height='100px' width='75px'><br /><br />" + " You have bought " + totalRow + " piece of art which are " + drawIDMessage + " with total of " + String.Format("RM {0:0.00}", totalPriceCheckOut) + "<br />"
                        //    + "<br />We hope you are satisfied with the experience on the site<br />and were able to find what you were looking for with ease.<br />" + "<br />Kind regards,<br />The Alzenda Artwork Team<br />";
                        ////Extract gamil
                        //con.Open();
                        //string strSelect6 = "Select Email From Customer Where CustomerID = @CustomerID6";
                        //SqlCommand cmdSelect6 = new SqlCommand(strSelect6, con);

                        //cmdSelect6.Parameters.AddWithValue("@CustomerID6", Session["Value"]);
                        //string email = cmdSelect6.ExecuteScalar().ToString();
                        //con.Close();

                        //MailMessage message = new MailMessage("testingg726@gmail.com", email, "Thank You for making purchased", messageContent); // from , to, subject, text
                        //message.IsBodyHtml = true;

                        //SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                        //client.UseDefaultCredentials = false;
                        //client.EnableSsl = true;
                        //client.Credentials = new System.Net.NetworkCredential("testingg726@gmail.com", "abcd.1234");
                        //client.Send(message);

                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Payment Successfully! " + "');", true);
                        Response.Redirect("HomePage.aspx");

                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "payment failed! " + "');", true);
                    }



                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Please select a payment methos first! " + "');", true);
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Please insert your delivery address first " + "');", true);
            }

        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonList1.SelectedValue.Equals("Master/Visa Card"))
            {
                CreditDetail.Visible = true;
            }
            else
            {
                CreditDetail.Visible = false;
            }
        }
    }
}