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
    public partial class flight_shedule_user : Form
    {
        private string userid;
        private string type;
        public flight_shedule_user(string userid, string type)
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
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 10);
            dataGridView1.Columns[0].DefaultCellStyle.Font = new Font("Arial", 12);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            profile_user profile_User = new profile_user(userid , type);
            profile_User.ShowDialog();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {

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
            Login logg = new Login();
            logg.ShowDialog();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

            // Define the SQL query to retrieve flight data
            string query = "SELECT FLIGHTID, ARRIVALLOCATION, DEPARTURELOCATION,  ARRIVALTIME, DEPARTURETIME, FLIGHTSTATUS FROM FLIGHT";

            // Define your connection string
            string connectionString = @"DATA SOURCE = localhost:1521/XE;User ID=PROJECT;Password=123";

            try
            {
                // Create a connection object
                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    // Create a data adapter to fetch data from the database
                    using (OracleDataAdapter dataAdapter = new OracleDataAdapter(query, connection))
                    {
                        // Create a DataTable to hold the fetched data
                        DataTable dataTable = new DataTable();

                        // Open the connection
                        connection.Open();

                        // Fill the DataTable with data fetched from the database
                        dataAdapter.Fill(dataTable);

                        // Close the connection
                        connection.Close();

                        // Bind the DataTable to the DataGridView to display the data
                        dataGridView1.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
