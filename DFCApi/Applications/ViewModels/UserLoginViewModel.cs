namespace API.Applications.ViewModels
{
    public class UserLoginViewModel
    {
        public UserLoginViewModel(string token)
        {
            Token = token;
        }

        public string Token { get; private set; }
    }
}