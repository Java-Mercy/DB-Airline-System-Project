using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WindowsFormsApp2
{
    public partial class Login : Form
    {
        // Declare OracleConnection at the class level
        private OracleConnection Con;

        public Login()
        {
            InitializeComponent();
            string add = @"DATA SOURCE = localhost:1521/XE;User ID=Project; Password=123";
            Con = new OracleConnection(add); // Initialize the connection
        }
        public static class Session
        {
            public static string UserID { get; set; }
            public static string type{ get; set; }

        }
        private string userid = Session.UserID, type = Session.type;



        //private void Loginbtn_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string userName = guna2TextBox1.Text;

        //        string password = guna2TextBox2.Text;

        //        Con.Open();

        //        // Prepare the SQL query using parameterized query to avoid SQL injection
        //        string roleQuery = "SELECT usertype FROM usertable WHERE email = :UserName AND password = :Password";
        //        OracleCommand roleCmd = new OracleCommand(roleQuery, Con);
        //        roleCmd.Parameters.Add(new OracleParameter("UserName", OracleDbType.Varchar2)).Value = userName;
        //        roleCmd.Parameters.Add(new OracleParameter("Password", OracleDbType.Varchar2)).Value = password;

        //        OracleDataReader roleReader = roleCmd.ExecuteReader();

        //        if (roleReader.Read()) // If a row is returned, it means the user exists
        //        {
        //            string userType = roleReader["usertype"].ToString();
        //            roleReader.Close();

        //            // Set session properties
        //            Session.UserID = userName;
        //            Session.type = userType;
        //            this.Hide();
        //            // Navigate to the appropriate dashboard based on the user's role
        //            switch (userType)
        //            {
        //                case "Admin":
        //                    Dashboard_admin dashboardAdmin = new Dashboard_admin(userName, userType);
        //                    dashboardAdmin.Show();
        //                    break;
        //                case "User":
        //                    Dashboard_user dashboardUser = new Dashboard_user(userName, userType);
        //                    dashboardUser.Show();
        //                    break;
        //                case "Employee":
        //                    Dashboard_employee dashboardEmployee = new Dashboard_employee(userName, userType);
        //                    dashboardEmployee.Show();
        //                    break;
        //                default:
        //                    MessageBox.Show("Invalid user type: " + userType);
        //                    break;
        //            }

        //            // Hide the login form
               
        //        }
        //        else
        //        {
        //            MessageBox.Show("Invalid username or password.");
        //        }

        //        // Close the connection
        //        Con.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error: " + ex.Message);
        //    }
        //}

        private void Loginbtn_Click(object sender, EventArgs e)
        {

            try
            {
                string userName = guna2TextBox1.Text;
                string password = guna2TextBox2.Text;

                Con.Open();
                // Your database query here to check the user's role
                //                string roleQuery = "SELECT usertype FROM usertable WHERE userid = "+userName+" AND password = "+password+" ";
                // int x = int.Parse(userName);
                string roleQuery = "SELECT usertype FROM usertable WHERE userid = " + userName + " AND password = " + password + " ";
;
                OracleCommand roleCmd = new OracleCommand(roleQuery, Con);
               
                OracleDataReader roleReader = roleCmd.ExecuteReader();

                if (roleReader.Read()) // If a row is returned, it means the user exists
                {
                    string userType = roleReader["usertypae"].ToString();

                    // Close the roleReader before executing the next query
                    roleReader.Close();

                    Session.UserID = guna2TextBox1.Text;
                    Session.type = userType;

                    // Navigate to the appropriate dashboard based on the user's role
                    switch (userType)
                    {
                        case "Admin":
                            this.Hide();
                            Dashboard_admin dashboardAdmin = new Dashboard_admin(userid, type);
                            dashboardAdmin.Show();
                            break;
                        case "User":
                            this.Hide();
                            Dashboard_user dashboardUser = new Dashboard_user(userid, type);
                            dashboardUser.Show();
                            break;
                        case "Employee":
                            this.Hide();
                            Dashboard_employee dashboardEmployee = new Dashboard_employee(Session.UserID, Session.type);
                            dashboardEmployee.Show();
                            break;
                        default:
                            MessageBox.Show("Invalid user type.");
                            break;
                    }
                   this.Hide();

                }
                else
                {
                    MessageBox.Show("Invalid username or password.");
                    this.Hide();
                    Login login = new Login();
                    login.Show();
                }

                // Close the connection
                Con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void maskedTextBox3_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void maskedTextBox4_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void Password_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
            if (guna2TextBox2.Text == "Password ")
                guna2TextBox2.Text = string.Empty;

        }
























        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            if(guna2TextBox1.Text == "User Name or Email ")
                guna2TextBox1.Text = string.Empty;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f = new Form2();
            f.ShowDialog();
        }
    }
}
