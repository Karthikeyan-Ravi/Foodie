using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;

namespace Foodie
{
    public partial class DisplayDetails : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                DisplayRestaurantDetails();
        }
        protected void DisplayRestaurantDetails()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            string query = "Sp_DisplayRestaurant";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            RestaurantDetails.DataSource = dataTable;
            RestaurantDetails.DataBind();
        }

        protected void RestaurantDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            RestaurantDetails.EditIndex = -1;
            DisplayRestaurantDetails();
        }

        protected void RestaurantDetails_RowEditing(object sender, GridViewEditEventArgs e)
        {
            RestaurantDetails.EditIndex = e.NewEditIndex;
            DisplayRestaurantDetails();
        }

        protected void RestaurantDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string query = "Sp_UpdateRestaurant";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                TextBox txtRestaurantName = RestaurantDetails.Rows[e.RowIndex].FindControl("txtRestaurantName") as TextBox;
                TextBox txtRestaurantType = RestaurantDetails.Rows[e.RowIndex].FindControl("txtRestaurantType") as TextBox;
                int id = Convert.ToInt16(RestaurantDetails.DataKeys[e.RowIndex].Values["RestaurantId"].ToString());
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@RestaurantName", txtRestaurantName.Text);
                sqlCommand.Parameters.AddWithValue("@RestaurantType", txtRestaurantType.Text);
                sqlCommand.Parameters.AddWithValue("@RestaurantId", id);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                RestaurantDetails.EditIndex = -1;
                DisplayRestaurantDetails();
            }
        }

        protected void RestaurantDetails_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

        protected void RestaurantDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            using(SqlConnection sqlConnection=new SqlConnection(connectionString))
            {
                string query = "Sp_DeleteRestaurant";
                int id = Convert.ToInt16(RestaurantDetails.DataKeys[e.RowIndex].Values["RestaurantId"].ToString());
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@RestaurantId", id);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                DisplayRestaurantDetails();
            }

        }
    }
}