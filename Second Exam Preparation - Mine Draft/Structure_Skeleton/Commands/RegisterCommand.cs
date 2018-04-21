using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class RegisterCommand : Command
{
    private IHarvesterController harvesterController;
    private IProviderController providerController;

    public RegisterCommand(IList<string> arguments, IHarvesterController harvesterController,
        IProviderController providerController) : base(arguments)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public override string Execute()
    {
        string entityType = this.Arguments[0];

        var args = this.Arguments.Skip(1).ToArray();

        object controllerType = this.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
            .FirstOrDefault(f => f.Name == entityType.ToLower() + "Controller").GetValue(this);

        IController controller = (IController)controllerType;

        string result = controller.Register(args);

        return result;
    }
}

