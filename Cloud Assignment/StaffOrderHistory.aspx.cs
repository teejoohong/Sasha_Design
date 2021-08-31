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
    public partial class StaffOrderHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Value"] != "0" && Session["Value"] != null)
            {

                SqlConnection con;
                string strcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                con = new SqlConnection(strcon);

                con.Open();
                string strSelect = "Select * From [Order]";
                SqlCommand cmdSelect = new SqlCommand(strSelect, con);

                //cmdSelect.Parameters.AddWithValue("@DrawID", HttpContext.Current.Request.QueryString["id"].ToString());

                SqlDataReader dtr = cmdSelect.ExecuteReader();

                if (dtr.HasRows)
                {
                    while (dtr.Read())
                    {
                        
                    }
                }
                else
                {
                    Label10.Text = "No record found";
                }
            }
        }
    }
}