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
        public Dictionary<string, User> UserList { get; }
        public Dictionary<string, User> SearchResult { get; }

        public DeleteUserModeView(Dictionary<string, User> userList, Dictionary<string, User> searchResult) : base("Administrator - Delete user mode")
        {
            UserList = userList;
            SearchResult = searchResult;
        }

        public void Display()
        {
            Console.Clear();
            Console.WriteLine("  Search result\n");
            var userListHandler = new UserListHandler();
            userListHandler.PrintUserListWithUserNames(SearchResult);
            Console.Write("\nDelete> ");
            var username = Console.ReadLine();
            Console.WriteLine($"\nDelete user {username}?  (Y)es (N)o (A)bort");
            var input = Console.ReadKey(true);

            switch (input.Key)
            {
                case ConsoleKey.Y:
                    if (SearchResult.Keys.Any(key => key.Equals(username)))
                    {
                        userListHandler.DeleteUserFromList(UserList, username);
                        userListHandler.DeleteUserFromDataBase(username);
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