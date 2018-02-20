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
    public class CustomerTier
    {
        public string connectionString { get; set; }
        public bool success { get; set; }

        public CustomerTier()
        {
            success = false;
            connectionString = ConfigurationManager.ConnectionStrings["myData"].ToString();
        }

        public List<Customer> getAllCustomers()
        {
            List<Customer> theList = null;
            Customer theCustomer;
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "SELECT * FROM Customers;";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader;

            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    theList = new List<Customer>();
                    while (reader.Read())
                    {
                        theCustomer = new Customer();
                        theCustomer.custID = (int)reader["custID"];
                        theCustomer.firstName = reader["firstName"].ToString();
                        theCustomer.lastName = reader["lastName"].ToString();
                        theCustomer.email = reader["email"].ToString();
                        theCustomer.address = reader["address"].ToString();
                        theCustomer.address2 = reader["address2"].ToString();
                        theCustomer.city = reader["city"].ToString();
                        theCustomer.state = reader["state"].ToString();
                        theCustomer.zip = (int)reader["zip"];

                        theList.Add(theCustomer);
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

        public bool insertCustomer(Customer cust)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "INSERT INTO Customers (firstName, lastName, email, address, address2, city, state, zip) " +
                "VALUES (@fName, @lName, @email, @address, @address2, @city, @state, @zip);";
            SqlCommand cmd = new SqlCommand(query, conn);
            int rows;

            cmd.Parameters.Add("@fName", SqlDbType.VarChar, 50).Value = cust.firstName;
            cmd.Parameters.Add("@lName", SqlDbType.VarChar, 50).Value = cust.lastName;
            cmd.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = cust.email;
            cmd.Parameters.Add("@address", SqlDbType.VarChar, 50).Value = cust.address;
            cmd.Parameters.Add("@address2", SqlDbType.VarChar, 50).Value = cust.address2;
            cmd.Parameters.Add("@city", SqlDbType.VarChar, 50).Value = cust.city;
            cmd.Parameters.Add("@state", SqlDbType.VarChar, 50).Value = cust.state;
            cmd.Parameters.Add("@zip", SqlDbType.Int).Value = cust.zip;

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

        public bool deleteCustomer(int custID)
        {
            int rows;
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "DELETE FROM Customers WHERE custID = @ID";
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = custID;

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

        public bool modifyCustomer(Customer theCustomer)   
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "UPDATE Customers SET " +
               "firstName = @fName, " +
               "lastName = @lName, " +
               "email = @email, " +
               "address = @address, " +
               "address2 = @address2, " +
               "city = @city, " +
               "state = @state, " +
               "zip = @zip " +
               "WHERE custID = @ID; ";
            SqlCommand cmd = new SqlCommand(query, conn);
            int rows;

            cmd.Parameters.Add("@fName", SqlDbType.VarChar, 50).Value = theCustomer.firstName;
            cmd.Parameters.Add("@lName", SqlDbType.VarChar, 50).Value = theCustomer.lastName;
            cmd.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = theCustomer.email;
            cmd.Parameters.Add("@address", SqlDbType.VarChar, 50).Value = theCustomer.address;
            cmd.Parameters.Add("@address2", SqlDbType.VarChar, 50).Value = theCustomer.address2;
            cmd.Parameters.Add("@city", SqlDbType.VarChar, 50).Value = theCustomer.city;
            cmd.Parameters.Add("@state", SqlDbType.VarChar, 50).Value = theCustomer.state;
            cmd.Parameters.Add("@zip", SqlDbType.Int).Value = theCustomer.zip;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = theCustomer.custID;

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

        public Customer getCustomerByID(int id)
        {
            Customer theCustomer = new Customer();
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "SELECT * FROM Customers WHERE custID = @ID;";
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
                    theCustomer.custID = (int)reader["custID"];
                    theCustomer.firstName = reader["firstName"].ToString();
                    theCustomer.lastName = reader["lastName"].ToString();
                    theCustomer.email = reader["email"].ToString();
                    theCustomer.address = reader["address"].ToString();
                    theCustomer.address2 = reader["address2"].ToString();
                    theCustomer.city = reader["city"].ToString();
                    theCustomer.state = reader["state"].ToString();
                    theCustomer.zip = (int)reader["zip"];
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

            return theCustomer;
        }
    }
}