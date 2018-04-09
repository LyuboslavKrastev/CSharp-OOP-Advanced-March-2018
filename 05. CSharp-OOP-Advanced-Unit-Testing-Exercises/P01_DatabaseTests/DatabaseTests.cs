using NUnit.Framework;
using System.Collections.Generic;

namespace P01_Database
{
    // Note to self: expected result should always be on the left.
    public class DatabaseTests
    {
        private const int expectedCapacity = 16;

        private int[] initialIntegers;
        private Database db;

        [SetUp]
        public void InitializeTest()
        {
            this.initialIntegers = new int[3] { 0, 1, 2 };
            this.db = new Database(initialIntegers);
        }

        [Test]
        [Category("Constructor Tests")]
        public void DatabaseConstructorThrowsUponNullInitialization()
        {
            Assert.That(() => new Database(null), Throws.ArgumentNullException);
        }

        [Test]
        [Category("Constructor Tests")]
        [TestCase(20)]
        public void DatabaseConstructorCannotBeInitializedWithABiggerCollectionThanTheAllowedCapacity(int capacity)
        {
            List<int> testList = CreateTestList(capacity);

            Assert.That(() => new Database(testList), Throws.InvalidOperationException);
        }

        [Test]
        [Category("CapacityTests")]
        public void CapacityIsEqualToTheGivenCapacity()
        {
            Assert.AreEqual(db.Capacity, expectedCapacity);
        }

        [Test]
        [Category("Add Tests")]
        public void DatabaseAddsElementAsLastElement()
        {
            int intToAdd = 5;

            db.Add(5);

            int lastElement = db.GetLastElement();

            Assert.That(intToAdd, Is.EqualTo(lastElement));
        }

        [Test]
        [Category("Add Tests")]
        [TestCase(expectedCapacity)]
        public void DatabaseCannotAddBeyondCapacity(int capacity)
        {
            int intToAdd = 5;

            List<int> testList = CreateTestList(capacity);

            Database testDb = new Database(testList);

            Assert.That(() => testDb.Add(intToAdd), Throws.InvalidOperationException);
        }

        [Test, Order(0)]
        [Category("Remove Tests")]
        public void DatabaseRemovesLastElement()
        {
            int expectedElement = db.InnerCollection[db.Count - 2];

            int expectedCount = db.Count - 1;

            db.Remove();

            Assert.AreEqual(expectedCount, db.Count);
            Assert.AreEqual(expectedElement, db.GetLastElement());
        }

        [Test, Order(1)]
        [Category("Remove Tests")]
        public void DatabaseCannotRemoveWhenEmpty()
        {
            while (db.Count > 0)
            {
                db.Remove();
            }

            Assert.That(() => db.Remove(), Throws.InvalidOperationException);
        }

        [Test]
        [Category("Fetch Tests")]
        public void DatabaseFetchesCorrectElements()
        {
            Assert.AreEqual(db.InnerCollection, db.Fetch());
        }

        private static List<int> CreateTestList(int capacity)
        {
            List<int> testList = new List<int>();

            for (int i = 0; i < capacity; i++)
            {
                testList.Add(i);
            }

            return testList;
        }

    }
}
