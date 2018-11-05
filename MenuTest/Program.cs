using MenuTest.Domain;
using MenuTest.Services;
using MenuTest.View;
using System;
using System.Threading;

namespace MenuTest
{
    public enum Role { None, Administrator, Veterinary, Receptionist};

    class Program
    {
        static void Main(string[] args)
        {
            var users = UserListHandler.GetUsersFromDbUsingEF();
            var authenticationService = new AuthenticationService(users);

            var admin = new User("admin", "secret", Role.Administrator);

            if(!authenticationService.UserExists(admin.Username, admin.Password))
            {
                UserListHandler.AddUserToList(users, admin);
                UserListHandler.SaveUserToDbUsingEF(admin);
            }

            var loginView = new LoginView(authenticationService);

            var validUser = loginView.Display();

            switch (validUser.Role)
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
