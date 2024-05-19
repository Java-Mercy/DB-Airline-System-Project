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
    public partial class Book_flight : Form
    {
        private string userid;
        private string type;
        public Book_flight(string userid, string type)
        {
            InitializeComponent();
            this.userid = userid;
            this.type = type;

            AdjustDataGridViewAppearance();
        }
        private void AdjustDataGridViewAppearance()
        {
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 11); // Change "Arial" and 12 to your desired font family and size

            dataGridView1.RowTemplate.Height = 50; // Change 50 to your desired row height

            // Optionally, you can set specific font size for header cells
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold); // Change "Arial" and 14 to your desired font family and size
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
            Book_flight book_Flight = new Book_flight(userid , type);
            book_Flight.ShowDialog();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Feedback_user feedback = new Feedback_user(userid , type);
            feedback.ShowDialog();
        }

        private void Book_flight_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Flight_schedule flight_Schedule = new Flight_schedule(userid , type);
            flight_Schedule.ShowDialog();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (type == "User")
            {
                profile_user profile = new profile_user(userid, type);
                profile.ShowDialog();
            }
            else
            {
                Profile prof = new Profile(userid , type);
                prof.ShowDialog();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 10);
            dataGridView1.Columns[0].DefaultCellStyle.Font = new Font("Arial", 12);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

                string s = "select * from Booking";

                string c = @"DATA SOURCE = localhost:1521/XE;User ID=PROJECT;Password=123";
                //   using (OracleConnection con = new OracleConnection(@"DATA SOURCE = localhost:1521/XE;User ID=SYSTEM;Password=123"))
                using (OracleConnection connection = new OracleConnection(c))
                {
                    using (OracleDataAdapter dataAdapter = new OracleDataAdapter(s, c))
                    {
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;
                    }
                }

            
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
} 
