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
    public partial class Dashboard_admin : Form
    {
        private string userid;
        private string type;
        public Dashboard_admin(string userid, string type)
        {
            InitializeComponent();
            this.userid = userid;
            this.type = type;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void iconButton2_Click(object sender, EventArgs e)
        {

        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {

            this.Hide();
            Login logg = new Login();
            logg.ShowDialog();
        }

        private void iconButton7_Click(object sender, EventArgs e)
        {

        }

        private void Password_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Employee employee = new Employee(userid , type);
            employee.ShowDialog();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
        //    this.Hide();
        //    Book_flight book_Flight = new Book_flight();
        //    book_Flight.ShowDialog();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {

            this.Hide();
            revenue rev = new revenue(userid , type);
            rev.ShowDialog();
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
            Profile prof = new Profile(userid , type);
            prof.ShowDialog();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Feedback_employee feedback_Employee = new Feedback_employee(userid , type );
            feedback_Employee.ShowDialog();
        }
    }
}
