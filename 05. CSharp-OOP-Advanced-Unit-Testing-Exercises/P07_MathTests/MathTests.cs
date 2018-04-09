using NUnit.Framework;
using System;

namespace P07_MathTests
{
    class MathTests
    {
        [TestCase(5.5, 5)]   
        [TestCase(155.55, 155)]
        [TestCase(-65.5543, -66)]
        public void MathFloorShouldReturnTheLargestIntegerLesSThanOrEqualToAGivenNumber(double input, double expected)
        {
            double floorResult = Math.Floor(input);

            Assert.AreEqual(expected, floorResult);
        }

        [TestCase(-5.5, 5.5)]
        [TestCase(155.55, 155.55)]
        [TestCase(-2.5, 2.5)]
        public void MathAbsShouldReturnTheAbsoluteValueOfADoublePrecisionFloatingPointNumber(double input, double expected)
        {
            double absResult = Math.Abs(input);

            Assert.AreEqual(expected, absResult);
        }
    }
}
