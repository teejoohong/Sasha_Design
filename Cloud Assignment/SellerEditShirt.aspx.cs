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
    public partial class SellerEditShirt : System.Web.UI.Page
    {
        string Drawid;
        protected void Page_Load(object sender, EventArgs e)
        {
            Drawid = HttpContext.Current.Request.QueryString["id"].ToString();
            if (!IsPostBack)
            {

                SqlConnection con;
                string strcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                con = new SqlConnection(strcon);

                con.Open();
                string strSelect = "SELECT * FROM Gallery WHERE DrawID=@DrawID";

                SqlCommand cmdSelect = new SqlCommand(strSelect, con);
                cmdSelect.Parameters.AddWithValue("@DrawID", Drawid);
                SqlDataReader dtr = cmdSelect.ExecuteReader();

                if (dtr.HasRows)
                {
                    while (dtr.Read())
                    {
                        NameTxt.Text = dtr["Name"].ToString();
                        DescriptionTxt.Text = dtr["Description"].ToString();
                        QuantityTxt.Text = dtr["Total"].ToString();
                        PriceTxt.Text = String.Format("{0:0.00}", dtr["Price"]).ToString();

                    }
                }
                con.Close();
            }
        }

        //protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        //{
        //    DataRowView datarow = (DataRowView)e.Item.DataItem;
        //    string imageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])datarow["Image"]);
        //    (e.Item.FindControl("Image1") as Image).ImageUrl = imageUrl;
        //}

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "ConfirmEdit")
            {
                SqlConnection con;
                string strcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                con = new SqlConnection(strcon);

                con.Open();

                string strUpdate = "UPDATE [Gallery] SET Name = @Name, Description = @Description, Total = @Total, Price = @Price WHERE DrawID = @DrawID";
                SqlCommand cmdUpdate = new SqlCommand(strUpdate, con);

                cmdUpdate.Parameters.AddWithValue("@DrawID", Drawid);
                cmdUpdate.Parameters.AddWithValue("@Name", NameTxt.Text);
                cmdUpdate.Parameters.AddWithValue("@Description", DescriptionTxt.Text);
                cmdUpdate.Parameters.AddWithValue("@Total", Int32.Parse(QuantityTxt.Text));
                double priceTxtDb = Convert.ToDouble(PriceTxt.Text);
                cmdUpdate.Parameters.AddWithValue("@Price", (System.Decimal)priceTxtDb);

                int numRowAffected = cmdUpdate.ExecuteNonQuery();


                if (numRowAffected > 0)
                {
                    // return insert success
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Edited! " + "');", true);
                    Response.Redirect("GalleryArtist.aspx");
                }
                else
                {
                    // return insert failed
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Edit failed! " + "');", true);
                }
                con.Close();


            }

            if (e.CommandName == "CancelEdit")
            {
                Response.Redirect("SellerViewShirt.aspx");
            }
        }

    }
}