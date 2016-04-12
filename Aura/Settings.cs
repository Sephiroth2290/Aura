
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
        if (!File.Exists(Program.StartupPath + "\\settings.xml"))
            return;
        XDocument xdocument = XDocument.Load(Program.StartupPath + "\\settings.xml");
        if (xdocument.Element("Settings") == null)
            return;
        XElement xelement = xdocument.Element("Settings");
        if (xelement.Element("DarkAgesPath") != null)
                DarkAgesPath = xelement.Element("DarkAgesPath").Value;
        if (xelement.Element("DataPath") == null)
            return;
            DataPath = xelement.Element("DataPath").Value;
    }

    public static void Save()
    {
        XDocument xdocument1 = new XDocument();
        XDocument xdocument2 = xdocument1;
        XName name = "Settings";
        object[] objArray = new object[2];
        int index1 = 0;
        XElement xelement1 = new XElement("DarkAgesPath", DarkAgesPath);
        objArray[index1] = xelement1;
        int index2 = 1;
        XElement xelement2 = new XElement("DataPath", DataPath);
        objArray[index2] = xelement2;
        XElement xelement3 = new XElement(name, objArray);
        xdocument2.Add(xelement3);
        xdocument1.Save(Program.StartupPath + "\\settings.xml");
    }
  }
}
