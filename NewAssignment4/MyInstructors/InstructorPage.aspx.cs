using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewAssignment4.MyInstructors
{
    public partial class InstructorPage : System.Web.UI.Page
    {
        KarateDataContext dbcon;

        String conn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KarateSchool.mdf;Integrated Security=True;Connect Timeout=30";

        protected void Page_Load(object sender, EventArgs e)
        {
            RefreshData();

            if (Session.Count != 0)
            {
                if (HttpContext.Current.Session["userType"].ToString().Trim().ToLower() == "member" ||
                    HttpContext.Current.Session["userType"].ToString().Trim().ToLower() == "administrator")
                {
                    Session.Clear();
                    Session.RemoveAll();
                    Session.Abandon();
                    Session.Abandon();
                    FormsAuthentication.SignOut();
                    Response.Redirect("Logon.aspx", true);
                }
            }
        }
        private void RefreshData()
        {
            dbcon = new KarateDataContext(conn);

            var result = from x in dbcon.Sections where x.Instructor_ID == Convert.ToInt32(HttpContext.Current.Session["UserID"]) select x;// need to edit this to make it the logged in memeber only.

            GridView1.DataSource = result;
            GridView1.DataBind();
        }
    }
}