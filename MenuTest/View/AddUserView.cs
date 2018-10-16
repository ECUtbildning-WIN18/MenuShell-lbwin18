using MenuTest.Domain;
using MenuTest.Services;
using System;
using System.Collections.Generic;
using System.Threading;

namespace MenuTest.View
{
    class AddUserView : BaseView
    {

        public AddUserView() : base("Administrator - Add user")
        {

        }

        public void Display()
        {
            var userListHandler = new UserListHandler();
            var users = new Dictionary<string, User>();
            users = userListHandler.GetUserList();
            var authenticationService = new AuthenticationService(users);

            bool isRunning = false;

            do
            {
                Console.Clear();

                Console.WriteLine("# Add user\n");
                Console.WriteLine("Username: ");
                Console.WriteLine("Password: ");
                Console.WriteLine("Role: ");
                Console.SetCursorPosition(10, 2);
                string username = Console.ReadLine();
                Console.SetCursorPosition(10, 3);
                string password = Console.ReadLine();
                Console.SetCursorPosition(10, 4);
                string role = Console.ReadLine();
                Enum.TryParse(role, true, out Role userRole);
                Console.WriteLine("\nIs this correct? (Y)es (N)o");

                var input = Console.ReadKey();

                switch (input.Key)
                {
                    case ConsoleKey.Y:
                        if (authenticationService.UserNameExists(username))
                        {
                            Console.WriteLine("Username already exists. Try another username.");
                        }
                        else
                        {
                            var newUser = new User(username, password, userRole);
                            userListHandler.AddUserToList(users, newUser);
                            userListHandler.AddUserToXMLFile("Users.xml", newUser);
                            Console.Clear();
                            userListHandler.PrintUserList(users);
                            Thread.Sleep(2000);
                            ManageUserView manageUserView = new ManageUserView();
                            manageUserView.Display();
                        }
                        break;
                    case ConsoleKey.N:
                        Console.SetCursorPosition(0, 7);
                        Console.WriteLine("Try again!");
                        Thread.Sleep(2000);
                        Console.Clear();
                        break;
                    default:
                        Console.SetCursorPosition(0, 7);
                        Console.WriteLine("Invalid option!");
                        Thread.Sleep(2000);
                        Console.Clear();
                        break;
                }

            } while(!isRunning);
           
        }
    }
}
