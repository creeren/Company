using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Company.Models
{
    /// <summary>
    ///  Database connection logic for WorkTasks table
    /// </summary>
    public class WorkTaskService
    {
        private readonly SqlConnection _connection;
        private readonly SqlCommand _command;

        public WorkTaskService()
        {
            _connection = new SqlConnection(ConfigurationManager
                .ConnectionStrings["Company"].ConnectionString);
            _command = new SqlCommand
            {
                Connection = _connection,
                CommandType = CommandType.StoredProcedure
            };
        }

        public List<WorkTask> GetAll()
        {
            List<WorkTask> WorkTasksList = new List<WorkTask>();
            try
            {
                _command.Parameters.Clear();
                _command.CommandText = "dbo.spWorkTasksSelect";
                _connection.Open();

                var sqlDataReader = _command.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    WorkTask workTask = null;
                    while (sqlDataReader.Read())
                    {
                        workTask = new WorkTask
                        {
                            TaskId = sqlDataReader.GetInt32(0),
                            TaskTitle = sqlDataReader.GetString(1),
                            TaskDescription = sqlDataReader.GetString(2),
                            EmployeeId = sqlDataReader.GetInt32(3),
                            ComputerId = sqlDataReader.GetInt32(4)
                        };

                        WorkTasksList.Add(workTask);
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
            return WorkTasksList;
        }

        public bool Save(WorkTask newWorkTask)
        {
            bool IsSaved = false;
            try
            {
                _command.Parameters.Clear();
                _command.CommandText = "dbo.spWorkTasksAdd";
                _command.Parameters.AddWithValue("@TaskTitle", newWorkTask.TaskTitle);
                _command.Parameters.AddWithValue("@TaskDescription", newWorkTask.TaskDescription);
                _command.Parameters.AddWithValue("@EmployeeID", newWorkTask.EmployeeId);
                _command.Parameters.AddWithValue("@ComputerID", newWorkTask.ComputerId);

                _connection.Open();

                int rowsAffected = _command.ExecuteNonQuery();
                IsSaved = rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _connection.Close();
            }
            return IsSaved;
        }

        public bool Update(WorkTask newWorkTask)
        {
            bool IsUpdated = false;
            try
            {
                _command.Parameters.Clear();
                _command.CommandText = "dbo.spWorkTasksUpdate";
                _command.Parameters.AddWithValue("@TaskId", newWorkTask.TaskId);
                _command.Parameters.AddWithValue("@TaskTitle", newWorkTask.TaskTitle);
                _command.Parameters.AddWithValue("@TaskDescription", newWorkTask.TaskDescription);
                _command.Parameters.AddWithValue("@EmployeeId", newWorkTask.EmployeeId);
                _command.Parameters.AddWithValue("@ComputerId", newWorkTask.ComputerId);
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

        public bool Delete(int id)
        {
            bool IsDeleted = false;

            try
            {
                _command.Parameters.Clear();
                _command.CommandText = "dbo.spWorkTasksDelete";
                _command.Parameters.AddWithValue("@TaskId", id);

                _connection.Open();
                int rowsAffected = _command.ExecuteNonQuery();
                IsDeleted = rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _connection.Close();
            }
            return IsDeleted;
        }

        public List<WorkTask> Search(string title)
        {
            List<WorkTask> workTaskList = new List<WorkTask>();
            try
            {
                _command.Parameters.Clear();
                _command.CommandText = "dbo.spWorkTasksSearch";
                _command.Parameters.AddWithValue("@TaskTitle", title + '%');
                _connection.Open();

                var sqlDataReader = _command.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    WorkTask workTask = null;        
                    while (sqlDataReader.Read())
                    {
                        workTask = new WorkTask
                        {
                            TaskId = sqlDataReader.GetInt32(0),
                            TaskTitle = sqlDataReader.GetString(1),
                            TaskDescription = sqlDataReader.GetString(2),
                            EmployeeId = sqlDataReader.GetInt32(3),
                            ComputerId = sqlDataReader.GetInt32(4),
                        };                      
                        workTaskList.Add(workTask);
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
            return workTaskList;
        }
    }
}
