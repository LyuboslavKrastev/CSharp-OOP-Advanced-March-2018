using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace P03_IteratorTests
{
    public class IteratorTests
    {
        private string[] values;
        private ListyIterator listIterator;

        [SetUp]
        public void InitializeTest()
        {
            this.values = new string[] { "Pesho", "Gosho", "Mimi", "Menethil", "Dragan" };
            this.listIterator = new ListyIterator(values);     
        }

        [Test]
        public void IteratorConstructorCantBeInitializedWithNull()
        {
            Assert.That(() => new ListyIterator(null), Throws.ArgumentNullException);
        }

        [Test]
        public void IteratorCanMoveToNextIndex()
        {
             Assert.IsTrue(listIterator.Move());
        }

        [Test]
        public void IterartorCantMoveOutOfCapacity()
        {
            this.MoveToEndOfIterator();

            Assert.IsFalse(listIterator.Move());
        }

 
        [Test]
        public void IteratorReturnsTrueIfHasNextElement()
        {
            Assert.IsTrue(listIterator.HasNext());
        }

        [Test]
        public void IteratorReturnsFalseIfItDoesntHaveANextElement()
        {
            this.MoveToEndOfIterator();

            Assert.IsFalse(listIterator.HasNext());
        }

        [Test]
        public void IteratorPrintingThrowsNoExceptionsIfNotEmpty()
        {
            Assert.That(listIterator.Print, Throws.Nothing);
        }

        [Test]
        public void IteratorPrintingThrowsIfEmpty()
        {
            List<string> emptyCollection = new List<string>();

            listIterator = new ListyIterator(emptyCollection);

            Assert.Throws<InvalidOperationException>(() => listIterator.Print());
        }

        private void MoveToEndOfIterator()
        {
            for (int i = 0; i < this.values.Length - 1; i++)
            {
                listIterator.Move();
            }
        }

    }
}
