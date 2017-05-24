using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CollectionsProject
{
    class Localization
    {
        static string GetValue(string name)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(Settings.Language + ".xml");
            XmlElement xRoot = xDoc.DocumentElement;
            foreach (XmlNode item in xRoot.ChildNodes)
            {
                if (item.Attributes["name"].Value == name)
                    return item.Attributes["value"].Value;
            }

            return null;
        }

        public static string PROGRAM_TITLE { get { return GetValue("PROGRAM_TITLE"); } }
        public static string FILE { get { return GetValue("FILE"); } }
        public static string CREATE_BASE { get { return GetValue("CREATE_BASE"); } }
        public static string OPEN_BASE { get { return GetValue("OPEN_BASE"); } }
        public static string SAVE_BASE { get { return GetValue("SAVE_BASE"); } }
    }
}
