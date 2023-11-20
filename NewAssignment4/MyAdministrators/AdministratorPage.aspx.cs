using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewAssignment4.MyAdministrators
{
    public partial class AdministratorPage : System.Web.UI.Page
    {
        KarateDataContext dbconn;

        string conn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KarateSchool.mdf;Integrated Security=True;Connect Timeout=30";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RefreshMembers();

                RefreshInstructors();
            }
        }

        private void RefreshMembers()
        {
            dbconn = new KarateDataContext(conn);
            //LINQ
            var result = from x in dbconn.Members select x;
            //Show data in gridview
            memberGridView.DataSource = result;
            memberGridView.DataBind();
        }

        private void RefreshInstructors()
        {
            dbconn = new KarateDataContext(conn);
            //LINQ
            var result = from x in dbconn.Instructors select x;
            //Show data in gridview
            instructorGridView.DataSource = result;
            instructorGridView.DataBind();
        }

        protected void memberGridView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void instructorGridView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnAddMember_Click(object sender, EventArgs e)
        {
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string phoneNumber = txtPhoneNumber.Text.Trim();
            string email = txtEmail.Text.Trim();
            string dateJoined = txtDateJoined.Text.Trim();

        }

        protected void btnAddInstructor_Click(object sender, EventArgs e)
        {
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string phoneNumber = txtPhoneNumber.Text.Trim();

        }
    }
}