﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewAssignment4
{
    public partial class Login : System.Web.UI.Page
    {
        //Connect to the database
        KarateDataContext dbcon;
        string conn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KarateSchool.mdf;Integrated Security=True;Connect Timeout=30";

        protected void Page_Load(object sender, EventArgs e) 
        {
            //Initialize connection string 
            dbcon = new KarateDataContext(conn);
        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            string nUserName = Login1.UserName;
            string nPassword = Login1.Password;

            HttpContext.Current.Session["nUserName"] = nUserName;
            HttpContext.Current.Session["uPass"] = nPassword;

            // Search for the current User, validate UserName and Password
            NetUser myUser = dbcon.NetUsers.FirstOrDefault
                                (x =>
                                 x.UserName == HttpContext.Current.Session["nUserName"].ToString() &&
                                 x.UserPassword == HttpContext.Current.Session["uPass"].ToString()
                                );

            if (myUser != null)
            {
                //Add UserID and User type to the Session
                HttpContext.Current.Session["userID"] = myUser.UserID;
                HttpContext.Current.Session["userType"] = myUser.UserType;

            }
            if (myUser != null && HttpContext.Current.Session["userType"].ToString().Trim().ToLower() == "member")
            {

                FormsAuthentication.RedirectFromLoginPage(HttpContext.Current.Session["nUserName"].ToString(), true);

                Response.Redirect("~/MyMembers/MemberPage.aspx");
            }
            else if (myUser != null && HttpContext.Current.Session["userType"].ToString().Trim().ToLower() == "instructor")
            {

                FormsAuthentication.RedirectFromLoginPage(HttpContext.Current.Session["nUserName"].ToString(), true);

                Response.Redirect("~/MyInstructors/InstructorPage.aspx");
            }
            else if (myUser != null && HttpContext.Current.Session["userType"].ToString().Trim().ToLower() == "administrator")
            {

                FormsAuthentication.RedirectFromLoginPage(HttpContext.Current.Session["nUserName"].ToString(), true);

                Response.Redirect("~/MyAdministrators/AdministratorPage.aspx");
            }
            else
            {
                Response.Redirect("Logon.aspx", true);
            }
        }
    }
}
