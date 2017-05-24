using System.Xml;
using System.Collections.Generic;

namespace LocalizationProject
{
    class XmlHelper
    {
        public static Data[] GetDataFromFile()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("russian.xml");
            XmlElement xRoot = xDoc.DocumentElement;

            List<Data> data = new List<Data>();

            foreach (XmlNode node in xRoot.ChildNodes)
                data.Add(new Data(node.Attributes["key"].Value, node.Attributes["value"].Value));

            return data.ToArray();
        }
    }
}
