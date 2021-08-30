﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cloud_Assignment
{
    public partial class SyaSyaDesign : System.Web.UI.MasterPage
    {
        String pageName;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Session["Username"] != null)
                {
                    CustomerUsername.Text = Session["Username"].ToString();

                }
            }

            foreach (MenuItem item in menuNav.Items)
            {
                if (item.NavigateUrl.Equals(Request.AppRelativeCurrentExecutionFilePath))
                {
                    item.Selected = true;
                    //Label1.Text = HttpContext.Current.Request.Url.AbsolutePath; /HomePage.aspx
                    //Label1.Text = item.Text.ToString(); Home
                    //Label1.Text = item.NavigateUrl.ToString(); ~/Calories.aspx
                }
                pageName = HttpContext.Current.Request.Url.AbsolutePath;
                if (pageName == "/EditProfile.aspx" || pageName == "/EditProfilePicture.aspx" || pageName == "/UserPreference.aspx")
                {
                    menuNav.FindItem("Profile").Selected = true;
                }
            }

        }


        protected void ltnButton1_Click(object sender, EventArgs e)
        {
            Session["Value"] = null;
            Session["Bar"] = null;
            Response.Redirect("LogIn.aspx");
        }
    }
}