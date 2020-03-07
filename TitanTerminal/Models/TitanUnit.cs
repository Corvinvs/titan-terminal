using System;
namespace TitanTerminal.Models
{
    public class TitanUnit
    {
        // Profile
        public string Speed { get; set; }

        public string Command { get; set; }

        public string BallisticSkill { get; set; }

        public string WeaponSkill { get; set; }

        public string Manuever { get; set; }

        public string ServitorClades { get; set; }

        public string Scale { get; set; }

        public TitanType Type { get; set; }

        // Structure
        public int Body { get; set; }

        public int BodyCritical { get; set; }

        public int Legs { get; set; }

        public int LegsCritical { get; set; }

        public int Head { get; set; }

        public int HeadCritical { get; set; }

        public int Plasma { get; set; }

        public string Shields { get; set; }
    }
}
