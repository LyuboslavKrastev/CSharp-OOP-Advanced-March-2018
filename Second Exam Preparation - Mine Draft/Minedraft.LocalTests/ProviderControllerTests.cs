using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

[TestFixture]
public class ProviderControllerTests
{
    private ProviderController providerController;
    private EnergyRepository energyRepository;

    [SetUp]
    public void InitializeProviderController()
    {
        this.energyRepository = new EnergyRepository();
        this.providerController = new ProviderController(energyRepository);
    }

    [Test]
    public void ProducesCorrectEnergyAmount()
    {
        List<string> providerOne = new List<string>()
        {
            "Solar", "1", "100"
        };

        List<string> providerTwo = new List<string>()
        {
            "Solar", "2", "100"
        };

        int expectedProducedEnergy = 1000;

        this.providerController.Register(providerOne);
        this.providerController.Register(providerTwo);

        for (int i = 0; i < 5; i++)
        {
            this.providerController.Produce();
        }

        Assert.AreEqual(expectedProducedEnergy, this.providerController.TotalEnergyProduced);
    }

    [Test]
    public void ProviderIsRemovedWhenBroken()
    {
        List<string> providerOne = new List<string>()
        {
            "Pressure", "1", "100"
        };

        this.providerController.Register(providerOne);

        for (int i = 0; i < 8; i++)
        {
            this.providerController.Produce();
        }

        Assert.AreEqual(0, this.providerController.Entities.Count);
    }

    [Test]
    public void ProviderIsRepairedCorrectly()
    {
        List<string> providerOne = new List<string>()
        {
            "Solar", "1", "100"
        };

        this.providerController.Register(providerOne);
        this.providerController.Repair(100);

        int expectedDurability = 1600;

        Assert.AreEqual(expectedDurability, this.providerController.Entities.First().Durability);
    }
}


