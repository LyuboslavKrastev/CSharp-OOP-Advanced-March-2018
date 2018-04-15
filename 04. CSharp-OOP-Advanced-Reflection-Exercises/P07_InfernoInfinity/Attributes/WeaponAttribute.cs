using P07_InfernoInfinity.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace P07_InfernoInfinity.Models.Attributes
{
    class WeaponAttribute : Attribute, IWeaponAttribute
    {
        public WeaponAttribute(string author, int revision, string description, params string[] reviewers)
        {
            this.Author = author;
            this.Revision = revision;
            this.Description = description;
            this.Reviewers = new List<string>(reviewers.ToList());
        }
        public string Author { get; private set; }

        public string Description { get; private set; }

        public List<string> Reviewers { get; private set; }

        public int Revision { get; private set; }

        public string PrintInfo(string field)
        {
            var joined = (string.Join(", ", this.Reviewers)).ToString();
            var result = (field == "Reviewers") ? ($"Reviewers: {joined}") : string.Empty;
            result = field == "Description" ? $"Class description: {this.Description}" : result;

            if (result == string.Empty)
            {
                var fieldToTake = typeof(WeaponAttribute).GetProperties().FirstOrDefault(p => p.Name == field);
                var fieldValue = fieldToTake.GetValue(this).ToString();
                result = $"{field}: {fieldValue}";
            }

            return result;
        }
    }
}
