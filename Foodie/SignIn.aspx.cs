using System;
using OnlineFoodOrder.BL;

namespace Foodie
{
    public partial class SignIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            CustomerBL customerBl = new CustomerBL(); 
            string result = customerBl.GetLogInDetails(txtEmail.Text, txtPassword.Text);
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