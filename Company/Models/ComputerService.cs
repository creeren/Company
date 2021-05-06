using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Company.Models
{
    /// <summary>
    ///  Database connection logic for Computers table
    /// </summary>
    public class ComputerService
    {
        private readonly SqlConnection _connection;
        private readonly SqlCommand _command;

        public ComputerService()
        {
            _connection = new SqlConnection(ConfigurationManager
                .ConnectionStrings["Company"].ConnectionString);
            _command = new SqlCommand
            {
                Connection = _connection,
                CommandType = CommandType.StoredProcedure
            };
        }

        public List<Computer> GetAll()
        {
            List<Computer> computersList = new List<Computer>();
            try
            {
                _command.Parameters.Clear();
                _command.CommandText = "dbo.spComputersSelect";
                _connection.Open();
                
                var sqlDataReader = _command.ExecuteReader();             
                if (sqlDataReader.HasRows)
                {
                    Computer computer = null;                  
                    while (sqlDataReader.Read())
                    {
                        computer = new Computer
                        {
                            ComputerId = sqlDataReader.GetInt32(0),
                            ComputerName = sqlDataReader.GetString(1),
                            Notes = sqlDataReader.GetString(2)
                        };
                        computersList.Add(computer);
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
            return computersList;
        }

        public bool Save(Computer newComputer)
        {
            bool IsSaved = false;
            try
            {
                _command.Parameters.Clear();
                _command.CommandText = "dbo.spComputersAdd";
                _command.Parameters.AddWithValue("@ComputerName", newComputer.ComputerName);
                _command.Parameters.AddWithValue("@Notes", newComputer.Notes);

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

        public bool Update(Computer newComputer)
        {
            bool IsUpdated = false;
            try
            {
                _command.Parameters.Clear();
                _command.CommandText = "dbo.spComputersUpdate";
                _command.Parameters.AddWithValue("@ComputerId", newComputer.ComputerId);
                _command.Parameters.AddWithValue("@ComputerName", newComputer.ComputerName);
                _command.Parameters.AddWithValue("@Notes", newComputer.Notes);

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
