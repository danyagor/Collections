using System.IO;
using System.Xml;
using System.Collections.Generic;

namespace CollectionsProject
{
    class XmlHelper
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

        private static Table GetMainTable(XmlNode collectionNode)
        {
            return new Table(
                collectionNode.Attributes["programName"].Value,
                collectionNode.Attributes["baseName"].Value,
                false,
                GetAllFieldsFromMainTable(collectionNode.FirstChild));
        }

        public static Table[] GetForeignTables(XmlNode collectionNode)
        {
            List<Table> tables = new List<Table>();

            // Таблицы коллекции
            XmlNodeList tableNodes = collectionNode.FirstChild.ChildNodes;

            foreach (XmlNode table in tableNodes)
            {
                string tablName = table.Attributes["baseName"].Value;
                tables.Add(new Table(
                    table.Attributes["programName"].Value,
                    tablName,
                    true,
                    GetAllFieldsFromForeignTable(collectionName, tablName)));
            }

            return tables.ToArray();
        }


        public static Field[] GetAllFieldsFromMainTable(XmlNode tableNode)
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

        public static Field[] GetAllFieldsFromForeignTable(string foreignTableName)
        {
            List<Field> fields = new List<Field>();

            // Поля таблицы
            XmlNodeList fieldNodes = tableNode.FirstChild.ChildNodes;

            foreach (XmlNode field in fieldNodes)
            {
                // Внешняя таблица
                fields.Add(new Field(
                    field["programName"].InnerText,
                    field["baseName"].InnerText,
                    field.Attributes["nameField"].Value == "true" ? true : false));
            }

            return fields.ToArray();
        }








        private static XmlNode[] GetAllForeignTables()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("collections.xml");
            XmlElement xRoot = xDoc.DocumentElement;

            List<XmlNode> nodes = new List<XmlNode>();

            foreach (XmlNode foreignTable in xRoot.ChildNodes[1].ChildNodes)
                nodes.Add(foreignTable);

            return nodes.ToArray();
        }

        private static XmlNode[] GetAllForeignTables(int collectionId)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("collections.xml");
            XmlElement xRoot = xDoc.DocumentElement;

            List<XmlNode> nodes = new List<XmlNode>();

            foreach (XmlNode foreignTable in xRoot.ChildNodes[1].ChildNodes)
                if (foreignTable.Attributes["colId"].Value == collectionId.ToString())
                    nodes.Add(foreignTable);

            return nodes.ToArray();
        }


        /// <summary>
        /// Возвращает нод коллекции по его имени
        /// </summary>
        /// <param name="collectionName">Имя коллекции</param>
        /// <returns>Нод коллекции</returns>
        private static XmlNode GetTypeNode(string collectionName)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("collections.xml");
            XmlElement xRoot = xDoc.DocumentElement;

            foreach (XmlNode typeNode in xRoot.ChildNodes)
                if (typeNode.Attributes["name"].Value == collectionName)
                    return typeNode;

            return null;
        }

        /// <summary>
        /// Возвращает нод таблицы по имени коллекции и таблицы
        /// </summary>
        /// <param name="collectionName">Имя коллекции</param>
        /// <param name="tableName">Имя таблицы</param>
        /// <returns>Нод таблицы</returns>
        private static XmlNode GetTableNode(string collectionName, string tableName)
        {
            // Таблицы коллекции
            XmlNodeList tables = GetTypeNode(collectionName).ChildNodes[0].ChildNodes;

            // Поиск таблицы
            foreach (XmlNode table in tables)
                if (table.Attributes["baseName"].Value == tableName)
                    return table;

            return null;
        }

        #endregion Коллекции

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
