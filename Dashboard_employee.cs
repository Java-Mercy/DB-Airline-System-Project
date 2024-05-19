using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Dashboard_employee : Form
    {
        private string userid;
        private string type;
        public Dashboard_employee( string userid ,string type)
        {
            InitializeComponent();
            this.type= type;
            this.userid = userid;
        }
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            TO_DO_TASK_emp td = new TO_DO_TASK_emp(userid , type);
            td.ShowDialog();
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
            Book_flight book_Flight = new Book_flight(userid, type);
            book_Flight.ShowDialog();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Feedback_employee fedback = new Feedback_employee(userid , type);
            fedback.ShowDialog();
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
            Profile profile = new Profile(userid , type );
            profile.ShowDialog();
        }

        private void Password_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            revenue revnue = new revenue(userid, type);
            revnue.ShowDialog();
        }
    }
}
