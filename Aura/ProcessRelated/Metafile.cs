using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Aura.ProcessRelated
{
    internal class Metafile
    {
        internal string Name { get; private set; }

        internal List<MetafileNode> Nodes { get; private set; }

        internal Metafile(string name)
        {
            this.Name = name;
            this.Nodes = new List<MetafileNode>();
        }

        internal Metafile(string name, params MetafileNode[] nodes)
        {
            this.Name = name;
            this.Nodes = new List<MetafileNode>((IEnumerable<MetafileNode>)nodes);
        }

        internal static Metafile Load(string path)
        {
            Metafile metafile = new Metafile(Path.GetFileNameWithoutExtension(path));
            FileStream fileStream = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            BinaryReader binaryReader = new BinaryReader((Stream)fileStream, Encoding.GetEncoding(949));
            int num1 = (int)binaryReader.ReadByte() << 8 | (int)binaryReader.ReadByte();
            for (int index1 = 0; index1 < num1; ++index1)
            {
                MetafileNode metafileNode = new MetafileNode(binaryReader.ReadString());
                int num2 = (int)binaryReader.ReadByte() << 8 | (int)binaryReader.ReadByte();
                for (int index2 = 0; index2 < num2; ++index2)
                {
                    int count = (int)binaryReader.ReadByte() << 8 | (int)binaryReader.ReadByte();
                    byte[] bytes = binaryReader.ReadBytes(count);
                    metafileNode.Properties.Add(Encoding.GetEncoding(949).GetString(bytes));
                }
                metafile.Nodes.Add(metafileNode);
            }
            binaryReader.Close();
            fileStream.Close();
            return metafile;
        }
    }
}
