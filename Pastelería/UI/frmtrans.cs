using Pastelería.GETSET;
using Pastelería.MAINC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pastelería.UI
{
    public partial class frmtrans : Form
    {
        int Product1, Product2, Product3, Product4, Product5, Product6;
        string stock1, stock2, stock3, stock4, stock5, stock6;

        cashierMainC dcDAL = new cashierMainC();
        productsMainC pDAL = new productsMainC();
        userMainC uDAL = new userMainC();

        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        //SQL Database
        SqlConnection conn = new SqlConnection(myconnstrng);
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        SqlDataReader dr;

        string mainSQL;

        //variables for sql
        string toDel;
        string query;
        int result;

        int toUpdate, toReduce;
        bool allowTrans;

        int a, b, t, d, v, f, g;


        public frmtrans()
        {
            InitializeComponent();
        }
        bool isRunning = true;
        private void frmtrans_Load(object sender, EventArgs e)
        {
            DataTable dt = dal.Select();
            dataGridView1.DataSource = dt;
            this.dataGridView1.ReadOnly = true;
            numericUpDown1.Select();

            //this.dataGridView1.Rows[0].Cells[0].Selected = false;


        }
     

        //variables-----------------------------------------------------------------------------------------------




        transv2GETSET trans = new transv2GETSET();
        transacv2 dal = new transacv2();
        userMainC udal = new userMainC();



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        int p;
        private void button15_Click(object sender, EventArgs e)
        {
            p++;
            numericUpDown6.Text = p.ToString();
        }

        private void dtpBillDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button15_Click_1(object sender, EventArgs e)
        {
            f++;
            numericUpDown6.Text = f.ToString();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            v++;
            numericUpDown5.Text = v.ToString();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            d++;
            numericUpDown4.Text = d.ToString();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            t++;
            numericUpDown3.Text = t.ToString();
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            b++;
            numericUpDown2.Text = b.ToString();
        }

      

       

        private void numericUpDown1_KeyPress(object sender, KeyPressEventArgs e)
        {
      //      if (e.KeyChar == (char)Keys.Q)
    //        {
    //            button16_Click(null, null);
     //       }
        }

        private void frmtrans_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void numericUpDown1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.Q)
            {
                button16.PerformClick();

            }
            else { }
            
            if (e.Control == true && e.KeyCode == Keys.W)
            {
                button11.PerformClick();
            }
            else { }
            if (e.Control == true && e.KeyCode == Keys.E)
            {
                button12.PerformClick();
            }
            else { }
            if (e.Control == true && e.KeyCode == Keys.A)
            {
                button13.PerformClick();
            }
            else { }
            if (e.Control == true && e.KeyCode == Keys.S)
            {
                button14.PerformClick();
            }
            else { }
            if (e.Control == true && e.KeyCode == Keys.D)
            {
                button15.PerformClick();
            }
            else { }

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {
            a++;
            numericUpDown1.Text = a.ToString();

        }
        transv2GETSET c = new transv2GETSET();

        private void button8_Click(object sender, EventArgs e)
        {

            trans.Egg_Pie = int.Parse(numericUpDown1.Text);
            trans.Buko_Pie = int.Parse(numericUpDown2.Text);
            trans.Cashew_Tart = int.Parse(numericUpDown3.Text);
            trans.Choco_Tart = int.Parse(numericUpDown4.Text);
            trans.Dried_Mango_Piaya = int.Parse(numericUpDown5.Text);
            trans.Jackfruit_Empanada = int.Parse(numericUpDown6.Text);
            trans.transaction_date = DateTime.Now;

            //Getting ID in Added by field
            string loggedUser = frmLogin.loggedIn;
            userGETSET usr = udal.GetIDFromUsername(loggedUser);
            //Passign the id of Logged in User in added by field
            trans.Cashier = usr.user_id;


            if (trans.Egg_Pie != 0 || trans.Buko_Pie != 0 || trans.Cashew_Tart != 0 || trans.Choco_Tart != 0 || trans.Dried_Mango_Piaya != 0 || trans.Jackfruit_Empanada != 0)
            {

                // check if there is a stock
                readStock1();
                readStock2();
                readStock3();
                readStock4();
                readStock5();
                readStock6();
                #region asdasd
                // condition for the stock
                stockCheck();
                if (allowTrans == true)
                {
                    // call all transaction, and update the database and records
                    Update_100();
                    Update_101();
                    Update_102();
                    Update_103();
                    Update_104();
                    Update_105();

                    //Creating Boolean Method To insert data into database
                    bool success = dal.Insert(trans);
                    if (success == true)
                    {
                        //NewCAtegory Inserted Successfully
                        //  MessageBox.Show("Process Complete");

                    }
                    else
                    {
                        // Failed to Insert 
                        MessageBox.Show("Failed");


                    }
                }
                #endregion
                else
                {
                    string outOfStockMessage = stock1 + stock2 + stock3 + stock4 + stock5 + stock6 + " is out of stock";
                    //MessageBox.Show("Cannot Be Process, Some Items You've Selected Is Out Of Stock");
                    MessageBox.Show(outOfStockMessage);
                }

            }
            else
            {
                MessageBox.Show("There's no order");
            }


            this.Close();
            frmtrans s = new frmtrans();
            s.Show();

        }

        #region Updates
        public void Update_100()
        {

            if (Product1 < trans.Egg_Pie)
            {

            }
            else
            {
                try
                {
                    //Insert_Transac();
                    toUpdate = Product1 - int.Parse(numericUpDown1.Text);
                    conn.Open();

                    string queryUpdate = "UPDATE tbl_products SET qty=" + toUpdate + "WHERE product_id= 1";
                    //string queryUpdate = "UPDATE tblProducts SET ProductQuantity=30 WHERE ProductId=100";

                    cmd.Connection = conn;
                    cmd.CommandText = queryUpdate;
                    result = cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        public void Update_101()
        {

            if (Product2 < trans.Buko_Pie)
            {

            }
            else
            {
                try
                {
                    //Insert_Transac();
                    toUpdate = Product2 - int.Parse(numericUpDown2.Text);
                    conn.Open();

                    string queryUpdate = "UPDATE tbl_products SET qty=" + toUpdate + "WHERE product_id= 2";
                    //string queryUpdate = "UPDATE tblProducts SET ProductQuantity=30 WHERE ProductId=100";

                    cmd.Connection = conn;
                    cmd.CommandText = queryUpdate;
                    result = cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public void Update_102()
        {

            if (Product3 < trans.Cashew_Tart)
            {

            }
            else
            {
                try
                {
                    //Insert_Transac();
                    toUpdate = Product3 - int.Parse(numericUpDown3.Text);
                    conn.Open();

                    string queryUpdate = "UPDATE tbl_products SET qty=" + toUpdate + "WHERE product_id= 3";
                    //string queryUpdate = "UPDATE tblProducts SET ProductQuantity=30 WHERE ProductId=100";

                    cmd.Connection = conn;
                    cmd.CommandText = queryUpdate;
                    result = cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }
        public void Update_103()
        {

            if (Product4 < trans.Choco_Tart)
            {

            }
            else
            {
                try
                {
                    //Insert_Transac();
                    toUpdate = Product4 - int.Parse(numericUpDown4.Text);
                    conn.Open();

                    string queryUpdate = "UPDATE tbl_products SET qty=" + toUpdate + "WHERE product_id= 4";
                    //string queryUpdate = "UPDATE tblProducts SET ProductQuantity=30 WHERE ProductId=100";

                    cmd.Connection = conn;
                    cmd.CommandText = queryUpdate;
                    result = cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }
        public void Update_104()
        {

            if (Product5 < trans.Dried_Mango_Piaya)
            {

            }
            else
            {
                try
                {
                    //Insert_Transac();
                    toUpdate = Product4 - int.Parse(numericUpDown5.Text);
                    conn.Open();

                    string queryUpdate = "UPDATE tbl_products SET qty=" + toUpdate + "WHERE product_id= 5";
                    //string queryUpdate = "UPDATE tblProducts SET ProductQuantity=30 WHERE ProductId=100";

                    cmd.Connection = conn;
                    cmd.CommandText = queryUpdate;
                    result = cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }
        public void Update_105()
        {

            if (Product5 < trans.Jackfruit_Empanada)
            {

            }
            else
            {
                try
                {
                    //Insert_Transac();
                    toUpdate = Product6 - int.Parse(numericUpDown6.Text);
                    conn.Open();

                    string queryUpdate = "UPDATE tbl_products SET qty=" + toUpdate + "WHERE product_id= 6";
                    //string queryUpdate = "UPDATE tblProducts SET ProductQuantity=30 WHERE ProductId=100";

                    cmd.Connection = conn;
                    cmd.CommandText = queryUpdate;
                    result = cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }
        #endregion

        public Boolean stockCheck()
        {
            if (Product1 >= trans.Egg_Pie && Product2 >= trans.Buko_Pie && Product3 >= trans.Cashew_Tart && Product4 >= trans.Choco_Tart && Product5 >= trans.Dried_Mango_Piaya && Product6 >= trans.Jackfruit_Empanada)
            {
                allowTrans = true;
            }
            else
            {
                allowTrans = false;
            }
            return allowTrans;
        }

        public void readStock1()
        {
            string qty1;
            try
            {
                conn.Open();
                string command = "SELECT qty FROM tbl_products WHERE product_id = 1";
                cmd.Connection = conn;
                cmd.CommandText = command;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    qty1 = (dr["qty"].ToString());
                    Product1 = int.Parse(qty1);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();

            // if the stock is 0
            // let know the system
            if (Product1 < trans.Egg_Pie)
            {
                stock1 = "Egg Pie, ";
            }
            else
            {
                stock1 = "";
            }
        }

        public void readStock2()
        {
            string qty1;
            try
            {
                conn.Open();
                string command = "SELECT qty FROM tbl_products WHERE product_id = 2";
                cmd.Connection = conn;
                cmd.CommandText = command;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    qty1 = (dr["qty"].ToString());
                    Product2 = int.Parse(qty1);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();

            // if the stock is 0
            // let know the system
            if (Product2 < trans.Buko_Pie)
            {
                stock2 = "Buko Pie, ";
            }
            else
            {
                stock2 = "";
            }
        }

        public void readStock3()
        {
            string qty1;
            try
            {
                conn.Open();
                string command = "SELECT qty FROM tbl_products WHERE product_id = 3";
                cmd.Connection = conn;
                cmd.CommandText = command;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    qty1 = (dr["qty"].ToString());
                    Product3 = int.Parse(qty1);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();

            // if the stock is 0
            // let know the system
            if (Product3 < trans.Cashew_Tart)
            {
                stock3 = "Cashew Tart, ";
            }
            else
            {
                stock3 = "";
            }
        }

        public void readStock4()
        {
            string qty1;
            try
            {
                conn.Open();
                string command = "SELECT qty FROM tbl_products WHERE product_id = 4";
                cmd.Connection = conn;
                cmd.CommandText = command;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    qty1 = (dr["qty"].ToString());
                    Product4 = int.Parse(qty1);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();

            // if the stock is 0
            // let know the system
            if (Product4 < trans.Choco_Tart)
            {
                stock4 = "Choco Tart, ";
            }
            else
            {
                stock4 = "";
            }
        }

        public void readStock5()
        {
            string qty1;
            try
            {
                conn.Open();
                string command = "SELECT qty FROM tbl_products WHERE product_id = 5";
                cmd.Connection = conn;
                cmd.CommandText = command;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    qty1 = (dr["qty"].ToString());
                    Product5 = int.Parse(qty1);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();

            // if the stock is 0
            // let know the system
            if (Product5 < trans.Dried_Mango_Piaya)
            {
                stock5 = "Dried Mango Piaya, ";
            }
            else
            {
                stock5 = "";
            }
        }

        public void readStock6()
        {
            string qty1;
            try
            {
                conn.Open();
                string command = "SELECT qty FROM tbl_products WHERE product_id = 6";
                cmd.Connection = conn;
                cmd.CommandText = command;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    qty1 = (dr["qty"].ToString());
                    Product6 = int.Parse(qty1);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();

            // if the stock is 0
            // let know the system
            if (Product6 < trans.Jackfruit_Empanada)
            {
                stock6 = "Jackfruit Empanada";
            }
            else
            {
                stock6 = "";
            }
       }
    }
}

