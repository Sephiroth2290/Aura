using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura.Entity
{
    public class Npc : Character
    {
        public int Image { get; set; }

        public NpcType Type { get; set; }

        public byte Color { get; set; }

        public enum NpcType
        {
            NormalMonster,
            PassableMonster,
            Mundane,
            Item,
        }
    }
}
