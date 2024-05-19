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
    public partial class Feedback_user : Form
    {
        private string userid, type;
        public Feedback_user( string userid , string type)
        {
            InitializeComponent();
            this.userid = userid;
            this.type = type;
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

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            profile_user profile = new profile_user(userid, type);  
            profile.ShowDialog();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            this.Hide();
        flight_shedule_user flight_Schedule = new flight_shedule_user(userid, type);
            flight_Schedule.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text == "If you have any query or feedback then write here !!")
                textBox1.Text = string.Empty;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            //submit query here
            //-------------------------------------------------------------------
            //-------------------------------------------------------------------
            //-------------------------------------------------------------------
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
        //    this.Hide();
        //    Feedback_user feeduser = new Feedback_user(userid, type);
        //    feeduser.ShowDialog();
        }
    }
}
