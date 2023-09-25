using Pastelería.UI;
using System;
using System.Windows.Forms;

namespace Pastelería
{
    public partial class frmAdminDashboard : Form
    {

        // eto yung auto close
        // lagay mo nalang din sa userdashboard menuStrip
        // tapos palitan mo yung frmAdminDashboard ng frmUserDashboard (yung name ng form ng user)
        // check mo din yung close function ng x button ng login pinalitan ko
        public void closeForms()
        {
            for (int i = Application.OpenForms.Count - 1; i >= 2; i--)
            {
                if (Application.OpenForms[i].Name != "frmAdminDashboard")
                    Application.OpenForms[i].Close();
            }
        }



        public frmAdminDashboard()
        {
            InitializeComponent();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {

            closeForms();

            frmUsers user = new frmUsers();
            user.Show();
        }

        private void frmAdminDashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmLogin login = new frmLogin();
            login.Show();
            this.Hide();
        }

        private void frmAdminDashboard_Load(object sender, EventArgs e)
        {
            lblLoggedInUser.Text = frmLogin.loggedIn;
        }


        private void inventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pnlFooter_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblLoggedInUser_Click(object sender, EventArgs e)
        {

        }

        private void lblFooter_Click(object sender, EventArgs e)
        {

        }

        private void lblUser_Click(object sender, EventArgs e)
        {

        }

        private void menuStripTop_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeForms();

            frmReports rep = new frmReports();
            rep.Show();
        }

        private void transaction_Click(object sender, EventArgs e)
        {
           
        }

        private void productsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            closeForms();

            frmProducts product = new frmProducts();
            product.Show();
        }

        private void categoryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            closeForms();

            frmCategories category = new frmCategories();
            category.Show();
        }

        private void salesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeForms();

            frmReports rep = new frmReports();
            rep.Show();
        }

        private void inventoryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            closeForms();

            frmInventory inventory = new frmInventory();
            inventory.Show();
        }

        private void transactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeForms();

            frmtrans transaction = new frmtrans();
            transaction.Show();
        }
    }
}
