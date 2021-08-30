using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static Cloud_Assignment.LogIn;

namespace Cloud_Assignment
{
    public partial class EditProfilePicture : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Value"] != "0" && Session["Value"] != null)
            {

                SqlConnection con;
                string strcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                con = new SqlConnection(strcon);
                if (Global.accountType == "s")
                {
                    //profile pic command
                    SqlDataSource1.SelectCommand = "SELECT [ProfilePicture] FROM [Staff] WHERE StaffID = @StaffID";
                }
                else
                {
                    //profile pic command
                    SqlDataSource1.SelectCommand = "SELECT [ProfilePicture] FROM [Customer] WHERE CustomerID = @CustomerID";
                }

            }
        }
        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {

            DataRowView datarow = (DataRowView)e.Item.DataItem;
            string imageUrl = (datarow["ProfilePicture"]).ToString();
            (e.Item.FindControl("Image1") as Image).ImageUrl = imageUrl;

        }

        protected void Change_Click(object sender, EventArgs e)
        {
            SqlConnection con;
            string strcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            con = new SqlConnection(strcon);



            int length = FileUpload1.PostedFile.ContentLength;
            byte[] pic = new byte[length];
            FileUpload1.PostedFile.InputStream.Read(pic, 0, length);

            if (Global.accountType == "s")
            {
                con.Open();

                string strUpdate = "UPDATE [Staff] SET ProfilePicture = @ProfilePicture WHERE StaffID = @StaffID";

                SqlCommand cmdUpdate = new SqlCommand(strUpdate, con);

                string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                string filePath = "ProfilePicture/" + fileName;
                FileUpload1.PostedFile.SaveAs(Server.MapPath(filePath));

                try
                {
                    cmdUpdate.Parameters.AddWithValue("@ProfilePicture", filePath);
                    cmdUpdate.Parameters.AddWithValue("@StaffID", Session["Value"]);
                    int n = cmdUpdate.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Something went wrong.");
                }

                con.Close();

            }
            else
            {
                con.Open();

                string strUpdate = "UPDATE [Customer] SET ProfilePicture = @ProfilePicture WHERE CustomerID = @CustomerID";

                SqlCommand cmdUpdate = new SqlCommand(strUpdate, con);

                string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                string filePath = "ProfilePicture/" + fileName;
                FileUpload1.PostedFile.SaveAs(Server.MapPath(filePath));

                try
                {
                    cmdUpdate.Parameters.AddWithValue("@ProfilePicture", filePath);
                    cmdUpdate.Parameters.AddWithValue("@CUstomerID", Session["Value"]);
                    int n = cmdUpdate.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Something went wrong.");
                }


                con.Close();
            }

            Response.Redirect("EditProfilePicture.aspx");
        }
    }
    
}