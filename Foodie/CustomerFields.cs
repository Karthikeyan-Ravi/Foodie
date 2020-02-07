using System;
using System.Collections.Generic;
namespace OnlineFoodOrdering
{
    public class CustomerFields
    {
        public string FullName
        {
            get;
            set;
        }
        public double PhoneNumber
        {
            get;
            set;
        }
        public string Mail
        {
            get;
            set;
        }
        public string Password
        {
            get;
            set;
        }
        public string Role
        {
            get;
            set;
        }
        //public static List<CustomerAdminFields> userAdminDetails = new List<CustomerAdminFields>();
        public CustomerFields(string fullName,double phoneNumber,string mail,string password,string role)
        {
            this.FullName = fullName;
            this.PhoneNumber = phoneNumber;
            this.Mail = mail;
            this.Password = password;
            this.Role = role;
        }
    }
}
