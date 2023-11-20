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

            // Refresh Gridview
            RefreshMembers();
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

            // Refresh Gridview
            RefreshInstructors();
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
                    lblSectionCreation.Text = "Could not find either member or instructor";
                    return;
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

            // Inform user that the section was created
            lblSectionCreation.Text = "Section has been created";

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

        protected void btnDeleteMember_Click(object sender, EventArgs e)
        {
            string memberToDeleteName = txtMemberFirstName.Text.Trim();

            using (dbconn = new KarateDataContext(conn))
            {
                // Find the member to delete based on the first name
                var memberToDelete = dbconn.Members.FirstOrDefault(m => m.MemberFirstName == memberToDeleteName);

                if (memberToDelete != null)
                {
                    int memberIdToDelete = memberToDelete.Member_UserID;

                    // Delete the member record
                    dbconn.Members.DeleteOnSubmit(memberToDelete);
                    dbconn.SubmitChanges();

                    // Find the associated NetUser using the retrieved Member_UserID
                    var userToDelete = dbconn.NetUsers.FirstOrDefault(u => u.UserID == memberIdToDelete);
                    if (userToDelete != null)
                    {
                        // Delete the associated NetUser record
                        dbconn.NetUsers.DeleteOnSubmit(userToDelete);
                        dbconn.SubmitChanges();
                    }
                }
                else
                {
                    lblDeletedMember.Text = "Could not find member or member first name not filled out";
                    return;
                }
            }
            
            // Clear textboxes
            lblDeletedMember.Text = "Member has been deleted";
            txtMemberFirstName.Text = "";
            txtMemberLastName.Text = "";
            txtMemberPhoneNumber.Text = "";
            txtMemberEmail.Text = "";
            txtMemberUserName.Text = "";
            txtMemberPassword.Text = "";

            // Refresh GridView
            RefreshMembers();
        }

        protected void btnDeleteInstructor_Click(object sender, EventArgs e)
        {
            string instructorToDeleteName = txtInstructorFirstName.Text.Trim();

            using (dbconn = new KarateDataContext(conn))
            {
                // Find the instructor to delete based on the first name
                var instructorToDelete = dbconn.Instructors.FirstOrDefault(i => i.InstructorFirstName == instructorToDeleteName);

                if (instructorToDelete != null)
                {
                    int instructorIdToDelete = instructorToDelete.InstructorID;

                    // Delete the instructor record
                    dbconn.Instructors.DeleteOnSubmit(instructorToDelete);
                    dbconn.SubmitChanges();

                    // Find the associated NetUser using the retrieved InstructorID
                    var userToDelete = dbconn.NetUsers.FirstOrDefault(u => u.UserID == instructorIdToDelete);
                    if (userToDelete != null)
                    {
                        // Delete the associated NetUser record
                        dbconn.NetUsers.DeleteOnSubmit(userToDelete);
                        dbconn.SubmitChanges();
                    }
                }
                else
                {
                    lblDeletedInstructor.Text = "Could not find instructor or instructor first name not filled out";
                    return;
                }
            }

            // Clear textboxes
            lblDeletedInstructor.Text = "Instructor has been deleted";
            txtInstructorFirstName.Text = "";
            txtInstructorLastName.Text = "";
            txtInstructorPhoneNumber.Text = "";
            txtInstructorUserName.Text = "";
            txtInstructorPassword.Text = "";

            // Refresh GridView
            RefreshInstructors();
        }
    }
}
