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
    public class ProductTier
    {
        public string connectionString { get; set; }
        public bool success { get; set; }

        public ProductTier()
        {
            connectionString = ConfigurationManager.ConnectionStrings["myData"].ToString();
            success = false;
        }

        public List<Product> getAllProducts()
        {
            List<Product> theList = null;
            Product theProduct;
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "SELECT * FROM Products;";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader;

            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    theList = new List<Product>();
                    while (reader.Read())
                    {
                        theProduct = new Product();
                        theProduct.prodID = (int)reader["prodID"];
                        theProduct.prodName = reader["prodName"].ToString();
                        theProduct.prodDesc = reader["prodDesc"].ToString();
                        theProduct.prodImg = (Byte[])reader["prodImg"];
                        theProduct.price = Double.Parse(reader["price"].ToString());
                        theProduct.inventory = (int)reader["inventory"];

                        theList.Add(theProduct);
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

        public bool insertProduct(Product prod)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "INSERT INTO Products (prodName, prodDesc, prodImg, price, inventory) " +
                "VALUES (@pName, @pDesc, @pImg, @price, @inv);";
            SqlCommand cmd = new SqlCommand(query, conn);
            int rows;

            cmd.Parameters.Add("@pName", SqlDbType.VarChar, 50).Value = prod.prodName;
            cmd.Parameters.Add("@pDesc", SqlDbType.VarChar, 250).Value = prod.prodDesc;
            cmd.Parameters.Add("@pImg", SqlDbType.Image).Value = prod.prodImg;
            cmd.Parameters.Add("@price", SqlDbType.Money).Value = prod.price;
            cmd.Parameters.Add("@inv", SqlDbType.Int).Value = prod.inventory;

            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
                if(rows > 0)
                {
                    success = true;
                }else
                {
                    success = false;
                }
            }catch(SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return success;
        }

        public bool deleteProduct(int prodID)
        {
            int rows;
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "DELETE FROM Products WHERE prodID = @prodID;";
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.Add("@prodID", SqlDbType.Int).Value = prodID;

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

        public bool modifyProduct(Product prod)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "UPDATE Products SET " +
                "prodName = @name, " +
                "prodDesc = @desc, " +
                "prodImg = @img, " +
                "price = @price, " +
                "inventory = @inventory " +
                "WHERE prodID = @ID;";
            SqlCommand cmd = new SqlCommand(query, conn);
            int rows;

            cmd.Parameters.Add("@name", SqlDbType.VarChar, 50).Value = prod.prodName;
            cmd.Parameters.Add("@desc", SqlDbType.VarChar, 250).Value = prod.prodDesc;
            cmd.Parameters.Add("@img", SqlDbType.Image).Value = prod.prodImg;
            cmd.Parameters.Add("@price", SqlDbType.Money).Value = prod.price;
            cmd.Parameters.Add("@inventory", SqlDbType.Int).Value = prod.inventory;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = prod.prodID;

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

        public Product getProductById(int id)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "SELECT * FROM Products WHERE prodID = @ID;";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader;
            Product theProduct = new Product();

            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;

            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                reader.Read();
                theProduct.prodID = (int)reader["prodID"];
                theProduct.prodName = reader["prodName"].ToString();
                theProduct.prodDesc = reader["prodDesc"].ToString();
                theProduct.prodImg = (Byte[])reader["prodImg"];
                theProduct.price = double.Parse(reader["price"].ToString());
                theProduct.inventory = (int)reader["inventory"];
            }
            catch(SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return theProduct;
        }

        public Byte[] getImage(int id)
        {
            Byte[] data = null;
            String query = "SELECT prodImg FROM Products WHERE prodID = @ID;";
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;

            try
            {
                conn.Open();
                data = (Byte[])cmd.ExecuteScalar();
            }
            catch(SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return data;
        }


    }
}