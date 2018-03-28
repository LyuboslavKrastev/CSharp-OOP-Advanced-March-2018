using System;
using System.Collections.Generic;
using _GenericBox.Models.BoxManipulators;

namespace _GenericBox
{
    class StartUp
    {
        static void Main(string[] args)
        {
            /* Problem 1 */
            var stringBoxes = BoxCollectionInitializer.GetStringBoxes(); 
            PrintBoxCollection(stringBoxes);

            /* Problem 2 */
            var intBoxes = BoxCollectionInitializer.GetIntBoxes(); 
            PrintBoxCollection(intBoxes); // Problem 2        

            /* Problem 3 */
            PrintResult(BoxSwapper.SwapStringBoxes(stringBoxes));

            /* Problem 4 */
            PrintResult(BoxSwapper.SwapIntBoxes(intBoxes));

            /* Problem 5 */
            PrintResult(BoxComparer.CompareStringBoxes(stringBoxes));

            /* Problem 6 */
            var doubleBoxes = BoxCollectionInitializer.GetDoubleBoxes(); 
            PrintResult(BoxComparer.CompareDoubleBoxes(doubleBoxes));
        }

        private static void PrintBoxCollection<T>(List<T> intBoxes)
        {
            Console.WriteLine(string.Join(Environment.NewLine, intBoxes));
        }

        private static void PrintResult<T>(T input)
        {
            Console.WriteLine(input);
        }
    }
}
