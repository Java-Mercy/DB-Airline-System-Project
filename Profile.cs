using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

namespace WindowsFormsApp2
{

    public partial class Profile : Form
    {
        private string userid;
        private string type;

        public Profile(string userid, string type)
        {
            InitializeComponent();
            this.userid = userid;
            this.type = type;
        }

        private void Profile_Load(object sender, EventArgs e)
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

    
    private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           // userID = guna2TextBox1.Text;


        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {

            this.Hide();
            Login login = new Login();
            login.ShowDialog();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {

            this.Hide();
            Book_flight book_Flight = new Book_flight(userid,type);
            book_Flight.ShowDialog();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Feedback_user feedback_User = new Feedback_user(userid, type);
            feedback_User.ShowDialog();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            revenue rev = new revenue(userid, type);
            rev.ShowDialog();
            
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Employee emp = new Employee(userid , type);
            emp.ShowDialog();

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Flight_schedule fligh = new Flight_schedule(userid , type);
            fligh.ShowDialog();
        }
    }
}
