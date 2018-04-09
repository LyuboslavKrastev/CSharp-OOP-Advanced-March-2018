using Moq;
using NUnit.Framework;
using System.Reflection;
using TDDMicroExercises.TirePressureMonitoringSystem;

namespace P10_TirePressureMSTests
{
    public class AlarmTests
    {
        private Mock<ISensor> mockedSensor;
        private IAlarm alarm;

        [SetUp]
        public void InitializeTest()
        {
            this.mockedSensor = new Mock<ISensor>();
            this.alarm = new Alarm();
        }

        [Test]
        public void AlarmOnIsFalseByDefault()
        {
            Assert.IsFalse(alarm.AlarmOn);
        }

        [TestCase(17)]
        [TestCase(18)]
        [TestCase(19)]
        [TestCase(20)]
        [TestCase(21)]
        public void AlarmOnShouldBeFalseInTheProvidedCases(double testValue)
        {
            //Arrange
            this.mockedSensor.Setup(ms => ms.PopNextPressurePsiValue()).Returns(testValue);

            FieldInfo sensor = this.alarm.GetType()
                .GetField("_sensor", BindingFlags.Instance | BindingFlags.NonPublic);

            sensor.SetValue(this.alarm, this.mockedSensor.Object);

            //Act
            this.alarm.Check();

            //Assert
            Assert.AreEqual(false, this.alarm.AlarmOn);
        }

        [TestCase(170)]
        [TestCase(-18)]
        [TestCase(5)]
        public void AlarmOnShouldBeTrueInTheProvidedCases(double testValue)
        {
            //Arrange
            this.mockedSensor.Setup(ms => ms.PopNextPressurePsiValue()).Returns(testValue);

            FieldInfo sensor = this.alarm.GetType()
                .GetField("_sensor", BindingFlags.Instance | BindingFlags.NonPublic);

            sensor.SetValue(this.alarm, this.mockedSensor.Object);

            //Act
            this.alarm.Check();

            //Assert
            Assert.AreEqual(true, this.alarm.AlarmOn);
        }
    }
}
