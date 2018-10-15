using MenuTest.Domain;
using System;

namespace MenuTest.View
{
    public abstract class BaseView
    {
        public string Title { get; }

        public BaseView(string title)
        {
            Title = title;
            Console.Title = title;
        }

        

        //public virtual User Display()
        //{
        //    Console.Clear();
        //    return null;
        //}
    }
}
