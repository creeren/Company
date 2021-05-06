using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Company.Models
{
    /// <summary>
    ///  Database connection logic for Employees table
    /// </summary>
    public class EmployeeService
    {
        private readonly SqlConnection _connection;
        private readonly SqlCommand _command;

        public EmployeeService()
        {
            _connection = new SqlConnection(ConfigurationManager
                .ConnectionStrings["Company"].ConnectionString);
            _command = new SqlCommand
            {
                Connection = _connection,
                CommandType = CommandType.StoredProcedure
            };
        }

        public List<Employee> GetAll()
        {
            List<Employee> EmployeesList = new List<Employee>();
            try
            {
                _command.Parameters.Clear();
                _command.CommandText = "dbo.spEmployeesSelect";
                _connection.Open();

                var sqlDataReader = _command.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    Employee employee = null;

                    while (sqlDataReader.Read())
                    {
                        employee = new Employee
                        {
                            EmployeeId = sqlDataReader.GetInt32(0),
                            FirstName = sqlDataReader.GetString(1),
                            LastName = sqlDataReader.GetString(2),
                            PhoneNumber = sqlDataReader.GetString(3)
                        };
                        EmployeesList.Add(employee);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _connection.Close();
            }
            return EmployeesList;
        }

        public bool Save(Employee newEmployee)
        {
            bool IsSaved = false;
            try
            {
                _command.Parameters.Clear();
                _command.CommandText = "dbo.spEmployeesAdd";
                _command.Parameters.AddWithValue("@FirstName", newEmployee.FirstName);
                _command.Parameters.AddWithValue("@LastName", newEmployee.LastName);
                _command.Parameters.AddWithValue("PhoneNumber", newEmployee.PhoneNumber);

                _connection.Open();

                int rowsAffected = _command.ExecuteNonQuery();
                IsSaved = rowsAffected > 0;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                _connection.Close();
            }
            return IsSaved;
        }

        public bool Update(Employee newEmployee)
        {
            bool IsUpdated = false;
            try
            {
                _command.Parameters.Clear();
                _command.CommandText = "dbo.spEmployeesUpdate";
                _command.Parameters.AddWithValue("@EmployeeId", newEmployee.EmployeeId);
                _command.Parameters.AddWithValue("@FirstName", newEmployee.FirstName);
                _command.Parameters.AddWithValue("@LastName", newEmployee.LastName);
                _command.Parameters.AddWithValue("@PhoneNumber", newEmployee.PhoneNumber);

                _connection.Open();

                int rowsAffected = _command.ExecuteNonQuery();
                IsUpdated = rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _connection.Close();
            }
            return IsUpdated;
        }
    }
}
