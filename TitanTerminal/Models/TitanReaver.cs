using System;
using TitanTerminal.Contracts;

namespace TitanTerminal.Models
{
    public class TitanReaver : ITitan
    {
        public TitanType Type => TitanType.Reaver;
        public int Scale => 8;
        public string ScaleDescription => "IMENNSUS";
        public int Cost => 250;
    }
}
