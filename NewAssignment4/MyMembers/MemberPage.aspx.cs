using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewAssignment4.MyMembers
{
    public partial class MemberPage : System.Web.UI.Page
    {
        KarateDataContext dbcon;

        String conn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Jack\\source\\repos\\Team1Assignment4\\NewAssignment4\\App_Data\\KarateSchool.mdf;Integrated Security=True;Connect Timeout=30";
        protected void Page_Load(object sender, EventArgs e)
        {
            RefreshData();

            if (Session.Count != 0)
            {
                if (HttpContext.Current.Session["userType"].ToString().Trim().ToLower() == "instructor" ||
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

            var result = from x in dbcon.Sections where x.Member.ToString() == LoginName1.ToString() select x;// need to edit this to make it the logged in memeber only.

            GridView1.DataSource = result;
            GridView1.DataBind();
        }
    }
}