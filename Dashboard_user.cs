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
    public partial class Dashboard_user : Form
    {
            private string userid;
            private string type;
        public Dashboard_user(string userid, string type)
        {
            InitializeComponent();

            this.userid = userid ;
            this.type = type;
        }

        
        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
          
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {

            this.Hide();
            flight_shedule_user flight_Schedule = new flight_shedule_user(userid, type);
            flight_Schedule.ShowDialog();
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
            Book_flight book_Flight = new Book_flight(userid, type);    
            book_Flight.ShowDialog();
            
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void iconButton5_Click(object sender, EventArgs e)
        {

        }

        private void Password_Paint(object sender, PaintEventArgs e)
        {

        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {

        }

        private void iconButton6_Click(object sender, EventArgs e)
        {

        }

        private void iconButton2_Click(object sender, EventArgs e)
        {

        }

        private void iconButton4_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
