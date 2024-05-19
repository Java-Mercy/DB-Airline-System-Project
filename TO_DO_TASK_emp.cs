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
    public partial class TO_DO_TASK_emp : Form
    {
        private string userid;
        private string type;
        public TO_DO_TASK_emp( string userid, string type)
        {
            InitializeComponent();
            this.userid = userid;
            this.type = type;
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            revenue REVENUE = new revenue(userid, type);
            REVENUE.ShowDialog();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Flight_schedule flight_Schedule = new Flight_schedule(userid, type);
            flight_Schedule.ShowDialog();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Profile profile = new Profile(userid, type);
            profile.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Password_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Feedback_employee femp = new Feedback_employee(userid, type); femp.ShowDialog();
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
