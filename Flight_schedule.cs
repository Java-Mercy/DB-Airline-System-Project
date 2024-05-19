using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Windows.Markup;

namespace WindowsFormsApp2
{
    public partial class Flight_schedule : Form
    {
        private string userid, type;
        public Flight_schedule( string userid , string type )
        {
            InitializeComponent();
            this.userid = userid;
            this.type = type;
            AdjustDataGridViewAppearance();
        }

      //  OracleConnection Con = new OracleConnection(@"DATA SOURCE = localhost:1521/XE;User ID=PROJECT;Password=123");
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Con.Open();


            //string str1 = "select * from usertable";
            
            //OracleDataAdapter ada = new OracleDataAdapter(str1 , Con);

            //DataTable dt = new DataTable();
            //ada.Fill(dt);
            //Con.Close();    
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string s = "";

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

        private void Password_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {

        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
            
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            revenue Revenue = new revenue(userid , type );
            Revenue.ShowDialog();
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Profile prof = new Profile(userid , type);
            prof.ShowDialog();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Employee employee = new Employee(userid,type); 
            employee.ShowDialog();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {

            this.Hide();
            revenue revnue = new revenue(userid, type);
            revnue.ShowDialog();
        }
        private void AdjustDataGridViewAppearance()
        {
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 11); // Change "Arial" and 12 to your desired font family and size

            dataGridView1.RowTemplate.Height = 50; // Change 50 to your desired row height

            // Optionally, you can set specific font size for header cells
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold); // Change "Arial" and 14 to your desired font family and size
        }
        
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 10); 
            dataGridView1.Columns[0].DefaultCellStyle.Font = new Font("Arial", 12);
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            // Define the SQL query to retrieve flight data
            string query = "SELECT FLIGHTID, ARRIVALTIME, DEPARTURETIME, ARRIVALLOCATION, DEPARTURELOCATION, FLIGHTSTATUS FROM FLIGHT";

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


        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {
            //arrival loc
        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {
            // departure loc 
        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {
            //arrival time 
        }

        private void guna2TextBox6_TextChanged(object sender, EventArgs e)
        {
            //deprture time 
        }

        private void guna2TextBox9_TextChanged(object sender, EventArgs e)
        {
            //status
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            // flight id 
        }
    }
}