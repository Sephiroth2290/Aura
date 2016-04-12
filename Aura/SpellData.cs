using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura
{
    public class SpellData
    {
        public int BaseLines { get; set; }

        public int ManaCost { get; set; }

        public string Name { get; set; }

        public SpellData(string name, int manacost, int baselines)
        {
            this.Name = name;
            this.ManaCost = manacost;
            this.BaseLines = baselines;
        }
    }
}
