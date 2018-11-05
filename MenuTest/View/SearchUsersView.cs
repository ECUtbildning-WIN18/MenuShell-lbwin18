using MenuTest.Services;
using System;
using System.Linq;
using System.Threading;

namespace MenuTest.View
{
    class SearchUsersView : BaseView
    {
        public SearchUsersView() : base("Administrator - Search user")
        {
        }

        public void Display()
        {
            Console.Clear();
            //var userListHandler = new UserListHandler();
            var userList = UserListHandler.GetUsersFromDbUsingEF();
            Console.WriteLine("Search by user name:\n");
            Console.Write("\n> ");
            var searchString = Console.ReadLine();

            var searchResult = UserListHandler.GetUsersStartingWithString(searchString);
            if (searchResult.Any())
            {
                Console.Clear();
                Console.WriteLine("  Search result\n");
                UserListHandler.PrintUserList(searchResult);
                Console.WriteLine("\n(D)elete  (A)bort");
                var input = Console.ReadKey(true);
                switch (input.Key)
                {
                    case ConsoleKey.D:
                        var deleteUserModeView = new DeleteUserModeView(userList, searchResult);
                        deleteUserModeView.Display();
                        break;
                    case ConsoleKey.A:
                        var manageUserView = new ManageUserView2();
                        manageUserView.Display();
                        break;
                    default:
                        Console.WriteLine("Invalid option. Try Again.");
                        Thread.Sleep(2000);
                        Display();
                        break;
                }
            }
            else
            {
                Console.WriteLine($"No users found matching the search term: {searchString}. Try again?");
                Console.WriteLine("(Y)es (N)o");

                var input = Console.ReadKey(true);

                switch (input.Key)
                {
                    case ConsoleKey.Y:
                        Display();
                        break;
                    case ConsoleKey.N:
                        var manageUserView = new ManageUserView2();
                        manageUserView.Display();
                        break;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        Thread.Sleep(2000);
                        Display();
                        break;
                }
            }
        }
    }
}
