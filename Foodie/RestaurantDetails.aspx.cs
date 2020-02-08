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
using OnlineFoodOrder.Entity;
using OnlineFoodOrder.BL;

namespace Foodie
{
    public partial class DisplayDetails : System.Web.UI.Page
    {
        RestaurantFields restaurantFields;
        RestaurantBL restaurantBL;
        string connectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                DisplayRestaurantDetails();
        }
        protected void DisplayRestaurantDetails()
        {
            restaurantBL = new RestaurantBL();
            DataTable data=restaurantBL.DisplayRestaurantDetails();
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
            string restaurantName = (RestaurantDetails.Rows[e.RowIndex].FindControl("txtRestaurantName") as TextBox).Text;
            string restaurantType = (RestaurantDetails.Rows[e.RowIndex].FindControl("txtRestaurantType")as TextBox).Text;
            string location = (RestaurantDetails.Rows[e.RowIndex].FindControl("txtLocation")as TextBox).Text;
            int id = Convert.ToInt16(RestaurantDetails.DataKeys[e.RowIndex].Values["RestaurantId"].ToString());
            restaurantBL = new RestaurantBL();
            restaurantBL.UpdateRestaurantDetails(restaurantName, restaurantType, location, id);
            RestaurantDetails.EditIndex = -1;
            DisplayRestaurantDetails();
        }
        protected void RestaurantDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt16(RestaurantDetails.DataKeys[e.RowIndex].Values["RestaurantId"].ToString());
            restaurantBL = new RestaurantBL();
            restaurantBL.DeleteRestaurantDetails(id);
            DisplayRestaurantDetails();
            

        }
  
        protected void ButtonInsert_Click1(object sender, EventArgs e)
        {
            string restaurantName = (RestaurantDetails.FooterRow.FindControl("txtInsertRestaurantName") as TextBox).Text;
            string restaurantType = (RestaurantDetails.FooterRow.FindControl("txtInsertRestaurantType") as TextBox).Text;
            string location = (RestaurantDetails.FooterRow.FindControl("txtInsertLocation") as TextBox).Text;
            restaurantFields = new RestaurantFields(restaurantName, restaurantType, location);
            restaurantBL = new RestaurantBL();
            restaurantBL.InsertRestaurantDetails(restaurantFields);
            DisplayRestaurantDetails();
        }
    }
}