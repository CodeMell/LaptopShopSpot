using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using ite264project.DataModel;

namespace ite264project.DBClasses
{
    public class OrderDetailTier
    {
        protected string connectionString { get; set; }
        protected bool success { get; set; }

        public OrderDetailTier()
        {
            connectionString = ConfigurationManager.ConnectionStrings["myData"].ToString();
            success = false;
        }

        public List<OrderDetail> getAllOrderDetails()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "SELECT * FROM OrderDetails;";
            SqlCommand cmd = new SqlCommand(query, conn);
            List<OrderDetail> theList = new List<OrderDetail>();
            SqlDataReader reader;
            OrderDetail theOrder;

            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    theList = new List<OrderDetail>();
                    while (reader.Read())
                    {
                        theOrder = new OrderDetail();
                        theOrder.orderID = (int)reader["orderID"];
                        theOrder.prodID = (int)reader["prodID"];
                        theOrder.quantitySold = (int)reader["quantitySold"];

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

        public bool insertOrderDetail(OrderDetail theOrd) 
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "INSERT INTO OrderDetails (orderID, prodID, quantitySold) VALUES (@orderID, @prodID, @quan);";
            SqlCommand cmd = new SqlCommand(query, conn);
            int rows;

            cmd.Parameters.Add("@orderID", SqlDbType.Int).Value = theOrd.orderID;
            cmd.Parameters.Add("@prodID", SqlDbType.Int).Value = theOrd.prodID;
            cmd.Parameters.Add("@quan", SqlDbType.Int).Value = theOrd.quantitySold;

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

        public bool deleteOrderDetail(int orderID, int prodID)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "DELETE FROM OrderDetails WHERE orderID = @orderID and prodID = @prodID;";
            SqlCommand cmd = new SqlCommand(query, conn);
            int rows;

            cmd.Parameters.Add("@orderID", SqlDbType.Int).Value = orderID;
            cmd.Parameters.Add("@prodID", SqlDbType.Int).Value = prodID;

            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    success = true;
                }
                else
                {
                    success = false;
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

            return success;
        }

        public bool modifyOrderDetail(OrderDetail theOrd)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "UPDATE OrderDetails SET " +
                "quantitySold = @quan " +
                "WHERE orderID = @orderID and prodID = @prodID;";
            SqlCommand cmd = new SqlCommand(query, conn);
            int rows;

            cmd.Parameters.Add("@orderID", SqlDbType.Int).Value = theOrd.orderID;
            cmd.Parameters.Add("@prodID", SqlDbType.Int).Value = theOrd.prodID;
            cmd.Parameters.Add("@quan", SqlDbType.Int).Value = theOrd.quantitySold;

            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    success = true;
                }
                else
                {
                    success = false;
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

            return success;
        }

        public OrderDetail getOrderDetailByID(int orderID, int prodID)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "SELECT * FROM OrderDetails WHERE orderID = @orderID and prodID = @prodID;";
            SqlCommand cmd = new SqlCommand(query, conn);
            OrderDetail theOrderDetail = new OrderDetail();
            SqlDataReader reader;

            cmd.Parameters.Add("@orderID", SqlDbType.Int).Value = orderID;
            cmd.Parameters.Add("@prodID", SqlDbType.Int).Value = prodID;

            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    theOrderDetail.orderID = orderID;
                    theOrderDetail.prodID = prodID;
                    theOrderDetail.quantitySold = (int)reader["quantitySold"];
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

            return theOrderDetail;
        }

        public List<OrderDetail> getFullOrder(int orderID)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "SELECT * FROM OrderDetails WHERE orderID = @orderID;";
            SqlCommand cmd = new SqlCommand(query, conn);
            List<OrderDetail> theList = new List<OrderDetail>();
            SqlDataReader reader;
            OrderDetail theOrder;

            cmd.Parameters.Add("@orderID", SqlDbType.Int).Value = orderID;
            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    theList = new List<OrderDetail>();
                    while (reader.Read())
                    {
                        theOrder = new OrderDetail();
                        theOrder.orderID = (int)reader["orderID"];
                        theOrder.prodID = (int)reader["prodID"];
                        theOrder.quantitySold = (int)reader["quantitySold"];

                        theList.Add(theOrder);
                    }
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

            return theList;
        }

        public bool deleteFullOrder(int orderID)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "DELETE FROM OrderDetails WHERE orderID = @orderID;";
            SqlCommand cmd = new SqlCommand(query, conn);
            int rows;

            cmd.Parameters.Add("@orderID", SqlDbType.Int).Value = orderID;

            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    success = true;
                }
                else
                {
                    success = false;
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

            return success;
        }
    }
}