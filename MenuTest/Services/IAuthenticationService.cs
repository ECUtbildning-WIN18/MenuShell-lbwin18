using MenuTest.Domain;

namespace MenuTest.Services
{
    interface IAuthenticationService
    {
        User Authenticate(string username, string password);
    }
}
