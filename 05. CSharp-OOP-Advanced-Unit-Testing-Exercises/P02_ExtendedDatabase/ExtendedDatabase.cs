using System;
using System.Collections.Generic;
using System.Linq;

namespace P02_ExtendedDatabase
{
    public class ExtendedDatabase
    {
        private const int DefaultCapacity = 16;
        private Person[] innerCollection;
        public readonly int Capacity = DefaultCapacity;

        private int currentIndex;

        public int Count => this.currentIndex;


        public ExtendedDatabase(IEnumerable<Person> initialIntegers)
        {
            this.InnerCollection = initialIntegers.ToArray();
        }

        public Person GetLastElement()
        {
            return this.InnerCollection[Count - 1];
        }

        public Person[] InnerCollection
        {
            get
            {
                return this.innerCollection;
            }
            set
            {
                if (value.Length > 16 || value.Length < 1)
                {
                    throw new InvalidOperationException();
                }

                this.innerCollection = new Person[DefaultCapacity];

                for (int i = 0; i < value.Length; i++)
                {
                    this.innerCollection[i] = value[i];
                }

                this.currentIndex = value.Length;
            }
        }

        public void Add(Person person)
        {
            if (this.currentIndex == DefaultCapacity)
            {
                throw new InvalidOperationException("The Database is Full!");
            }

            if (this.InnerCollection.Any())
            {
                CheckUserCredentials(person);
            }
          

            this.innerCollection[currentIndex] = person;

            currentIndex++;
        }

        public void Remove()
        {
            if (this.currentIndex == 0)
            {
                throw new InvalidOperationException("The Database is Empty!");
            }

            this.innerCollection[currentIndex] = default(Person);
            currentIndex--;
        }


        public Person[] Fetch()
        {
            var elements = this.innerCollection;
            return elements;
        }

        public Person FindByUsername(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Invalid Username!");
            }

            Person user = null;

            for (int i = 0; i < currentIndex; i++)
            {
                var currentPerson = this.innerCollection[i];

                if (currentPerson.UserName == userName)
                {
                    user = currentPerson;
                }
            }

            if (user == default(Person))
            {
                throw new InvalidOperationException("No User found with the provided Username.");
            }

            return user;
        }

        public Person FindById(int id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            Person user = null;

            for (int i = 0; i < currentIndex; i++)
            {
                var currentPerson = this.innerCollection[i];

                if (currentPerson.Id == id)
                {
                    user = currentPerson;
                }
            }

            if (user == default(Person))
            {
                throw new InvalidOperationException("No User found with the provided Id.");
            }

            return user;
        }

        private void CheckUserCredentials(Person person)
        {
            for (int i = 0; i < currentIndex; i++)
            {
                var currentPerson = this.innerCollection[i];
                if(currentPerson.Id == person.Id)
                {
                    throw new InvalidOperationException("A person with the provided Id already exists!");
                }
                if (currentPerson.UserName == person.UserName)
                {
                    throw new InvalidOperationException("A person with the provided Username already exists!");
                }
            }           
        }

    }
}
