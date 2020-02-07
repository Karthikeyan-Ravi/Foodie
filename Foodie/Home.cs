using System;
namespace OnlineFoodOrdering
{
    class Home
    {
        public static void Main(string[] args)
        {
            Portal portal = new Portal();
            portal.GetUserChoice();
            Console.ReadLine();
        }
    }
}
