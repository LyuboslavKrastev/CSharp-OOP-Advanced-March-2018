using P07_InfernoInfinity.Interfaces;
using System;
using System.Linq;
using System.Reflection;

namespace P07_InfernoInfinity.Core
{
    public class Engine : IRunnable
    {
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            string input;
            while ((input = Console.ReadLine()) != "END")
            {

                string[] data = input.Split(';');
                string commandName = data[0];
                IExecutable command = this.commandInterpreter.InterpretCommand(data, commandName);

                var method = typeof(IExecutable).GetMethods().First();

                try
                {
                    string result = (string)method.Invoke(command, null);
                    if (result != string.Empty)
                    {
                        Console.WriteLine(result);
                    }
                }
                catch (TargetInvocationException tie) { }
            }
        }
    }
}
