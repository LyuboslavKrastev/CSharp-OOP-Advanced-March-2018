using System;
using System.Collections.Generic;
using System.Linq;

namespace _GenericBox.Models.BoxManipulators
{
    public static class BoxSwapper
    {
        public static string SwapIntBoxes(List<Box<int>> boxList)
        {
            var swapArgs = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var indexA = swapArgs[0];
            var indexB = swapArgs[1];

            var swappedList = Swap(boxList, indexA, indexB);

            var result = string.Join(Environment.NewLine, swappedList);

            return result;
        }

        public static string SwapStringBoxes(List<Box<string>> boxList)
        {
            var swapArgs = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var indexA = swapArgs[0];
            var indexB = swapArgs[1];

            var swappedList = Swap(boxList, indexA, indexB);

            var result = string.Join(Environment.NewLine, swappedList);

            return result;
        }

        private static List<T> Swap<T>(this List<T> list, int indexA, int indexB)
        {
            T tmp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = tmp;
            return list;
        }
    }
}
