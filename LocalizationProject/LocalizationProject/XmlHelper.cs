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

            foreach (XmlNode category in xRoot.ChildNodes)
            {
                List<Data> strings = new List<Data>();
                foreach (XmlNode str in category.ChildNodes)
                    strings.Add(new Data(str.Attributes["key"].Value, str.Attributes["value"].Value));

                categories.Add(new Category(category.Attributes["name"].Value, strings));
            }

            return categories;
        }

        public static void SaveCategories(string file)
        {

        }
    }
}
