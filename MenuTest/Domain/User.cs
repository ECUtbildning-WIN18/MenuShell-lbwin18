namespace MenuTest.Domain
{
    public class User
    {
        public string Username { get; }
        public string Password { get; }
        public Role UserRole { get; }

        public User(string username, string password, Role role)
        {
            Username = username;
            Password = password;
            UserRole = role;
        }
    }
}
