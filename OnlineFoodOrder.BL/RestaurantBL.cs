using OnlineFoodOrder.DAL;
using OnlineFoodOrder.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFoodOrder.BL
{
    public class RestaurantBL
    {
        RestaurantRepository restaurantRepository = new RestaurantRepository(); 
        public DataTable DisplayRestaurantDetails()
        {
            return restaurantRepository.DisplayRestaurantDetails();
        }
        public void UpdateRestaurantDetails(string name, string type, string location, int id)
        {
            restaurantRepository.UpdateRestaurantDetails(name, type, location, id);
        }
        public void DeleteRestaurantDetails(int id)
        {
            restaurantRepository.DeleteRestaurantDetails(id);
        }
        public void InsertRestaurantDetails(RestaurantFields restaurantFields)
        {
            restaurantRepository.InsertRestaurantDetails(restaurantFields);
        }
    }
}
