using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using System.IO;

namespace CollectionsProject
{
    public class Database
    {
        string basePath;
        string baseName;
        SQLiteConnection connection;
        SQLiteDataAdapter adapter;

        #region Свойства

        /// <summary>
        /// Путь до файла базы данных
        /// </summary>
        public string BasePath { get { return basePath; } }

        /// <summary>
        /// Имя базы данных с расширением
        /// </summary>
        public string BaseName { get { return baseName; } }

        /// <summary>
        /// Подсоединена ли программа к базе
        /// </summary>
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

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Database()
        {

        }

        /// <summary>
        /// Конструктор для создания базы данных
        /// </summary>
        /// <param name="path">Путь до базы данных</param>
        /// <param name="userName">Имя пользователя базы данных</param>
        /// <param name="userEmail">Почтовый адрес пользователя базы данных</param>
        /// <param name="password">Пароль</param>
        public Database(string path, string userName, string userEmail, string password = "")
        {
            CreateDatabase(path, userName, userEmail, password);
        }

        #endregion Конструкторы



        #region Запросы

        /// <summary>
        /// Простой SQL запрос (INSERT, UPDATE, DELETE...)
        /// </summary>
        /// <param name="query">Строка запроса</param>
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

        /// <summary>
        /// SQL запрос с возвратом таблицы данных 
        /// </summary>
        /// <param name="query">Строка запроса</param>
        /// <returns>Возвращает DataTable с данными, который вернул запрос</returns>
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

        /// <summary>
        /// SQL запрос с возвратом объекта с данными первой строки первого столбца
        /// </summary>
        /// <param name="query">Строка запроса</param>
        /// <returns>Возвращает объект с данными первой строки первого столбца</returns>
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

        /// <summary>
        /// SQL запрос с возвратом коллекции всех строчек
        /// </summary>
        /// <param name="query">Строка запроса</param>
        /// <returns>Коллекция строчек, которые вернул запрос</returns>
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

