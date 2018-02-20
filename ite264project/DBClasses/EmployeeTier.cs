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
    public class EmployeeTier
    {
        public string connectionString { get; set; }
        public bool success { get; set; }

        public EmployeeTier()
        {
            connectionString = ConfigurationManager.ConnectionStrings["myData"].ToString();
            success = false;
        }

        public List<Employee> getAllEmployees()
        {
            List<Employee> theList = null;
            Employee theEmployee = new Employee();
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "SELECT * FROM Employees;";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader;

            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        theList = new List<Employee>();
                        theEmployee = new Employee();
                        theEmployee.empID = (int)reader["EmpID"];
                        theEmployee.firstName = reader["firstName"].ToString();
                        theEmployee.lastName = reader["lastName"].ToString();
                        theEmployee.email = reader["email"].ToString();
                        theEmployee.address = reader["address"].ToString();
                        theEmployee.address2 = reader["address2"].ToString();
                        theEmployee.city = reader["city"].ToString();
                        theEmployee.state = reader["state"].ToString();
                        theEmployee.zip = (int)reader["zip"];
                        theEmployee.hireDate = (DateTime)reader["hireDate"];
                        theEmployee.termDate = (DateTime)reader["termDate"];

                        theList.Add(theEmployee);
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

        public bool insertEmployee(Employee theEmployee)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "INSERT INTO Employees (firstName, lastName, email, address, address2, city, state, zip, hireDate, termDate) " +
                "VALUES (@fName, @lName, @email, @add, @add2, @city, @state, @zip, @hDate, @tDate);";
            SqlCommand cmd = new SqlCommand(query, conn);
            int rows;

            cmd.Parameters.Add("@fName", SqlDbType.VarChar, 50).Value = theEmployee.firstName;
            cmd.Parameters.Add("@lName", SqlDbType.VarChar, 50).Value = theEmployee.lastName;
            cmd.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = theEmployee.email;
            cmd.Parameters.Add("@add", SqlDbType.VarChar, 50).Value = theEmployee.address;
            cmd.Parameters.Add("@add2", SqlDbType.VarChar, 50).Value = theEmployee.address2;
            cmd.Parameters.Add("@city", SqlDbType.VarChar, 50).Value = theEmployee.city;
            cmd.Parameters.Add("@state", SqlDbType.VarChar, 50).Value = theEmployee.state;
            cmd.Parameters.Add("@zip", SqlDbType.Int).Value = theEmployee.zip;
            cmd.Parameters.Add("@hDate", SqlDbType.Date).Value = theEmployee.hireDate;
            cmd.Parameters.Add("@tDate", SqlDbType.Date).Value = theEmployee.termDate;

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

        public bool deleteEmployee(int empID)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "DELETE FROM Employees WHERE EmpID = @ID;";
            SqlCommand cmd = new SqlCommand(query, conn);
            int rows;

            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = empID;

            try
            {
                rows = cmd.ExecuteNonQuery();
                if(rows > 0)
                {
                    success = true;
                }else
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

        public bool modifyEmployee(Employee theEmployee)
        {
            int rows;
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "UPDATE Employees SET " +
                "firstName = @fName, " +
                "lastName = @lName, " +
                "email = @email, " +
                "address = @address, "+
                "address2 = @address2, " +
                "city = @city, " +
                "state = @state, " +
                "zip = @zip, " +
                "hireDate = @hDate, " +
                "termDate = @tDate " +
                "WHERE EmpID = @ID;";
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.Add("@fName", SqlDbType.VarChar, 50).Value = theEmployee.firstName;
            cmd.Parameters.Add("@lName", SqlDbType.VarChar, 50).Value = theEmployee.lastName;
            cmd.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = theEmployee.email;
            cmd.Parameters.Add("@address", SqlDbType.VarChar, 50).Value = theEmployee.address;
            cmd.Parameters.Add("@address2", SqlDbType.VarChar, 50).Value = theEmployee.address2;
            cmd.Parameters.Add("@city", SqlDbType.VarChar, 50).Value = theEmployee.city;
            cmd.Parameters.Add("@state", SqlDbType.VarChar, 50).Value = theEmployee.state;
            cmd.Parameters.Add("@zip", SqlDbType.Int).Value = theEmployee.zip;
            cmd.Parameters.Add("@hDate", SqlDbType.Date).Value = theEmployee.hireDate;
            cmd.Parameters.Add("@tDate", SqlDbType.Date).Value = theEmployee.termDate;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = theEmployee.empID;


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

        public Employee getEmployeeByID(int id)
        {
            Employee theEmployee = new Employee();
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "SELECT * FROM Employees WHERE EmpID = @ID";
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
                    theEmployee.empID = (int)reader["EmpID"];
                    theEmployee.firstName = reader["firstName"].ToString();
                    theEmployee.lastName = reader["lastName"].ToString();
                    theEmployee.email = reader["email"].ToString();
                    theEmployee.address = reader["address"].ToString();
                    theEmployee.address2 = reader["address2"].ToString();
                    theEmployee.city = reader["city"].ToString();
                    theEmployee.state = reader["state"].ToString();
                    theEmployee.zip = (int)reader["zip"];
                    theEmployee.hireDate = (DateTime)reader["hireDate"];
                    theEmployee.termDate = (DateTime)reader["termDate"];
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

            return theEmployee;
        }
    }
}