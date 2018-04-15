using BashSoft.Contracts;
using BashSoft.DataStructures;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BashSoft_Testing
{
    [TestFixture]
    public class OrderedDataStructureTester
    {
        private ISimpleOrderedBag<string> names;
        private int expectedCapacity; 
        private int expectedSize;


        [SetUp]
        public void SetUp()
        {
            this.names = new SimpleSortedList<string>();
            this.expectedCapacity = 16; //the default capacity of the collection
            this.expectedSize = 0; // the default size of the collection
        }

        [Test]
        public void TestEmptyCtor()
        {
            Assert.AreEqual(expectedSize, this.names.Size);
            Assert.AreEqual(expectedCapacity, this.names.Capacity);
        }

        [Test]
        public void TestCtorWithInitialCapacity()
        {
            expectedCapacity = 20;

            this.names = new SimpleSortedList<string>(expectedCapacity);

            Assert.AreEqual(expectedSize, this.names.Size);
            Assert.AreEqual(expectedCapacity, this.names.Capacity);
        }

        [Test]
        public void TestCtorWithAllParameters()
        {
            expectedCapacity = 30;

            this.names = new SimpleSortedList<string>(StringComparer.OrdinalIgnoreCase, expectedCapacity);

            Assert.AreEqual(expectedSize, this.names.Size);
            Assert.AreEqual(expectedCapacity, this.names.Capacity);
        }

        [Test]
        public void TestCtorWithInitialComparer()
        {
            expectedCapacity = 16;
            expectedSize = 0;

            this.names = new SimpleSortedList<string>(StringComparer.OrdinalIgnoreCase);

            Assert.AreEqual(expectedSize, this.names.Size);
            Assert.AreEqual(expectedCapacity, this.names.Capacity);
        }

        [Test]
        public void TestAddIncreasesCollectionSize()
        {
            expectedSize = 1;

            this.names.Add("Stamat");

            Assert.AreEqual(expectedSize, this.names.Size);
        }

        [Test]
        public void TestAddActaullyAddsTheElementToTheCollection()
        {
            this.names.Add("Stamat");

            Assert.IsTrue(this.names.Contains("Stamat"));
        }

        [Test]  
        public void TestAddNullThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => this.names.Add(null));
        }


        [Test]
        public void TestAddUnsortedDataIsHeldSorted()
        {
            string[] testCollection = new string[] { "Georgi", "Rosen", "Balkan", "Dragan" };

            for (int i = 0; i < testCollection.Length; i++)
            {
                this.names.Add(testCollection[i]);
            }

            /* sort the testCollection so we can compare it with the sorted names from our
               sorted list */
            Array.Sort(testCollection); 

            Assert.AreEqual(testCollection, names);
        }

        [Test]
        [TestCase(17)]
        [TestCase(22)]
        [TestCase(32)]
        public void TestAddingMoreThanInitialCapacity(int elementsCount)
        {
            char startingNameLetter = 'A'; //to provide quality Pesho-like names

            for (int i = 0; i < elementsCount; i++)
            {                       
                this.names.Add($"{startingNameLetter}esho");
                startingNameLetter++;
            }

            Assert.AreEqual(elementsCount, this.names.Size);
            Assert.AreNotEqual(expectedSize, this.names.Capacity);
        }

        [Test]
        public void TestAddingAllFromCollectionIncreasesSize()
        {
            string[] testCollection = new string[3] { "Stamat", "Stavri", "Kenov" };
            expectedSize = testCollection.Length;

            names.AddAll(testCollection);

            Assert.AreEqual(expectedSize, this.names.Size);
        }

        [Test]
        public void TestAddingAllAboveDefualtCollectionCapacityIncreasesSizeProperly()
        {
            List<String> testCollection = new List<string>{ "Stamat", "Stavri", "Kenov" };
            expectedSize = testCollection.Count;
            char startingNameLetter = 'A'; //to provide quality Pesho-like names

            for (int i = 0; i < 17; i++)
            {
                this.names.Add($"{startingNameLetter}esho");
                expectedSize++;
            }

            names.AddAll(testCollection);

            Assert.AreEqual(expectedSize, this.names.Size);
        }

        [Test]
        public void TestAddingAllFromCollectionActuallyAddsTheElements()
        {
            string[] testCollection = new string[3] { "Stamat", "Stavri", "Kenov" };

            names.AddAll(testCollection);

            foreach (var element in testCollection)
            {
                Assert.IsTrue(this.names.Contains(element));
            }
        }

        [Test]
        public void TestAddingAllFromNullThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => this.names.AddAll(null));
        }

        [Test]
        public void TestAddAllKeepsCollectionSorted()
        {
            string[] testCollection = new string[3] { "Stamat", "Stavri", "Kenov" };

            Array.Sort(testCollection);

            names.AddAll(testCollection);

            Assert.AreEqual(testCollection, this.names);
        }

        [Test]
        public void TestAddingElementIncreasesCollectionSize()
        {
            string pesho = "Pesho";
            this.names.Add(pesho);

            expectedSize = 1;

            Assert.AreEqual(expectedSize, this.names.Size);
        }

        [Test]
        public void TestRemoveValidElementDecreasesCollectionSize()
        {
            string pesho = "Pesho";
            expectedSize = 0;

            this.names.Add(pesho);
            this.names.Remove(pesho);

            Assert.AreEqual(expectedSize, this.names.Size);
        }

        [Test]
        public void TestRemoveValidElementRemovesSelectedOne()
        {
            string[] ivanAndNasko = new string[] { "Ivan", "Nasko" };

            this.names.Remove("Nasko");

            Assert.That(this.names.Contains("Nasko"), Is.False);
        }

        [Test]
        public void TestRemovingNullThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => this.names.Remove(null));
        }

        [Test]
        public void TestJoinWithNullThrowsArgumentNullException()
        {
            string[] ivanAndNasko = new string[] { "Ivan", "Nasko" };

            this.names.AddAll(ivanAndNasko);

            Assert.Throws<ArgumentNullException>(() => this.names.JoinWith(null));
        }

        [Test]
        [TestCase(", ")]
        [TestCase("/")]
        [TestCase("-  ")]
        public void TestJoinWithMethodWorksFine(string joiner)
        {
            string[] allStarsCollection = new string[] { "Ivan", "Nasko", "Blagovest", "Stamat", "Pesho" };

            names.AddAll(allStarsCollection);

            string expectedJoinResult = string.Join(joiner, this.names);

            string namesJoinerResult = names.JoinWith(joiner);

            Assert.AreEqual(expectedJoinResult, namesJoinerResult);
        }
    }
}
