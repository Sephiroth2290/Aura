using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura.MapRelated
{
    public class Town
    {
        public string Name { get; set; }

        public uint Number { get; set; }

        public ushort DestX { get; set; }

        public ushort DestY { get; set; }

        public Town()
        {
            this.Name = string.Empty;
            this.Number = 0U;
            this.DestX = (ushort)0;
            this.DestY = (ushort)0;
        }
    }
}
