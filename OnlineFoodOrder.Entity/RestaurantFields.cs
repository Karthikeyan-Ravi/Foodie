using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFoodOrder.Entity
{
    public class RestaurantFields
    {
        public string RestaurantName
        {
            get;
            set;
        }
        public string RestaurantType
        {
            get;
            set;
        }
        public string Location
        {
            get;
            set;
        }
        public RestaurantFields(string restaurantName,string restaurantType,string location)
        {
            this.RestaurantName = restaurantName;
            this.RestaurantType = restaurantType;
            this.Location = location;
        }
    }
}
