﻿namespace P01_EventImplementation
{
    public class NameChangeEventArgs
    {
        public NameChangeEventArgs(string name)
        {
            this.Name = name;
        }
        public string Name { get; set; }
    }
}
