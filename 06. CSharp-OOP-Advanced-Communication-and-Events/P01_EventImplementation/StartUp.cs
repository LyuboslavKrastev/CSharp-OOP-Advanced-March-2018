using System;

namespace P01_EventImplementation
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Dispatcher dispatcher = new Dispatcher();
            Handler handler = new Handler();

            dispatcher.NameChange += handler.OnDispatcherNameChange;

            string name;

            while ((name = Console.ReadLine())!= "End")
            {
                dispatcher.Name = name;
            }

        }
    }
}
