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
    }
}
