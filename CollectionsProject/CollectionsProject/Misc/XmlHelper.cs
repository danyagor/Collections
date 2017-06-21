using System.IO;
using System.Xml;
using System.Collections.Generic;
using System.Data;

namespace CollectionsProject
{
    static class XmlHelper
    {
        #region Создание служебных файлов

        public static void CreateCollectionsFile()
        {

        }

        public static void CreateLastFilesFile()
        {

        }

        public static void CreateLanguageFile()
        {

        }

        #endregion Создание служебных файлов

        #region Коллекции

        // Все коллекции
        public static Collection[] GetAllCollections()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("collections.xml");
            XmlElement xRoot = xDoc.DocumentElement;

            List<Collection> collections = new List<Collection>();

            foreach (XmlNode typeNode in xRoot.FirstChild.ChildNodes)
            {
                collections.Add(new Collection(
                    int.Parse(typeNode.Attributes["id"].Value),
                    typeNode.Attributes["name"].Value,
                    GetMainTable(typeNode),
                    GetForeignTables(typeNode)));
            }

            return collections.ToArray();
        }

        // Главная таблица
        private static Table GetMainTable(XmlNode collectionNode)
        {
            return new Table(
                collectionNode.FirstChild.Attributes["programName"].Value,
                collectionNode.FirstChild.Attributes["baseName"].Value,
                false,
                false,
                GetAllFieldsFromMainTable(collectionNode.FirstChild));
        }

        // Внешние таблицы
        private static Table[] GetForeignTables(XmlNode collectionNode)
        {
            List<Table> tables = new List<Table>();

            // Поля главной таблицы коллекции
            XmlNodeList mainTableFields = collectionNode.FirstChild.FirstChild.ChildNodes;

            foreach (XmlNode field in mainTableFields)
            {
                if (field.Attributes["foreignTable"] != null)
                    tables.Add(GetForeignTable(field.Attributes["foreignTable"].Value));
            }

            return tables.ToArray();
        }


        // Поля главной таблицы
        private static Field[] GetAllFieldsFromMainTable(XmlNode tableNode)
        {
            List<Field> fields = new List<Field>();

            // Поля таблицы
            XmlNodeList fieldNodes = tableNode.FirstChild.ChildNodes;

            foreach (XmlNode field in fieldNodes)
            {
                // Внешняя таблица
                string foreignTable = "";
                if (field.Attributes["foreignTable"] != null)
                    foreignTable = field.Attributes["foreignTable"].Value;

                // Главная таблица
                fields.Add(new Field(
                    field["programName"].InnerText,
                    field["baseName"].InnerText,
                    foreignTable != "" ? true : false,
                    foreignTable));
            }

            return fields.ToArray();
        }

        // Внешняя таблица по имени
        private static Table GetForeignTable(string tableName)
        {
            XmlNode[] foreignTables = GetAllForeignTablesNodes();

            foreach (XmlNode table in foreignTables)
            {
                if (table.Attributes["baseName"].Value == tableName)
                {
                    List<Field> fields = new List<Field>();
                    foreach (XmlNode field in table.FirstChild.ChildNodes)
                    {
                        // Внешняя таблица
                        fields.Add(new Field(
                            field["programName"].InnerText,
                            field["baseName"].InnerText,
                            field.Attributes["nameField"].Value == "true" ? true : false));
                    }

                    return new Table(
                        table.Attributes["programName"].Value,
                        table.Attributes["baseName"].Value,
                        true,
                        table.Attributes["fixed"] != null ? true : false,
                        fields.ToArray());
                }
            }

            return null;
        }

        // Все внешние таблицы
        private static XmlNode[] GetAllForeignTablesNodes()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("collections.xml");
            XmlElement xRoot = xDoc.DocumentElement;

            List<XmlNode> nodes = new List<XmlNode>();

            foreach (XmlNode foreignTable in xRoot.ChildNodes[1].ChildNodes)
                nodes.Add(foreignTable);

