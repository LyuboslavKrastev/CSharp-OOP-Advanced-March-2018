using NUnit.Framework;

namespace Skeleton.Testers
{
    public class AxeTester
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
        public void AxeLosesDurabilityAfterAttack()
        {
            var expectedDurability = axe.AttackPoints-1;

            axe.Attack(dummy);

            Assert.That(axe.DurabilityPoints, Is.EqualTo(expectedDurability));
        }

        [Test]
        public void BrokenAxeCantAttack()
        {
            DestroyAxe();

            Assert.That(() => axe.Attack(dummy), Throws.InvalidOperationException);
        }

        private void DestroyAxe()
        {
            while (axe.DurabilityPoints > 0)
            {
                axe.Attack(dummy);
            }
        }
    }
}
