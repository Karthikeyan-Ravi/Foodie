using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlineFoodOrdering;

namespace Foodie
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            CustomerRepository customerRepository = new CustomerRepository();
            CustomerFields customerFields = new CustomerFields(Txtname.Text, Convert.ToDouble(TxtPhone.Text), TxtEmail.Text, TxtPassword.Text,"User");
            bool result = customerRepository.GetSignUpDetails(customerFields);
            if (result == true)
            {
                Response.Write("Registration successful");
                Response.Redirect("SigIn.aspx");
            }
            else
                Response.Write("Registration failed");
        }
    }
}