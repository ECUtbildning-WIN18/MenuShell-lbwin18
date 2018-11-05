using MenuTest.Domain;
using MenuTest.Services;
using System;
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
            var users = UserListHandler.GetUsersFromDbUsingEF();
            var authenticationService = new AuthenticationService(users);

            bool isRunning = false;

            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
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
                Console.WriteLine("\nIs this correct? (Y)es (N)o (A)bort");

                var input = Console.ReadKey(true);

                switch (input.Key)
                {
                    case ConsoleKey.Y:
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
                            var newUser = new User(username, password, userRole);
                            UserListHandler.AddUserToList(users, newUser);
                            UserListHandler.SaveUserToDbUsingEF(newUser);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"\nAdding user {username} was succesful\n");
                            Thread.Sleep(2000);
                            var manageUserViewYPressed = new ManageUserView2();
                            manageUserViewYPressed.Display();
                        }
                        break;
                    case ConsoleKey.N:
                        Console.WriteLine("Try again!");
                        Thread.Sleep(2000);
                        break;
                    case ConsoleKey.A:
                        var manageUserViewAPressed = new ManageUserView2();
                        manageUserViewAPressed.Display();
                        break;
                    default:
                        Console.WriteLine("Invalid option!");
                        Thread.Sleep(2000);
                        break;
                }
            } while (!isRunning);
        }
    }
}