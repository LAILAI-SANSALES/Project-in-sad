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
    public partial class Form3 : Form
    {
        frmDonor f = new frmDonor();
        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataReader dr;
        ConnectionDB db = new ConnectionDB();
        public Form3()
        {
            InitializeComponent();
            con = new OleDbConnection(db.GetConnection());
            LoadData();
        }


        public void LoadData()
        {
            dgvDList.Rows.Clear();
            int i = 0;
            con.Open();
            cmd = new OleDbCommand("SELECT * FROM ListOfDonors", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvDList.Rows.Add(i, dr["ID"].ToString(), dr["DName"].ToString(), dr["Age"].ToString(), dr["Contact"].ToString(), dr["BloodType"].ToString(), con);
            }
            dr.Close();
            con.Close();
        }



        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnAddDonor_Click(object sender, EventArgs e)
        {
            frmDonor f = new frmDonor();
            f.Show();
            f.BringToFront();
        }

        private void dgvDList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colname = dgvDList.Columns[e.ColumnIndex].Name;

            if (colname == "colEdit")
            {
                frmDonor f = new frmDonor();
                f.txtID.Text = dgvDList.Rows[e.RowIndex].Cells[1].Value.ToString();
                f.txtName.Text = dgvDList.Rows[e.RowIndex].Cells[2].Value.ToString();
                f.txtAge.Text = dgvDList.Rows[e.RowIndex].Cells[3].Value.ToString();
                f.txtContact.Text = dgvDList.Rows[e.RowIndex].Cells[4].Value.ToString();
                f.txtBloodType.Text = dgvDList.Rows[e.RowIndex].Cells[5].Value.ToString();
                f.ShowDialog();
                //LoadData();
                f.btnSave.Enabled = false;
            }
        }
    }
}
