using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cloud_Assignment
{
    public partial class SellerUploadShirt : System.Web.UI.Page
    {
       


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submit_Click(object sender, EventArgs e)
        {

            int length = Picture.PostedFile.ContentLength;
            byte[] pic = new byte[length];
            Picture.PostedFile.InputStream.Read(pic, 0, length);

            SqlConnection con;
            string strcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            con = new SqlConnection(strcon);

            con.Open();
            string strSelect = "Select count(DrawID) from Gallery";
            SqlCommand cmdSelect = new SqlCommand(strSelect, con);
            int total = (int)cmdSelect.ExecuteScalar();
            con.Close();

            int newIndex = total + 1;

            string drawID = "DR" + newIndex.ToString();

            con.Open();
            string strSelect1 = "Select DrawID from Gallery";
            SqlCommand cmdSelect1 = new SqlCommand(strSelect1, con);
            SqlDataReader dtr = cmdSelect1.ExecuteReader();

            if (dtr.HasRows)
            {
                while (dtr.Read())
                {

                    if (drawID.Equals(dtr["DrawID"]))
                    {
                        newIndex += 1;
                        drawID = "DR" + newIndex.ToString();

                    }
                }
            }
            con.Close();

            con.Open();

            string fileName = Path.GetFileName(Picture.PostedFile.FileName);
            string filePath = "BuildInPictures/" + fileName;
            Picture.PostedFile.SaveAs(Server.MapPath(filePath));

            string strInsert = "Insert into Gallery (DrawID, StaffID, Name, Description, Price, Total, Image,Category) Values (@DrawID, @StaffID, @Name, @Description, @Price, @Total, @Image,@Category)";

            SqlCommand cmdInsert = new SqlCommand(strInsert, con);
            cmdInsert.Parameters.AddWithValue("@DrawID", drawID);
            cmdInsert.Parameters.AddWithValue("@StaffID", Session["Value"]);
            cmdInsert.Parameters.AddWithValue("@Name", ArtName.Text);
            cmdInsert.Parameters.AddWithValue("@Description", ArtDescription.Text);
            cmdInsert.Parameters.AddWithValue("@Price", Price.Text);
            cmdInsert.Parameters.AddWithValue("@Total", TotalArt.Text);
            cmdInsert.Parameters.AddWithValue("@Image", filePath);
            cmdInsert.Parameters.AddWithValue("@Category", CategoryList.SelectedValue);
            int numRowAffected = cmdInsert.ExecuteNonQuery();
            con.Close();

            if (numRowAffected > 0)
            {
                ArtName.Text = "";
                ArtDescription.Text = "";
                Price.Text = "";
                // return insert success
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Added! " + "');", true);

            }
            else
            {
                // return insert failed
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Added failed! " + "');", true);
            }

        }

        protected void Cancel_Click(object sender, EventArgs e)
        {

        }
    }
}