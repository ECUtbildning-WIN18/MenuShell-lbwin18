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

            Console.Clear();
            Console.WriteLine("1. Add user");
            Console.WriteLine("2. Delete user");
            Console.WriteLine("3. Back to Main menu");

            Console.Write("\n>");

            var input = Console.ReadKey(true);

            switch (input.Key)
            {
                case ConsoleKey.D1:
                    var addUserView = new AddUserView();
                    addUserView.Display();
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    var deleteUserView = new DeleteUserView();
                    deleteUserView.Display();
                    break;
                case ConsoleKey.D3:
                    var adminView = new AdminView();
                    adminView.Display();    
                    break;
                default:
                    Console.WriteLine("Not a valid option.");
                    Thread.Sleep(2000);
                    Display();
                    break;
            }
        }
    }
}
