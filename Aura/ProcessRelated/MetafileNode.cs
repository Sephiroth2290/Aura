using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura.ProcessRelated
{
    internal class MetafileNode
    {
        internal string Name { get; private set; }

        internal List<string> Properties { get; private set; }

        internal MetafileNode(string name)
        {
            this.Name = name;
            this.Properties = new List<string>();
        }

        internal MetafileNode(string name, params string[] properties)
        {
            this.Name = name;
            this.Properties = new List<string>((IEnumerable<string>)properties);
        }

        internal MetafileNode(string name, params object[] properties)
        {
            this.Name = name;
            this.Properties = new List<string>(Enumerable.Select<object, string>((IEnumerable<object>)properties, (Func<object, string>)(o => o.ToString())));
        }
    }
}
