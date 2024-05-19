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
    public partial class Loading : Form
    {
        Timer timer;

        public Loading()
        {
            InitializeComponent();

            progressBar1.ForeColor = Color.DimGray;

            // Initialize and configure the timer
            timer = new Timer();
            timer.Interval = 400; // 0.4 seconds interval
            timer.Tick += Timer_Tick;

            // Start the timer
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Update the progress bar value
            progressBar1.PerformStep();

            // Check if progress bar has reached maximum value
            if (progressBar1.Value >= progressBar1.Maximum)
            {
                // Stop the timer
                timer.Stop();

                // Hide the loading form
                this.Hide();

                // Show the login form
                Login loginForm = new Login();
                loginForm.ShowDialog();

                // Optionally close the loading form
                this.Close();
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
