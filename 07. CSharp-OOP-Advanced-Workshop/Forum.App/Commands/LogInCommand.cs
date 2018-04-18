namespace Forum.App.Commands
{
    using System;

    using Contracts;

    public class LogInCommand : ICommand
    {
        private const string errorMessage = "Invalid username or password!";

        private IUserService userService;
        private IMenuFactory menuFactory;

        public LogInCommand(IUserService userService, IMenuFactory menuFactory)
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
                throw new ArgumentException(errorMessage);
            }

            bool successfulLogin = this.userService.TryLogInUser(username, password);

            if (!successfulLogin)
            {
                throw new InvalidOperationException(errorMessage);
            }

            return this.menuFactory.CreateMenu("MainMenu");
        }
    }
}
