namespace OnlineFoodOrder.Entity
{
    public class CustomerFields
    {
        public string FullName
        {
            get;
            set;
        }
        public long PhoneNumber
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
        public CustomerFields(string fullName, long phoneNumber, string mail, string password, string role)
        {
            this.FullName = fullName;
            this.PhoneNumber = phoneNumber;
            this.Mail = mail;
            this.Password = password;
            this.Role = role;
        }
    }
}
