using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace OnlineFoodOrdering
{
    public static class Validation 
    {
        public static string fullName;
        public static string phoneNumber;
        public static string mail;
        public static string password;
        public static string logInMail;
        public static string logInPassword;
        public static string GetAndValidateName()
        {
            try
            {
                
                fullName = Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "Re-enter the name");
                GetAndValidateName();
            }
            if (fullName.Length < 4)
            {
                Console.WriteLine("Entered name is too small");
                GetAndValidateName();
            }
            if (fullName != null)
            {
                int index = 3;
                for (int i = 0; i < fullName.Length - 2; i++)
                {
                    if ((fullName.Substring(i, index).Equals(fullName.Substring(i, index)) == false))
                    {
                        Console.WriteLine("Invalid string");
                        GetAndValidateName();
                    }
                }
            }
            Regex check = new Regex(@"^[A-Za-z\s]{1,}[\.]{0,1}[A-Za-z\s]{0,}$");
            if (check.IsMatch(fullName) == false)
            {
                Console.WriteLine("Enter the correct name");
                GetAndValidateName();
            }
            return (fullName);
        }
        public static string GetAndValidatePhoneNumber()
        {
            try
            {
                phoneNumber = Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "Re-enter the phone number");
                GetAndValidatePhoneNumber();
            }
            Regex check = new Regex(@"^[6789]\d{9}$");
            if (check.IsMatch(phoneNumber) == false)
            {
                Console.WriteLine("Invalid phone number");
                GetAndValidatePhoneNumber();
            }
            return phoneNumber;
        }
        public static string GetAndValidateMail()
        {
            try
            {
                mail = Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "Re-enter the mail address");
                GetAndValidateMail();
            }
            Regex check = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            if (check.IsMatch(mail) == false)
            {
                Console.WriteLine("Invalid email id");
                GetAndValidateMail();
            }
            return mail;
        }
        public static string GetAndValidatePassword()
        {
            try
            {
                password = Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "Re-enter the password");
                GetAndValidatePassword();
            }
            Regex regex = new Regex(@"^(?=.{8,})(?=.*[a-z])(?=.*[A-Z])(?!.*\s).*$");
            if ((regex.IsMatch(password)) == false)
            {
                Console.WriteLine("Enter the password in correct format");
                GetAndValidatePassword();
            }
            return password;
        }
        public static string GetLogInMail()
        {
            try
            {
                Console.WriteLine("Enter the registered email address");
                logInMail = Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                GetLogInMail();
            }
            Regex regex = new Regex((@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"));
            if (regex.IsMatch(logInMail) == false)
            {
                Console.WriteLine("Invalid email id");
                GetLogInMail();
            }
            return logInMail;
        }
        public static string GetLogInPassword()
        {
            try
            {
                Console.WriteLine("Enter the password");
                logInPassword = Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                GetLogInPassword();
            }
            Regex regex = new Regex(@"^(?=.{8,})(?=.*[a-z])(?=.*[A-Z])(?!.*\s).*$");
            if ((regex.IsMatch(logInPassword)) == false)
            {
                Console.WriteLine("Enter the password in correct format");
                GetLogInPassword();
            }
            return logInPassword;
        }
        //public static bool ValidateLogInDetails(List<CustomerFields> details)
        //{
        //    foreach (CustomerFields customer in details)
        //    {
        //        if (((customer.Mail).Equals(logInMail)) && ((customer.Password).Equals(logInPassword)))
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}
    }
}
