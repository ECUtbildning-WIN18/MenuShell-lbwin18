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
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.WriteLine("1. Manage users");
            Console.WriteLine("2. List users");
            Console.WriteLine("3. Exit");
            Console.Write("\n>");

            var input = Console.ReadKey();
            var manageUserView = new ManageUserView();
            var userListHandler = new UserListHandler();

            switch (input.Key)
            {
                case ConsoleKey.D1:
                    manageUserView.Display();
                    break;
                case ConsoleKey.D2:
                    Console.SetCursorPosition(0, 4);
                    Console.ForegroundColor = ConsoleColor.Green;
                    userListHandler.PrintUserList(userListHandler.GetUserList());
                    Console.ReadKey();
                    Console.Clear();
                    Display();
                    break;
                case ConsoleKey.D3:
                    Environment.Exit(1);
                    break;

                default:
                    Console.SetCursorPosition(0, 4);
                    Console.WriteLine("Not a valid  option.");
                    Console.ReadKey();
                    Console.Clear();
                    Display();
                    break;
            }
        }   
    }
}
