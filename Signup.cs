using FontAwesome.Sharp;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WindowsFormsApp2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private int GenerateUniqueUserID()
        {
            Random random = new Random();
            int userId;
            bool isUnique = false;

            // Keep generating random numbers until a unique one is found
            do
            {
                userId = random.Next(10000, 99999); // Generate a random 5-digit number
                isUnique = IsUserIDUnique(userId); // Check if the generated number is unique
            } while (!isUnique);

            return userId;
        }
        string connectionString = @"DATA SOURCE = localhost:1521/XE;User ID=PROJECT;Password=123";
        private bool IsUserIDUnique(int userId)
        {
            // Check if the generated USERID exists in the database
            string query = "SELECT COUNT(*) FROM UserTable WHERE USERID = :USERID";
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add(":USERID", OracleDbType.Int32).Value = userId;
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count == 0; // Return true if the USERID is unique
                }
            }
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if all textboxes are filled
                if (!string.IsNullOrWhiteSpace(guna2TextBox1.Text) &&
                    !string.IsNullOrWhiteSpace(guna2TextBox2.Text) &&
                    !string.IsNullOrWhiteSpace(guna2TextBox3.Text) &&
                    !string.IsNullOrWhiteSpace(guna2TextBox4.Text) &&
                    !string.IsNullOrWhiteSpace(guna2TextBox5.Text) &&
                    !string.IsNullOrWhiteSpace(guna2TextBox7.Text))
                {
                    // Insert the user data into the database
                    string add = @"DATA SOURCE = localhost:1521/XE;User ID=PROJECT;Password=123";
                    using (OracleConnection con = new OracleConnection(add))
                    {


                        con.Open();
                        //string roleQuery = "SELECT count(userid) FROM usertable ";
                        //OracleCommand roleCmd = new OracleCommand(roleQuery, con);
                        //OracleDataReader roleReader = roleCmd.ExecuteReader();
                        int userCount = GenerateUniqueUserID();


                        //                        if (roleReader.Read()) // Check if there is a row returned
                        {
                            //                            userCount = Convert.ToInt32(roleReader);
                            //                            userCount++;
                            //                            MessageBox.Show("nxk"+ userCount);

                        }
                        //
                        //                        string query = "INSERT INTO Users (LASTNAME, FIRSTNAME, USERID, USERTYPE, EMAIL, PASSWORD, CNIC, PHONENUMBER, DOB) VALUES (:LASTNAME, :FIRSTNAME, :USERID, :USERTYPE, :EMAIL, :PASSWORD, :CNIC, :PHONENUMBER, :DOB)";

                        //string query = "INSERT INTO Users (LASTNAME, FIRSTNAME, USERID, USERTYPE, EMAIL, PASSWORD, CNIC, PHONENUMBER, DOB) VALUES("+guna2TextBox2 +", "+guna2TextBox1 +", "+ userCount +",User , "+guna2TextBox3+"," +guna2TextBox7+", "+guna2TextBox4+", "+guna2TextBox6+"," +guna2TextBox5+");";
                       // string query = "INSERT INTO UserTable (LASTNAME, FIRSTNAME, USERID, USERTYPE, EMAIL, PASSWORD, CNIC, PHONENUMBER, DOB) VALUES('" + guna2TextBox2.Text + "', '" + guna2TextBox1.Text + "', " + userCount + ", 'User', '" + guna2TextBox3.Text + "', '" + guna2TextBox7.Text + "', '" + guna2TextBox4.Text + "', '" + guna2TextBox6.Text + "', '" + guna2TextBox5.Text + ")";
                        string query = "INSERT INTO UserTable (LASTNAME, FIRSTNAME, USERID, USERTYPE, EMAIL, PASSWORD, CNIC, PHONENUMBER, DOB) VALUES(:LASTNAME, :FIRSTNAME, :USERID, :USERTYPE, :EMAIL, :PASSWORD, :CNIC, :PHONENUMBER, :DOB)";

                        using (OracleCommand cmd = new OracleCommand(query, con))
                        {
                            cmd.Parameters.Add(":LASTNAME", OracleDbType.Varchar2).Value = guna2TextBox2.Text;
                            cmd.Parameters.Add(":FIRSTNAME", OracleDbType.Varchar2).Value = guna2TextBox1.Text;
                            cmd.Parameters.Add(":USERID", OracleDbType.Int32).Value = userCount; // Output parameter
                            cmd.Parameters.Add(":USERTYPE", OracleDbType.Varchar2).Value = "User";
                            cmd.Parameters.Add(":EMAIL", OracleDbType.Varchar2).Value = guna2TextBox3.Text;
                            cmd.Parameters.Add(":PASSWORD", OracleDbType.Varchar2).Value = guna2TextBox7.Text;
                            // if confirm passwd == password 
                            cmd.Parameters.Add(":CNIC", OracleDbType.Varchar2).Value = guna2TextBox4.Text;
                            cmd.Parameters.Add(":PHONENUMBER", OracleDbType.Varchar2).Value = guna2TextBox6.Text;
                            cmd.Parameters.Add(":DOB", OracleDbType.Date).Value = DateTime.Parse(guna2TextBox5.Text);

                            int rowsInserted = cmd.ExecuteNonQuery();
                            if (rowsInserted > 0)
                            {
                                MessageBox.Show("User successfully registered!");

                                // Get the auto-generated USERID value
                                int userId = Convert.ToInt32(cmd.Parameters[":USERID"].Value);
                                MessageBox.Show("Generated USERID: " + userId);
                            }
                            else
                            {
                                MessageBox.Show("Failed to register user!");
                            }
                        }

                        con.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Please fill all fields!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void Loginbtn_Click(object sender, EventArgs e)
        {

            this.Hide();

            Login loginForm = new Login();
            loginForm.ShowDialog();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox8_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
