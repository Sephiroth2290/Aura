using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura.Entity
{
    public class Legend
    {
        private Dictionary<string, LegendMark> _items;

        public int Count
        {
            get
            {
                return this._items.Count;
            }
        }

        internal ICollection<string> Keys
        {
            get
            {
                return (ICollection<string>)this._items.Keys;
            }
        }

        internal ICollection<LegendMark> Values
        {
            get
            {
                return (ICollection<LegendMark>)this._items.Values;
            }
        }

        public LegendMark this[string key]
        {
            get
            {
                return this._items[key];
            }
            internal set
            {
                this._items[key] = value;
            }
        }

        internal Legend()
        {
            this._items = new Dictionary<string, LegendMark>();
        }

        internal void Add(string key, LegendMark value)
        {
            this._items.Add(key, value);
        }

        internal bool Remove(string key)
        {
            return this._items.Remove(key);
        }

        internal void Clear()
        {
            this._items.Clear();
        }

        public bool ContainsKey(string key)
        {
            return this._items.ContainsKey(key);
        }

        public bool TryGetValue(string key, out LegendMark value)
        {
            return this._items.TryGetValue(key, out value);
        }
    }
}
