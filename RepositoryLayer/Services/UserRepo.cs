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

    }
}
