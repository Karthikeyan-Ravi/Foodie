using System;
namespace OnlineFoodOrdering
{
    public class Portal
    {
        //enum UserChoice
        //{
        //        customer,
        //        admin,
        //        exit
        //};
        enum UserChoice
        {
            SignUp,
            LogIn,
            Exit
        };
        public void GetUserChoice()
        {

            foreach (UserChoice userchoice in Enum.GetValues(typeof(UserChoice)))
            {
                Console.WriteLine("\n" + userchoice.ToString() + "\n");
            }
            Console.WriteLine("Enter the choice");
            string choice = Console.ReadLine();
            UserChoice userChoice = (UserChoice)Enum.Parse(typeof(UserChoice), choice);
            //Admin admin = new Admin();
            CustomerRepository customerRepository = new CustomerRepository();
            switch (userChoice)
            {
                case UserChoice.SignUp:
                    {
                        //ustomerRepository.GetSignUpDetails();
                    }
                    break;
                case UserChoice.LogIn:
                    {
                        //customerRepository.GetLogInDetails();
                    } break;
                case UserChoice.Exit:
                    {

                    }break;
            }
        }
    }
}
            
                
