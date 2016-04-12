using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura
{
    public class Skill
    {
        public static Dictionary<string, double> Cooldowns { get; set; }

        public int CurrentLevel { get; set; }

        public int Icon { get; set; }

        public int MaximumLevel { get; set; }

        public string Name { get; set; }

        public DateTime NextUse { get; set; }

        public string Caption { get; set; }

        public int SkillSlot { get; set; }

        public Skill()
        {
            this.NextUse = DateTime.UtcNow;
        }

        public override string ToString()
        {
            return string.Format("{0} ({1}/{2})", (object)this.Name, (object)this.CurrentLevel, (object)this.MaximumLevel);
        }
    }
}
