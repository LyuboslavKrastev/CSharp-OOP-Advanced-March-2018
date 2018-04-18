namespace Forum.App.Commands
{
    using Contracts;
    using System;

    public class SignUpCommand : ICommand
    {
        private IUserService userService;
        private IMenuFactory menuFactory;

        public SignUpCommand(IUserService userService, IMenuFactory menuFactory)
        {
            this.userService = userService;
            this.menuFactory = menuFactory;
        }

        public IMenu Execute(params string[] args)
        {
            string username = args[0];
            string password = args[1];

            bool invalidUserName = string.IsNullOrEmpty(username) || username.Length < 4;
            bool invalidPassword = string.IsNullOrEmpty(username) || username.Length < 4;

            if (invalidUserName || invalidPassword)
            {
                throw new ArgumentException("Invalid credentials length!!");
            }

            bool successfulSignUp = this.userService.TrySignUpUser(username, password);

            if (!successfulSignUp)
            {
                throw new InvalidOperationException("Username already taken!");
            }

            return this.menuFactory.CreateMenu("MainMenu");
        }
    }
}
