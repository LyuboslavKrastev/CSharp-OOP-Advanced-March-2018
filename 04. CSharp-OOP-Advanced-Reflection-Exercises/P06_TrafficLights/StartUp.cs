using System;
using System.Collections.Generic;

namespace P06_TrafficLights
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var trafficLight = new TrafficLight();

            ProcessInput(input, trafficLight);

            var linesCount = int.Parse(Console.ReadLine());

            PrintLights(trafficLight, linesCount);
        }

        private static void ProcessInput(string[] input, TrafficLight trafficLight)
        {
            foreach (var lightInput in input)
            {
                try
                {
                    trafficLight.AddLight(new Light(lightInput));
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }

        private static void PrintLights(TrafficLight trafficLight, int linesCount)
        {
            for (int i = 0; i < linesCount; i++)
            {
                trafficLight.ChangeLights();

                Console.WriteLine(trafficLight);
            }
        }
    }
}
