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
            var result = from x in dbconn.Members 
                         select new 
                         { x.MemberFirstName, 
                           x.MemberLastName, 
                           x.MemberPhoneNumber, 
                           x.MemberDateJoined 
                         };
            //Show data in gridview
            memberGridView.DataSource = result;
            memberGridView.DataBind();
        }

        private void RefreshInstructors()
        {
            dbconn = new KarateDataContext(conn);
            //LINQ
            var result = from x in dbconn.Instructors 
                         select new { x.InstructorFirstName, x.InstructorLastName };
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
            // Retreive data from textboxes
            string firstName = txtMemberFirstName.Text.Trim();
            string lastName = txtMemberLastName.Text.Trim();
            string phoneNumber = txtMemberPhoneNumber.Text.Trim();
            string email = txtMemberEmail.Text.Trim();
            DateTime dateJoined = DateTime.Parse(txtMemberDateJoined.Text.Trim());

            string userName = txtMemberUserName.Text.Trim();
            string userPassword = txtMemberPassword.Text.Trim();

            using (KarateDataContext dbconn = new KarateDataContext(conn))
            {
                // Create a new NetUser
                NetUser newUser = new NetUser
                {
                    UserName = userName,
                    UserPassword = userPassword,
                    UserType = "member"
                };

                // Add the new User to the database
                dbconn.NetUsers.InsertOnSubmit(newUser);
                dbconn.SubmitChanges();

                // Retrieve the UserID of the last inserted NetUser
                int lastInsertedUserID = dbconn.NetUsers.OrderByDescending(u => u.UserID).FirstOrDefault()?.UserID ?? 0;

                // Create a new Member
                Member newMember = new Member
                {
                    Member_UserID = lastInsertedUserID, // Set Member_UserID to the last inserted UserID
                    MemberFirstName = firstName,
                    MemberLastName = lastName,
                    MemberPhoneNumber = phoneNumber,
                    MemberEmail = email,
                    MemberDateJoined = dateJoined
                };

                // Add the new Member to the database
                dbconn.Members.InsertOnSubmit(newMember);
                dbconn.SubmitChanges();
            }
            
            // Clear textboxes
            txtMemberFirstName.Text = "";
            txtMemberLastName.Text = "";
            txtMemberPhoneNumber.Text = "";
            txtMemberEmail.Text = "";
            txtMemberDateJoined.Text = "";
            txtMemberUserName.Text = "";
            txtMemberPassword.Text = "";
        }

        protected void btnAddInstructor_Click(object sender, EventArgs e)
        {
            // Retreive data from textboxes
            string firstName = txtInstructorFirstName.Text.Trim();
            string lastName = txtInstructorLastName.Text.Trim();
            string phoneNumber = txtInstructorPhoneNumber.Text.Trim();

            string userName = txtInstructorUserName.Text.Trim();
            string userPassword = txtInstructorPassword.Text.Trim();

            using (KarateDataContext dbconn = new KarateDataContext(conn))
            {
                // Create a new NetUser
                NetUser newUser = new NetUser
                {
                    UserName = userName,
                    UserPassword = userPassword,
                    UserType = "instructor"
                };

                dbconn.NetUsers.InsertOnSubmit(newUser);
                dbconn.SubmitChanges();

                // Retrieve the UserID of the last inserted NetUser
                int lastInsertedUserID = dbconn.NetUsers.OrderByDescending(u => u.UserID).FirstOrDefault()?.UserID ?? 0;

                // Create a new Instructor
                Instructor newInstructor = new Instructor
                {
                    InstructorID = lastInsertedUserID, // Set InstructorID to the last inserted UserID
                    InstructorFirstName = firstName,
                    InstructorLastName = lastName,
                    InstructorPhoneNumber = phoneNumber
                };

                // Add the new Instructor to the database
                dbconn.Instructors.InsertOnSubmit(newInstructor);
                dbconn.SubmitChanges();
            }

            // Clear textboxes
            txtInstructorFirstName.Text = "";
            txtInstructorLastName.Text = "";
            txtInstructorPhoneNumber.Text = "";
            txtInstructorUserName.Text = "";
            txtInstructorPassword.Text = "";
        }
    }
}