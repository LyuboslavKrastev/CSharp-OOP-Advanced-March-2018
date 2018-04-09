using NUnit.Framework;
using P02_ExtendedDatabase;
using System;
using System.Collections.Generic;

namespace P01_Database
{
    public class ExtendedDatabaseTests
    {
        private Person Pesho;
        private Person Joro;
        private Person Vankata;
        private Person[] initialPeople;
        private const int expectedCapacity = 16;

        private ExtendedDatabase db;
       

        [SetUp]
        public void InitializeTest()
        {       
            this.Pesho = new Person(0, "Pesho"); 
            this.Joro = new Person(1, "Joro");
            this.Vankata = new Person(2, "VankataPcPc"); 
            this.initialPeople = new Person[3] { Pesho, Joro, Vankata };
            this.db = new ExtendedDatabase(initialPeople);
        }

        [Test]
        [Category("Constructor Tests")]
        public void DatabaseConstructorThrowsUponNullInitialization()
        {
            Assert.That(() => new ExtendedDatabase(null), Throws.ArgumentNullException);
        }

        [Test]
        [Category("Constructor Tests")]
        public void DatabaseInnerCollectionIsInitialized()
        {
            var expectedCollection = CreateTestList(16);

            var testDb = new ExtendedDatabase(expectedCollection);
            Assert.AreEqual(expectedCollection, testDb.InnerCollection);
        }

        [Test]
        [Category("Constructor Tests")]
        [TestCase(20)]
        public void DatabaseConstructorCannotBeInitializedWithABiggerCollectionThanTheAllowedCapacity(int capacity)
        {
            List<Person> testList = CreateTestList(capacity);

            Assert.That(() => new ExtendedDatabase(testList), Throws.InvalidOperationException);
        }

        [Test]
        [Category("CapacityTests")]
        public void CapacityIsEqualToTheGivenCapacity()
        {
            Assert.AreEqual(expectedCapacity, db.Capacity);
        }
   
        [Test]
        [Category("Add Tests")]
        public void DatabaseAddsElementAsLastElement()
        {
            int userId = 66;
            string userName = "Tresho";

            Person user = new Person(userId, userName);

            db.Add(user);

            Person lastElement = db.GetLastElement();

            Assert.That(user, Is.EqualTo(lastElement));
            System.Console.WriteLine();
        }

        [Test]
        [Category("Add Tests")]
        public void DatabaseCannotAddExistingUsername()
        {
            int userId = 66;
            string userName = "Pesho";

            Person user = new Person(userId, userName);

            Assert.That(() => db.Add(user), Throws.InvalidOperationException);
        }

        [Test]
        [Category("Add Tests")]
        public void DatabaseCannotAddExistingId()
        {
            int userId = 0;
            string userName = "NewPesho";

            Person user = new Person(userId, userName);

            Assert.That(() => db.Add(user), Throws.InvalidOperationException);
        }

        [Test]
        [Category("Add Tests")]
        [TestCase(expectedCapacity)]
        public void DatabaseCannotAddBeyondCapacity(int capacity)
        {
            Person personToAdd = new Person(55, "GoshoUsera");

            List<Person> testList = CreateTestList(capacity);

            ExtendedDatabase testDb = new ExtendedDatabase(testList);

            Assert.That(() => testDb.Add(personToAdd), Throws.InvalidOperationException);
        }
   
        [Test]
        [Category("Remove Tests")]
        public void DatabaseRemovesLastElement()
        {
            Person expectedElement = db.InnerCollection[db.Count - 2];

            int expectedCount = db.Count - 1;

            db.Remove();

            Assert.AreEqual(expectedCount, db.Count);
            Assert.AreEqual(expectedElement, db.GetLastElement());
        }
     
        [Test]
        [Category("Remove Tests")]
        public void DatabaseCannotRemoveWhenEmpty()
        {
            ExtendedDatabase testDb = new ExtendedDatabase(new List<Person> { new Person(0, "Stamat") });

            testDb.Remove();

            Assert.That(() => testDb.Remove(), Throws.InvalidOperationException);
        }
     
        [Test]
        [Category("Fetch Tests")]
        public void DatabaseFetchesCorrectElements()
        {
            Assert.AreEqual(db.InnerCollection, db.Fetch());
        }

        private static List<Person> CreateTestList(int capacity)
        {
            List<Person> testList = new List<Person>();

            for (int i = 0; i < capacity; i++)
            {
                var person = new Person(i, $"{(char)i}esho");
                testList.Add(person);
            }

            return testList;
        }

        [Test]
        [Category("Find Tests")]
        public void DatabaseNoUserFoundWithProvidedUsername()
        {
            string userName = "Genadi";

            Assert.That(() => db.FindByUsername(userName), Throws.InvalidOperationException);
        }

        [Test]
        [Category("Find Tests")]
        public void DatabaseFindByNullUsernameThrowsException()
        {
            Assert.That(() => db.FindByUsername(null), Throws.ArgumentNullException);
        }

        [Test]
        [Category("Find Tests")]
        public void DatabaseFindByUsernameIsCaseSensitive()
        {
            string userName = "pesho";

            Assert.That(() => db.FindByUsername(userName), Throws.InvalidOperationException);
        }

        [Test]
        [Category("Find Tests")]
        public void DatabaseNoUserFoundWithProvidedId()
        {
            int id = 551;

            Assert.That(() => db.FindById(id), Throws.InvalidOperationException);
        }

        [Test]
        [Category("Find Tests")]
        public void DatabaseNegativeIdsFound()
        {
            int id = -551;

            Assert.Throws<ArgumentOutOfRangeException>(() => db.FindById(id));
        }
    }
}
