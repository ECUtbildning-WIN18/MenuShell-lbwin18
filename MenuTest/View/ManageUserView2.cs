using MenuTest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MenuTest.View
{
    class ManageUserView2 : BaseView
    {
        public ManageUserView2() : base("Administrator - Manage User")
        {
        }

            public void Display()
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("1. Add user");
                Console.WriteLine("2. Search user");
                Console.WriteLine("3. Back to Main menu");
                Console.Write("\n>");

                var input = Console.ReadKey(true);

                switch (input.Key)
                {
                    case ConsoleKey.D1:
                        var addUserView = new AddUserView();
                        addUserView.Display();
                        break;
                    case ConsoleKey.D2:
                        var searchUsersView = new SearchUsersView();
                        searchUsersView.Display();
                        break;
                    case ConsoleKey.D3:
                        Console.SetCursorPosition(0, 4);
                        var adminView = new AdminView();
                        adminView.Display();
                        break;
                    default:
                        Console.WriteLine("Not a valid option.");
                        Thread.Sleep(2000);
                        Display();
                        break;
                }
            }
        
    }
}
