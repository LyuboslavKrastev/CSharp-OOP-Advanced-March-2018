using Moq;
using NUnit.Framework;
using System;

namespace P09_DateTimeMocking
{
    public class DateTimeTests
    {
        private ITimeProvider dateTime;
        private Mock<ITimeProvider> mockedDt;

        [SetUp]
        public void InitializeTests()
        {
            this.dateTime = new CustomDateTime();
            this.mockedDt = new Mock<ITimeProvider>();
        }

        [Test]
        public void DateTimeNowShouldReturnCorrectDate()
        {
            DateTime expectedTime = DateTime.Now.Date;
            DateTime returnedTime = dateTime.Now.Date;

            Assert.AreEqual(expectedTime, returnedTime);
        }

        [Test]
        public void DateTimeNowShouldReturnCorrectDay()
        {
            int expectedTime = DateTime.Now.Day;
            int returnedTime = dateTime.Now.Day;

            Assert.AreEqual(expectedTime, returnedTime);
        }

        [Test]
        public void DateTimeNowShouldReturnCorrectMonth()
        {
            int expectedTime = DateTime.Now.Month;
            int returnedTime = dateTime.Now.Month;

            Assert.AreEqual(expectedTime, returnedTime);
        }

        [Test]
        public void DateTimeAddDayInTheMiddleOfTheMonthShouldReturnCorrectDay()
        {
            mockedDt.Setup(x => x.Now).Returns(new DateTime(2018, 06, 15));

            DateTime dateTime = mockedDt.Object.Now.AddDays(1);

            Assert.AreEqual(16, dateTime.Day);
        }

        [Test]
        public void DateTimeAddDayAtEndOfMonthShouldChangeToNextMonth()
        {
            mockedDt.Setup(x => x.Now).Returns(new DateTime(2018, 04, 30));

            DateTime dateTime = mockedDt.Object.Now.AddDays(1);

            Assert.AreEqual(5, dateTime.Month);
        }

        [Test]
        public void DateTimeAddingNegativeDaysShouldReturnCorrectDay()
        {
            mockedDt.Setup(x => x.Now).Returns(new DateTime(2018, 06, 15));

            DateTime dateTime = mockedDt.Object.Now.AddDays(-5);

            Assert.AreEqual(10, dateTime.Day);
        }

        [Test]
        public void DateTimeAddingNegativeDaysAtStartOfMonthShouldChangeToPreviousMonth()
        {
            mockedDt.Setup(x => x.Now).Returns(new DateTime(2018, 06, 1));

            DateTime dateTime = mockedDt.Object.Now.AddDays(-5);

            Assert.AreEqual(5, dateTime.Month);
        }

        [Test]
        public void DateTimeAddingDaysToLeapYearsShouldReturnCorrectDay()
        {
            mockedDt.Setup(x => x.Now).Returns(new DateTime(2008, 02, 28));

            DateTime dateTime = mockedDt.Object.Now.AddDays(1);

            Assert.AreEqual(29, dateTime.Day);
        }

        [Test]
        public void DateTimeAddingDaysToNonLeapYearsShouldReturnCorrectDay()
        {
            mockedDt.Setup(x => x.Now).Returns(new DateTime(2018, 02, 28));

            DateTime dateTime = mockedDt.Object.Now.AddDays(1);

            Assert.AreEqual(1, dateTime.Day);
        }

        [Test]
        public void DateTimeAddingDaysToLeapYearsShouldReturnCorrectMonth()
        {
            mockedDt.Setup(x => x.Now).Returns(new DateTime(2008, 02, 28));

            DateTime dateTime = mockedDt.Object.Now.AddDays(1);

            Assert.AreEqual(2, dateTime.Month);
        }

        [Test]
        public void DateTimeAddingDaysToNonLeapYearsShouldReturnCorrectMonth()
        {
            mockedDt.Setup(x => x.Now).Returns(new DateTime(2007, 02, 28));

            DateTime dateTime = mockedDt.Object.Now.AddDays(1);

            Assert.AreEqual(3, dateTime.Month);
        }

        [Test]
        public void DateTimeAddingDaysToDateTimeMaxValueThrows()
        {
            mockedDt.Setup(x => x.Now).Returns(DateTime.MaxValue);

            Assert.Throws<ArgumentOutOfRangeException>(() => mockedDt.Object.Now.AddDays(1));
        }

        [Test]
        public void DateTimeAddingDaysToDateTimeMinValueDoesntThrow()
        {
            mockedDt.Setup(x => x.Now).Returns(DateTime.MinValue);

            Assert.That(() => mockedDt.Object.Now.AddDays(1), Throws.Nothing);
        }


        [Test]
        public void DateTimeSubstractingDaysFromDateTimeMinValueThrows()
        {
            mockedDt.Setup(x => x.Now).Returns(DateTime.MinValue);

            var daysToSubstract = TimeSpan.FromDays(2);

            Assert.Throws<ArgumentOutOfRangeException>(() => mockedDt.Object.Now.Subtract(daysToSubstract));
        }

        [Test]
        public void DateTimeSubstractingDaysFromDateTimeMaxValueDoesntThrow()
        {
            mockedDt.Setup(x => x.Now).Returns(DateTime.MaxValue);

            var daysToSubstract = TimeSpan.FromDays(2);

            Assert.That(() => mockedDt.Object.Now.Subtract(daysToSubstract), Throws.Nothing);
        }
    }
}
