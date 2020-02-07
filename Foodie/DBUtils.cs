using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace OnlineFoodOrdering
{
    class DBUtils
    {
        
        
        public SqlConnection ConnectionMethod()
        {
            SqlConnection sqlConnection = new SqlConnection(@"data source=DESKTOP-RLL3JF9\SQLEXPRESS;database=OnlineFoodOrdering;User Id=sa;Password=karthi");
            return sqlConnection;

        }
        /*public void AddDetailsToDatabase(List<Customer> details,SqlConnection sqlConnection)
        {
            string name;
            string phoneNumber;
            string mail;
            string password;
            string role;
            string query = "Registration";
            using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
            {    //SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query,sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter sqlParameter;
                sqlConnection.Open();
                Console.WriteLine("Connection opened");
                foreach (Customer customer in details)
                {
                    name = customer.FullName;
                    sqlParameter = new SqlParameter();
                    sqlParameter.ParameterName = "@FullName";
                    sqlParameter.Value = name;
                    sqlCommand.Parameters.Add(sqlParameter);
                    phoneNumber = customer.PhoneNumber;
                    sqlParameter = new SqlParameter();
                    sqlParameter.ParameterName = "@PhoneNumber";
                    sqlParameter.Value = phoneNumber;
                    sqlCommand.Parameters.Add(sqlParameter);
                    mail = customer.Mail;
                    sqlParameter = new SqlParameter();
                    sqlParameter.ParameterName = "@Mail";
                    sqlParameter.Value = mail;
                    sqlCommand.Parameters.Add(sqlParameter);
                    password = customer.Password;
                    sqlParameter = new SqlParameter();
                    sqlParameter.ParameterName = "@Password";
                    sqlParameter.Value = password;
                    sqlCommand.Parameters.Add(sqlParameter);
                    role = customer.Role;
                    sqlParameter = new SqlParameter();
                    sqlParameter.ParameterName = "@Role";
                    sqlParameter.Value = role;
                    sqlCommand.Parameters.Add(sqlParameter);
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }*/
        public bool CheckLogInDetails(string mail,string password,SqlConnection connection)
        {
            
            string query = "LogIn";
            using(SqlCommand sqlCommand =new SqlCommand(query,connection))
            {
                connection.Open();
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter sqlParameter=new SqlParameter();
               
               
                sqlCommand.Parameters.Add(sqlParameter);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlCommand.Parameters.Add("@Error",SqlDbType.VarChar,20);
                sqlCommand.Parameters["@Error"].Direction = ParameterDirection.Output;
                //sqlDataAdapter.SelectCommand = sqlCommand;
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count == 1)
                {
                    Console.WriteLine(sqlCommand.Parameters["@Error"].Value);
                    return true;
                }
                else
                {
                    Console.WriteLine(sqlCommand.Parameters["@Error"].Value);
                    return false;
                }
                    
            }
        }
        
    }
}
