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
    public partial class Home : Form
    {
        Form4 f = new Form4();
        public Home()
        {
            InitializeComponent();
            ProductCount();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        public void ProductCount()
        {
            int numberofbloods = f.dgvInventory.Rows.Count;
            txtTotal.Text = numberofbloods.ToString();
        } 
        
    private void Home_Load(object sender, EventArgs e)
        {
            
        }

        private void Loginpic_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.ShowDialog();
            
        }
    }
}
