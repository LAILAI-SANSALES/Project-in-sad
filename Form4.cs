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
using System.Xml.Linq;
namespace BloodBank
{
    public partial class Form4 : Form
    {
        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataReader dr;
        ConnectionDB db = new ConnectionDB();
        public Form4()
        {
            InitializeComponent();
            con = new OleDbConnection(db.GetConnection());
            LoadRecords();
        

        }

        public void LoadRecords()
        {
            dgvInventory.Rows.Clear();
            int i = 0;
            con.Open();
            cmd = new OleDbCommand("SELECT * FROM Inventory", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvInventory.Rows.Add(i, dr["ID"].ToString(), dr["BloodType"].ToString(), dr["Volume"].ToString(), DateTime.Parse(dr["IssueDate"].ToString()).ToShortDateString(), DateTime.Parse(dr["ExpiryDate"].ToString()).ToShortDateString(), con);
            }
            dr.Close();
            con.Close();
        }

    
        private void btnAddStocks_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "" || cmbBlood.Text == "" || txtVolume.Text == "" || dtpIssue.Text == "" || dtpExpiry.Text == "")
            {
                MessageBox.Show("Required Missing Fields", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                con.Open();
                cmd = new OleDbCommand("INSERT INTO Inventory (ID, BloodType, Volume, IssueDate, ExpiryDate) VALUES (@ID, @BloodType, @Volume, @IssueDate, @ExpiryDate)", con);
                cmd.Parameters.AddWithValue("@ID", txtID.Text);
                cmd.Parameters.AddWithValue("@BloodType", cmbBlood.Text);
                cmd.Parameters.AddWithValue("@Volume", txtVolume.Text);
                cmd.Parameters.AddWithValue("@IssueDate", dtpIssue);
                cmd.Parameters.AddWithValue("@ExpiryDate", dtpExpiry);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Successfully Saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadRecords();
             
                txtID.Text = "";
                cmbBlood.Text = "";
                txtVolume.Text = "";
                dtpIssue.Text = "";
                dtpExpiry.Text = "";
            }
        }

        
        private void dgvInventory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colname = dgvInventory.Columns[e.ColumnIndex].Name;

            if (colname == "colDelete")
            {
                if (MessageBox.Show("Do you want to delete this file?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    cmd = new OleDbCommand("DELETE FROM Inventory WHERE [ID] = @ID ", con);
                    cmd.Parameters.AddWithValue("ID", dgvInventory.Rows[e.RowIndex].Cells[1].Value.ToString());
                    cmd.Parameters.AddWithValue("BloodType", dgvInventory.Rows[e.RowIndex].Cells[2].Value.ToString());
                    cmd.Parameters.AddWithValue("Volume", dgvInventory.Rows[e.RowIndex].Cells[3].Value.ToString());
                    cmd.Parameters.AddWithValue("IssueDate", dgvInventory.Rows[e.RowIndex].Cells[4].Value.ToString());
                    cmd.Parameters.AddWithValue("ExpiryDate", dgvInventory.Rows[e.RowIndex].Cells[5].Value.ToString());
                    MessageBox.Show("Record Deleted", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);                  
                    cmd.ExecuteNonQuery();
                    con.Close();
                                    
                    LoadRecords();
                }
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            
          
         
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvInventory.Rows.Clear();
            int i = 0;
            con.Open();
            cmd = new OleDbCommand("SELECT * FROM Inventory WHERE [ID] = @ID", con);
            cmd.Parameters.AddWithValue("@ID", txtID.Text);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvInventory.Rows.Add(i, dr["ID"].ToString(), dr["BloodType"].ToString(), dr["Volume"].ToString(), DateTime.Parse(dr["IssueDate"].ToString()).ToShortDateString(), DateTime.Parse(dr["ExpiryDate"].ToString()).ToShortDateString(), con);
            }
            dr.Close();
            con.Close();
        }
    }
}
