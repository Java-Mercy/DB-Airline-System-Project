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
    public partial class Employee : Form
    {

        //private string userid, type;

        //public Employee(string userid, string type)
        //{
        //    InitializeComponent();
        //    this.userid = userid;
        //    this.type = type;
        //}

        // Method to view employee data
    //    private void ViewEmployees()
    //    {
    //        string query = "SELECT * FROM usertable WHERE usertype = 'Employee'";

    //        string connectionString = @"DATA SOURCE = localhost:1521/XE;User ID=PROJECT;Password=123";

    //        using (OracleConnection connection = new OracleConnection(connectionString))
    //        {
    //            using (OracleDataAdapter dataAdapter = new OracleDataAdapter(query, connection))
    //            {
    //                DataTable dataTable = new DataTable();
    //                dataAdapter.Fill(dataTable);
    //                dataGridView1.DataSource = dataTable;
    //            }
    //        }
    //    }

    //    private void Employee_Load(object sender, EventArgs e)
    //    {
    //        ViewEmployees();
    //    }

    //    private void guna2Button1_Click(object sender, EventArgs e)
    //    {
    //        // Add employee
    //        string query = "INSERT INTO usertable (USERID, USERTYPE, ...) VALUES (:USERID, 'Employee', ...)";

    //        // Set up OracleConnection and OracleCommand objects with appropriate parameters
    //        // Execute the query
    //        // Refresh the DataGridView
    //    }

    //    private void guna2Button2_Click(object sender, EventArgs e)
    //    {
    //        // Update employee
    //        string query = "UPDATE usertable SET ... WHERE USERID = :USERID";

    //        // Set up OracleConnection and OracleCommand objects with appropriate parameters
    //        // Execute the query
    //        // Refresh the DataGridView
    //    }

    //    private void guna2Button3_Click(object sender, EventArgs e)
    //    {
    //        // Delete employee
    //        string query = "DELETE FROM usertable WHERE USERID = :USERID";

    //        // Set up OracleConnection and OracleCommand objects with appropriate parameters
    //        // Execute the query
    //        // Refresh the DataGridView
    //    }

    //    private void guna2Button4_Click(object sender, EventArgs e)
    //    {
    //        // View employees
    //        ViewEmployees();
    //    }
    //}
    //-----------------------------------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------------------------------
    private string userid, type;

        public Employee(string userid , string type)
        {
            InitializeComponent();
            this.userid = userid;
            this.type = type;
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            while (true)
            {
                if (guna2TextBox5.Text == guna2TextBox4.Text)
                {
                    AddEmployee();
                    break;
                }
                else
                    MessageBox.Show("Password != confirm password ... ");
            }
        }
        private void AddEmployee()
        {
            string connectionString = @"DATA SOURCE = localhost:1521/XE;User ID=PROJECT;Password=123";
            string query = "INSERT INTO usertable (USERID, USERTYPE, EMAIL, PASSWORD, CNIC, PHONENUMBER, DOB, FIRSTNAME, LASTNAME) VALUES (:USERID, 'Employee', :EMAIL, :PASSWORD, :CNIC, :PHONENUMBER, :DOB, :FIRSTNAME, :LASTNAME)";

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    // generate random id using guid 
                    string randomUserID = Guid.NewGuid().ToString();

                    command.Parameters.Add(":USERID", OracleDbType.Varchar2).Value = userid;
                    command.Parameters.Add(":EMAIL", OracleDbType.Varchar2).Value = guna2TextBox3.Text;
                    command.Parameters.Add(":PASSWORD", OracleDbType.Varchar2).Value = guna2TextBox5.Text;
                    command.Parameters.Add(":CNIC", OracleDbType.Varchar2).Value = guna2TextBox4.Text;
                    command.Parameters.Add(":PHONENUMBER", OracleDbType.Varchar2).Value = guna2TextBox9.Text;
                    command.Parameters.Add(":DOB", OracleDbType.Date).Value = guna2TextBox11.Text;
                    command.Parameters.Add(":FIRSTNAME", OracleDbType.Varchar2).Value = guna2TextBox1.Text;
                    command.Parameters.Add(":LASTNAME", OracleDbType.Varchar2).Value = guna2TextBox2.Text;
                    command.Parameters.Add(":USERTYPE", OracleDbType.Varchar2).Value = "Employee";

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }

            ViewEmployees();
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        private void iconButton1_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.ShowDialog(); 
            
        }
        //  ----------------- view employe in grid ------------------------------------------------------------------------------------------------------------
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ViewEmployees();
        }
        private void guna2Button9_Click(object sender, EventArgs e)
        {

            ViewEmployees();
            //string s = "SELECT * FROM usertable WHERE usertype = 'Employee'"; // Corrected SQL query

            //string c = @"DATA SOURCE = localhost:1521/XE;User ID=PROJECT;Password=123";

            //using (OracleConnection connection = new OracleConnection(c))
            //{
            //    using (OracleDataAdapter dataAdapter = new OracleDataAdapter(s, connection)) // Corrected OracleDataAdapter constructor
            //    {
            //        DataTable dataTable = new DataTable();
            //        dataAdapter.Fill(dataTable);
            //        dataGridView1.DataSource = dataTable;
            //    }
            //}
        }
        private void ViewEmployees()
        {
            string query = "SELECT * FROM usertable WHERE usertype = 'Employee'";
            string connectionString = @"DATA SOURCE = localhost:1521/XE;User ID=PROJECT;Password=123";

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                using (OracleDataAdapter dataAdapter = new OracleDataAdapter(query, connection))
                {
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                }
            }
        }
        //  ----------------- END ------ view employe in grid ------------------------------------------------------------------------------------------------------------

        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Profile profile = new Profile(userid, type);
            profile.ShowDialog();
        }

       

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Flight_schedule flight = new Flight_schedule(userid , type);
            flight.ShowDialog();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            revenue revenue = new revenue(userid , type);   revenue.ShowDialog();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Feedback_employee feed = new Feedback_employee(userid , type); feed.ShowDialog();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Book_flight book_Flight = new Book_flight(userid , type); book_Flight.ShowDialog();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox9_TextChanged(object sender, EventArgs e)
        {

        }
        //------------  DELETE EMPLOYEE  ---------------------------------------------------------------------------------------------------------
        private void DeleteEmployee()
        {
            string connectionString = @"DATA SOURCE = localhost:1521/XE;User ID=PROJECT;Password=123";
            string query = "DELETE FROM usertable WHERE USERID = :USERID";

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add(":USERID", OracleDbType.Varchar2).Value = guna2TextBox1.Text;

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }

            ViewEmployees();
        }
        private void guna2Button10_Click(object sender, EventArgs e)
        {
            DeleteEmployee();
        }

        private void guna2TextBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
