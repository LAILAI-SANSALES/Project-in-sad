using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Runtime.InteropServices;
using System.Xml.Linq;
namespace BloodBank
{
    public partial class RegistrationForm : Form
    {
        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataReader dr;
        ConnectionDB db = new ConnectionDB();
        public RegistrationForm()
        {
            InitializeComponent();
            con = new OleDbConnection(db.GetConnection());
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (tbUsername.Text == "" || tbPassword.Text == "" || txtConfirm.Text == "" )
            {
                MessageBox.Show("Required Missing Fields", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if(txtConfirm.Text != tbPassword.Text)
            {
                MessageBox.Show("Password doesn't match, Please confirm again", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                con.Open();
                cmd = new OleDbCommand("INSERT INTO Admin ([Username], [Password]) VALUES (@Username, @Password)", con);
                cmd.Parameters.AddWithValue("@Username", tbUsername.Text);
                cmd.Parameters.AddWithValue("@Password", tbPassword.Text);              
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Successfully Saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);                                   
               
            }
        }
    }
}
