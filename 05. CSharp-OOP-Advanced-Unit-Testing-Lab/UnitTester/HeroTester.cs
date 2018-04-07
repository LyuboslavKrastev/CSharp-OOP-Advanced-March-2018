using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTester
{
    public class HeroTester
    {
        [Test]
        public void HeroGainsExperienceAfterAttackIfTargetDies()
        {
            var expectedExperience = 5;
            Mock<ITarget> fakeTarget = new Mock<ITarget>();

            fakeTarget.Setup(t => t.IsDead()).Returns(true);

            fakeTarget.Setup(t => t.GiveExperience()).Returns(expectedExperience);

            var weapon = new Mock<IWeapon>();

            var hero = new Hero("Pesho", weapon.Object);

            hero.Attack(fakeTarget.Object);

            Assert.That(hero.Experience, Is.EqualTo(expectedExperience));
        }
    }
}
