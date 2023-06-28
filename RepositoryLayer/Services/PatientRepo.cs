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
    public class PatientRepo :IPatientRepo
    {
        readonly SqlConnection connection = new SqlConnection();
        readonly string sqlConnectString;
        private readonly IConfiguration config;
        //readonly string FetchAdminLoginRecordSQL = "FetchAdminLoginRecord";

        public PatientRepo(IConfiguration config)
        {
            this.config = config;
            sqlConnectString = config.GetConnectionString("DBConnection");
            connection.ConnectionString = sqlConnectString;

        }

        public PatientModel AddPatientDetails(PatientModel Account)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("uspAddPatientProfile", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("DOB", Account.DOB);
                cmd.Parameters.AddWithValue("Gender", Account.Gender);
                cmd.Parameters.AddWithValue("BloodGroup", Account.BloodGroup);
                cmd.Parameters.AddWithValue("PatientImage", Account.PatientImage);
                cmd.Parameters.AddWithValue("HealthConcern", Account.HealthConcern);
                cmd.Parameters.AddWithValue("MedicalHistory", Account.MedicalHistory);
                cmd.Parameters.AddWithValue("InsuranceProvider", Account.InsuranceProvider);
                cmd.Parameters.AddWithValue("UserID", Account.UserID);
                cmd.Parameters.AddWithValue("CreatedAt", DateTime.Now);
                cmd.Parameters.AddWithValue("UpdatedAt", DateTime.Now);
                var returnParameter = cmd.Parameters.Add("@Result", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;

                PatientModel patient = new PatientModel();
                SqlDataReader rd = cmd.ExecuteReader();
                var result = returnParameter.Value;
                if (result != null && result.Equals(0))
                {
                    throw new Exception("No data added");
                }
                if (rd.Read())
                {
                    patient.PatientID= rd["PatientID"] == DBNull.Value ? default : rd.GetInt32("PatientID");
                   // patient.DOB = rd["FullName"] == DBNull.Value ? default : rd.GetString("FullName");
                    patient.PatientImage = rd["PatientImage"] == DBNull.Value ? default : rd.GetString("PatientImage");
                    //customer.Password = rd["Password"] == DBNull.Value ? default : rd.GetString("Password");
                    patient.UserID = rd["UserID"] == DBNull.Value ? default : rd.GetInt32("UserID");
                }

                return patient;
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

        public PatientModel GetPatientDetails(int UserID)
        {
            try
            {
                //UserModel books = new UserModel();
                PatientModel docs = new PatientModel();
                using (connection)
                {
                    SqlCommand command = new SqlCommand("uspGetPatientById", connection);

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("UserID", UserID);

                    connection.Open();
                    SqlDataReader Reader = command.ExecuteReader();


                    while (Reader.Read())
                    {


                        docs.UserID = Reader.IsDBNull("UserID") ? 0 : Reader.GetInt32("UserID");
                        docs.PatientID = Reader.IsDBNull("PatientID") ? 0 : Reader.GetInt32("PatientID");
                        docs.DOB = Reader.GetDateTime(1);
                        docs.PatientImage = Reader.IsDBNull("PatientImage") ? string.Empty : Reader.GetString("PatientImage");
                        docs.MedicalHistory = Reader.IsDBNull("MedicalHistory") ? string.Empty : Reader.GetString("MedicalHistory");
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

        public List<PatientModel> GetAllPatientProfile()
        {
            //SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                List<PatientModel> patients = new List<PatientModel>();
                using (connection)
                {
                    SqlCommand command = new SqlCommand("uspGetAllPatients", connection);

                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();
                    SqlDataReader Reader = command.ExecuteReader();

                    if (Reader.HasRows)
                    {
                        while (Reader.Read())
                        {
                            PatientModel docs = new PatientModel()
                            {
                                UserID = Reader.IsDBNull("UserID") ? 0 : Reader.GetInt32("UserID"),
                                PatientID = Reader.IsDBNull("PatientID") ? 0 : Reader.GetInt32("PatientID"),
                                PatientImage = Reader.IsDBNull("PatientImage") ? string.Empty : Reader.GetString("PatientImage"),
                                DOB = Reader.GetDateTime(1),
                                HealthConcern = Reader.IsDBNull("HealthConcern") ? string.Empty : Reader.GetString("HealthConcern"),
                                MedicalHistory = Reader.IsDBNull("MedicalHistory") ? string.Empty : Reader.GetString("MedicalHistory"),
                                Gender = Reader.IsDBNull("Gender") ? string.Empty : Reader.GetString("Gender"),

                            };
                            patients.Add(docs);
                        }
                        return patients;
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



        /* Appointment APIS */

        public AppointmentModel AddAppointments(AppointmentModel Account)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("uspAddAppointment", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("Concerns", Account.Concerns);
                cmd.Parameters.AddWithValue("Appointmentdate", Account.Appointmentdate);
                cmd.Parameters.AddWithValue("StartTime", Account.StartTime);
                cmd.Parameters.AddWithValue("EndTime", Account.EndTime);
                cmd.Parameters.AddWithValue("DoctorID", Account.DoctorID);
                cmd.Parameters.AddWithValue("PatientID", Account.PatientID);
                cmd.Parameters.AddWithValue("ScheduleID", Account.ScheduleID);
                cmd.Parameters.AddWithValue("CreatedAt", DateTime.Now);
                cmd.Parameters.AddWithValue("UpdatedAt", DateTime.Now);
                var returnParameter = cmd.Parameters.Add("@Result", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;

                AppointmentModel appointment = new AppointmentModel();
                SqlDataReader rd = cmd.ExecuteReader();
                var result = returnParameter.Value;
                if (result != null && result.Equals(0))
                {
                    throw new Exception("No data added");
                }
                if (rd.Read())
                {
                    appointment.DoctorID= rd["DoctorID"] == DBNull.Value ? default : rd.GetInt32("DoctorID");
                    appointment.PatientID = rd["PatientID"] == DBNull.Value ? default : rd.GetInt32("PatientID");
                    appointment.Concerns = rd["Concerns"] == DBNull.Value ? default : rd.GetString("Concerns");
                    appointment.Appointmentdate = rd.GetDateTime(2);
                    appointment.StartTime = rd.GetTimeSpan(3);
                    appointment.EndTime = rd.GetTimeSpan(4);
                   
                }

                return appointment;
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


        public List<AppointmentModel> GetAppointmentByPatientID(int PatientID)
        {
            try
            {

                List<AppointmentModel> data = new List<AppointmentModel>();
                using (connection)
                {
                    SqlCommand command = new SqlCommand("uspGetAppointmentByPatientID", connection);

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("PatientID", PatientID);

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
