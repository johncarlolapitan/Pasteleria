using Pastelería.GETSET;
using Pastelería.MAINC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pastelería.UI
{
    public partial class frmReports : Form
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        SqlConnection conn = new SqlConnection(myconnstrng);
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        SqlDataReader dr;
        userMainC udal = new userMainC();
        frmReportsMainC pdal = new frmReportsMainC();
        transacv2 dbTrans = new transacv2();
        transv2GETSET c = new transv2GETSET();


        // for all the product variable
        int prd1, prd2, prd3, prd4, prd5, prd6, rowIndex;
        double total1, total2, total3, total4, total5, total6;

        // for the void functionality
        bool selectVoid;
        int zeroTrans = 0;
        string refunded = "Yes";

        public frmReports()
        {
            InitializeComponent();
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void frmReports_Load(object sender, EventArgs e)
        {
            // load all
            loadAll();
        }

        public OleDbConnection DBcon { get; private set; }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        public void SumOfA1()
        {
            try
            {
                conn.Open();
                string query = "SELECT SUM(Egg_Pie) FROM tbltransv2";
                cmd.Connection = conn;
                cmd.CommandText = query;
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    prd1 = Convert.ToInt32(dr[0]);
                    textBox1.Text = prd1.ToString();
                }
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Sum to  " + ex);
            }
        }

        public void SumOfB1()
        {
            try
            {
                conn.Open();
                string query = "SELECT SUM(Buko_Pie) FROM tbltransv2";
                cmd.Connection = conn;
                cmd.CommandText = query;
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    prd2 = Convert.ToInt32(dr[0]);
                    textBox2.Text = prd2.ToString();
                }
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Sum to  " + ex);
            }
        }

        public void SumOfC1()
        {
            try
            {
                conn.Open();
                string query = "SELECT SUM(Cashew_Tart) FROM tbltransv2";
                cmd.Connection = conn;
                cmd.CommandText = query;
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    prd3 = Convert.ToInt32(dr[0]);
                    textBox3.Text = prd3.ToString();
                }
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Sum to  " + ex);
            }
        }

        public void SumOfD1()
        {
            try
            {
                conn.Open();
                string query = "SELECT SUM(Choco_Tart) FROM tbltransv2";
                cmd.Connection = conn;
                cmd.CommandText = query;
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    prd4 = Convert.ToInt32(dr[0]);
                    textBox4.Text = prd4.ToString();
                }
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Sum to  " + ex);
            }
        }

        public void SumOfE1()
        {
            try
            {
                conn.Open();
                string query = "SELECT SUM(Dried_Mango_Piaya) FROM tbltransv2";
                cmd.Connection = conn;
                cmd.CommandText = query;
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    prd5 = Convert.ToInt32(dr[0]);
                    textBox5.Text = prd5.ToString();
                }
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Sum to  " + ex);
            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            rowIndex = e.RowIndex;
            selectVoid = true;
        }

        public void SumOfF1()
        {
            try
            {
                conn.Open();
                string query = "SELECT SUM(Jackfruit_Empanada) FROM tbltransv2";
                cmd.Connection = conn;
                cmd.CommandText = query;
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    prd6 = Convert.ToInt32(dr[0]);
                    textBox6.Text = prd6.ToString();
                }
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Sum to  " + ex);
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        public void totalA1()
        {
            total1 = prd1 * 74;
            textBox14.Text = total1.ToString();
        }
        public void totalB1()
        {
            total2 = prd2 * 125;
            textBox13.Text = total2.ToString();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        public void totalC1()
        {
            total3 = prd3 * 18.06;
            textBox12.Text = total3.ToString();
        }   

        public void totalD1()
        {
            total4 = prd4 * 45.40;
            textBox11.Text = total4.ToString();
        }
        public void totalE1()
        {
            total5 = prd5 * 42;
            textBox10.Text = total5.ToString();
        }
        public void totalF1()
        {
            total6 = prd6 * 60;
            textBox9.Text = total6.ToString();
        }

        public void totalall()
        {
            double total7 = 0;
            total7 = total1 + total2 + total3 + total4 + total5 + total6;
            textBox20.Text = total7.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectVoid == true)
            {
                // for the void button
                c.Transaction_id = int.Parse(dataGridView1.Rows[rowIndex].Cells[0].Value.ToString());
                c.Egg_Pie = zeroTrans;
                c.Buko_Pie = zeroTrans;
                c.Cashew_Tart = zeroTrans;
                c.Choco_Tart = zeroTrans;
                c.Dried_Mango_Piaya = zeroTrans;
                c.Jackfruit_Empanada = zeroTrans;
                c.refund = refunded;

                // update

                //Create a boolean variable to check if the product is updated or not
                bool success = dbTrans.voided(c);
                //If the prouct is updated successfully then the value of success will be true else it will be false
                if (success == true)
                {
                    //Product updated Successfully
                    MessageBox.Show("Refunded");
                    //REfresh the Data Grid View
                    loadAll();
                }
                else
                {
                    //Failed to Update Product
                    MessageBox.Show("Unable to refund");
                }
            }
            else {
                MessageBox.Show("Select a transaction data");
            }
        }

        public void loadAll() {
            selectVoid = false;
            DataTable pdt = pdal.Select();
            dataGridView1.DataSource = pdt;

            if (dataGridView1.RowCount != 0)
            {
                // if there is no transaction record

                // call all SUM functions
                SumOfA1();
                SumOfB1();
                SumOfC1();
                SumOfD1();
                SumOfE1();
                SumOfF1();

                // call the total of products
                totalA1();
                totalB1();
                totalC1();
                totalD1();
                totalE1();
                totalF1();

                //total all
                totalall();
            }
            else {
                MessageBox.Show("No record to show");
            }
        }
    }
}
