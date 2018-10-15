using MenuTest.Domain;
using MenuTest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MenuTest.View
{
    class LoginView : BaseView
    {
        public AuthenticationService AuthenticationService { get; }

        public LoginView(AuthenticationService authenticationService) : base("Login")
        {
            AuthenticationService = authenticationService;
        }

        public User Display()
        {
            bool isRunning = false;
            User myUser = null;

            do
            {
                Console.WriteLine("Username: ");
                Console.WriteLine("Password: ");
                Console.SetCursorPosition(10, 0);
                string username = Console.ReadLine();
                Console.SetCursorPosition(10, 1);
                string password = Console.ReadLine();
                Console.WriteLine("\nIs this correct? (Y)es (N)o");

                var input = Console.ReadKey();

                switch (input.Key)
                {
                    case ConsoleKey.Y:
                        {
                            if (AuthenticationService.UserExists(username, password))
                            {
                                isRunning = true;
                                myUser = AuthenticationService.Authenticate(username, password);
                            }
                            else
                            {
                                Console.SetCursorPosition(0, 4);
                                Console.WriteLine("Login failed. Please try again!.");
                                Thread.Sleep(2000);
                                Console.Clear();
                            }
                        }
                        break;
                    case ConsoleKey.N:
                        {                            
                            // retry login
                            Console.SetCursorPosition(0, 4);
                            Console.WriteLine("Try again!");
                            Thread.Sleep(2000);
                            Console.Clear();
                        }
                        break;
                    case ConsoleKey.Q:
                        {
                            Console.SetCursorPosition(0, 4);
                            Console.WriteLine("Exit program");
                            Thread.Sleep(2000);
                            Environment.Exit(1);
                        }
                        break;
                    default:
                        {
                            Console.SetCursorPosition(0, 3);
                            Console.WriteLine("Invalid selection!");
                            Thread.Sleep(2000);
                            Console.Clear();
                        }
                        break;
                }
            } while (!isRunning);
            Console.SetCursorPosition(0, 3);
            Console.WriteLine("\nLogin successful");
            Thread.Sleep(2000);
            return myUser;
        }
    }
}
