using System;
using System.Collections.Generic;

namespace _GenericBox.Models.BoxManipulators
{
    public static class BoxComparer
    {
        public static int CompareDoubleBoxes(List<Box<double>> intBoxes)
        {
            var boxToCompare = new Box<double>(double.Parse(Console.ReadLine()));
            var count = CountGreterValues(intBoxes, boxToCompare);
            return count;
        }

        public static int CompareStringBoxes(List<Box<string>> stringBoxes)
        {
            var boxToCompare = new Box<string>(Console.ReadLine());
            var count = CountGreterValues(stringBoxes, boxToCompare);
            return count;
        }

        private static int CountGreterValues<T>(List<T> list, T element)
            where T : IComparable<T>
        {
            var counter = 0;

            foreach (var item in list)
            {
                if (item.CompareTo(element) == 1)
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
