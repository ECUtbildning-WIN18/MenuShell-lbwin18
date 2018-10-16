﻿using MenuTest.Domain;
using MenuTest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MenuTest.View
{
    class ManageUserView : BaseView
    {
        public ManageUserView() : base("Administrator - Manage User")
        {

        }

        public void Display()
        {
            var userListHandler = new UserListHandler();

            Console.Clear();
            Console.WriteLine("1. Add user");
            Console.WriteLine("2. Delete user");
            Console.Write("\n>");

            var input = Console.ReadKey();

            switch (input.Key)
            {
                case ConsoleKey.D1:
                    AddUserView addUserView = new AddUserView();
                    addUserView.Display();
                    break;

                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    DeleteUserView deleteUserView = new DeleteUserView();
                    deleteUserView.Display();
                    break;

                default:
                    Console.WriteLine("Not a valid option.");
                    Thread.Sleep(2000);
                    Console.Clear();
                    Display();
                    break;
            }
        }
    }
}
