namespace P02_BlackBoxInteger
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            Type type = Type.GetType("P02_BlackBoxInteger.BlackBoxInteger");

            FieldInfo innerValue = type.GetField("innerValue", BindingFlags.NonPublic | BindingFlags.Instance);
            MethodInfo[] methods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

            object instance = Activator.CreateInstance(type, true); //true for bool nonpublic

            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input.Split('_');

                string command = tokens[0];

                MethodInfo method = methods.First(m => m.Name == command);

                int number = int.Parse(tokens[1]);

                method.Invoke(instance, new object[] {number});
                Console.WriteLine(innerValue.GetValue(instance));
            }

        }
    }
}
