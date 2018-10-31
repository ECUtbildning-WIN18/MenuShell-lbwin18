using MenuTest.Domain;
using System.Collections.Generic;
using System.Linq;

namespace MenuTest.Services
{
    class AuthenticationService : IAuthenticationService
    {

        public Dictionary<string, User> UserList { get; }

        public AuthenticationService(Dictionary<string, User> users)
        {
            UserList = users;
        }


        public  User Authenticate(string username, string password)
        {    
            return UserList.Values.FirstOrDefault(x => x.Username == username && x.Password == password);
        }


        public bool UserExists(string username, string password)
        {
            return (UserList.Any(x => x.Value.Username == username && x.Value.Password == password) ? true : false);               
        }

        public bool UserNameExists(string username)
        {
            return (UserList.Any(x => x.Value.Username == username) ? true : false);
        }

        public bool RoleIsLegit(Role role)
        {
            return (role == Role.None) ? false : true;
        }
    }
}
