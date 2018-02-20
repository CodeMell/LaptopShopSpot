using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;
using ite264project.DataModel;

namespace ite264project.DBClasses
{
    public class OrderTier
    {
        public string connectionString { get; set; }
        public bool success { get; set; }

        public OrderTier()
        {
            connectionString = ConfigurationManager.ConnectionStrings["myData"].ToString();
            success = false;
        }

        public List<Order> getAllOrders()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "SELECT * FROM Orders;";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader;
            List<Order> theList = null;
            Order theOrder = new Order();

            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    theList = new List<Order>();
                    while (reader.Read())
                    {
                        theOrder = new Order();
                        theOrder.orderID = (int)reader["orderID"];
                        theOrder.custID = (int)reader["custID"];
                        theOrder.cartID = (Guid)reader["cartID"];
                        theOrder.total = double.Parse(reader["total"].ToString());
                        theOrder.dateOfSale = (DateTime)reader["dateOfSale"];
                        theOrder.taxRate = double.Parse(reader["taxRate"].ToString());
                        theOrder.discount = double.Parse(reader["discount"].ToString());

                        theList.Add(theOrder);
                    }
                }
            }
            catch(SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return theList;
        }

        public bool insertOrder(Order theOrder)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "INSERT INTO Orders (custID, cartID, total, dateOfSale, taxRate, discount) " +
                "VALUES (@custID, @cartID, @total, @dateOfSale, @taxRate, @discount);";
            SqlCommand cmd = new SqlCommand(query, conn);
            int rows;

            cmd.Parameters.Add("@custID", SqlDbType.Int).Value = theOrder.custID;
            cmd.Parameters.Add("@cartID", SqlDbType.UniqueIdentifier).Value = theOrder.cartID;
            cmd.Parameters.Add("@total", SqlDbType.Money).Value = theOrder.total;
            cmd.Parameters.Add("@dateOfSale", SqlDbType.Date).Value = theOrder.dateOfSale;
            cmd.Parameters.Add("@taxRate", SqlDbType.Real).Value = theOrder.taxRate;
            cmd.Parameters.Add("@discount", SqlDbType.Real).Value = theOrder.discount;

            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
                if(rows > 0)
                {
                    success = true;
                }
                else
                {
                    success = false;
                }
            }
            catch(SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return success;
        }

        public bool deleteOrder(int id)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "DELETE FROM Orders WHERE orderID = @ID";
            SqlCommand cmd = new SqlCommand(query, conn);
            int rows;

            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;

            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
                if(rows > 0)
                {
                    success = true;
                }
                else
                {
                    success = false;
                }
            }
            catch(SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return success;
        }

        public bool modifyOrder(Order theOrder)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "UPDATE Orders SET " +
                "custID = @custID, " +
                "cartID = @cartID, " +
                "total = @total, " +
                "dateOfSale = @dateOfSale, " +
                "taxRate = @taxRate, " +
                "discount = @discount " +
                "WHERE orderID = @ID;";
            SqlCommand cmd = new SqlCommand(query, conn);
            int rows;

            cmd.Parameters.Add("@custID", SqlDbType.Int).Value = theOrder.custID;
            cmd.Parameters.Add("@cartID", SqlDbType.UniqueIdentifier).Value = theOrder.cartID;
            cmd.Parameters.Add("@total", SqlDbType.Money).Value = theOrder.total;
            cmd.Parameters.Add("@dateOfSale", SqlDbType.Date).Value = theOrder.dateOfSale;
            cmd.Parameters.Add("@taxRate", SqlDbType.Real).Value = theOrder.taxRate;
            cmd.Parameters.Add("@discount", SqlDbType.Real).Value = theOrder.discount;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = theOrder.orderID;

            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
                if(rows > 0)
                {
                    success = true;
                }
                else
                {
                    success = false;
                }
            }
            catch(SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return success;
        }

        public Order getOrderByID(int id)
        {
            Order theOrder = new Order();
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "SELECT * FROM Orders WHERE orderID = @ID;";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader;

            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;

            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    theOrder.orderID = (int)reader["orderID"];
                    theOrder.custID = (int)reader["custID"];
                    theOrder.cartID = (Guid)reader["cartID"];
                    theOrder.total = double.Parse(reader["total"].ToString());
                    theOrder.dateOfSale = DateTime.Parse(reader["dateOfSale"].ToString());
                    theOrder.taxRate = double.Parse(reader["taxRate"].ToString());
                    theOrder.discount = double.Parse(reader["discount"].ToString());
                }
            }
            catch(SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return theOrder;
        }

        public Order getOrderByCartID(int id)
        {
            Order theOrder = new Order();
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "SELECT * FROM Orders WHERE cartID = @ID;";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader;

            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;

            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    theOrder.orderID = (int)reader["orderID"];
                    theOrder.custID = (int)reader["custID"];
                    theOrder.cartID = (Guid)reader["cartID"];
                    theOrder.total = double.Parse(reader["total"].ToString());
                    theOrder.dateOfSale = DateTime.Parse(reader["dateOfSale"].ToString());
                    theOrder.taxRate = double.Parse(reader["taxRate"].ToString());
                    theOrder.discount = double.Parse(reader["discount"].ToString());
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return theOrder;
        }

        public Order getLastOrder()
        {
            Order theOrder = new Order();
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "SELECT TOP 1 * FROM Orders ORDER BY orderID DESC;";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader;


            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    theOrder.orderID = (int)reader["orderID"];
                    theOrder.custID = (int)reader["custID"];
                    theOrder.cartID = (Guid)reader["cartID"];
                    theOrder.total = double.Parse(reader["total"].ToString());
                    theOrder.dateOfSale = DateTime.Parse(reader["dateOfSale"].ToString());
                    theOrder.taxRate = double.Parse(reader["taxRate"].ToString());
                    theOrder.discount = double.Parse(reader["discount"].ToString());
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return theOrder;
        }
    }
}