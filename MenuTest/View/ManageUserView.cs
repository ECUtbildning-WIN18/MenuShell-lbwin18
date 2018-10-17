using MenuTest.Services;
using System;
using System.Threading;

namespace MenuTest.View
{
    class ManageUserView : BaseView
    {
        public ManageUserView() : base("Administrator - Manage User")
        {

        }

        public void Display()
        {
            Console.ForegroundColor = ConsoleColor.White;
            var userListHandler = new UserListHandler();
            var addUserView = new AddUserView();
            var deleteUserView = new DeleteUserView();
            var adminView = new AdminView();

            Console.Clear();
            Console.WriteLine("1. Add user");
            Console.WriteLine("2. Delete user");
            Console.WriteLine("3. Back to Main menu");

            Console.Write("\n>");

            var input = Console.ReadKey();

            switch (input.Key)
            {
                case ConsoleKey.D1:
                    addUserView.Display();
                    break;

                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    deleteUserView.Display();
                    break;
                case ConsoleKey.D3:
                    {
                        Console.SetCursorPosition(0, 4);
                        adminView.Display();
                    }
                    break;
                default:
                    Console.WriteLine("Not a valid option.");
                    Thread.Sleep(2000);
                    Console.Clear();
                    Display();
                    break;
            }
        }
    }
}
