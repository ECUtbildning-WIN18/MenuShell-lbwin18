using MenuTest.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace MenuTest.Services
{
    class UserListHandler
    {
        public  UserListHandler()
        {

        }

        public Dictionary<string, User> GetUserList()
        {
            var users = new Dictionary<string, User>();
            var xDocument = XDocument.Load("Users.xml");
            var root = xDocument.Root;

            foreach(var element in xDocument.Root.Elements())
            {
                var username = element.Attribute("username").Value;
                var password = element.Attribute("password").Value;
                var role = element.Attribute("role").Value;

                Enum.TryParse(role, true, out Role userRole);
                users.Add(username, new User(username, password, userRole));
            }
            return users;    
        }


        public int PrintUserList(Dictionary<string, User> userList)
        {
            var x = 0;
            foreach(var user in userList)
            {
                x++;
                Console.WriteLine($"{x}. {user.Value.Username,-15} {user.Value.UserRole,-15}");            
            } return x;
        }

        public void AddUserToList(Dictionary<string, User> userList, User user)
        {
            userList.Add(user.Username, user);
        }
        
        public void RemoveUserFromList(Dictionary<string, User> userList, string username)
        {
            userList.Remove(username);
        }

        public void AddUserToXMLFile(string xmlFileName, User user)
        {
            var xDocument = XDocument.Load("Users.xml");
            xDocument.Element("Users").Add(
                new XElement("User",
                    new XAttribute("username", user.Username),
                    new XAttribute("password", user.Password),
                    new XAttribute("role", user.UserRole)
                ));
            xDocument.Save(xmlFileName);
        }

        public void DeleteUserFromXMLFile(string xmlFileName, string username)
        {
            var xDocument = XDocument.Load("Users.xml");
            xDocument.Root.Elements().Where(x => x.Attribute("username").Value == username).Remove();
            xDocument.Save(xmlFileName);
        }
    }
}
