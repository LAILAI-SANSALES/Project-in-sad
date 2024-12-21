using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BloodBank
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.TopLevel = false;
            DisplayPanel.Controls.Add(f);
            f.Show();
            f.BringToFront();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            Form4 f = new Form4();
            f.TopLevel = false;
            DisplayPanel.Controls.Add(f);
            f.Show();
            f.BringToFront();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to logout?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Hide();
                this.Dispose();
            }
            else
            {
                return;
            }
        }

        private void btnBloodStock_Click(object sender, EventArgs e)
        {
            BloodStocks BloodStocks = new BloodStocks();

            // Hide the current form
            this.Hide();

            // Show the second form
            BloodStocks.Show();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Home f = new Home();
            f.TopLevel = false;
            DisplayPanel.Controls.Add(f);
            f.Show();
            f.BringToFront();
        }

        private void btnBloodCollection_Click(object sender, EventArgs e)
        {
            RegistrationForm f = new RegistrationForm();
            f.TopLevel = false;
            DisplayPanel.Controls.Add(f);
            f.Show();
            f.BringToFront();
        }
    }
}
