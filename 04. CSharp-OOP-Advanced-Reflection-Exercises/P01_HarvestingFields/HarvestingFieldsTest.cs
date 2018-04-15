 namespace P01_HarvestingFields
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            Type type = Type.GetType("P01_HarvestingFields.HarvestingFields");

            FieldInfo[] allFields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
            string command;
          

            while ((command = Console.ReadLine()) != "HARVEST")
            {
                IEnumerable<FieldInfo> fieldsToPrint = null;

                switch (command)
                {
                    case "public":
                        fieldsToPrint = allFields.Where(f => f.IsPublic);
                        break;
                    case "protected":
                        fieldsToPrint = allFields.Where(f => f.IsFamily);
                        break;
                    case "private":
                        fieldsToPrint = allFields.Where(f => f.IsPrivate);
                        break;
                    case "all":
                        fieldsToPrint = allFields;
                        break;
                }

                foreach (var field in fieldsToPrint)
                {
                    Print(field);
                }
            }

    


        }

        private static void Print(FieldInfo field)
        {
            string access = field.Attributes.ToString().ToLower();

            if (field.Attributes == FieldAttributes.Family)
            {
                access = "protected";
            }

            string fieldString = $"{access} {field.FieldType.Name} {field.Name}";
            Console.WriteLine(fieldString);
        }
    }
}
