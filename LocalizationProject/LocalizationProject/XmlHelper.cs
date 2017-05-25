using System.Xml;
using System.Collections.Generic;

namespace LocalizationProject
{
    class XmlHelper
    {
        public static List<Category> GetCategoriesFromFile(string file)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(file);
            XmlElement xRoot = xDoc.DocumentElement;

            List<Category> categories = new List<Category>();

            foreach (XmlNode node in xRoot.ChildNodes)
            {
                foreach (XmlNode str in node.ChildNodes)
                {
                    data.Add(new Data(str.Attributes["key"].Value, str.Attributes["value"].Value));
                }
            }

            return data.ToArray();
        }

        public static Data[] GetDataFromFile(string category)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("russian.xml");
            XmlElement xRoot = xDoc.DocumentElement;

            List<Data> data = new List<Data>();

            foreach (XmlNode node in xRoot.ChildNodes)
            {
                if (node.Attributes["name"].Value == category)
                {
                    foreach (XmlNode str in node.ChildNodes)
                    {
                        data.Add(new Data(str.Attributes["key"].Value, str.Attributes["value"].Value));
                    }

                    break;
                }
            }

            return data.ToArray();
        }

        public static string[] GetCategories()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("russian.xml");
            XmlElement xRoot = xDoc.DocumentElement;

            List<string> categories = new List<string>();

            foreach (XmlNode node in xRoot.ChildNodes)
                categories.Add(node.Attributes["name"].Value);

            return categories.ToArray();
        }
    }
}
