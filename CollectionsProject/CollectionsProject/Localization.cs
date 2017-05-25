using System.Xml;

namespace CollectionsProject
{
    class Localization
    {
        static string GetValue(string name)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("Languages/" + Settings.Language);
            XmlElement xRoot = xDoc.DocumentElement;
            foreach (XmlNode category in xRoot.ChildNodes)
                foreach (XmlNode str in category.ChildNodes)
                    if (str.Attributes["key"].Value == name)
                        return str.Attributes["value"].Value;

            return null;
        }

        public static string PROGRAM_TITLE { get { return GetValue("PROGRAM_TITLE"); } }
        public static string ERROR { get { return GetValue("ERROR"); } }
        public static string COLLECTIONS_FILES { get { return GetValue("COLLECTIONS_FILES"); } }
        public static string BASE_IS_OPENED { get { return GetValue("BASE_IS_OPENED"); } }
        public static string CONNECTED { get { return GetValue("CONNECTED"); } }
        public static string DISCONNECTED { get { return GetValue("DISCONNECTED"); } }
        public static string SEARCHING_RESULTS { get { return GetValue("SEARCHING_RESULTS"); } }
        public static string FILE { get { return GetValue("FILE"); } }
        public static string CREATE_BASE { get { return GetValue("CREATE_BASE"); } }
        public static string OPEN_BASE { get { return GetValue("OPEN_BASE"); } }
        public static string LAST_BASES { get { return GetValue("LAST_BASES"); } }
        public static string EXIT { get { return GetValue("EXIT"); } }
        public static string COLLECTIONS { get { return GetValue("COLLECTIONS"); } }
        public static string CREATE_COLLECTION { get { return GetValue("CREATE_COLLECTION"); } }
        public static string RENAME_COLLECTION { get { return GetValue("RENAME_COLLECTION"); } }
        public static string DELETE_COLLECTION { get { return GetValue("DELETE_COLLECTION"); } }
        public static string ITEMS { get { return GetValue("ITEMS"); } }
        public static string ADD_ITEM { get { return GetValue("ADD_ITEM"); } }
        public static string EDIT_ITEM { get { return GetValue("EDIT_ITEM"); } }
        public static string DELETE_ITEM { get { return GetValue("DELETE_ITEM"); } }
        public static string SEARCH_ITEM { get { return GetValue("SEARCH_ITEM"); } }
        public static string VIEW { get { return GetValue("VIEW"); } }
        public static string PHOTOS_PANEL { get { return GetValue("PHOTOS_PANEL"); } }
        public static string DESCRIPTION_PANEL { get { return GetValue("DESCRIPTION_PANEL"); } }
        public static string ICONS_PANEL { get { return GetValue("ICONS_PANEL"); } }
        public static string CATALOGS { get { return GetValue("CATALOGS"); } }
        public static string CATALOGS_EDITOR { get { return GetValue("CATALOGS_EDITOR"); } }
        public static string SERVICE { get { return GetValue("SERVICE"); } }
        public static string SETTINGS { get { return GetValue("SETTINGS"); } }
        public static string HELP { get { return GetValue("HELP"); } }
        public static string ABOUT { get { return GetValue("ABOUT"); } }
    }
}
