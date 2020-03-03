using System;
using System.Xml.Linq;

namespace TitanTerminal.Models
{
    public class Unit
    {
        public string Name { get; set; }
        public int Cost { get; set; }
        public XElement UnitElement { get; set; }
    }
}
