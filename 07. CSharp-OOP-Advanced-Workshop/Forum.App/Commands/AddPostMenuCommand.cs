namespace Forum.App.Commands
{
    using Contracts;

    public class AddPostMenuCommand : NavigationCommand
    {
        public AddPostMenuCommand(IMenuFactory menuFactory) : base(menuFactory)
        {
        }
    }
}
