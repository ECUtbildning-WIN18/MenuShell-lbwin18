using MenuTest.Domain;
using MenuTest.Services;
using System;
using System.Collections.Generic;
using System.Threading;

namespace MenuTest.View
{
    class DeleteUserView : BaseView
    {
        public DeleteUserView() : base("Admisistrator - Delete user")
        {              
        }

        public void Display()
        {
            var userListHandler = new UserListHandler();
            var users = new Dictionary<string, User>();
            users = userListHandler.GetUserList();
            var authenticationService = new AuthenticationService(users);
            var adminView = new AdminView();

            Console.Clear();

            Console.WriteLine("# Delete user\n");
            var numberOfUsers = userListHandler.PrintUserList(users);
            Console.Write("\n> ");
            string input = Console.ReadLine();
            var legitInput= int.TryParse(input, out int choice);
            if (!legitInput || choice < 1 || choice > numberOfUsers)
            {
                Console.WriteLine("Not a valid Input. Try again.");
                Thread.Sleep(2000);
                Console.Clear();
                Display();
            }

            int x = 1;
            string userToDelete="";
            foreach (var element in users)
            {
                if (choice == x)
                {
                    userToDelete = element.Value.Username;
                }
                x++;
            }
            Console.WriteLine($"You are about to delete {userToDelete}.");
            Console.WriteLine("Is this correct? (Y)es (N)o (A)bort");

            var deleteChoice = Console.ReadKey();

            switch (deleteChoice.Key)
            {
                case ConsoleKey.Y:
                    userListHandler.DeleteUserFromList(users, userToDelete);
                    userListHandler.DeleteUserFromXMLFile("Users.xml", userToDelete);
                    Console.Clear();
                    userListHandler.PrintUserList(users);
                    Thread.Sleep(3000);
                    adminView.Display();
                    break;
                case ConsoleKey.N:
                    ManageUserView manageUserView = new ManageUserView();
                    manageUserView.Display();
                    break;
                case ConsoleKey.A:
                    adminView.Display();
                    break;
            }
        }
    }
}