using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
        }

        private void RefreshData()
        {
            dbcon = new KarateDataContext(conn);

            var result = from x in dbcon.Sections select x;

            GridView1.DataSource = result;
            GridView1.DataBind();
        }
    }
}