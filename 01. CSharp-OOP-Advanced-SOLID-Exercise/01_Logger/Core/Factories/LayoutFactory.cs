using _Logger.Models.Classes.Layouts;
using _Logger.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _Logger.Core.Factories
{
    public class LayoutFactory
    {
        public ILayout CreateLayout(string layoutType)
        {
            switch (layoutType)
            {
                case "SimpleLayout":
                    return new SimpleLayout();
                case "XmlLayout":
                    return new XmlLayout();
                default:
                    throw new ArgumentException("Invalid Layout Type!");
            }
        }
    }
}
