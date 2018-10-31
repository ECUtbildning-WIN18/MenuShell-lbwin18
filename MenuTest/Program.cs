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

            var userListHandler = new UserListHandler();
            var users = userListHandler.GetUserListFromDatabase();  //From Database
            var authenticationService = new AuthenticationService(users);
            var Admin = new User("admin", "admin", Role.Administrator);
            if(!authenticationService.UserExists(Admin.Username, Admin.Password))
            {
                userListHandler.AddUserToList(users, Admin);
            }

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
