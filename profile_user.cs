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

namespace WindowsFormsApp2
{
    public partial class profile_user : Form
    {
        private string userid;
        private string type;

        public profile_user(string userid , string type)
        {
            InitializeComponent();

            this.userid = userid; 
            this.type= type;
        }

            
        private void profile_user_Load(object sender, EventArgs e)
        {
            LoadUserData();
        }

        private void LoadUserData()
        {
            try
            {
                string connectionString = @"DATA SOURCE=localhost:1521/XE;USER ID=YourUsername;Password=YourPassword";

                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM User WHERE userID = 3";
                    OracleCommand command = new OracleCommand(query, connection);
                    command.Parameters.Add(":UserID", OracleDbType.Int32).Value = Convert.ToInt32(userid);

                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            //label12.Text = reader["userID"].ToString();
                            label12.Text = reader["First Name"].ToString();
                            label11.Text = reader["Last Name"].ToString();
                            label10.Text = reader["Email"].ToString();
                            label9.Text = reader["CNIC"].ToString();
                            label8.Text = reader["phoneNumber"].ToString();
                            label7.Text = reader["DoOB"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("User not found.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // Other event handlers...


        private void guna2Button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Flight_schedule flight_Schedule = new Flight_schedule(userid, type);
            flight_Schedule.ShowDialog();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Feedback_user feedback_User = new Feedback_user(userid, type);
            feedback_User.ShowDialog();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Book_flight book_Flight = new Book_flight(userid , type);
            book_Flight.ShowDialog();
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