        /// <summary>
        /// Создание базы данных
        /// </summary>
        /// <param name="path">Путь до файла базы, который будет создан</param>
        /// <param name="userName">Имя пользователя этой базы данных</param>
        /// <param name="userEmail">Почтовый адрес пользователя этой базы данных</param>
        /// <param name="password">Пароль</param>
        private void CreateDatabase(string path, string userName, string userEmail, string password = "")
        {
            try
            {
                if (connection != null)
                    connection.Shutdown();

                // Создание файла
                SQLiteConnection.CreateFile(path);

                // Connection string
                SQLiteConnectionStringBuilder connectionString = new SQLiteConnectionStringBuilder();
                connectionString.DataSource = path;
                connectionString.Version = 3;
                connectionString.Password = password;

                // Подсоеденение к базе
                connection = new SQLiteConnection(connectionString.ConnectionString);
                connection.Open();

                basePath = connection.FileName;
                baseName = Path.GetFileName(basePath);

                // Смена пароля
                connection.ChangePassword(password);
                connection.Close();

                SqlQuery("PRAGMA auto_vacuum = 1");

                // Создание таблиц и занесение в них первоначальной информации
                // UserInfo
                SqlQuery("CREATE TABLE UserInfo(username TEXT, useremail TEXT)");
                SqlQuery("INSERT INTO UserInfo VALUES('" + userName + "', '" + userEmail + "')");

                // Collections
                SqlQuery("CREATE TABLE Collections(id INTEGER PRIMARY KEY AUTOINCREMENT, baseName TEXT, programName TEXT, typeId INTEGER)");

                // Configurations
                SqlQuery("CREATE TABLE Configurations(key VARCHAR, value VARCHAR)");
                SqlQuery("INSERT INTO Configurations VALUES('COLLECTION_COUNTER', '0')");

                // Создание внешних таблиц
                foreach (Collection collection in CollectionTypes.Collections)
                {
                    foreach (Table table in collection.ForeignTables)
                    {
                        string query = "CREATE TABLE " + table.BaseName + " (id INTEGER PRIMARY KEY AUTOINCREMENT, ";
                        foreach (Field field in table.Fields)
                            query += field.BaseName + " " + field.Type + ", ";
                        query += "note TEXT)";

                        SqlQuery(query);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Подсоединение к базе данных
        /// </summary>
        /// <param name="path">Путь до базы</param>
        /// <param name="password">Пароль</param>
        /// <returns>Возвращает true если посдоединение прошло успешно, иначе false</returns>
        public bool ConnectToDatabase(string path, string password = "")
        {
            try
            {
                if (connection != null)
                    connection.Shutdown();

                SQLiteConnectionStringBuilder connectionString = new SQLiteConnectionStringBuilder();
                connectionString.DataSource = path;
                connectionString.Version = 3;
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
                if (ex.ErrorCode == 26)
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

        /// <summary>
        /// Создание коллекции определенного типа и имени
        /// </summary>
        /// <param name="name">Имя коллекции</param>
        /// <param name="collectionId">Идентификатор типа коллекции</param>
        public void CreateCollection(string name, int collectionId)
        {
            // Получение количества созданных коллекций + 1
            int numberOfCreatedCollections = int.Parse(SqlQueryScalar("SELECT value FROM Configurations WHERE(key = 'COLLECTION_COUNTER')").ToString()) + 1;
            SqlQuery("UPDATE Configurations SET value = '" + numberOfCreatedCollections + "' WHERE(key = 'COLLECTION_COUNTER')");

            // Запрос на создание главной таблицы
            string query = "CREATE TABLE " + CollectionTypes.GetCollection(collectionId)[0].BaseName + "_" + numberOfCreatedCollections + "(";
            query += "id INTEGER PRIMARY KEY AUTOINCREMENT, ";
            foreach (Field field in CollectionTypes.GetCollection(collectionId)[0].Fields)
                query += field.BaseName + " " + field.Type + ", ";
            query += "uploadDate DATETIME, changeDate DATETIME, note TEXT, photo1 BLOB, photo2 BLOB, photo3 BLOB, photo4 BLOB, comment1 TEXT, comment2 TEXT, comment3 TEXT, comment4 TEXT)";
            SqlQuery(query);

            // Добавление в таблицу Collections данных о текущей коллекции
            SqlQuery("INSERT INTO Collections(baseName, programName, typeId) VALUES('" + CollectionTypes.GetCollection(collectionId)[0].BaseName + "_" + numberOfCreatedCollections + "', '" + name + "', " + collectionId + ")");
        }

        /// <summary>
        /// Переименование коллекции
        /// </summary>
        /// <param name="name">Имя коллекции</param>
        /// <param name="newName">Новое имя коллекции</param>
        public void RenameCollection(string name, string newName)
        {
            int collectionId = int.Parse(SqlQueryScalar("SELECT id FROM Collections WHERE(programName = '" + name + "')").ToString());
            SqlQuery("UPDATE Collections SET programName = '" + newName + "' WHERE(id = " + collectionId + ")");
        }

        /// <summary>
        /// Удаление коллекции
        /// </summary>
        /// <param name="name">Имя коллекции</param>
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

        /// <summary>
        /// Добавление предмета в указанную коллекцию
        /// </summary>
        /// <param name="collectionType">Тип коллекции</param>
        /// <param name="collectionName">Имя коллекции</param>
        /// <param name="fields">Значения полей для добавления</param>
        /// <param name="note">Описание предмета</param>
        /// <param name="foreignTable">Имя внешней таблицы</param>
        public void AddItem(int collectionType, string[] fields, string note, string collectionName = "", string foreignTable = "", ItemImage[] images = null)
        {
            Field[] tableFields;
            string query;
            if (foreignTable == "")
            {
                int collectionNumber = GetCollectionNumber(collectionName);
                tableFields = CollectionTypes.GetCollection(collectionType)[0].Fields;
                query = "INSERT INTO " + CollectionTypes.GetCollection(collectionType)[0].BaseName + "_" + collectionNumber + " VALUES(NULL, ";
            }
            else
            {
                tableFields = CollectionTypes.GetCollection(collectionType)[foreignTable].Fields;
                query = "INSERT INTO " + foreignTable  + " VALUES(NULL, ";
            }

            // Формирование запроса на добавление
            int fieldsCounter = 0;
            foreach (Field field in tableFields)
            {
                if (fields[fieldsCounter] != "")
                {
                    if (field.Type == "INTEGER")
                        query += fields[fieldsCounter] + ", ";
                    else
                        query += "'" + fields[fieldsCounter] + "', ";
                }
                else
                {
                    if (field.Type == "INTEGER")
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

        /// <summary>
        /// Обновление данных о предмете
        /// </summary>
        /// <param name="collectionType">Тип коллекции</param>
        /// <param name="collectionName">Имя коллекции</param>
        /// <param name="itemId">Идентификатор предмета для обновления данных</param>
        /// <param name="fields">Значения полей для обновления данных</param>
        /// <param name="note">Описание предмета</param>
        /// <param name="foreignTable">Имя внешней таблицы</param>
        public void UpdateItem(int collectionType, int itemId, string[] fields, string note, string collectionName = "", string foreignTable = "", ItemImage[] images = null)
        {
            Field[] tableFields;
            string query;
            if (foreignTable == "")
            {
                int collectionNumber = GetCollectionNumber(collectionName);
                tableFields = CollectionTypes.GetCollection(collectionType)[0].Fields;
                query = "UPDATE " + CollectionTypes.GetCollection(collectionType)[0].BaseName + "_" + collectionNumber + " SET ";
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
                if (field.Type == "INTEGER")
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

        /// <summary>
        /// Удаление предмета
        /// </summary>
        /// <param name="collectionType">Тип коллекции</param>
        /// <param name="collectionName">Имя коллекции</param>
        /// <param name="itemId">Идентификатор предмета для удаления</param>
        /// <param name="foreignTable">Имя внешней таблицы</param>
        public void DeleteItem(int collectionType, int itemId, string collectionName = "", string foreignTable = "")
        {
            if (foreignTable == "")
            {
                int collectionNumber = GetCollectionNumber(collectionName);
                SqlQuery("DELETE FROM " + CollectionTypes.GetCollection(collectionType)[0].BaseName + "_" + collectionNumber + " WHERE(id = " + itemId + ")");
            }
            else
                SqlQuery("DELETE FROM " + CollectionTypes.GetCollection(collectionType)[foreignTable].BaseName + " WHERE(id = " + itemId + ")");
        }


        /// <summary>
        /// Возвращает все предметы из всех коллекций
        /// </summary>
        /// <returns>DataTable с данными о всех предметах из всех коллекций</returns>
        public DataTable GetAllItemsFromAllCollections()
        {
            DataRowCollection collectionsInfo = SqlQueryRows("SELECT baseName, programName, typeId FROM Collections");

            DataTable[] collections = new DataTable[collectionsInfo.Count];
            for (int i = 0; i < collections.Length; i++)
                collections[i] = SqlQueryDataTable("SELECT " + CollectionTypes.GetCollection(int.Parse(collectionsInfo[i].ItemArray[2].ToString()))[0][0].BaseName + ", uploadDate, changeDate FROM " + collectionsInfo[i][0]);

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


        /// <summary>
        /// Возвращает предмет из коллекции по определенному ID
        /// </summary>
        /// <param name="collectionType">Тип коллекции</param>
        /// <param name="collectionName">Имя коллекции</param>
        /// <param name="itemId">Идентификатор предмета</param>
        /// <param name="foreignTable">Имя внешней таблицы</param>
        /// <returns>DataRow с предметом</returns>
        public DataRow GetItemFromCollection(int collectionType, int itemId, string collectionName = "", string foreignTable = "")
        {
            DataTable dt;
            if (foreignTable == "")
            {
                int collectionNumber = GetCollectionNumber(collectionName);
                dt = SqlQueryDataTable("SELECT * FROM " + CollectionTypes.GetCollection(collectionType)[0].BaseName + "_" + collectionNumber + " WHERE(id = " + itemId + ")");
            }
            else
                dt = SqlQueryDataTable("SELECT * FROM " + CollectionTypes.GetCollection(collectionType)[foreignTable].BaseName + " WHERE(id = " + itemId + ")");

            return dt.Rows[0];
        }

        /// <summary>
        /// Возвращает предметы из коллекции по ее имени
        /// </summary>
        /// <param name="collectionType">Тип коллекции</param>
        /// <param name="collectionName">Имя коллекции</param>
        /// <param name="foreignTable">Имя внешней таблицы</param>
        /// <returns>DataTable со строками из коллекции</returns>
        public DataTable GetItemsFromCollection(int collectionType, string collectionName = "", string foreignTable = "")
        {
            if (foreignTable == "")
            {
                int collectionNumber = GetCollectionNumber(collectionName);
                return SqlQueryDataTable("SELECT * FROM " + CollectionTypes.GetCollection(collectionType)[0].BaseName + "_" + collectionNumber);
            }
            else
                return SqlQueryDataTable("SELECT * FROM " + CollectionTypes.GetCollection(collectionType)[foreignTable].BaseName);
        }


        /// <summary>
        /// Возвращает описание из предмета
        /// </summary>
        /// <param name="collectionType">Тип коллекции</param>
        /// <param name="collectionName">Имя коллекции</param>
        /// <param name="itemId">Идентификатор предмета</param>
        /// <param name="foreignTable">Имя внешней таблицы</param>
        /// <returns>Строку описания предмета</returns>
        public string GetNoteFromItem(int collectionType, int itemId, string collectionName = "", string foreignTable = "")
        {
            if (foreignTable == "")
            {
                int collectionNumber = GetCollectionNumber(collectionName);
                return SqlQueryScalar("SELECT note FROM " + CollectionTypes.GetCollection(collectionType)[0].BaseName + "_" + collectionNumber + " WHERE(id = " + itemId + ")").ToString();
            }
            else
                return SqlQueryScalar("SELECT note FROM " + CollectionTypes.GetCollection(collectionType)[foreignTable].BaseName + " WHERE(id = " + itemId + ")").ToString();
        }

        #endregion Работа с предметами



        #region Работа с предметами из внешних таблиц NAMEFIELD

        /// <summary>
        /// Возвращает строку предмета, соедененную по аттрибуту "nameField" из внешней таблицы
        /// </summary>
        /// <param name="collectionType">Идентификатор типа коллекции</param>
        /// <param name="foreignTable">Имя внешней таблицы</param>
        /// <param name="itemId">Идентификатор предмета</param>
        /// <returns>Строка предмета, соедененная по аттрибуту "nameField"</returns>
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

        /// <summary>
        /// Возвращает все строки, соедененные по аттрибуту "nameField" из внешней таблицы
        /// </summary>
        /// <param name="collectionType">Идентификатор типа коллекции</param>
        /// <param name="foreignTable">Имя внешней таблицы</param>
        /// <returns>Строки, соедененные по аттрибуту "nameField"</returns>
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

        /// <summary>
        /// Возвращает имена всех коллекций, которые есть в текущей базе данных
        /// </summary>
        /// <returns>Имена всех коллекций</returns>
        public string[] GetAllCollectionsNamesInCurrentDB()
        {
            DataTable dt = SqlQueryDataTable("SELECT programName FROM Collections");

            string[] collections = new string[dt.Rows.Count];
            for (int i = 0; i < collections.Length; i++)
                collections[i] = dt.Rows[i].ItemArray[0].ToString();

            return collections;
        }

        /// <summary>
        /// Возвращает идентификатор типа всех коллекций, которые есть в текущей базе данных
        /// </summary>
        /// <returns>Идентификатор типа всех коллекций</returns>
        public int[] GetAllCollectionsTypesIdInCurrentDB()
        {
            DataTable dt = SqlQueryDataTable("SELECT typeId FROM Collections");

            int[] types = new int[dt.Rows.Count];
            for (int i = 0; i < types.Length; i++)
                types[i] = int.Parse(dt.Rows[i].ItemArray[0].ToString());

            return types;
        }

        /// <summary>
        /// Проверяет, существует ли коллекция с данным именем в базе
        /// </summary>
        /// <param name="name">Имя коллекции</param>
        /// <returns>Возвращает true коллекция с таким именем существует в базе, иначе false</returns>
        public bool CollectionExists(string name)
        {
            DataTable collectionsDt = SqlQueryDataTable("SELECT programName FROM Collections");
            foreach (DataRow row in collectionsDt.Rows)
                if (row.ItemArray[0].ToString() == name)
                    return true;

            return false;
        }

        /// <summary>
        /// Возвращает номер коллекции по её имени
        /// </summary>
        /// <param name="collectionName">Имя коллекции</param>
        /// <returns>Номер коллекции</returns>
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
            foreach (Field field in CollectionTypes.GetCollection(collectionType)[0].Fields)
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
