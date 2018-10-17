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
            var manageUserView = new ManageUserView();


            bool isRunning = false;

            do
            {
                Console.ForegroundColor = ConsoleColor.White;
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
                        Console.SetCursorPosition(0, 7);
                        if (authenticationService.UserNameExists(username))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Username already exists. Try another username.");
                            Thread.Sleep(2000);
                        }
                        else if (!authenticationService.RoleIsLegit(userRole))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("You entered a non legit role.");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Pleae enter one of the following roles:");
                            Console.WriteLine($"{Role.Administrator}, {Role.Veterinary} or {Role.Receptionist}");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            var newUser = new User(username, password, userRole);
                            userListHandler.AddUserToList(users, newUser);
                            userListHandler.AddUserToXMLFile("Users.xml", newUser);
                            Console.Clear();
                            Console.WriteLine("Adding user was succesful\n");
                            userListHandler.PrintUserList(users);
                            Console.ReadKey();
                            manageUserView.Display();
                        }
                        break;
                    case ConsoleKey.N:
                        Console.SetCursorPosition(0, 7);
                        Console.WriteLine("Try again!");
                        Thread.Sleep(2000);
                        break;
                    default:
                        Console.SetCursorPosition(0, 7);
                        Console.WriteLine("Invalid option!");
                        Thread.Sleep(2000);
                        break;
                }

            } while(!isRunning);
           
        }
    }
}
