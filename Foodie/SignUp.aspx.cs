using System;
using OnlineFoodOrder.BL;
using OnlineFoodOrder.Entity;

namespace Foodie
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            CustomerFields customerFields = new CustomerFields(txtname.Text,long.Parse((txtPhone.Text)), txtEmail.Text, txtPassword.Text,"User");
            CustomerBL customerBl = new CustomerBL(); 
            bool result = customerBl.GetSignUpDetails(customerFields);
            if (result == true)
            {
                Response.Write("Registration successful");
                Response.Redirect("SignIn.aspx");
            }
            else
                Response.Write("Registration failed");
        }

        protected void SignInButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("SignIn.aspx");
        }
    }
}