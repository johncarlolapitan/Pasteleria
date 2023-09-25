using Pastelería.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pastelería
{
    public partial class frmUserDashboard : Form
    {
        public frmUserDashboard()
        {
            InitializeComponent();
        }

        public void closeForms()
        {
            for (int i = Application.OpenForms.Count - 1; i >= 2; i--)
            {
                if (Application.OpenForms[i].Name != "frmUserDashboard")
                    Application.OpenForms[i].Close();
            }
        }
        //Set a public static method to specify whether the form is purchase or sales
        public static string transactionType;
       

        private void frmUserDashboard_Load(object sender, EventArgs e)
        {
            lblLoggedInUser.Text = frmLogin.loggedIn;
        }

        private void frmUserDashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmLogin login = new frmLogin();
            login.Show();
            this.Hide();
        }

        private void ms1_Click(object sender, EventArgs e)
        {

        }

        private void ms2_Click(object sender, EventArgs e)
        {

        }

        private void ms3_Click_1(object sender, EventArgs e)
        {
            closeForms();

            frmInventory inventory = new frmInventory();
            inventory.Show();
        }

        private void ms2_Click_1(object sender, EventArgs e)
        {
            closeForms();

            //set value on transactionType static method
            transactionType = "Transaction";
            frmtrans purchase = new frmtrans();
            purchase.Show();
        }



        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void asdToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStripTop_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
