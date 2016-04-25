using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura.Entity
{
    public class Statistics
    {
        public int Ability { get; set; }

        public uint AbilityExp { get; set; }

        public int ArmorClass { get; set; }

        public Elements AttackElement { get; set; }

        public int AttackElement2 { get; set; }

        public int AvailablePoints { get; set; }

        public int BitMask { get; set; }

        public int Con { get; set; }

        public uint CurrentHP { get; set; }

        public uint CurrentMP { get; set; }

        public int CurrentWeight { get; set; }

        public int Damage { get; set; }

        public Elements DefenseElement { get; set; }

        public int DefenseElement2 { get; set; }

        public int Dex { get; set; }

        public uint Experience { get; set; }

        public uint GamePoints { get; set; }

        public uint Gold { get; set; }

        public int Hit { get; set; }

        public int Int { get; set; }

        public int Level { get; set; }

        public int MagicResistance { get; set; }

        public uint MaximumHP { get; set; }

        public uint MaximumMP { get; set; }

        public int MaximumWeight { get; set; }

        public int Str { get; set; }

        public uint ToNextAbility { get; set; }

        public uint ToNextLevel { get; set; }

        public int Wis { get; set; }

        public enum Elements
        {
            None,
            Fire,
            Sea,
            Wind,
            Earth,
            Light,
            Dark,
            Wood,
            Metal,
            Undead,
        }
    }
}
