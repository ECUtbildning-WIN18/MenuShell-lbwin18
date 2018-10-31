using MenuTest.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Xml.Linq;

namespace MenuTest.Services
{
    class UserListHandler
    {
        public UserListHandler()
        {
        }

        // ********** XML related methods **********

        public Dictionary<string, User> GetUserList()
        {
            var users = new Dictionary<string, User>();
            var xDocument = XDocument.Load("Users.xml");
            var root = xDocument.Root;

            foreach (var element in xDocument.Root.Elements())
            {
                var username = element.Attribute("username").Value;
                var password = element.Attribute("password").Value;
                var role = element.Attribute("role").Value;

                Enum.TryParse(role, true, out Role userRole);
                users.Add(username, new User(username, password, userRole));
            }
            return users;
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
        // ********** End XML related methods **********



        // ********** Database related methods **********

        public Dictionary<string, User> GetUserListFromDatabase()
        {
            var users = new Dictionary<string, User>();

            string sqlQuery = "SELECT * FROM [User] ORDER BY Username ASC";
            string connectionString = DatabaseService.GetConnectionString(); //"Data Source=.\\MSSQLSERVER01;Initial Catalog=MenuShell;Integrated Security=true";
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    var sqlCommand = new SqlCommand(sqlQuery, connection);
                    var dataReader = sqlCommand.ExecuteReader();

                    while (dataReader.Read())
                    {
                        var username = dataReader["Username"].ToString();
                        var password = dataReader["Password"].ToString();
                        var role = dataReader["Role"].ToString();
                        Enum.TryParse(role, true, out Role userRole);
                        users.Add(username, new User(username, password, userRole));
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
            return users;
        }

        public Dictionary<string, User> GetUsersFromDBStartingWithString(string searchString)
        {
            var resultList = new Dictionary<string, User>();
            string sqlQuery = $"SELECT * FROM [User] WHERE Username LIKE '{searchString}%' ORDER BY Username ASC";
            string connectionString = DatabaseService.GetConnectionString();
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    var sqlCommand = new SqlCommand(sqlQuery, connection);
                    var dataReader = sqlCommand.ExecuteReader();

                    while (dataReader.Read())
                    {
                        var username = dataReader["Username"].ToString();
                        var password = dataReader["Password"].ToString();
                        var role = dataReader["Role"].ToString();
                        Enum.TryParse(role, true, out Role userRole);
                        resultList.Add(username, new User(username, password, userRole));
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
            return resultList;
        }


        public void AddUserToDatabase(User user)
        {
            string sqlQuery = $"INSERT INTO [User] (Username, Password, Role) " +
                $"VALUES('{user.Username}', '{user.Password}', '{user.UserRole}')";
            string connectionString = DatabaseService.GetConnectionString();
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    var sqlCommand = new SqlCommand(sqlQuery, connection);
                    sqlCommand.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        public void DeleteUserFromDataBase(string username)
        {
            string sqlQuery = String.Format($"DELETE FROM [User] WHERE Username = '{username}'");
            string connectionString = DatabaseService.GetConnectionString();
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    var sqlCommand = new SqlCommand(sqlQuery, connection);
                    sqlCommand.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }
        // ********** End Database related methods **********



        // ********** Dictionary related methods **********

        public int PrintUserList(Dictionary<string, User> userList)
        {
            var x = 0;
            foreach (var user in userList)
            {
                x++;
                Console.WriteLine($"{x}. {user.Value.Username,-15} {user.Value.UserRole,-15}");
            }
            return x;
        }


        public int PrintUserListWithUserNames(Dictionary<string, User> userList)
        {
            var x = 0;
            foreach (var user in userList)
            {
                x++;
                Console.WriteLine($"- {user.Value.Username,-15}");
            }
            return x;
        }


        public void AddUserToList(Dictionary<string, User> userList, User user)
        {
            userList.Add(user.Username, user);
        }

        public void DeleteUserFromList(Dictionary<string, User> userList, string username)
        {
            userList.Remove(username);
        }


        public Dictionary<string, User> GetUsersStartingWithString(string searchString)
        {
            Dictionary<string, User> searchList = GetUserList();
            var resultList = searchList.Where(x => x.Key.StartsWith(searchString)).ToDictionary(x => x.Key, x => x.Value);

            return resultList;
        }
        // ********** End Dictionary related methods **********
    }
}
    

