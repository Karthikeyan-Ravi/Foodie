using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

namespace OnlineFoodOrdering
{
    public class CustomerRepository
    {
        //string logInMail;
        //string logInPassword;
        SqlConnection sqlConnection;
        string connectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;


        public bool GetSignUpDetails(CustomerFields customerFields)
        {
            string query = "Registration";
            //DBUtils dBUtils = new DBUtils();
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
                int rows=sqlCommand.ExecuteNonQuery();
                if (rows >= 1)
                    return true;
                else
                {
                    return false;
                }
            }
            //Customer customer = new Customer(fullName, phoneNumber, mail, password,"user");
            //userDetails.Add(customer);
            ///DBUtils dBUtils = new DBUtils();
            //dBUtils.ConnectionMethod();
            //dBUtils.AddDetailsToDatabase(userDetails, dBUtils.ConnectionMethod());
            //Console.WriteLine("Registration successful");
        }
        public string GetLogInDetails(string mail,string password)
        {
            //logInMail = Validation.GetLogInMail();
            //logInPassword = Validation.GetLogInPassword();
            //DBUtils dBUtils = new DBUtils();
            //dBUtils.CheckLogInDetails(logInMail,logInPassword,dBUtils.ConnectionMethod());
            string query = "LogIn";
            using (sqlConnection=new SqlConnection(connectionString))
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
                if (Convert.ToString(sqlCommand.Parameters["@Role"].Value)=="User"|| Convert.ToString(sqlCommand.Parameters["@Role"].Value)=="Admin")
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
