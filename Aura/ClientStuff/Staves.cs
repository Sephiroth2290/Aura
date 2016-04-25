using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura.ClientStuff
{
    public class Staves
    {
        public uint Lines { get; set; }

        public string Name { get; set; }

        public Staves(uint lines, string name)
        {
            Name = name;
            Lines = lines;
        }
    }
}
