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
    public class AdminRepo: IAdminRepo
    {
        readonly SqlConnection connection = new SqlConnection();
        readonly string sqlConnectString;
        private readonly IConfiguration config;
        //readonly string FetchAdminLoginRecordSQL = "FetchAdminLoginRecord";

        public AdminRepo(IConfiguration config)
        {
            this.config = config;
            sqlConnectString = config.GetConnectionString("DBConnection");
            connection.ConnectionString = sqlConnectString;

        }

        public List<UserModel> GetAllDocs()
        {
            //SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                List<UserModel> books = new List<UserModel>();
                using (connection)
                {
                    SqlCommand command = new SqlCommand("uspGetAllDoctors", connection);

                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();
                    SqlDataReader Reader = command.ExecuteReader();

                    if (Reader.HasRows)
                    {
                        while (Reader.Read())
                        {
                            UserModel docs = new UserModel()
                            {
                                UserID = Reader.IsDBNull("UserID") ? 0 : Reader.GetInt32("UserID"),
                                FullName = Reader.IsDBNull("FullName") ? string.Empty : Reader.GetString("FullName"),
                                EmailID = Reader.IsDBNull("EmailID") ? string.Empty : Reader.GetString("EmailID"),
                                Password = Reader.IsDBNull("Password") ? string.Empty : Reader.GetString("Password"),
                                ContactNo = Reader.IsDBNull("ContactNo") ? 0 : Reader.GetInt64("ContactNo"),
                                RoleID = Reader.IsDBNull("RoleID") ? 0 : Reader.GetInt32("RoleID"),
                                IsAccepted = Reader.IsDBNull("IsAccepted") ? false : Reader.GetBoolean("IsAccepted"),
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

        public List<AppointmentModel> GetAllAppointment()
        {
            try
            {

                List<AppointmentModel> data = new List<AppointmentModel>();
                using (connection)
                {
                    SqlCommand command = new SqlCommand("uspGetAllAppointments", connection);

                    command.CommandType = CommandType.StoredProcedure;
                    //command.Parameters.AddWithValue("PatientID", PatientID);

                    connection.Open();
                    SqlDataReader Reader = command.ExecuteReader();

                    if (Reader.HasRows)
                    {

                        while (Reader.Read())
                        {
                            AppointmentModel docs = new AppointmentModel()
                            {

                                // docs.DoctorID = Reader.IsDBNull("UserID") ? 0 : Reader.GetInt32("UserID");
                                DoctorID = Reader.IsDBNull("DoctorID") ? 0 : Reader.GetInt32("DoctorID"),
                                //docs.DOB = Reader.GetDateTime(1);
                                Appointmentdate = Reader.GetDateTime(2),
                                StartTime = Reader.GetTimeSpan(3),
                                EndTime = Reader.GetTimeSpan(4)
                                //docs.Gender = Reader.IsDBNull("Gender") ? string.Empty : Reader.GetString("Gender");
                            };
                            data.Add(docs);


                        }
                        return data;

                    }
                    return null;
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
    }
}
