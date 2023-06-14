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
    }
}
