﻿using System;
using System.Data;
using Devart.Data.SQLite;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using System.Drawing;

namespace CollectionsProject
{
    public class Database
    {
        string basePath;
        string baseName;
        SQLiteConnection connection;
        SQLiteDataAdapter adapter;

        #region Свойства

        // Путь до файла базы данных
        public string BasePath { get { return basePath; } }

        // Имя базы данных с расширением
        public string BaseName { get { return baseName; } }

        // Подсоединена ли программа к базе
        public bool Connected
        {
            get
            {
                if (connection != null)
                    return true;
                else
                    return false;
            }
        }

        #endregion Свойства



        #region Конструкторы

        // Конструктор по умолчанию
        public Database()
        {

        }

        // Конструктор для создания базы данных
        public Database(string path, string userName, string userEmail, string password = "")
        {
            CreateDatabase(path, userName, userEmail, password);
        }

        #endregion Конструкторы



        #region Запросы

        // Простой SQL запрос (INSERT, UPDATE, DELETE...)
        private void SqlQuery(string query)
        {
            try
            {
                SQLiteCommand command = new SQLiteCommand(query, connection);

                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }

        // SQL запрос с возвратом таблицы данных 
        private DataTable SqlQueryDataTable(string query)
        {
            try
            {
                DataTable dt = new DataTable();
                adapter = new SQLiteDataAdapter(query, connection);

                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                adapter.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
                return null;
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }

        // SQL запрос с возвратом объекта с данными первой строки первого столбца
        private object SqlQueryScalar(string query)
        {
            try
            {
                SQLiteCommand command = new SQLiteCommand(query, connection);

                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                return command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
                return null;
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }

        // SQL запрос с возвратом коллекции всех строчек
        private DataRowCollection SqlQueryRows(string query)
        {
            try
            {
                DataTable dt = new DataTable();
                adapter = new SQLiteDataAdapter(query, connection);

                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                adapter.Fill(dt);
                return dt.Rows;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
                return null;
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }

        #endregion Запросы



        #region Работа с базой

        // Создание базы данных
        private void CreateDatabase(string path, string userName, string userEmail, string password = "")
        {
            try
            {
                //if (connection != null)
                //    connection.Shutdown();

                // Создание файла
                SQLiteConnection.CreateFile(path);

                // Connection string
                SQLiteConnectionStringBuilder connectionString = new SQLiteConnectionStringBuilder();
                connectionString.DataSource = path;
                connectionString.Version = 3;
                connectionString.Encryption = EncryptionMode.SQLiteCrypt;
                connectionString.Password = password;

                // Подсоеденение к базе
                connection = new SQLiteConnection(connectionString.ConnectionString);
                connection.Open();

                basePath = connection.DataSource;
                baseName = Path.GetFileName(basePath);

                // Смена пароля
                connection.ChangePassword(password);
                connection.Close();

                SqlQuery("PRAGMA auto_vacuum = 1");

                // Создание таблиц и занесение в них первоначальной информации
                // UserInfo
                SqlQuery("CREATE TABLE UserInfo(username VARCHAR, useremail VARCHAR)");
                SqlQuery("INSERT INTO UserInfo VALUES('" + userName + "', '" + userEmail + "')");

                // Collections
                SqlQuery("CREATE TABLE Collections(id INTEGER PRIMARY KEY AUTOINCREMENT, baseName VARCHAR, programName VARCHAR, typeId INTEGER)");

                // Configurations
                SqlQuery("CREATE TABLE Configurations(key VARCHAR, value VARCHAR)");
                SqlQuery("INSERT INTO Configurations VALUES('COLLECTION_COUNTER', '0')");

                // Создание внешних таблиц
                foreach (Table table in CollectionTypes.ForeignTables)
                {
                    string query = "CREATE TABLE " + table.BaseName + " (id INTEGER PRIMARY KEY AUTOINCREMENT, ";
                    foreach (Field field in table.Fields)
                        query += field.BaseName + " VARCHAR, ";
                    query += "note TEXT)";
                    SqlQuery(query);

                    // Начальные значения
                    List<string[]> beginValues = XmlHelper.GetBeginValuesOfForeignTable(table.BaseName);
                    if (beginValues.Count > 0)
                    {
                        string beginValQuery = "INSERT INTO " + table.BaseName + " VALUES";
                        foreach (string[] beginVal in beginValues)
                        {
                            beginValQuery += "(NULL, ";
                            foreach (string val in beginVal)
                                beginValQuery += "'" + val + "', ";

                            beginValQuery += "''), ";
                        }
                        beginValQuery = beginValQuery.Remove(beginValQuery.Length - 2, 2);

                        SqlQuery(beginValQuery);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Подсоединение к базе данных
        public bool ConnectToDatabase(string path, string password = "")
        {
            try
            {
                //if (connection != null)
                //    connection.Shutdown();

                SQLiteConnectionStringBuilder connectionString = new SQLiteConnectionStringBuilder();
                connectionString.DataSource = path;
                connectionString.Version = 3;
                connectionString.Locking = LockingMode.Exclusive;
                connectionString.Password = password;

                connection = new SQLiteConnection(connectionString.ConnectionString);
                // Проверка правильно ли введен пароль, если нет, то выведет сообщение
                SQLiteCommand command = new SQLiteCommand("SELECT * FROM UserInfo", connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                basePath = path;
                baseName = Path.GetFileName(path);
                
                return true;
            }
            catch (SQLiteException ex)
            {
                if (ex.ErrorCode == SQLiteErrorCode.NotADatabase)
                    MessageBox.Show("Неправильный пароль");
                else
                    MessageBox.Show(ex.Message);

                if (connection != null)
                    connection.Close();

                connection = null;
                return false;
            }
        }

        #endregion Работа с базой



        #region Работа с коллекциями

        // Создание коллекции определенного типа и имени
        public void CreateCollection(string name, int collectionId)
        {
            // Получение количества созданных коллекций + 1
            int numberOfCreatedCollections = int.Parse(SqlQueryScalar("SELECT value FROM Configurations WHERE(key = 'COLLECTION_COUNTER')").ToString()) + 1;
            SqlQuery("UPDATE Configurations SET value = '" + numberOfCreatedCollections + "' WHERE(key = 'COLLECTION_COUNTER')");

            // Запрос на создание главной таблицы
            string query = "CREATE TABLE " + CollectionTypes.GetCollection(collectionId).MainTable.BaseName + "_" + numberOfCreatedCollections + "(";
            query += "id INTEGER PRIMARY KEY AUTOINCREMENT, ";
            foreach (Field field in CollectionTypes.GetCollection(collectionId).MainTable.Fields)
            {
                if (field.ForeignKey)
                    query += field.BaseName + " INTEGER, ";
                else
                    query += field.BaseName + " VARCHAR, ";
            }
            query += "uploadDate DATETIME, changeDate DATETIME, note TEXT, photo1 BLOB, photo2 BLOB, photo3 BLOB, photo4 BLOB, comment1 VARCHAR, comment2 VARCHAR, comment3 VARCHAR, comment4 VARCHAR)";
            SqlQuery(query);

            // Добавление в таблицу Collections данных о текущей коллекции
            SqlQuery("INSERT INTO Collections(baseName, programName, typeId) VALUES('" + CollectionTypes.GetCollection(collectionId).MainTable.BaseName + "_" + numberOfCreatedCollections + "', '" + name + "', " + collectionId + ")");
        }

        // Переименование коллекции
        public void RenameCollection(string name, string newName)
        {
            int collectionId = int.Parse(SqlQueryScalar("SELECT id FROM Collections WHERE(programName = '" + name + "')").ToString());
            SqlQuery("UPDATE Collections SET programName = '" + newName + "' WHERE(id = " + collectionId + ")");
        }

        /// Удаление коллекции
        public void DeleteCollection(string name)
        {
            DataRow dr = SqlQueryDataTable("SELECT id, typeId, baseName FROM Collections WHERE(programName = '" + name + "')").Rows[0];
            int collectionId = int.Parse(dr.ItemArray[0].ToString());
            int collectionTypeId = int.Parse(dr.ItemArray[1].ToString());

            // Поиск номера коллекции
            string collectionNumber = dr.ItemArray[2].ToString();
            collectionNumber = collectionNumber.Remove(0, collectionNumber.LastIndexOf('_'));

            // Удаление таблиц коллекции
            SqlQuery("DROP TABLE " + CollectionTypes.GetCollection(collectionTypeId)[0].BaseName + collectionNumber);

            // Удалить коллекцию из таблицы коллекций
            SqlQuery("DELETE FROM Collections WHERE(id = " + collectionId + ")");
        }

        #endregion Работа с коллекциями



        #region Работа с предметами

        // Добавление предмета в указанную коллекцию
        public void AddItem(int collectionType, string[] fields, string note, string collectionName = "", string foreignTable = "", ItemImage[] images = null)
        {
            Field[] tableFields;
            string query;
            if (foreignTable == "")
            {
                int collectionNumber = GetCollectionNumber(collectionName);
                tableFields = CollectionTypes.GetCollection(collectionType).MainTable.Fields;
                query = "INSERT INTO " + CollectionTypes.GetCollection(collectionType).MainTable.BaseName + "_" + collectionNumber + " VALUES(NULL, ";
            }
            else
            {
                tableFields = CollectionTypes.GetCollection(collectionType)[foreignTable].Fields;
                query = "INSERT INTO " + foreignTable + " VALUES(NULL, ";
            }

            // Формирование запроса на добавление
            int fieldsCounter = 0;
            foreach (Field field in tableFields)
            {
                if (fields[fieldsCounter] != "")
                {
                    if (field.ForeignKey)
                        query += fields[fieldsCounter] + ", ";
                    else
                        query += "'" + fields[fieldsCounter] + "', ";
                }
                else
                {
                    if (field.ForeignKey)
                        query += "0, ";
                    else
                        query += "'', ";
                }

                fieldsCounter++;
            }

            // Даты добавления и изменения
            if (foreignTable == "")
                query += "datetime('now'), datetime('now'), ";

            // Описание
            query += "'" + note + "'";

            if (foreignTable == "")
            {
                query += ", @photo1, @photo2, @photo3, @photo4, @comment1, @comment2, @comment3, @comment4)";
                SQLiteCommand cmd = new SQLiteCommand(query, connection);
                for (int i = 0; i < images.Length; i++)
                {
                    cmd.Parameters.Add("@photo" + (i + 1), DbType.Binary).Value = images[i].ImageBytes;
                    cmd.Parameters.Add("@comment" + (i + 1), DbType.String).Value = images[i].Comment;
                }

                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            else
            {
                query += ")";
                SqlQuery(query);
            }
        }

        // Обновление данных о предмете
        public void UpdateItem(int collectionType, int itemId, string[] fields, string note, string collectionName = "", string foreignTable = "", ItemImage[] images = null)
        {
            Field[] tableFields;
            string query;
            if (foreignTable == "")
            {
                int collectionNumber = GetCollectionNumber(collectionName);
                tableFields = CollectionTypes.GetCollection(collectionType).MainTable.Fields;
                query = "UPDATE " + CollectionTypes.GetCollection(collectionType).MainTable.BaseName + "_" + collectionNumber + " SET ";
            }
            else
            {
                tableFields = CollectionTypes.GetCollection(collectionType)[foreignTable].Fields;
                query = "UPDATE " + CollectionTypes.GetCollection(collectionType)[foreignTable].BaseName + " SET ";
            }

            // Формирование запроса на обновление
            int fieldsCounter = 0;
            foreach (Field field in tableFields)
            {
                if (field.ForeignKey)
                    if (fields[fieldsCounter] != "")
                        query += field.BaseName + " = " + fields[fieldsCounter] + ", ";
                    else
                        query += field.BaseName + " = 0, ";
                else
                    query += field.BaseName + " = '" + fields[fieldsCounter] + "', ";

                fieldsCounter++;
            }

            if (foreignTable == "")
                query += "changeDate = datetime('now'), ";

            query += "note = '" + note + "'";

            if (foreignTable == "")
            {
                query += ", photo1 = @photo1, photo2 = @photo2, photo3 = @photo3, photo4 = @photo4, comment1 = @comment1, comment2 = @comment2, comment3 = @comment3, comment4 = @comment4 WHERE(id = " + itemId + ")";
                SQLiteCommand cmd = new SQLiteCommand(query, connection);
                for (int i = 0; i < images.Length; i++)
                {
                    cmd.Parameters.Add("@photo" + (i + 1), DbType.Binary).Value = images[i].ImageBytes;
                    cmd.Parameters.Add("@comment" + (i + 1), DbType.String).Value = images[i].Comment;
                }

                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            else
            {
                query += "WHERE(id = " + itemId + ")";
                SqlQuery(query);
            }
        }

        // Удаление предмета
        public void DeleteItem(int collectionType, int itemId, string collectionName = "", string foreignTable = "")
        {
            if (foreignTable == "")
            {
                int collectionNumber = GetCollectionNumber(collectionName);
                SqlQuery("DELETE FROM " + CollectionTypes.GetCollection(collectionType).MainTable.BaseName + "_" + collectionNumber + " WHERE(id = " + itemId + ")");
            }
            else
                SqlQuery("DELETE FROM " + CollectionTypes.GetCollection(collectionType)[foreignTable].BaseName + " WHERE(id = " + itemId + ")");
        }


        // Возвращает все предметы из всех коллекций
        public DataTable GetAllItemsFromAllCollections()
        {
            DataRowCollection collectionsInfo = SqlQueryRows("SELECT baseName, programName, typeId FROM Collections");

            DataTable[] collections = new DataTable[collectionsInfo.Count];
            for (int i = 0; i < collections.Length; i++)
                collections[i] = SqlQueryDataTable("SELECT " + CollectionTypes.GetCollection(int.Parse(collectionsInfo[i].ItemArray[2].ToString())).MainTable[0].BaseName + ", uploadDate, changeDate FROM " + collectionsInfo[i][0]);

            DataTable resultDt = new DataTable();
            resultDt.Columns.Add("id");
            resultDt.Columns.Add("itemName");
            resultDt.Columns.Add("collectionName");
            resultDt.Columns.Add("collectionType");
            resultDt.Columns.Add("uploadDate");
            resultDt.Columns.Add("changeDate");

            int itemsCounter = 1;
            for (int i = 0; i < collections.Length; i++)
            {
                for (int j = 0; j < collections[i].Rows.Count; j++)
                {
                    resultDt.Rows.Add(
                        itemsCounter,
                        collections[i].Rows[j][0],
                        collectionsInfo[i][1],
                        CollectionTypes.GetCollection(int.Parse(collectionsInfo[i][2].ToString())).Name,
                        collections[i].Rows[j][1],
                        collections[i].Rows[j][2]);

                    itemsCounter++;
                }
            }

            return resultDt;
        }


        // Возвращает предмет из коллекции по определенному ID
        public DataRow GetItemFromCollection(int collectionType, int itemId, string collectionName = "", string foreignTable = "")
        {
            DataTable dt;
            if (foreignTable == "")
            {
                int collectionNumber = GetCollectionNumber(collectionName);
                dt = SqlQueryDataTable("SELECT * FROM " + CollectionTypes.GetCollection(collectionType).MainTable.BaseName + "_" + collectionNumber + " WHERE(id = " + itemId + ")");
            }
            else
                dt = SqlQueryDataTable("SELECT * FROM " + CollectionTypes.GetForeignTable(foreignTable).BaseName + " WHERE(id = " + itemId + ")");

            return dt.Rows[0];
        }

        // Возвращает предметы из коллекции по ее имени
        public DataTable GetItemsFromCollection(int collectionType, string collectionName = "", string foreignTable = "")
        {
            if (foreignTable == "")
            {
                int collectionNumber = GetCollectionNumber(collectionName);
                return SqlQueryDataTable("SELECT * FROM " + CollectionTypes.GetCollection(collectionType).MainTable.BaseName + "_" + collectionNumber);
            }
            else
                return SqlQueryDataTable("SELECT * FROM " + CollectionTypes.GetForeignTable(foreignTable).BaseName);
        }


        // Возвращает описание из предмета
        public string GetNoteFromItem(int collectionType, int itemId, string collectionName = "", string foreignTable = "")
        {
            if (foreignTable == "")
            {
                int collectionNumber = GetCollectionNumber(collectionName);
                return SqlQueryScalar("SELECT note FROM " + CollectionTypes.GetCollection(collectionType).MainTable.BaseName + "_" + collectionNumber + " WHERE(id = " + itemId + ")").ToString();
            }
            else
                return SqlQueryScalar("SELECT note FROM " + CollectionTypes.GetForeignTable(foreignTable).BaseName + " WHERE(id = " + itemId + ")").ToString();
        }

        public Image[] GetImagesFromItem(int collectionType, int itemId, string collectionName)
        {
            int collectionNumber = GetCollectionNumber(collectionName);
            DataTable dt = SqlQueryDataTable("SELECT photo1, photo2, photo3, photo4 FROM " + CollectionTypes.GetCollection(collectionType).MainTable.BaseName + "_" + collectionNumber + " WHERE(id = " + itemId + ")");

            Image[] images = new Image[4];

            for (int i = 0; i < 4; i++)
                if (dt.Rows[0].ItemArray[i].ToString() != "")
                    images[i] = ByteToImage((byte[])dt.Rows[0].ItemArray[i]);

            return images;
        }

        public DataTable SearchItems(string search, UserCollection collection)
        {
            int collectionNumber = GetCollectionNumber(collection.Name);
            return SqlQueryDataTable("SELECT * FROM " + collection.CollectionType.MainTable.BaseName + "_" + collectionNumber + " WHERE(name LIKE '%" + search + "%')");
        }

        public DataTable SearchItems(string search)
        {
            return null;
        }

        #endregion Работа с предметами



        #region Работа с предметами из внешних таблиц NAMEFIELD

        // Возвращает строку предмета, соедененную по аттрибуту "nameField" из внешней таблицы
        public string GetNameFieldItem(int collectionType, string foreignTable, int itemId)
        {
            if (itemId == 0)
                return "";

            // Формирование запроса на получение данных из внешней таблицы
            string query = "SELECT ";
            foreach (Field field in CollectionTypes.GetCollection(collectionType)[foreignTable].Fields)
                if (field.NameField)
                    query += field.BaseName + ", ";
            query = query.Remove(query.Length - 2);
            query += " FROM " + foreignTable + " WHERE(id = " + itemId + ")";

            DataTable queryRes = SqlQueryDataTable(query);

            string res = "";
            foreach (string item in queryRes.Rows[0].ItemArray)
                res += item + " ";

            return res;
        }

        // Возвращает все строки, соедененные по аттрибуту "nameField" из внешней таблицы
        public DataTable GetNameFields(int collectionType, string foreignTable)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id");
            dt.Columns.Add("data");

            // Формирование запроса на получение данных из внешней таблицы
            string query = "SELECT id, ";
            foreach (Field field in CollectionTypes.GetCollection(collectionType)[foreignTable].Fields)
                if (field.NameField)
                    query += field.BaseName + ", ";
            query = query.Remove(query.Length - 2);
            query += " FROM " + foreignTable;

            DataTable queryRes = SqlQueryDataTable(query);
            foreach (DataRow row in queryRes.Rows)
            {
                string nameFieldsData = "";
                for (int i = 1; i < row.ItemArray.Length; i++)
                    nameFieldsData += row.ItemArray[i] + " ";

                dt.Rows.Add(row.ItemArray[0], nameFieldsData);
            }
            return dt;
        }

        #endregion Работа с предметами из внешних таблиц



        #region Вспомогательные методы

        // Возвращает имена всех коллекций, которые есть в текущей базе данных
        public string[] GetAllCollectionsProgramNamesInCurrentDB()
        {
            DataTable dt = SqlQueryDataTable("SELECT programName FROM Collections");

            string[] collections = new string[dt.Rows.Count];
            for (int i = 0; i < collections.Length; i++)
                collections[i] = dt.Rows[i].ItemArray[0].ToString();

            return collections;
        }

        public string[] GetAllCollectionsNamesInCurrentDB()
        {
            DataTable dt = SqlQueryDataTable("SELECT programName FROM Collections");

            string[] collections = new string[dt.Rows.Count];
            for (int i = 0; i < collections.Length; i++)
                collections[i] = dt.Rows[i].ItemArray[0].ToString();

            return collections;
        }

        // Возвращает идентификатор типа всех коллекций, которые есть в текущей базе данных
        public int[] GetAllCollectionsTypesIdInCurrentDB()
        {
            DataTable dt = SqlQueryDataTable("SELECT typeId FROM Collections");

            int[] types = new int[dt.Rows.Count];
            for (int i = 0; i < types.Length; i++)
                types[i] = int.Parse(dt.Rows[i].ItemArray[0].ToString());

            return types;
        }

        // Проверяет, существует ли коллекция с данным именем в базе
        public bool CollectionExists(string name)
        {
            DataTable collectionsDt = SqlQueryDataTable("SELECT programName FROM Collections");
            foreach (DataRow row in collectionsDt.Rows)
                if (row.ItemArray[0].ToString() == name)
                    return true;

            return false;
        }

        // Возвращает номер коллекции по её имени
        public int GetCollectionNumber(string collectionName)
        {
            string collectionNumber = SqlQueryScalar("SELECT baseName FROM Collections WHERE(programName = '" + collectionName + "')").ToString();
            collectionNumber = collectionNumber.Remove(0, collectionNumber.LastIndexOf('_') + 1);
            return int.Parse(collectionNumber);
        }

        public bool ItemExists(int itemId, int collectionType, string foreignTable)
        {
            DataTable dt = SqlQueryDataTable("SELECT baseName FROM Collections WHERE(typeId = " + collectionType + ")");

            string[] collections = new string[dt.Rows.Count];
            for (int i = 0; i < collections.Length; i++)
                collections[i] = dt.Rows[i].ItemArray[0].ToString();

            string foreignField = "";
            foreach (Field field in CollectionTypes.GetCollection(collectionType).MainTable.Fields)
                if (field.ForeignTable == foreignTable)
                    foreignField = field.BaseName;

            string query = "SELECT " + foreignField + " FROM " + collections[0] + " WHERE(" + foreignField + " = " + itemId + ") ";

            for (int i = 1; i < collections.Length; i++)
                query += " UNION ALL SELECT " + foreignField + " FROM " + collections[i] + " WHERE(" + foreignField + " = " + itemId + ") ";

            DataTable items = SqlQueryDataTable(query);
            if (items.Rows.Count > 0)
                return true;
            else
                return false;
        }

        // Конвертирует массив байтов в картинку
        public Image ByteToImage(byte[] imageBytes)
        {
            if (imageBytes.Length == 0)
                return null;

            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = new Bitmap(ms);
            return image;
        }


        // TODO Сравнивает типы коллекций, которые есть в базе и из файла коллекций и если в файле добавился какой-нибудь тип, то добавляет его в базу
        public void CheckForNewCollectionTypes()
        {
            //string[] typesFromBase = GetAllTypes();
            //string[] typesFromFile = XmlHelper.GetAllTypesNames();

            //if (types)
        }

        #endregion Вспомогательные методы
    }
}
