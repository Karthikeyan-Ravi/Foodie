using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using OnlineFoodOrdering;

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
            CustomerRepository customerRepository = new CustomerRepository();
            DataTable data=customerRepository.DisplayRestaurantDetails();
            RestaurantDetails.DataSource = data;
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
            CustomerRepository customerRepository = new CustomerRepository();
            string restaurantName = (RestaurantDetails.Rows[e.RowIndex].FindControl("txtRestaurantName") as TextBox).Text;
            string restaurantType = (RestaurantDetails.Rows[e.RowIndex].FindControl("txtRestaurantType")as TextBox).Text;
            string location = (RestaurantDetails.Rows[e.RowIndex].FindControl("txtLocation")as TextBox).Text;
            int id = Convert.ToInt16(RestaurantDetails.DataKeys[e.RowIndex].Values["RestaurantId"].ToString());
            customerRepository.UpdateRestaurantDetails(restaurantName, restaurantType, location, id);
            RestaurantDetails.EditIndex = -1;
            DisplayRestaurantDetails();
            //customerRepository.UpdateRestaurantDetails(restaurantName, rstaurantType, id);
            //string query = "Sp_UpdateRestaurant";
            //using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            //{
            //    TextBox txtRestaurantName = RestaurantDetails.Rows[e.RowIndex].FindControl("txtRestaurantName") as TextBox;
            //    TextBox txtRestaurantType = RestaurantDetails.Rows[e.RowIndex].FindControl("txtRestaurantType") as TextBox;
            //    int id = Convert.ToInt16(RestaurantDetails.DataKeys[e.RowIndex].Values["RestaurantId"].ToString());
            //    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            //    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            //    sqlCommand.Parameters.AddWithValue("@RestaurantName", txtRestaurantName.Text);
            //    sqlCommand.Parameters.AddWithValue("@RestaurantType", txtRestaurantType.Text);
            //    sqlCommand.Parameters.AddWithValue("@RestaurantId", id);
            //    sqlConnection.Open();
            //    sqlCommand.ExecuteNonQuery();
            //    RestaurantDetails.EditIndex = -1;
            //    DisplayRestaurantDetails();
            //}
        }
        protected void RestaurantDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            CustomerRepository customerRepository = new CustomerRepository();
            int id = Convert.ToInt16(RestaurantDetails.DataKeys[e.RowIndex].Values["RestaurantId"].ToString());
            customerRepository.DeleteRestaurantDetails(id);
            DisplayRestaurantDetails();
            

        }
        public void OnClick_Insert()
        {
            CustomerRepository customerRepository = new CustomerRepository();
            string restaurantName = (RestaurantDetails.FooterRow.FindControl("txtInsertRestaurantName") as TextBox).Text;
            string restaurantType = (RestaurantDetails.FooterRow.FindControl("txtInsertRestaurantType") as TextBox).Text;
            string location = (RestaurantDetails.FooterRow.FindControl("txtInsertLocation") as TextBox).Text;
            customerRepository.InsertRestaurantDetails(restaurantName, restaurantType, location);
            DisplayRestaurantDetails();
        }
    }
}