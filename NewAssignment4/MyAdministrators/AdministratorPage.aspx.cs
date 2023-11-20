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
                         {
                             x.MemberFirstName,
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

        protected void memberGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int memberIdToDelete = (int)memberGridView.DataKeys[e.RowIndex].Value; // Get the ID of the member to delete

            using (dbconn = new KarateDataContext(conn))
            {
                // Retrieve the Member and associated UserID
                var memberToDelete = dbconn.Members.FirstOrDefault(m => m.Member_UserID == memberIdToDelete);
                int userIdToDelete = memberToDelete?.Member_UserID ?? 0;

                if (memberToDelete != null)
                {
                    dbconn.Members.DeleteOnSubmit(memberToDelete);
                    dbconn.SubmitChanges();

                    // Delete the associated NetUser using the retrieved UserID
                    var userToDelete = dbconn.NetUsers.FirstOrDefault(u => u.UserID == userIdToDelete);
                    if (userToDelete != null)
                    {
                        dbconn.NetUsers.DeleteOnSubmit(userToDelete);
                        dbconn.SubmitChanges();
                    }
                }
            }

            // Refresh the gridview
            RefreshMembers();
        }

        protected void instructorGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int instructorIdToDelete = (int)instructorGridView.DataKeys[e.RowIndex].Value; // Get the ID of the instructor to delete

            using (dbconn = new KarateDataContext(conn))
            {
                // Retrieve the Instructor and associated UserID
                var instructorToDelete = dbconn.Instructors.FirstOrDefault(i => i.InstructorID == instructorIdToDelete);
                int userIdToDelete = instructorToDelete?.InstructorID ?? 0;

                if (instructorToDelete != null)
                {
                    dbconn.Instructors.DeleteOnSubmit(instructorToDelete);
                    dbconn.SubmitChanges();

                    // Delete the associated NetUser using the retrieved UserID
                    var userToDelete = dbconn.NetUsers.FirstOrDefault(u => u.UserID == userIdToDelete);
                    if (userToDelete != null)
                    {
                        dbconn.NetUsers.DeleteOnSubmit(userToDelete);
                        dbconn.SubmitChanges();
                    }
                }
            }

            // Refresh the gridview
            RefreshInstructors();
        }

        protected void btnAddMember_Click(object sender, EventArgs e)
        {
            // Retreive data from textboxes
            string firstName = txtMemberFirstName.Text.Trim();
            string lastName = txtMemberLastName.Text.Trim();
            string phoneNumber = txtMemberPhoneNumber.Text.Trim();
            string email = txtMemberEmail.Text.Trim();
            DateTime dateJoined = DateTime.Now;

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

        protected void btnAddSection_Click(object sender, EventArgs e)
        {
            // Retrieve data from textboxes
            string sectionName = sectionDropDown.SelectedValue;
            DateTime startDate = DateTime.Now;
            string member = txtMember.Text.Trim();
            string instructor = txtInstructor.Text.Trim();
            decimal sectionPrice = Convert.ToDecimal((lblSectionPrice.Text).Replace("$", ""));

            using (KarateDataContext dbconn = new KarateDataContext(conn))
            {
                // Find the id for both member and instructor
                int memberUserId = 0;
                int instructorUserId = 0;

                var foundMember = dbconn.Members.FirstOrDefault(m => m.MemberFirstName == member);
                var foundInstructor = dbconn.Instructors.FirstOrDefault(m => m.InstructorFirstName == instructor);

                if (foundMember != null && foundInstructor != null)
                {
                    memberUserId = foundMember.Member_UserID;
                    instructorUserId = foundInstructor.InstructorID;
                }
                else
                {

                }

                Section newSection = new Section
                {
                    SectionName = sectionName,
                    SectionStartDate = startDate,
                    Member_ID = memberUserId,
                    Instructor_ID = instructorUserId,
                    SectionFee = sectionPrice
                };

                //Update Database
                dbconn.Sections.InsertOnSubmit(newSection);
                dbconn.SubmitChanges();
            }

            // Clear textboxes
            sectionDropDown.ClearSelection();
            txtMember.Text = "";
            txtInstructor.Text = "";
            lblSectionPrice.Text = "$0";
        }

        protected void sectionDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sectionDropDown.SelectedIndex == 0)
            {
                lblSectionPrice.Text = "$500";
            }

            if (sectionDropDown.SelectedIndex == 1)
            {
                lblSectionPrice.Text = "$600";
            }
        }
    }
}
