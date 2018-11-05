using MenuTest.Domain;
using System.Collections.Generic;
using System.Linq;

namespace MenuTest.Services
{
    class UserListHandler
    {

        public static IList<User> GetUsersFromDbUsingEF()
        {
            using (var context = new MenuShellDbContext())
            {
                return context.Users.OrderBy(x => x.Username).ToList();
            }
        }


        public static void PrintUserList(IList<User> userList)
        {
            foreach (var user in userList)
            {
                System.Console.WriteLine($"{user.Username} \t {user.Role}");
            }
        }


        public static void SaveUserToDbUsingEF(User user)
        {
            using (var context = new MenuShellDbContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }


        public static void RemoveUserFromDbUsingEF(string username)
        {
            using (var context = new MenuShellDbContext())
            {
                var userToBeDeleted = context.Users.Where(x => x.Username == username).FirstOrDefault();
                context.Users.Remove(userToBeDeleted);
                context.SaveChanges();
            }
        }


        public static IList<User> GetUsersStartingWithString(string searchString)
        {
            var searchList = GetUsersFromDbUsingEF();
            var matchingUsers = searchList.Where(x => x.Username.ToLower().StartsWith(searchString.ToLower())).ToList();
            return matchingUsers;
        }


        public static void AddUserToList(IList<User> userList, User user)
        {
            userList.Add(user);
        }


        public static void RemoveUserFromList(IList<User> userList, string username )
        {
            userList.Remove(new User() { Username = username });
        }

    }
}