using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BloodBank
{
    public partial class Form1 : Form
    {
        OleDbConnection conn;
        OleDbCommand cmd;
        OleDbDataReader dr;
        OleDbDataAdapter adapter;
        private int loginAttempts = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Initialize the connection string
            conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Admin\\Desktop\\backup\\BloodBank\\bin\\Debug\\BloodBank.accdb");

            try
            {
                conn.Open();

                // Check login for Admin
                string adminQuery = "SELECT COUNT(*) FROM Admin WHERE Username = @username AND [Password] = @password";
                using (OleDbCommand cmd = new OleDbCommand(adminQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@username", tbUsername.Text);
                    cmd.Parameters.AddWithValue("@password", tbPassword.Text);

                    int adminCount = (int)cmd.ExecuteScalar();

                    if (adminCount > 0)
                    {
                        Form2 bi = new Form2();
                        bi.Show();
                        bi.BringToFront();

                        tbPassword.Text = "";
                        tbUsername.Text = "";

                        return;
                    }
                }
                // If both queries fail
                loginAttempts++;
                MessageBox.Show("Invalid username or password.");

                if (loginAttempts >= 3)
                {
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }


        private void label4_Click(object sender, EventArgs e)
        {

        }

    }
}
