using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;

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
        public DataTable DisplayRestaurantDetails()
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                string query = "Sp_DisplayRestaurant";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                return dataTable;
                
            }
        }
        public void UpdateRestaurantDetails(string name,string type,string location, int id)
        {
            string query = "Sp_UpdateRestaurant";
            using (sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@RestaurantName", name);
                sqlCommand.Parameters.AddWithValue("@RestaurantType", type);
                sqlCommand.Parameters.AddWithValue("@Location", location);
                sqlCommand.Parameters.AddWithValue("@RestaurantId", id);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                DisplayRestaurantDetails();
            }
        }
        public void DeleteRestaurantDetails(int id)
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                string query = "Sp_DeleteRestaurant";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@RestaurantId", id);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();

            }
        }
        public void InsertRestaurantDetails(string restaurantName,string restaurantType,string location)
        {
            string query = "Sp_InsertRestaurant";
            using(sqlConnection=new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@RestaurantName", restaurantName);
                sqlCommand.Parameters.AddWithValue("@RestaurantType", restaurantType);
                sqlCommand.Parameters.AddWithValue("@Location", location);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                DisplayRestaurantDetails();
            }
        }
        
    }

}
