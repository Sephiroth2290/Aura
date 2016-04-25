using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aura.ClientStuff;

namespace Aura.Entity
{
    public class UserlistItem
    {
        public string Name { get; set; }

        public Status Status { get; set; }

        public string Title { get; set; }

        public bool Visible { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
