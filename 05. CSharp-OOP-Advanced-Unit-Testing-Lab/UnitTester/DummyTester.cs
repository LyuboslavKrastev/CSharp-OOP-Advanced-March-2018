using NUnit.Framework;


namespace UnitTester
{
    public class DummyTester
    {
        private const int AxeAttack = 2;
        private const int AxeDurability = 2;
        private const int DummyHealth = 20;
        private const int DummyXP = 20;

        private Axe axe;
        private Dummy dummy;

        [SetUp]

        public void InitializeTest()
        {
            this.axe = new Axe(AxeAttack, AxeDurability);
            this.dummy = new Dummy(DummyHealth, DummyXP);
        }

        [Test]
        public void DummyLosesHealthIfAttacked()
        {
            var expectedhealth = dummy.Health - axe.AttackPoints;

            dummy.TakeAttack(axe.AttackPoints);        

            Assert.That(dummy.Health, Is.EqualTo(expectedhealth));
        }

        [Test]
        public void DeadDummyCantBeAttacked()
        {
            DestroyDummy();
            Assert.That(() => dummy.TakeAttack(axe.AttackPoints), Throws.InvalidOperationException);
        }

        [Test]
        public void DeadDummyCanGiveXp()
        {
            DestroyDummy();

            Assert.That(() => dummy.GiveExperience(), Throws.Nothing);
        }

        [Test]
        public void AliveDummyCantGiveXp()
        {

            Assert.That(() => dummy.GiveExperience(), Throws.InvalidOperationException);
        }

        private void DestroyDummy()
        {
            while (dummy.Health > 0)
            {
                dummy.TakeAttack(axe.AttackPoints);
            }
        }

    }
}
