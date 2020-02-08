using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlineFoodOrder.BL;
using OnlineFoodOrdering;

namespace Foodie
{
    public partial class SignIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            CustomerBl customerBl = new CustomerBl(); 
            string result = customerBl.GetLogInDetails(TextEmail.Text, TextPassword.Text);
            if (result == "Admin" || result == "User")
            {
                Response.Write(result + " LogIn successful");
            }
            else
            {
                Response.Write(result);
            }
        }
    }
}