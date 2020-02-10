using OnlineFoodOrder.Entity;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace OnlineFoodOrder.DAL
{
    public class CustomerRepository
    {

        SqlConnection sqlConnection;
        string connectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;


        public bool GetSignUpDetails(CustomerFields customerFields)
        {
            string query = "Sp_Registration";
            using (sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter sqlParameter = new SqlParameter();
                sqlCommand.Parameters.AddWithValue("@FullName", customerFields.FullName);
                sqlCommand.Parameters.AddWithValue("@PhoneNumber", customerFields.PhoneNumber);
                sqlCommand.Parameters.AddWithValue("@Mail", customerFields.Mail);
                sqlCommand.Parameters.AddWithValue("@Password", customerFields.Password);
                sqlCommand.Parameters.AddWithValue("@Role", customerFields.Role);
                sqlConnection.Open();
                int rows = sqlCommand.ExecuteNonQuery();
                if (rows >= 1)
                    return true;
                else
                {
                    return false;
                }
            }
        }
        public string GetLogInDetails(string mail, string password)
        {
            string query = "Sp_LogIn";
            using (sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter sqlParameter = new SqlParameter();
                sqlCommand.Parameters.AddWithValue("@Mail", mail);
                sqlCommand.Parameters.AddWithValue("@Password", password);
                sqlCommand.Parameters.Add("@Role", SqlDbType.VarChar, 10);
                sqlCommand.Parameters["@Role"].Direction = ParameterDirection.Output;
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                if (Convert.ToString(sqlCommand.Parameters["@Role"].Value) == "User" || Convert.ToString(sqlCommand.Parameters["@Role"].Value) == "Admin")
                {
                    return Convert.ToString(sqlCommand.Parameters["@Role"].Value);
                }
                else
                {
                    return "LogIn failed";
                }
            }
        }
    }
}
