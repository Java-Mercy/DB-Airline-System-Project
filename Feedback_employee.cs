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
    public partial class Feedback_employee : Form
    {
        private string userid;
        private string type;

        public Feedback_employee(string userid, string type)
        {
            InitializeComponent();
            this.userid = userid;
            this.type = type;
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            TO_DO_TASK_emp TDO = new TO_DO_TASK_emp(userid, type);
            TDO.ShowDialog();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string s = "select * from Feedback";

                string c = @"DATA SOURCE = localhost:1521/XE;User ID=PROJECT;Password=123";
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

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Profile prof = new Profile(userid, type);
            prof.Show();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Flight_schedule fff = new Flight_schedule(userid, type);
            fff.ShowDialog();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            revenue Reve = new revenue(userid, type);
            Reve.ShowDialog();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Feedback_employee feedd = new Feedback_employee(userid, type);
            feedd.ShowDialog();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Book_flight book_Flight = new Book_flight(userid, type); book_Flight.ShowDialog();
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {

            this.Hide();
            Login logg = new Login();
            logg.ShowDialog();
        }
    }
}
