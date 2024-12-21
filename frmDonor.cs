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

namespace BloodBank
{
    public partial class frmDonor : Form
    {
        //Form3 f = new Form3();
        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataReader dr;
        ConnectionDB db = new ConnectionDB();
        public frmDonor()
        {
            InitializeComponent();
            con = new OleDbConnection(db.GetConnection());
            
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
       

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtID.Text == "" || txtAge.Text == "" || txtName.Text == "" || txtContact.Text == "" || txtBloodType.Text == "")
            {
                MessageBox.Show("Required Missing Fields", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                con.Open();
                cmd = new OleDbCommand("INSERT INTO ListOfDonors (ID, Dname, Age, Contact, BloodType) VALUES (@ID, @Dname, @Age, @Contact, @BloodType)", con);
                cmd.Parameters.AddWithValue("@ID", txtID.Text);
                cmd.Parameters.AddWithValue("@Dname", txtName.Text);
                cmd.Parameters.AddWithValue("@Age", txtAge.Text);
                cmd.Parameters.AddWithValue("@Contact", txtContact.Text);
                cmd.Parameters.AddWithValue("BloodType", txtBloodType.Text);             
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Successfully Saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //f.LoadData();              
                this.Dispose();
                //btnUpdate.Enabled = false;
            }
        }

        private void update_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "" || txtAge.Text == "" || txtName.Text == "" || txtContact.Text == "" || txtBloodType.Text == "")
            {
                MessageBox.Show("Required Missing Fields", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DialogResult result = MessageBox.Show("Do you want to update this file?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    con.Open();
                    cmd = new OleDbCommand("UPDATE ListOfDonors SET [ID] = @ID,  [Dname] = @Dname, [Age] = @Age, [Contact] = @Contact, [BloodType] = @BloodType WHERE [ID] = @ID", con);
                    cmd.Parameters.AddWithValue("@ID", txtID.Text);
                    cmd.Parameters.AddWithValue("@Dname", txtName.Text);
                    cmd.Parameters.AddWithValue("@Age", txtAge.Text);
                    cmd.Parameters.AddWithValue("@Contact", txtContact.Text);
                    cmd.Parameters.AddWithValue("@BloodType", txtBloodType.Text);
                    int rowsaffected = cmd.ExecuteNonQuery();
                    con.Close();

                    if(rowsaffected > 0)
                    {
                        MessageBox.Show("Record Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Dispose();
                        //btnSave.Enabled = true;
                        //btnUpdate.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Record Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch(Exception ex)
                {
                    con.Close();
                    MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
