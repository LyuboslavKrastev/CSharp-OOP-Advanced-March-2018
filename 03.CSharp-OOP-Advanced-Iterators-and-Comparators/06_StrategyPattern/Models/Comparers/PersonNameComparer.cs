using System;
using System.Collections.Generic;
using System.Text;

public class PersonNameComparer : IComparer<Person>
{
    public int Compare(Person firstPerson, Person secondPerson)
    {
        var result = firstPerson.Name.Length.CompareTo(secondPerson.Name.Length);

        if (result == 0)
        {
            var firstPersonLetter = char.ToLower(firstPerson.Name[0]);
            var secondPersonLetter = char.ToLower(secondPerson.Name[0]);

            result = firstPersonLetter.CompareTo(secondPersonLetter);
        }

        return result;
    }
}

