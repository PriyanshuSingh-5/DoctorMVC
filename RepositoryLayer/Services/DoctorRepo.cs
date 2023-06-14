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
    }
}
