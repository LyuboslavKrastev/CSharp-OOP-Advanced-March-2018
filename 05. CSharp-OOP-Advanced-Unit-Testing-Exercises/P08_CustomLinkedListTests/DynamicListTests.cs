using CustomLinkedList;
using NUnit.Framework;
using System;

namespace P08_CustomLinkedListTests
{
    public class DynamicListTests
    {
        private const string IndexMissmatchError = "The returned index does not match the expected one.";
        private DynamicList<int> unitTestedSystem;

        [SetUp]
        public void TestInit()
        {
            this.unitTestedSystem = new DynamicList<int>();
        }

        [TestCase(-1)]
        public void DynamicListCannotGetElementWithNegativeIndex(int negativeIndex)
        {
            // Assert
            Assert.That(() => 
            this.unitTestedSystem[negativeIndex], 
            Throws.InstanceOf<ArgumentOutOfRangeException>(), 
            "The provided index was negative.");
        }

        [TestCase(int.MaxValue)]
        [Test]
        public void DynamicListCannotGetElementWithIndexAboveItsCapacity(int greaterThanCapacityIndex)
        {
            // Assert
            Assert.That(() =>
             this.unitTestedSystem[greaterThanCapacityIndex], 
             Throws.InstanceOf<ArgumentOutOfRangeException>(),
            "The provided index was greater than the collection capacity.");
        }

        [Test]
        public void DynamicListAddShouldIncreaseCollectionCount()
        {
            //Arrange
            int expectedCount = 4;

            //Act
            this.SeedList(expectedCount);

            // Assert
            Assert.AreEqual(expectedCount, this.unitTestedSystem.Count,
                "The dynamic list counter does not increase when adding elements to the collection.");
        }

        [TestCase(5)]
        [TestCase(3)]
        [TestCase(17)]
        [TestCase(21)]
        public void DynamicListShouldSaveElementAtTheEndOfTheCollection(int numberOfElements)
        {
            // Arrange
            this.SeedList(numberOfElements);
            int expectedElement = numberOfElements - 1;
            int lastIndex = this.unitTestedSystem.Count - 1;
            int lastElement = this.unitTestedSystem[lastIndex];

            // Assert
            Assert.AreEqual(expectedElement, lastElement, "Element is not the same as the one added");
        }

        [TestCase(-5)]
        [TestCase(5)]
        public void DynamicListThrowsUponTryingToRemoveOutOfRangeIndex(int outOfRageIndex)
        {
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => this.unitTestedSystem.RemoveAt(outOfRageIndex));
        }

        [TestCase(5, 2)]
        [TestCase(7, 6)]
        [TestCase(3, 2)]
        [TestCase(2, 0)]
        public void DyamicListRemoveAtShouldRemoveTheElementAtTheGivenIndex(int numberOfElements, int indexToRemove)
        {
            // Arrange
            this.SeedList(numberOfElements);
            int expectedElement = unitTestedSystem[indexToRemove];

            // Act
            int returnedElement = this.unitTestedSystem.RemoveAt(indexToRemove);

            // Assert
            Assert.AreEqual(expectedElement, returnedElement);
        }

        [Test]
        [TestCase(6)]
        public void IndexOfShouldReturnTheIndexPointingAtTheCurrentLocationOfTheElement(int numberOfElements)
        {
            //Arrange
            this.SeedList(numberOfElements);

            for (int i = 0; i < numberOfElements; i++)
            {
                int expectedIndex = i;

                //Act
                int returnedIndex = this.unitTestedSystem.IndexOf(i);

                //Assert
                Assert.AreEqual(expectedIndex, returnedIndex, IndexMissmatchError);
            }
          
        }

        [TestCase(5)]
        public void DynamicListShouldReturnMinusOneIfTheElementOfIndexOfIsNotFound(int numberOfElements)
        {
            // Arrange
            this.SeedList(numberOfElements);
            int expectedIndex = -1;

            // Act
            int returnedIndex = this.unitTestedSystem.IndexOf(600);

            // Assert
            Assert.AreEqual(expectedIndex, returnedIndex, IndexMissmatchError);
        }

        [TestCase(5, 4)]
        [TestCase(16, 2)]
        [TestCase(3, 0)]
        public void DynamicListRemoveShouldRemoveTheProvidedElement(int numberOfElements, int elementToRemove)
        {
            // Arrange
            this.SeedList(numberOfElements);
            int expectedIndex = this.unitTestedSystem.IndexOf(elementToRemove);

            // Act
            int returnedIndex = this.unitTestedSystem.Remove(elementToRemove);

            // Assert
            Assert.AreEqual(expectedIndex, returnedIndex, IndexMissmatchError);
        }

        [Test]
        [TestCase(5, 2)]
        [TestCase(15, -1)]
        [TestCase(2, 10)]
        public void DynamicListRemoveShouldReturnTheIndexOfTheRemovedElement(int numberOfAdditions, int elementToRemove)
        {
            // Arrange
            this.SeedList(numberOfAdditions);
            int expectedIndex = this.unitTestedSystem.IndexOf(elementToRemove);

            // Act
            int returnedIndex =  this.unitTestedSystem.Remove(elementToRemove);

            // Assert
            Assert.AreEqual(expectedIndex, returnedIndex, IndexMissmatchError);
        }

        [Test]
        [TestCase(3, 55)]
        [TestCase(5, 42)]
        [TestCase(10, -5)]
        public void DynamicListRemoveShouldReturnMinusOneUponNotFindingElement(int numberOfElements, int elementToRemove)
        {
            // Arrange 
            this.SeedList(numberOfElements);
            var expectedIndex = -1;

            // Act
            var returnedIndex = this.unitTestedSystem.Remove(elementToRemove);

            // Assert
            Assert.AreEqual(expectedIndex, returnedIndex, IndexMissmatchError);
        }

        [Test]
        [TestCase(2, 1)]
        [TestCase(3, 0)]
        [TestCase(4, 3)]
        public void DynamicListContainsShouldReturnTrueUponFindingElementTroughContains(int numberOfElements, int keyElement)
        {
            // Arrange
            this.SeedList(numberOfElements);

            // Assert
            Assert.IsTrue(this.unitTestedSystem.Contains(keyElement), 
                "The element exists in the collection but it returned false.");
        }

        [TestCase(3, 55)]
        [TestCase(5, -4)]
        public void DynamicListContainsShouldReturnFalseUponNotFindingElementTroughContains(int numberOfElements, int keyElement)
        {
            // Arrange
            this.SeedList(numberOfElements);

            // Assert
            Assert.IsFalse(this.unitTestedSystem.Contains(keyElement),
               "The element does not exist in the collection but it returned true.");
        }

        private void SeedList(int numberOfElements)
        {
            for (int i = 0; i < numberOfElements; i++)
            {
                this.unitTestedSystem.Add(i);
            }
        }
    }
}
