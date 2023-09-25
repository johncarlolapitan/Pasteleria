using Pastelería.GETSET;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pastelería.MAINC
{
    class transacv2
    {
        //Static String Method for Database Connection String
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;


        #region Select Method
        public DataTable Select()
        {
            //Creating Database Connection
            SqlConnection conn = new SqlConnection(myconnstrng);

            DataTable dtttt = new DataTable();

            try
            {
                //Wrting SQL Query to get all the data from DAtabase
                string sql = "SELECT * FROM tbltransv2";

                SqlCommand cmd = new SqlCommand(sql, conn);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                //Open DAtabase Connection
                conn.Open();
                //Adding the value from adapter to Data TAble dt
                adapter.Fill(dtttt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return dtttt;
        }
        #endregion
        #region Insert New CAtegory
        public bool Insert(transv2GETSET c)
        {
            //Creating A Boolean VAriable and set its default value to false
            bool isSucces = false;

            //Connecting to Database
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //Writing Query to Add New Category
                string sql = "INSERT INTO tbltransv2 (Cashier, Egg_Pie, Buko_Pie, Cashew_Tart, Choco_Tart, Dried_Mango_Piaya, Jackfruit_Empanada, transaction_date) VALUES (@Cashier, @Egg_Pie, @Buko_Pie, @Cashew_Tart, @Choco_Tart, @Dried_Mango_Piaya, @Jackfruit_Empanada , @transaction_date)";

                //Creating SQL Command to pass values in our query
                SqlCommand cmd = new SqlCommand(sql, conn);
                //Passing Values through parameter
                cmd.Parameters.AddWithValue("@Cashier", c.Cashier);
                cmd.Parameters.AddWithValue("@Egg_Pie", c.Egg_Pie);
                cmd.Parameters.AddWithValue("@Buko_Pie", c.Buko_Pie);
                cmd.Parameters.AddWithValue("@Cashew_Tart", c.Cashew_Tart);
                cmd.Parameters.AddWithValue("@Choco_Tart", c.Choco_Tart);
                cmd.Parameters.AddWithValue("@Dried_Mango_Piaya", c.Dried_Mango_Piaya);
                cmd.Parameters.AddWithValue("@Jackfruit_Empanada", c.Jackfruit_Empanada);
                cmd.Parameters.AddWithValue("@transaction_date", c.transaction_date);

                //Open Database Connection
                conn.Open();

                //Creating the int variable to execute query
                int rows = cmd.ExecuteNonQuery();

                //If the query is executed successfully then its value will be greater than 0 else it will be less than 0

                if (rows > 0)
                {
                    //Query Executed Succesfully
                    isSucces = true;
                }
                else
                {
                    //Failed to Execute Query
                    isSucces = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //Closing Database Connection
                conn.Close();
            }

            return isSucces;
        }
        #endregion

        #region METHOD TO GET CURRENT QUantity from the Database based on Product ID
        public decimal GetProductQty(int ProductID)
        {
            //SQl Connection First
            SqlConnection conn = new SqlConnection(myconnstrng);
            //Create a Decimal Variable and set its default value to 0
            decimal qty = 0;

            //Create Data Table to save the data from database temporarily
            DataTable dtttt = new DataTable();

            try
            {
                //Write WQL Query to Get Quantity from Database
                string sql = "SELECT qty FROM tbl_products WHERE product_id = " + ProductID;

                //Cerate A SqlCommand
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Create a SQL Data Adapter to Execute the query
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //open DAtabase Connection
                conn.Open();

                //PAss the calue from Data Adapter to DataTable
                adapter.Fill(dtttt);

                //Lets check if the datatable has value or not
                if (dtttt.Rows.Count > 0)
                {
                    qty = decimal.Parse(dtttt.Rows[0]["qty"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //Close Database Connection
                conn.Close();
            }

            return qty;
        }
        #endregion
        #region METHOD TO DECREASE PRODUCT
        public bool DecreaseProduct(int ProductID, decimal Qty)
        {
            //Create Boolean Variable and SEt its Value to false
            bool success = false;

            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //Get the Current product Quantity
                decimal currentQty = GetProductQty(ProductID);

                //Decrease the Product Quantity based on product sales
                decimal NewQty = currentQty - Qty;

                //Update Product in Database
                success = UpdateQuantity(ProductID, NewQty);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return success;
        }
        #endregion
        #region METHOD TO UPDATE QUANTITY
        public bool UpdateQuantity(int ProductID, decimal Qty)
        {
            //Create a Boolean Variable and Set its value to false
            bool success = false;

            //SQl Connection to Connect Database
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //Write the SQL Query to Update Qty
                string sql = "UPDATE tbl_products SET qty=@qty WHERE product_id=@product_id";

                //Create SQL Command to Pass the calue into Queyr
                SqlCommand cmd = new SqlCommand(sql, conn);
                //Passing the VAlue trhough parameters
                cmd.Parameters.AddWithValue("@qty", Qty);
                cmd.Parameters.AddWithValue("@product_id", ProductID);

                //Open Database Connection
                conn.Open();

                //Create Int Variable and Check whether the query is executed Successfully or not
                int rows = cmd.ExecuteNonQuery();
                //Lets check if the query is executed Successfully or not
                if (rows > 0)
                {
                    //Query Executed Successfully
                    success = true;
                }
                else
                {
                    //Failed to Execute Query
                    success = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return success;
        }
        #endregion
        public DataTable Select1()
        {
            //Creating Database Connection
            SqlConnection conn = new SqlConnection(myconnstrng);

            DataTable dtttt = new DataTable();

            try
            {
                //Wrting SQL Query to get all the data from DAtabase
                string sql = "SELECT * FROM tbl_products";

                SqlCommand cmd = new SqlCommand(sql, conn);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                //Open DAtabase Connection
                conn.Open();
                //Adding the value from adapter to Data TAble dt
                adapter.Fill(dtttt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return dtttt;
        }

        public bool voided(transv2GETSET c)
        {
            //Create a Boolean Variable and Set its value to false
            bool success = false;

            //SQl Connection to Connect Database
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //Write the SQL Query to Update Qty
                string sql = "UPDATE tbltransv2 SET Egg_Pie = @Egg_Pie, Buko_Pie = @Buko_Pie, Cashew_Tart = @Cashew_Tart, Choco_Tart = @Choco_Tart, Dried_Mango_Piaya = @Dried_Mango_Piaya, Jackfruit_Empanada = @Jackfruit_Empanada, Refund = @Refund WHERE Transaction_id = @Transaction_id";

                //Create SQL Command to Pass the calue into Queyr
                SqlCommand cmd = new SqlCommand(sql, conn);
                //Passing the VAlue trhough parameters
                cmd.Parameters.AddWithValue("@Egg_Pie", c.Egg_Pie);
                cmd.Parameters.AddWithValue("@Buko_Pie", c.Buko_Pie);
                cmd.Parameters.AddWithValue("@Cashew_Tart", c.Cashew_Tart);
                cmd.Parameters.AddWithValue("@Choco_Tart", c.Choco_Tart);
                cmd.Parameters.AddWithValue("@Dried_Mango_Piaya", c.Dried_Mango_Piaya);
                cmd.Parameters.AddWithValue("@Jackfruit_Empanada", c.Jackfruit_Empanada);
                cmd.Parameters.AddWithValue("@Refund", c.refund);
                cmd.Parameters.AddWithValue("@Transaction_id", c.Transaction_id);

                //Open Database Connection
                conn.Open();

                //Create Int Variable and Check whether the query is executed Successfully or not
                int rows = cmd.ExecuteNonQuery();
                //Lets check if the query is executed Successfully or not
                if (rows > 0)
                {
                    //Query Executed Successfully
                    success = true;
                }
                else
                {
                    //Failed to Execute Query
                    success = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return success;
        }



        //code for reports
        #region Delete Category Method
        public bool Delete(transv2GETSET c)
        {
            //Create a Boolean variable and set its value to false
            bool isSuccess = false;

            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //SQL Query to Delete from Database
                string sql = "DELETE FROM transv2 WHERE Transaction_id=@Transaction_id";

                SqlCommand cmd = new SqlCommand(sql, conn);
                //Passing the value using cmd
                cmd.Parameters.AddWithValue("@Transaction_id", c.Transaction_id);

                //Open SqlConnection
                conn.Open();

                int rows = cmd.ExecuteNonQuery();

                //If the query is executd successfully then the value of rows will be greater than zero else it will be less than 0
                if (rows > 0)
                {
                    //Query Executed Successfully
                    isSuccess = true;
                }
                else
                {
                    //Faied to Execute Query
                    isSuccess = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return isSuccess;
        }
        #endregion
    }
}
       

