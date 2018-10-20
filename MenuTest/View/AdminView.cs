using MenuTest.Services;
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
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1. Manage users");
            Console.WriteLine("2. List users");
            Console.WriteLine("3. Exit");
            Console.Write("\n>");

            var input = Console.ReadKey(true);
            var userListHandler = new UserListHandler();

            switch (input.Key)
            {
                case ConsoleKey.D1:
                    var manageUserView = new ManageUserView2();
                    manageUserView.Display();
                    break;
                case ConsoleKey.D2:
                    Console.WriteLine();
                    userListHandler.PrintUserList(userListHandler.GetUserList());
                    Console.ReadKey();
                    Display();
                    break;
                case ConsoleKey.D3:
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Not a valid  option.");
                    Console.ReadKey();
                    Display();
                    break;
            }
        }   
    }
}
