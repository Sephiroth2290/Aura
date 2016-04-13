
using System.IO;
using System.Xml.Linq;

namespace Aura
{
  public static class Settings
  {
    public static string DarkAgesDirectory
    {
      get
      {
        return Path.GetDirectoryName(DarkAgesPath);
      }
    }

    public static string DarkAgesPath { get; set; }

    public static string DataPath { get; set; }

    public static string MapsDirectory
    {
      get
      {
        return Path.Combine(DataPath, "maps");
      }
    }

    static Settings()
    {
            DarkAgesPath = "C:\\Users\\Public\\Games\\Dark Ages\\Darkages.exe";
            DataPath = "C:\\Users\\Public\\Games\\Dark Ages";
    }

    public static void Load()
        {
            if (File.Exists(Program.StartupPath + "\\settings.xml"))
            {
                XDocument xDocument = XDocument.Load(Program.StartupPath + "\\settings.xml");
                if (xDocument.Element("Settings") != null)
                {
                    XElement xElement = xDocument.Element("Settings");
                    if (xElement.Element("DarkAgesPath") != null)
                    {
                        DarkAgesPath = xElement.Element("DarkAgesPath").Value;
                    }
                    if (xElement.Element("DataPath") != null)
                    {
                        DataPath = xElement.Element("DataPath").Value;
                    }
                }
            }
        }

        public static void Save()
        {
            XDocument xDocument = new XDocument();
            xDocument.Add(new XElement("Settings", new object[]
            {
                new XElement("DarkAgesPath", DarkAgesPath),
                new XElement("DataPath", DataPath)
            }));
            xDocument.Save(Program.StartupPath + "\\settings.xml");
        }
    }
}
