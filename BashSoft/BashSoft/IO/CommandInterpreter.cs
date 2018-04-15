using System;
using BashSoft.Exceptions;
using BashSoft.IO.Commands;
using BashSoft.Contracts;
using BashSoft.Contracts.RepositoryContracts;
using System.Reflection;
using System.Linq;
using BashSoft.Attributes;

namespace BashSoft
{
    public class CommandInterpreter : IInterpreter
    {
        private IContentComparer judge;
        private IDatabase repository;
        private IDirectoryManager inputOutputManager;

        public CommandInterpreter(IContentComparer judge, IDatabase repository, IDirectoryManager inputOutputManager)
        {
            this.judge = judge;
            this.repository = repository;
            this.inputOutputManager = inputOutputManager;
        }

        public void IntepredCommand(string input)
        {

            string[] data = input.Split(' ');
            string commandName = data[0].ToLower(); // so it is case insensitive for easier command input
            try
            {
                IExecutable command = this.ParseCommand(input, data, commandName);
                command.Execute();
            }
            catch (Exception ex)
            {
                OutputWriter.DisplayException(ex.Message);
            }
        }

        private IExecutable ParseCommand(string input, string[] data, string command)
        {
            object[] parametersForConstruction = new object[] { input, data };

            Type typeOfCommand = GetTypeOfCommand(input, command);

            Type typeOfInterpreter = typeof(CommandInterpreter);

            Command exe = (Command)Activator
                .CreateInstance(typeOfCommand, parametersForConstruction);

            FieldInfo[] fieldsOfCommand = typeOfCommand
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            FieldInfo[] fieldsOfInterpreter = typeOfInterpreter
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance);


            foreach (var commandField in fieldsOfCommand)
            {
                Attribute atrAttribute = commandField.GetCustomAttribute(typeof(InjectAttribute));

                if (atrAttribute != null)
                {
                    if (fieldsOfInterpreter.Any(x => x.FieldType == commandField.FieldType))
                    {
                        commandField.SetValue(exe,
                            fieldsOfInterpreter.First(x => x.FieldType == commandField.FieldType)
                            .GetValue(this));
                    }
                }
            }

            return exe;
        }

        private static Type GetTypeOfCommand(string input, string command)
        {         
            try
            {
            Type typeOfCommand = Assembly.GetExecutingAssembly()
                     .GetTypes()
                     .First(type => type.GetCustomAttributes(typeof(AliasAttribute))
                     .Where(atr => atr.Equals(command))
                     .ToArray().Length > 0);

                return typeOfCommand;
            }
            catch (InvalidOperationException)
            {
                throw new InvalidCommandException(input);
            }           
        }
    }
}