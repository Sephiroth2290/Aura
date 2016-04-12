﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura
{
    public class Spell
    {
        public string[] Captions { get; set; }

        public int CastLines { get; set; }

        public static Dictionary<string, double> Cooldowns { get; set; }

        public int CurrentLevel { get; set; }

        public int Icon { get; set; }

        public int MaximumLevel { get; set; }

        public string Name { get; set; }

        public DateTime NextUse { get; set; }

        public string Prompt { get; set; }

        public int SpellSlot { get; set; }

        public int Type { get; set; }

        public Spell()
        {
            this.Captions = new string[10];
            this.NextUse = DateTime.UtcNow;
        }

        public override string ToString()
        {
            return string.Format("{0} ({1}/{2})", (object)this.Name, (object)this.CurrentLevel, (object)this.MaximumLevel);
        }
    }
}