            return nodes.ToArray();
        }

        public static Table[] GetAllForeignTables()
        {
            XmlNode[] tables = GetAllForeignTablesNodes();
            List<Table> resTables = new List<Table>();
            foreach (XmlNode table in tables)
            {
                List<Field> fields = new List<Field>();
                foreach (XmlNode field in table.FirstChild.ChildNodes)
                {
                    fields.Add(new Field(
                        field["programName"].InnerText,
                        field["baseName"].InnerText,
                        field.Attributes["nameField"].Value == "true" ? true : false));
                }
                resTables.Add(new Table(
                    table.Attributes["programName"].Value,
                    table.Attributes["baseName"].Value,
                    true,
                    table.Attributes["fixed"] != null ? true : false,
                    fields.ToArray()));
            }

            return resTables.ToArray();
        }

        public static List<string[]> GetBeginValuesOfForeignTable(string foreignTableName)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("collections.xml");
            XmlElement xRoot = xDoc.DocumentElement;

            List<string[]> beginVals = new List<string[]>();

            foreach (XmlNode foreignTable in xRoot.ChildNodes[1].ChildNodes)
            {
                if (foreignTable.Attributes["baseName"].Value == foreignTableName)
                {
                    if (foreignTable.SelectSingleNode("beginValues") != null)
                    {                        
                        foreach (XmlNode value in foreignTable.ChildNodes[1].ChildNodes)
                        {
                            List<string> vals = new List<string>();
                            foreach (XmlNode field in value.ChildNodes)
                                vals.Add(field.InnerText);

                            beginVals.Add(vals.ToArray());
                        }

                        break;
                    }
                    else
                        break;
                }
            }

            return beginVals;
        }

        #endregion Коллекции

        #region Настройки

        public static void OpenSettingsFromFile()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("configurations.xml");
            XmlElement xRoot = xDoc.DocumentElement;

            Settings.Language = xRoot.ChildNodes[0].Attributes["value"].Value;
            Settings.PhotosSize = int.Parse(xRoot.ChildNodes[1].Attributes["value"].Value);
            Settings.IconsSize = int.Parse(xRoot.ChildNodes[2].Attributes["value"].Value);
        }

        public static void SaveSettings()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("configurations.xml");
            XmlElement xRoot = xDoc.DocumentElement;

            xRoot.ChildNodes[0].Attributes["value"].Value = Settings.Language;
            xRoot.ChildNodes[1].Attributes["value"].Value = Settings.PhotosSize.ToString();
            xRoot.ChildNodes[2].Attributes["value"].Value = Settings.IconsSize.ToString();

            xDoc.Save("configurations.xml");
        }

        #endregion Настройки


        public static DataTable GetLanguages()
        {
            DataTable languages = new DataTable();
            languages.Columns.Add("lang");
            languages.Columns.Add("file");

            DirectoryInfo di = new DirectoryInfo("Languages");
            foreach (FileInfo file in di.GetFiles())
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load("Languages/" + file.Name);
                XmlElement xRoot = xDoc.DocumentElement;

                languages.Rows.Add(xRoot.Attributes["language"].Value, file.Name);
            }

            return languages;
        }

        #region Последние файлы

        /// <summary>
        /// Возвращает пути последних использованых файлов
        /// </summary>
        /// <returns>Пути последних использованых файлов</returns>
        public static string[] GetLastFiles()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("lastfiles.xml");
            XmlElement xRoot = xDoc.DocumentElement;

            string[] files = new string[xRoot.ChildNodes.Count];
            for (int i = 0; i < files.Length; i++)
                files[i] = xRoot.ChildNodes[i].Attributes["path"].Value;

            return files;
        }

        /// <summary>
        /// Возвращает путь последнего открытого файла
        /// </summary>
        /// <returns>Путь последнего открытого файла</returns>
        public static string GetLastActiveFile()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("lastfiles.xml");
            XmlElement xRoot = xDoc.DocumentElement;

            for (int i = 0; i < xRoot.ChildNodes.Count; i++)
                if (xRoot.ChildNodes[i].Attributes["active"] != null)
                    return xRoot.ChildNodes[i].Attributes["path"].Value;

            return null;
        }

        /// <summary>
        /// Записывает в файл lastfiles.xml путь последнего использованного файла
        /// </summary>
        /// <param name="file">Путь файла</param>
        public static void WriteLastFile(string file)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("lastfiles.xml");
            XmlElement xRoot = xDoc.DocumentElement;

            bool fileFound = false;
            int fileIndex = 0;

            // Поиск такого же файла
            for (int i = 0; i < xRoot.ChildNodes.Count; i++)
            {
                if (xRoot.ChildNodes[i].Attributes["path"].Value == file)
                {
                    fileFound = true;
                    fileIndex = i;
                    break;
                }
            }

            // Удаление у активного файла соответсвующий атрибут
            for (int i = 0; i < xRoot.ChildNodes.Count; i++)
                if (xRoot.ChildNodes[i].Attributes["active"] != null)
                    xRoot.ChildNodes[i].Attributes.RemoveNamedItem("active");


            if (!fileFound)
            {
                XmlNode fileNode = xDoc.CreateNode(XmlNodeType.Element, "file", "");
                XmlAttribute pathAttr = xDoc.CreateAttribute("path");
                XmlAttribute lastActiveAttr = xDoc.CreateAttribute("active");
                pathAttr.Value = file;
                lastActiveAttr.Value = "true";
                fileNode.Attributes.Append(pathAttr);
                fileNode.Attributes.Append(lastActiveAttr);
                xRoot.PrependChild(fileNode);
            }
            else
            {
                XmlNode pathNode = xRoot.ChildNodes[fileIndex];
                xRoot.RemoveChild(pathNode);
                XmlAttribute lastActiveAttr = xDoc.CreateAttribute("active");
                lastActiveAttr.Value = "true";
                pathNode.Attributes.Append(lastActiveAttr);
                xRoot.PrependChild(pathNode);
            }

            // Удаление последнего в списке файла, если их количество превышает 10
            if (xRoot.ChildNodes.Count > 10)
                xRoot.RemoveChild(xRoot.LastChild);

            xDoc.Save("lastfiles.xml");
        }

        /// <summary>
        /// Удаление не существующих путей последних файлов
        /// </summary>
        public static void DeleteNotExistsLastFiles()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("lastfiles.xml");
            XmlElement xRoot = xDoc.DocumentElement;

            XmlNode[] fileNodes = new XmlNode[xRoot.ChildNodes.Count];
            List<XmlNode> nodesToDelete = new List<XmlNode>();

            for (int i = 0; i < fileNodes.Length; i++)
                if (!File.Exists(xRoot.ChildNodes[i].Attributes["path"].Value))
                    nodesToDelete.Add(xRoot.ChildNodes[i]);

            foreach (XmlNode node in nodesToDelete)
                xRoot.RemoveChild(node);

            xDoc.Save("lastfiles.xml");
        }

        #endregion Последние файлы
    }
}
