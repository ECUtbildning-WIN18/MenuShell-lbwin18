namespace MenuTest.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }

        public User()
        {
        }

        public User(string username, string password, Role role)
        {
            Username = username;
            Password = password;
            Role = role;
        }
    }
}