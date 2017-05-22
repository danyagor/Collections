using System;
using System.Collections.Generic;
using System.Xml;

namespace CollectionsEditor
{
    class XmlHelper
    {
        // Все коллекции
        public static List<Collection> GetAllCollections()
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
                    GetCollectionTables(typeNode)));
            }

            return collections;
        }


        // Таблицы коллекции
        private static List<Table> GetCollectionTables(XmlNode collectionNode)
        {
            List<Table> tables = new List<Table>();
            tables.Add(new Table(
                collectionNode.FirstChild.Attributes["programName"].Value,
                collectionNode.FirstChild.Attributes["baseName"].Value,
                false,
                false,
                GetAllFieldsFromMainTable(collectionNode.FirstChild)));

            tables.AddRange(GetForeignTables(collectionNode));

            return tables;
        }

        // Поля главной таблицы
        private static List<Field> GetAllFieldsFromMainTable(XmlNode tableNode)
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

            return fields;
        }

        // Внешние таблицы
        private static List<Table> GetForeignTables(XmlNode collectionNode)
        {
            List<Table> tables = new List<Table>();

            // Поля главной таблицы коллекции
            XmlNodeList mainTableFields = collectionNode.FirstChild.FirstChild.ChildNodes;

            foreach (XmlNode field in mainTableFields)
            {
                if (field.Attributes["foreignTable"] != null)
                    tables.Add(GetForeignTable(field.Attributes["foreignTable"].Value));
            }

            return tables;
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
                        fields);
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

                        fieldNode.AppendChild(programName);
                        fieldNode.AppendChild(baseName);

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


  
    }
}
