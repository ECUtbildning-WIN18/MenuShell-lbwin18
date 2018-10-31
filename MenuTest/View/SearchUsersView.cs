using MenuTest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
            var userListHandler = new UserListHandler();
            var userList = userListHandler.GetUserList();
            //userListHandler.PrintUserListWithUserNames(userList);
            Console.WriteLine("Search by user name:\n");
            Console.Write("\n> ");
            var searchString = Console.ReadLine();

            var searchResult = userListHandler.GetUsersFromDBStartingWithString(searchString);
            if (searchResult.Any())
            {
                Console.Clear();
                Console.WriteLine("  Search result\n");
                userListHandler.PrintUserListWithUserNames(searchResult);
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
