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

        public UserModel LoginAdmin(UserLogin loginCustomerAccount)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("uspUserLogin", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("EmailID", loginCustomerAccount.EmailID);
                cmd.Parameters.AddWithValue("Password", loginCustomerAccount.Password);
                var returnParameter = cmd.Parameters.Add("@Result", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;

               UserModel user = new UserModel();
                SqlDataReader rd = cmd.ExecuteReader();
                var result = returnParameter.Value;

                if (result != null && result.Equals(2))
                {
                    throw new Exception("Email not registered");
                }
               
                if (rd.Read())
                {
                    user.UserID = rd["UserID"] == DBNull.Value ? default : rd.GetInt32("UserID");
                    user.UserID = rd.GetInt32(0);
                    user.FullName = rd["FullName"] == DBNull.Value ? default : rd.GetString("FullName");
                    user.EmailID = rd["EmailID"] == DBNull.Value ? default : rd.GetString("EmailID");
                    user.Password = rd["Password"] == DBNull.Value ? default : rd.GetString("Password");
                    user.RoleID = rd["RoleID"] == DBNull.Value ? default : rd.GetInt32("RoleID");
                    user.IsAccepted= (rd.IsDBNull("IsAccepted") ? false : rd.GetBoolean("IsAccepted"));
                }
                return user;
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

        //public UserModel LoginAdmin(UserLogin loginModel)
        //{
        //    try
        //    {
        //        //using (SqlConnection con = new SqlConnection(this.iconfiguration.GetConnectionString("Hospital")))
        //        //{
        //            SqlCommand cmd = new SqlCommand("uspUserLogin", connection);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            connection.Open();
        //            cmd.Parameters.AddWithValue("EmailID", loginModel.EmailID);
        //            cmd.Parameters.AddWithValue("Password", loginModel.Password);


        //            var result = cmd.ExecuteScalar();

        //            if (result != null)
        //            {

        //                SqlDataReader reader = cmd.ExecuteReader();
        //                UserModel regiModel = new UserModel();


        //                while (reader.Read())
        //                {
        //                    regiModel.UserID = Convert.ToInt32(reader["UserID"]);
        //                    regiModel.FullName = reader["FullName"].ToString();
        //                    regiModel.EmailID = reader["EmailID"].ToString();
        //                    regiModel.Password = reader["Password"].ToString();
        //                    regiModel.RoleID = Convert.ToInt32(reader["RoleID"]);
        //            }
        //                //con.Close();
        //                return regiModel;
        //            }
        //            else
        //            {
        //                return null;
        //            }
        //       // }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public bool LoginAdmin(UserLogin loginAccount)
        //{
        //    try
        //    {
        //            SqlCommand cmd = new SqlCommand("uspUserLogin ", connection)
        //            {
        //                CommandType = CommandType.StoredProcedure
        //            };
        //            connection.Open();
        //            cmd.Parameters.AddWithValue("EmailID", loginAccount.EmailID);
        //            cmd.Parameters.AddWithValue("Password", loginAccount.Password);

        //            var result = cmd.ExecuteScalar();
        //        return true;


        //            //if (result != null)
        //            //{

        //            //    SqlDataReader reader = cmd.ExecuteReader();
        //            //    UserModel regiModel = new UserModel();


        //            //    while (reader.Read())
        //            //    {
        //            //        regiModel.UserID = Convert.ToInt32(reader["UserID"]);
        //            //        regiModel.FullName = reader["FullName"].ToString();
        //            //        regiModel.EmailID = reader["EmailID"].ToString();
        //            //        regiModel.Password = reader["Password"].ToString();
        //            //        regiModel.RoleID = Convert.ToInt32(reader["RoleID"]);
        //            //    }
        //            //    //con.Close();
        //            //    return regiModel;
        //            //}
        //            //else
        //            //{
        //            //    return null;
        //            //}

        //    }

        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //    finally
        //    {
        //        connection.Close();
        //    }
        //}


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
                    customer.UserID = rd["UserID"] == DBNull.Value ? default : rd.GetInt32("UserID");
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


       


       
    }

    }

