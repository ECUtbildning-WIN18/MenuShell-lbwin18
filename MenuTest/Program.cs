using MenuTest.Domain;
using MenuTest.Services;
using MenuTest.View;
using System;
using System.Collections.Generic;
using System.Threading;

namespace MenuTest
{
    public enum Role { Administrator, Veterinary, Receptionist};

    class Program
    {
        static void Main(string[] args)
        {
            var users = new Dictionary<string, User>
            {
               {
                    "admin",
                    new User(username: "admin",
                           password: "secret",
                           role: Role.Administrator)
               }
            };

            var authenticationService = new AuthenticationService(users);

            var loginView = new LoginView(authenticationService);

            var validUser = loginView.Display();

            switch (validUser.UserRole)
            {
                case Role.Administrator:
                    {
                        Console.Clear();
                        AdminView adminview = new AdminView();
                        adminview.Display();
                        Thread.Sleep(2000);
                    }
                    break;
                case Role.Receptionist:
                    {
                        Console.Clear();
                        System.Console.WriteLine("receptionist view");
                        Thread.Sleep(2000);
                    }
                    break;
                case Role.Veterinary:
                    {
                        Console.Clear();
                        System.Console.WriteLine("veterinary view");
                        Thread.Sleep(2000);
                    }
                    break;
            }


        }
    }
}
