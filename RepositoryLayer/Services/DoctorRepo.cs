using CommonLayer.Models;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Services
{
    public class DoctorRepo : IDoctorRepo
    {
        readonly SqlConnection connection = new SqlConnection();
        readonly string sqlConnectString;
        private readonly IConfiguration config;
        //readonly string FetchAdminLoginRecordSQL = "FetchAdminLoginRecord";

        public DoctorRepo(IConfiguration config)
        {
            this.config = config;
            sqlConnectString = config.GetConnectionString("DBConnection");
            connection.ConnectionString = sqlConnectString;

        }

        public UserModel GetDocDetail(string EmailID)
        {
            try
            {
                //UserModel books = new UserModel();
                UserModel docs = new UserModel();
                using (connection)
                {
                    SqlCommand command = new SqlCommand("uspGetAllDocById", connection);

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("EmailID", EmailID);

                    connection.Open();
                    SqlDataReader Reader = command.ExecuteReader();


                    while (Reader.Read())
                    {


                        docs.UserID = Reader.IsDBNull("UserID") ? 0 : Reader.GetInt32("UserID");
                        docs.FullName = Reader.IsDBNull("FullName") ? string.Empty : Reader.GetString("FullName");
                        docs.EmailID = Reader.IsDBNull("EmailID") ? string.Empty : Reader.GetString("EmailID");
                        docs.Password = Reader.IsDBNull("Password") ? string.Empty : Reader.GetString("Password");
                        docs.ContactNo = Reader.IsDBNull("ContactNo") ? 0 : Reader.GetInt64("ContactNo");
                        docs.RoleID = Reader.IsDBNull("RoleID") ? 0 : Reader.GetInt32("RoleID");
                        docs.IsAccepted = (Reader.IsDBNull("IsAccepted") ? false : Reader.GetBoolean("IsAccepted"));

                        //books.Add(docs);
                    }
                    return docs;

                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        public DoctorModel AddDocDetails(DoctorModel Account)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("uspAddDoctorProfile", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("DoctorImage", Account.DoctorImage);
                cmd.Parameters.AddWithValue("Age", Account.Age);
                cmd.Parameters.AddWithValue("Gender", Account.Gender);
                cmd.Parameters.AddWithValue("Qualification", Account.Qualification);
                cmd.Parameters.AddWithValue("Experience", Account.Experience);
                cmd.Parameters.AddWithValue("UserID", Account.UserID);
                cmd.Parameters.AddWithValue("RoleID", Account.RoleID);
               
                cmd.Parameters.AddWithValue("CreatedAt", DateTime.Now);
                cmd.Parameters.AddWithValue("UpdatedAt", DateTime.Now);
                cmd.Parameters.AddWithValue("CategoryID", Account.CategoryID);
                var returnParameter = cmd.Parameters.Add("@Result", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;

                DoctorModel doctor = new DoctorModel();
                SqlDataReader rd = cmd.ExecuteReader();
                var result = returnParameter.Value;
                if (result != null && result.Equals(0))
                {
                    throw new Exception("No data added");
                }
                if (rd.Read())
                {
                    doctor.DoctorID = rd["DoctorID"] == DBNull.Value ? default : rd.GetInt32("DoctorID");
                    // patient.DOB = rd["FullName"] == DBNull.Value ? default : rd.GetString("FullName");
                    doctor.DoctorImage = rd["DoctorImage"] == DBNull.Value ? default : rd.GetString("DoctorImage");
                    //customer.Password = rd["Password"] == DBNull.Value ? default : rd.GetString("Password");
                    doctor.UserID = rd["UserID"] == DBNull.Value ? default : rd.GetInt32("UserID");
                    doctor.RoleID = rd["RoleID"] == DBNull.Value ? default : rd.GetInt32("RoleID");
                }

                return doctor;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        public DoctorModel GetDoctorDetails(int UserID)
        {
            try
            {
                //UserModel books = new UserModel();
                DoctorModel docs = new DoctorModel();
                using (connection)
                {
                    SqlCommand command = new SqlCommand("uspGetDoctorById", connection);

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("UserID", UserID);

                    connection.Open();
                    SqlDataReader Reader = command.ExecuteReader();


                    while (Reader.Read())
                    {


                        docs.UserID = Reader.IsDBNull("UserID") ? 0 : Reader.GetInt32("UserID");
                        docs.DoctorID = Reader.IsDBNull("DoctorID") ? 0 : Reader.GetInt32("DoctorID");
                        //docs.DOB = Reader.GetDateTime(1);
                        docs.DoctorImage = Reader.IsDBNull("DoctorImage") ? string.Empty : Reader.GetString("DoctorImage");
                        docs.Qualification = Reader.IsDBNull("Qualification") ? string.Empty : Reader.GetString("Qualification");
                        docs.Experience = Reader.IsDBNull("Experience") ? 0 : Reader.GetDouble("Experience");
                        docs.Gender = Reader.IsDBNull("Gender") ? string.Empty : Reader.GetString("Gender");


                        //books.Add(docs);
                    }
                    return docs;

                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        public List<DoctorModel> GetAllDoctorProfile()
        {
            //SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                List<DoctorModel> books = new List<DoctorModel>();
                using (connection)
                {
                    SqlCommand command = new SqlCommand("uspGetAllDoctorProfiles", connection);

                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();
                    SqlDataReader Reader = command.ExecuteReader();

                    if (Reader.HasRows)
                    {
                        while (Reader.Read())
                        {
                            DoctorModel docs = new DoctorModel()
                            {
                                UserID = Reader.IsDBNull("UserID") ? 0 : Reader.GetInt32("UserID"),
                                DoctorID = Reader.IsDBNull("DoctorID") ? 0 : Reader.GetInt32("DoctorID"),
                                DoctorImage = Reader.IsDBNull("DoctorImage") ? string.Empty : Reader.GetString("DoctorImage"),
                                Qualification = Reader.IsDBNull("Qualification") ? string.Empty : Reader.GetString("Qualification"),
                                Experience = Reader.IsDBNull("Experience") ? 0 : Reader.GetDouble("Experience"),
                                CategoryID = Reader.IsDBNull("CategoryID") ? 0 : Reader.GetInt32("CategoryID"),
                                Gender = Reader.IsDBNull("Gender") ? string.Empty : Reader.GetString("Gender"),
                              
                            };
                            books.Add(docs);
                        }
                        return books;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }


        public ScheduleModel AddScheduleAndLocation(ScheduleModel schedule)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("uspAddScheduleWithLocation", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("ScheduleTime", schedule.ScheduleTime);
                cmd.Parameters.AddWithValue("Location", schedule.Location);
                cmd.Parameters.AddWithValue("DoctorID", schedule.DoctorID);
                
                var returnParameter = cmd.Parameters.Add("@Result", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;

                ScheduleModel model = new ScheduleModel();
                SqlDataReader rd = cmd.ExecuteReader();
                var result = returnParameter.Value;
                if (result != null && result.Equals(0))
                {
                    throw new Exception("No data added");
                }
                if (rd.Read())
                {
                    model.DoctorID = rd["DoctorID"] == DBNull.Value ? default : rd.GetInt32("DoctorID");
                    //DateTime time = rd.GetDateTime(1);
                    // model.ScheduleTime = time.ToString("hh':'mm':'ss");
                    // Read the DateTime value from the column
                    //DateTime scheduleDateTime = rd.GetDateTime(1);

                    //// Extract the time component as a TimeSpan
                    //TimeSpan timeValue = scheduleDateTime.TimeOfDay;

                    //// Process the time value as needed
                    //model.ScheduleTime = DateTime.Today.Add(timeValue);
                    //string timeString = rd.GetTimeSpan(0).ToString();

                    //// Extract the hours and minutes part
                    //string formattedTime = timeString.Substring(0, 5);
                    model.ScheduleTime = rd.GetTimeSpan(1);
                    //// Assign the formatted time to the docs.DOB property
                    //model.ScheduleTime = formattedTime;
                    model.Location = rd["Location"] == DBNull.Value ? default : rd.GetString("Location");
                   
                }

                return model;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                connection.Close();
            }
        }


        public List<ScheduleModel> GetAllSchedules(int DoctorID)
        {
            //SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                List<ScheduleModel> schedules = new List<ScheduleModel>();
                using (connection)
                {
                    SqlCommand command = new SqlCommand("uspGetAllScheduleOfDOC", connection);

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("DoctorID", DoctorID);

                    connection.Open();
                    SqlDataReader Reader = command.ExecuteReader();

                    if (Reader.HasRows)
                    {
                        while (Reader.Read())
                        {
                            ScheduleModel docs = new ScheduleModel()
                            {
                                DoctorID = Reader.IsDBNull("DoctorID") ? 0 : Reader.GetInt32("DoctorID"),
                                ScheduleTime = Reader.GetTimeSpan(1),
                                Location = Reader.IsDBNull("Location") ? string.Empty : Reader.GetString("Location"),
                                
                            };
                            schedules.Add(docs);
                        }
                        return schedules;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
    }
}
