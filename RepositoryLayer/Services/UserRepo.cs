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
    public class UserRepo : IUserRepo
    {
        readonly SqlConnection connection = new SqlConnection();
        readonly string sqlConnectString;
        private readonly IConfiguration config;
        //readonly string FetchAdminLoginRecordSQL = "FetchAdminLoginRecord";

        public UserRepo(IConfiguration config)
        {
            this.config = config;
            sqlConnectString = config.GetConnectionString("DBConnection");
            connection.ConnectionString = sqlConnectString;

        }


        public bool LoginAdmin(UserLogin loginAccount)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("uspUserLogin ", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("AdminID", loginAccount.EmailID);
                cmd.Parameters.AddWithValue("Password", loginAccount.Password);
                var returnParameter = cmd.Parameters.Add("@Result", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;


                var result = returnParameter.Value;
                if (result != null && result.Equals(2))
                {
                    throw new Exception("AdminID is invalid");
                }

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }


        public UserModel RegisterCustomer(UserModel registerAccount)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("uspRegisterUser", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("FullName", registerAccount.FullName);
                cmd.Parameters.AddWithValue("EmailID", registerAccount.EmailID);
                cmd.Parameters.AddWithValue("Password", registerAccount.Password);
                cmd.Parameters.AddWithValue("ContactNo", registerAccount.ContactNo);
                cmd.Parameters.AddWithValue("RoleID", registerAccount.RoleID);
                cmd.Parameters.AddWithValue("CreatedAt", DateTime.Now);
                cmd.Parameters.AddWithValue("UpdatedAt", DateTime.Now);
                var returnParameter = cmd.Parameters.Add("@Result", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;

                UserModel customer = new UserModel();
                SqlDataReader rd = cmd.ExecuteReader();
                var result = returnParameter.Value;
                if (result != null && result.Equals(2))
                {
                    throw new Exception("Email already registered");
                }
                if (rd.Read())
                {
                    customer.UserID = rd["UserID"] == DBNull.Value ? default : rd.GetInt64("UserID");
                    customer.FullName = rd["FullName"] == DBNull.Value ? default : rd.GetString("FullName");
                    customer.EmailID = rd["EmailID"] == DBNull.Value ? default : rd.GetString("EmailID");
                    //customer.Password = rd["Password"] == DBNull.Value ? default : rd.GetString("Password");
                    customer.ContactNo = rd["ContactNo"] == DBNull.Value ? default : rd.GetInt64("ContactNo");
                }

                return customer;
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
                                UserID = Reader.IsDBNull("UserID") ? 0 : Reader.GetInt64("UserID"),
                                FullName = Reader.IsDBNull("FullName") ? string.Empty : Reader.GetString("FullName"),
                                EmailID = Reader.IsDBNull("EmailID") ? string.Empty : Reader.GetString("EmailID"),
                                Password = Reader.IsDBNull("Password") ? string.Empty : Reader.GetString("Password"),
                                ContactNo = Reader.IsDBNull("ContactNo") ? 0 : Reader.GetInt64("ContactNo"),
                                RoleID = Reader.IsDBNull("RoleID") ? 0 : Reader.GetInt32("RoleID"),
                                IsAccepted = Reader.IsDBNull("IsAccepted") ? false :Reader.GetBoolean("IsAccepted"),
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


                        docs.UserID = Reader.IsDBNull("UserID") ? 0 : Reader.GetInt64("UserID");
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

