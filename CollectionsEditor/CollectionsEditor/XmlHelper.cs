using System;
using System.Collections.Generic;
using System.Xml;

namespace CollectionsEditor
{
    class XmlHelper
    {
        // Возвращает все коллекции из файла
        public static List<Collection> GetAllCollections(string filePath)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(filePath);
            XmlElement xRoot = xDoc.DocumentElement;

            List<Collection> collections = new List<Collection>();

            foreach (XmlNode typeNode in xRoot.ChildNodes)
            {
                string colName = typeNode.Attributes["name"].Value;
                collections.Add(new Collection(
                    colName, 
                    GetAllTables(colName, filePath)));
            }

            return collections;
        }

        // Возвращает все таблицы из коллекции по её имени
        public static List<Table> GetAllTables(string collectionName, string filePath)
        {
            List<Table> tables = new List<Table>();

            // Таблицы коллекции
            XmlNodeList tableNodes = GetTypeNode(collectionName, filePath).ChildNodes[0].ChildNodes;

            foreach (XmlNode table in tableNodes)
            {
                string tablName = table.Attributes["baseName"].Value;
                tables.Add(new Table(
                    table.Attributes["programName"].Value,
                    tablName,
                    table.Attributes["foreignTable"].Value == "true" ? true : false,
                    GetAllFields(collectionName, tablName, filePath)));
            }

            return tables;
        }

        // Возвращает все поля из таблицы по имени коллекции и таблицы
        public static List<Field> GetAllFields(string collectionName, string tableName, string filePath)
        {
            List<Field> fields = new List<Field>();

            XmlNode tableNode = GetTableNode(collectionName, tableName, filePath);

            // Поля таблицы
            XmlNodeList fieldNodes = tableNode.FirstChild.ChildNodes;

            foreach (XmlNode field in fieldNodes)
            {
                if (tableNode.Attributes["foreignTable"].Value == "true")
                {
                    fields.Add(new Field(
                        field["programName"].InnerText,
                        field["baseName"].InnerText,
                        field["type"].InnerText,
                        field["width"].InnerText,
                        field.Attributes["required"].Value == "true" ? true : false,
                        field.Attributes["nameField"].Value == "true" ? true : false));
                }
                else
                {
                    fields.Add(new Field(
                        field["programName"].InnerText,
                        field["baseName"].InnerText,
                        field["type"].InnerText,
                        field["width"].InnerText,
                        field.Attributes["required"].Value == "true" ? true : false,
                        field.Attributes["foreignKey"].Value == "true" ? true : false,
                        field["foreignTable"] != null ? field["foreignTable"].InnerText : ""));
                }
            }

            return fields;
        }


        // Сохранение коллекций в файл
        public static void SaveCollectionFile(Collection[] collections, string filePath)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.AppendChild(xDoc.CreateXmlDeclaration("1.0", "UTF-8", ""));
            XmlElement xRoot = xDoc.CreateElement("collections");

            byte collectionCounter = 1;
            // Коллекции
            foreach (Collection collection in collections)
            {
                XmlElement collectionNode = xDoc.CreateElement("collection");
                XmlAttribute colIdAttr = xDoc.CreateAttribute("id");
                colIdAttr.Value = collectionCounter.ToString();
                XmlAttribute colNameAttr = xDoc.CreateAttribute("name");
                colNameAttr.Value = collection.Name;
                collectionNode.Attributes.Append(colIdAttr);
                collectionNode.Attributes.Append(colNameAttr);

                // Таблицы
                XmlElement tablesNode = xDoc.CreateElement("tables");
                foreach (Table table in collection.Tables)
                {
                    XmlElement tableNode = xDoc.CreateElement("table");
                    XmlAttribute tableProgramNameAttr = xDoc.CreateAttribute("programName");
                    tableProgramNameAttr.Value = table.ProgramName;
                    XmlAttribute tableBaseNameAttr = xDoc.CreateAttribute("baseName");
                    tableBaseNameAttr.Value = table.BaseName;
                    XmlAttribute foreignTableAttr = xDoc.CreateAttribute("foreignTable");
                    foreignTableAttr.Value = table.Foreign ? "true" : "false";
                    tableNode.Attributes.Append(tableProgramNameAttr);
                    tableNode.Attributes.Append(tableBaseNameAttr);
                    tableNode.Attributes.Append(foreignTableAttr);

                    // Поля
                    XmlElement fieldsNode = xDoc.CreateElement("fields");
                    foreach (Field field in table.Fields)
                    {
                        XmlElement fieldNode = xDoc.CreateElement("field");

                        XmlAttribute requiredAttr = xDoc.CreateAttribute("required");
                        requiredAttr.Value = field.RequiredField ? "true" : "false";
                        fieldNode.Attributes.Append(requiredAttr);
                        
                        if (table.Foreign)
                        {
                            XmlAttribute nameFieldAttr = xDoc.CreateAttribute("nameField");
                            nameFieldAttr.Value = field.NameField ? "true" : "false";
                            fieldNode.Attributes.Append(nameFieldAttr);
                        }
                        else
                        {
                            XmlAttribute foreignKeyAttr = xDoc.CreateAttribute("foreignKey");
                            foreignKeyAttr.Value = field.ForeignKey ? "true" : "false";
                            fieldNode.Attributes.Append(foreignKeyAttr);
                        }

                        XmlElement programName = xDoc.CreateElement("programName");
                        programName.InnerText = field.ProgramName;
                        XmlElement baseName = xDoc.CreateElement("baseName");
                        baseName.InnerText = field.BaseName;
                        XmlElement type = xDoc.CreateElement("type");
                        type.InnerText = field.Type;
                        XmlElement width = xDoc.CreateElement("width");
                        width.InnerText = field.Width;

                        fieldNode.AppendChild(programName);
                        fieldNode.AppendChild(baseName);
                        fieldNode.AppendChild(type);
                        fieldNode.AppendChild(width);

                        if (field.ForeignKey)
                        {
                            XmlElement foreignTable = xDoc.CreateElement("foreignTable");
                            foreignTable.InnerText = field.ForeignTable;
                            fieldNode.AppendChild(foreignTable);
                        }

                        fieldsNode.AppendChild(fieldNode);
                    }
                    tableNode.AppendChild(fieldsNode);
                    tablesNode.AppendChild(tableNode);
                }
                collectionNode.AppendChild(tablesNode);
                xRoot.AppendChild(collectionNode);
                collectionCounter++;
            }

            xDoc.AppendChild(xRoot);
            xDoc.Save(filePath);
        }


        // Возвращает нод коллекции по его имени
        private static XmlNode GetTypeNode(string collectionName, string filePath)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(filePath);
            XmlElement xRoot = xDoc.DocumentElement;

            foreach (XmlNode typeNode in xRoot.ChildNodes)
                if (typeNode.Attributes["name"].Value == collectionName)
                    return typeNode;

            return null;
        }

        // Возвращает нод таблицы по ее имени
        private static XmlNode GetTableNode(string collectionName, string tableName, string filePath)
        {
            // Таблицы коллекции
            XmlNodeList tables = GetTypeNode(collectionName, filePath).ChildNodes[0].ChildNodes;

            // Поиск таблицы
            foreach (XmlNode table in tables)
                if (table.Attributes["baseName"].Value == tableName)
                    return table;

            return null;
        }
    }
}
