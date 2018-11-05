using MenuTest.Domain;
using MenuTest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace MenuTest.View
{
    class DeleteUserModeView : BaseView
    {
        public IList<User> UserList { get; }
        public IList<User> SearchResult { get; }

        public DeleteUserModeView(IList<User> userList, IList<User> searchResult) : base("Administrator - Delete user mode")
        {
            UserList = userList;
            SearchResult = searchResult;
        }

        public void Display()
        {
            Console.Clear();
            Console.WriteLine("  Search result\n");
            UserListHandler.PrintUserList(SearchResult);
            Console.Write("\nDelete> ");
            var username = Console.ReadLine();
            Console.WriteLine($"\nDelete user {username}?  (Y)es (N)o (A)bort");
            var input = Console.ReadKey(true);

            switch (input.Key)
            {
                case ConsoleKey.Y:
                    if (SearchResult.Any(x => x.Username == username))
                    {
                        UserListHandler.RemoveUserFromList(UserList, username);
                        UserListHandler.RemoveUserFromDbUsingEF(username);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"User { username} successfully deleted.");
                        Console.ForegroundColor = ConsoleColor.White;
                        Thread.Sleep(2000);
                        var adminView = new AdminView();
                        adminView.Display();
                    }
                    else
                    {
                        Console.WriteLine($"The username: {username} didn't match any in the list. Try again.");
                        Console.ReadKey();
                        Display();
                    }
                    break;
                case ConsoleKey.N:
                    Display();
                    break;
                case ConsoleKey.A:
                    var manageUsersView = new ManageUserView2();
                    manageUsersView.Display();
                    break;
            }
        }
    }
}