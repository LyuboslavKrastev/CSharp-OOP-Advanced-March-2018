using System.Collections.Generic;

namespace P07_InfernoInfinity.Interfaces
{
    interface IWeaponAttribute
    {
        string Author { get; }

        string Description { get; }

        List<string> Reviewers { get; }

        int Revision { get; }

        string PrintInfo(string field);
    }
}

