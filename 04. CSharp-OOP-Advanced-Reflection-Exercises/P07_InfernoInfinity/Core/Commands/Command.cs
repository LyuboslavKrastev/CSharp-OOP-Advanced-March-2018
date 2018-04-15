using P07_InfernoInfinity.Interfaces;

namespace P07_InfernoInfinity.Core.Commands
{
    public abstract class Command : IExecutable
    {
        protected string[] data;

        public Command(string[] data)
        {
            this.data = data;
        }


        public abstract string Execute();
    }
}