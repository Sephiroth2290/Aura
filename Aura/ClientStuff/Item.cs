using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura.ClientStuff
{
    public class Item
    {
        public uint Amount { get; set; }

        public uint CurrentDurability { get; set; }

        public byte Icon { get; set; }

        public ushort IconSet { get; set; }

        public int InventorySlot { get; set; }

        public uint MaximumDurability { get; set; }

        public string Name { get; set; }

        public DateTime LastUse { get; set; }

        public byte Stackable { get; set; }

        public int x { get; set; }

        public int y { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
