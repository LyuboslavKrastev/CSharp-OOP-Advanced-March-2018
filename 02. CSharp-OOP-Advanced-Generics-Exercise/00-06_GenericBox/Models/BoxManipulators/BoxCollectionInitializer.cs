using System;
using System.Collections.Generic;

namespace _GenericBox.Models.BoxManipulators
{
    public static class BoxCollectionInitializer
    {  

        public static List<Box<int>> GetIntBoxes()
        {
            var n = int.Parse(Console.ReadLine());

            var boxList = new List<Box<int>>();
            for (int i = 0; i < n; i++)
            {
                var value = int.Parse(Console.ReadLine());
                boxList.Add(new Box<int>(value));
            }
            return boxList;
        }

        public static List<Box<double>> GetDoubleBoxes()
        {
            var n = int.Parse(Console.ReadLine());

            var boxList = new List<Box<double>>();
            for (int i = 0; i < n; i++)
            {
                var value = double.Parse(Console.ReadLine());
                boxList.Add(new Box<double>(value));
            }
            return boxList;
        }

        public static List<Box<string>> GetStringBoxes()
        {
            var n = int.Parse(Console.ReadLine());

            var boxList = new List<Box<string>>();
            for (int i = 0; i < n; i++)
            {
                var value = Console.ReadLine();
                boxList.Add(new Box<string>(value));
            }
            return boxList;
        }
    }
}
