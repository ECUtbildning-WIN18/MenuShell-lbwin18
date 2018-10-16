using System;
using System.Threading;

namespace MenuTest.View
{
    class AdminView : BaseView
    {
        public AdminView() : base("Administrator")
        {

        }

        public void Display()
        {
            Console.Clear();
            Console.WriteLine("1. Manage users");
            Console.WriteLine("2. Exit");
            Console.Write("\n>");

            var input = Console.ReadKey();

            switch (input.Key)
            {
                case ConsoleKey.D1:
                    //Console.WriteLine("Manage User View");
                    ManageUserView manageUserView = new ManageUserView();
                    manageUserView.Display();
                    break;

                case ConsoleKey.D2:
                    Environment.Exit(1);
                    break;

                default:
                    Console.WriteLine("Not a valid  option.");
                    Thread.Sleep(2000);
                    Console.Clear();
                    Display();
                    break;
            }
        }   
    }
}
