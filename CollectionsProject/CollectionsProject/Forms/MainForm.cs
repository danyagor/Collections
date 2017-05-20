using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using CollectionsProject.Forms;

namespace CollectionsProject
{
    public partial class MainForm : Form
    {
        private Database currentDatabase;

        public MainForm()
        {
            InitializeComponent();
            Text = Localization.PROGRAM_TITLE;
            CollectionTypes.Collections = XmlHelper.GetAllCollections();
            CollectionTypes.ForeignTables = XmlHelper.GetAllForeignTables();
        }

        #region Свойства

        public Database CurrentDatabase { get { return currentDatabase; } }

        #endregion Свойства



        #region Работа с базой

        // Создание базы
        private void CreateDatabase()
        {
            CreateDatabaseForm cdf = new CreateDatabaseForm(this);
            cdf.ShowDialog();
        }

        // Смена базы
        public void ChangeDatabase(Database database)
        {
            currentDatabase = database;
            AddLastFile(database.BasePath);
            UpdateLastFilesMenuItem();
            CheckDatabaseConnection();
            InitializeBase();
        }

        // Обновление данных в TreeView о всех коллекциях в подсоединенной базе данных
        private void InitializeBase()
        {
            treeView.Nodes[0].Nodes.Clear();
            string[] collectionsNames = CurrentDatabase.GetAllCollectionsNamesInCurrentDB();
            int[] collectionsTypes = CurrentDatabase.GetAllCollectionsTypesIdInCurrentDB();

            for (int i = 0; i < collectionsNames.Length; i++)
                AddCollectionInTreeView(collectionsNames[i], collectionsTypes[i]);

            // Очистка всех данных из ListView
            dgvItems.DataSource = null;
        }

        // Открытие базы данных
        public void OpenDatabase()
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Файлы коллекций (*.cdb)| *.cdb";
                string dbPath = "";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    dbPath = ofd.FileName;
                    // Если путь открываемой базы совпадает с уже открытой, то вывести ошибку
                    if (CurrentDatabase != null)
                    {
                        if (dbPath != CurrentDatabase.BasePath)
                        {
                            if (FileEncrypted(dbPath))
                            {
                                OpenEncryptedDatabaseForm odbf = new OpenEncryptedDatabaseForm(this, dbPath);
                                odbf.ShowDialog();
                            }
                            else
                            {
                                Database newDb = new Database();
                                if (newDb.ConnectToDatabase(dbPath))
                                    ChangeDatabase(newDb);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Такая база уже открыта.");
                        }
                    }
                    else
                    {
                        if (FileEncrypted(dbPath))
                        {
                            OpenEncryptedDatabaseForm odbf = new OpenEncryptedDatabaseForm(this, dbPath);
                            odbf.ShowDialog();
                        }
                        else
                        {
                            Database newDb = new Database();
                            if (newDb.ConnectToDatabase(dbPath))
                                ChangeDatabase(newDb);
                        }
                    }

                    InitializeBase();
                }   
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        // Открыть базу данных через путь
        public void OpenDatabaseByPath(string path)
        {
            try
            {
                // Если путь открываемой базы совпадает с уже открытой, то вывести ошибку
                if (CurrentDatabase != null)
                {
                    if (path != CurrentDatabase.BasePath)
                    {
                        if (FileEncrypted(path))
                        {
                            OpenEncryptedDatabaseForm odbf = new OpenEncryptedDatabaseForm(this, path);
                            if (odbf.ShowDialog() != DialogResult.OK)
                                return;
                        }
                        else
                        {
                            Database newDb = new Database();
                            if (newDb.ConnectToDatabase(path))
                                ChangeDatabase(newDb);
                        }
                    }
                    else
                        MessageBox.Show("Такая база уже открыта.");
                }
                else
                {
                    if (FileEncrypted(path))
                    {
                        OpenEncryptedDatabaseForm odbf = new OpenEncryptedDatabaseForm(this, path);
                        if (odbf.ShowDialog() != DialogResult.OK)
                            return;
                    }
                    else
                    {
                        Database newDb = new Database();
                        if (newDb.ConnectToDatabase(path))
                            ChangeDatabase(newDb);
                    }
                }

                InitializeBase();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        #endregion Работа с базой



        #region Работа с коллекциями

        // Создание коллекции
        private void CreateCollection()
        {
            CreateCollectionForm cf = new CreateCollectionForm(this);
            cf.ShowDialog();
        }

        // Переименование коллекции
        private void RenameCollection(string name)
        {
            RenameCollectionForm rcf = new RenameCollectionForm(this, name);
            rcf.ShowDialog();
        }

        // Удаление коллекции
        private void DeleteCollection(string name)
        {
            if (MessageBox.Show("Вы уверены, что хотите удалить коллекцию \"" + name + "\"", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                currentDatabase.DeleteCollection(name);
                DeleteCollectionInTreeView(name);
            }
        }


        // Добавить нод коллекции в TreeView
        public void AddCollectionInTreeView(string name, int typeId)
        {
            TreeNode newNode = new TreeNode(name);
            newNode.Tag = typeId;
            newNode.ContextMenuStrip = innerCollectionsCMS;
            treeView.Nodes[0].Nodes.Add(newNode);
            treeView.Nodes[0].ExpandAll();
        }

        // Переименование нода коллекции в TreeView
        public void RenameCollectionInTreeView(string name, string newName)
        {
            for (int i = 0; i < treeView.Nodes[0].Nodes.Count; i++)
                if (treeView.Nodes[0].Nodes[i].Text == name)
                    treeView.Nodes[0].Nodes[i].Text = newName;
        }

        // Удалить нод коллекции в TreeView
        public void DeleteCollectionInTreeView(string name)
        {
            for (int i = 0; i < treeView.Nodes[0].Nodes.Count; i++)
                if (treeView.Nodes[0].Nodes[i].Text == name)
                    treeView.Nodes[0].Nodes.RemoveAt(i);

            dgvItems.DataSource = null;
        }


        // Обновление колонок в ListView исходя из типа коллекции 
        private void UpdateListViewColumns(int typeId)
        {
            dgvItems.Rows.Clear();
            dgvItems.Columns.Clear();

            dgvItems.Columns.Add("id", "№");

            foreach (Field field in CollectionTypes.GetCollection(typeId).MainTable.Fields)
                dgvItems.Columns.Add(field.BaseName, field.ProgramName);

            dgvItems.Columns.Add("uploadDate", "Дата добавления");
            dgvItems.Columns.Add("changeDate", "Дата изменения");
        }

        // Обновить данные в DataGridView о коллекции
        private void UpdateDataGridView(int collectionType, string collectionName)
        {
            dgvItems.Rows.Clear();
            DataTable dt = CurrentDatabase.GetItemsFromCollection(collectionType, collectionName);
            Field[] fields = CollectionTypes.GetCollection(collectionType).MainTable.Fields;
            foreach (DataRow row in dt.Rows)
            {
                string[] items = new string[row.ItemArray.Length];
                int fieldsCounter = 0;

                // Без описания
                for (int i = 0; i < row.ItemArray.Length - 1; i++)
                {
                    // Если поле внешнее, то производит поиск по внешней таблице и записывает значения именных полей
                    if (fieldsCounter < fields.Length)
                    { 
                        if (dt.Columns[i].ColumnName == fields[fieldsCounter].BaseName)
                        {
                            if (fields[fieldsCounter].ForeignKey)
                            {
                                items[i] = CurrentDatabase.GetNameFieldItem(collectionType, fields[fieldsCounter].ForeignTable, int.Parse(row.ItemArray[i].ToString()));
                                fieldsCounter++;
                                continue;
                            }

                            fieldsCounter++;
                        }
                    }

                    items[i] = row.ItemArray[i].ToString();
                }

  
                dgvItems.Rows.Add(items);
                dgvItems.Rows[dgvItems.Rows.Count - 1].Tag = row.ItemArray[0];
            }
        }

        #endregion Работа с коллекциями



        #region Предметы

        // Добавление предмета в коллекцию
        private void AddItem(int collectionId, string collectionName)
        {
            ItemPropertiesForm ipf = new ItemPropertiesForm(this, collectionId, collectionName);
            ipf.ShowDialog();

            UpdateDataGridView(collectionId, collectionName);
        }

        // Редактирование предмета
        private void EditItem(int collectionId, string collectionName, int itemId)
        {
            ItemPropertiesForm ipf = new ItemPropertiesForm(this, collectionId, collectionName, itemId);
            ipf.ShowDialog();

            UpdateDataGridView(collectionId, collectionName);
        }

        // Удаление предмета из коллекции
        private void DeleteItem(int collectionType, string collectionName, int itemId)
        {
            currentDatabase.DeleteItem(collectionType, itemId, collectionName);

            UpdateDataGridView(collectionType, collectionName);
        }


        // Обновление данных о всех предметах из всех коллекций в ListView
        private void UpdateListViewAllItems()
        {
            dgvItems.Rows.Clear();
            dgvItems.Columns.Clear();

            // Обновление колонок
            //dgvItems.Columns.Add("id", "№");
            dgvItems.Columns.Add("name", "Название");
            dgvItems.Columns.Add("collectionName", "Из коллекции");
            dgvItems.Columns.Add("collectionType", "Тип коллекции");
            dgvItems.Columns.Add("uploadDate", "Дата добавления");
            dgvItems.Columns.Add("changeDate", "Дата изменения");

            DataTable items = CurrentDatabase.GetAllItemsFromAllCollections();
            foreach (DataRow row in items.Rows)
            {
                dgvItems.Rows.Add(row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString());
                dgvItems.Rows[dgvItems.Rows.Count - 1].Tag = row.ItemArray[0];
            }
        }

        // Формирование описания предмета
        private void FormDescriptionOfItem(int collectionType, string collectionName, int itemId)
        {
            string description = "Описание: \n";
            description += CurrentDatabase.GetNoteFromItem(collectionType, itemId, collectionName) + "\n";
            rtbItemDescription.Text = description;

            // TODO: При выделении предмета в ноде "Коллекции" дописать после описания все главные поля и их значения
        }

        #endregion Предметы



        #region Последние файлы

        // Добавить файл базы в файл lastfiles.xml
        private void AddLastFile(string path)
        {
            XmlHelper.WriteLastFile(path);
        }

        // Обновление элементов в MenuItem "Последние базы"
        private void UpdateLastFilesMenuItem()
        {
            tsmiLastBases.DropDownItems.Clear();
            string[] files = XmlHelper.GetLastFiles();
            for (int i = 0; i < files.Length; i++)
            {
                tsmiLastBases.DropDownItems.Add((i + 1) + ". " + files[i]);
                tsmiLastBases.DropDownItems[i].Click += LastBases_Click;
            }
        }

        #endregion Последние файлы
  


        #region Вспомогательные методы

        // Проверка на зашифрованность файла базы
        public bool FileEncrypted(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string str = sr.ReadLine();
                str = str.Substring(0, 15).ToUpper();
                if (str == "SQLITE FORMAT 3")
                    return false;
                else
                    return true;
            }
        }

        // Проверка подсоединения к базе
        private void CheckDatabaseConnection()
        {
            if (CurrentDatabase != null)
            {
                tssLabelConnectionState.Text = "Подсоединено к \"" + CurrentDatabase.BaseName + "\"";
                Text = "Коллекции - \"" +CurrentDatabase.BaseName + "\"";

                // Включение кнопок
                ChangeButtonsState(true);
            }
            else
            {
                tssLabelConnectionState.Text = "Не подсоединено";
                Text = "Коллекции";

                // Выключение кнопок кнопок
                ChangeButtonsState(false);
                tsmiCreateCollection.Enabled = false;
            }
        }


        private void ChangeButtonsState(bool value)
        {
            tsmiRenameCollection.Enabled = value;
            tsmiDeleteCollection.Enabled = value;

            tsmiAddItem.Enabled = value;
            tsmiEditItem.Enabled = value;
            tsmiDeleteItem.Enabled = value;

            itemsCmsAddItem.Enabled = value;
            itemsCmsEditItem.Enabled = value;
            itemsCmsDeleteItem.Enabled = value;
        }

        #endregion Вспомогательные методы



        #region События

        // Загрузка формы
        private void MainForm_Load(object sender, EventArgs e)
        {
            CheckDatabaseConnection();
            UpdateLastFilesMenuItem();
        }


        // Создание базы
        private void CreateDatabase_Click(object sender, EventArgs e)
        {
            CreateDatabase();
        }

        // Открытие базы
        private void OpenDatabase_Click(object sender, EventArgs e)
        {
            OpenDatabase();
        }


        // Создание коллекции
        private void CreateCollection_Click(object sender, EventArgs e)
        {
            CreateCollection();
        }

        // Переименование коллекции
        private void RenameCollection_Click(object sender, EventArgs e)
        {
            if (treeView.SelectedNode.Parent != null)
                if (treeView.SelectedNode.Parent.Text == "Коллекции")
                    RenameCollection(treeView.SelectedNode.Text);
        }

        // Удаление коллекции
        private void DeleteCollection_Click(object sender, EventArgs e)
        {
            if (treeView.SelectedNode.Parent != null)
                if (treeView.SelectedNode.Parent.Text == "Коллекции")
                    DeleteCollection(treeView.SelectedNode.Text);
        }


        // Добавление предмета
        private void AddItem_Click(object sender, EventArgs e)
        {
            if (treeView.SelectedNode.Parent != null)
                if (treeView.SelectedNode.Parent.Text == "Коллекции")
                    AddItem(int.Parse(treeView.SelectedNode.Tag.ToString()), treeView.SelectedNode.Text);
        }

        // Редактирование предмета
        private void EditItem_Click(object sender, EventArgs e)
        {
            if (treeView.SelectedNode.Parent != null && dgvItems.SelectedCells.Count != 0)
                if (treeView.SelectedNode.Parent.Text == "Коллекции")
                    EditItem(int.Parse(treeView.SelectedNode.Tag.ToString()), treeView.SelectedNode.Text, int.Parse(dgvItems.SelectedCells[0].Value.ToString()));
        }

        // Удаление предмета
        private void DeleteItem_Click(object sender, EventArgs e)
        {
            if (treeView.SelectedNode.Parent != null && dgvItems.SelectedCells.Count != 0)
                if (treeView.SelectedNode.Parent.Text == "Коллекции")
                    DeleteItem(int.Parse(treeView.SelectedNode.Tag.ToString()), treeView.SelectedNode.Text, int.Parse(dgvItems.SelectedCells[0].Value.ToString()));
        }


        // Клик на ListView
        private void lvData_MouseClick(object sender, MouseEventArgs e)
        {
            if (treeView.SelectedNode.Text != "Коллекции")
                FormDescriptionOfItem(int.Parse(treeView.SelectedNode.Tag.ToString()), treeView.SelectedNode.Text, int.Parse(dgvItems.SelectedRows[0].Tag.ToString()));
        }


        // Выбор нода в TreeView
        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // Обновление колонок в ListView
            if (treeView.SelectedNode.Tag != null)
                UpdateListViewColumns((int)treeView.SelectedNode.Tag);

            // Обновление ListView для отображения всех предметов из всех коллекций
            if (treeView.SelectedNode.Text == "Коллекции" && CurrentDatabase != null)
            {
                if (treeView.SelectedNode.Nodes.Count != 0)
                {
                    UpdateListViewAllItems();
                    if (CurrentDatabase != null)
                    {
                        ChangeButtonsState(false);
                        tsmiCreateCollection.Enabled = true;
                    }
                }
                else
                {
                    ChangeButtonsState(false);
                    tsmiCreateCollection.Enabled = true;
                }
            }
            else
                if (CurrentDatabase != null)
                    ChangeButtonsState(true);

            // Обновление строк в ListView
            if (treeView.SelectedNode.Parent != null)
                if (treeView.SelectedNode.Parent.Text == "Коллекции")
                    UpdateDataGridView(int.Parse(treeView.SelectedNode.Tag.ToString()), treeView.SelectedNode.Text);
        }


        // Последние базы
        private void LastBases_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = (ToolStripMenuItem)sender;
            string path = tsmi.Text.Remove(0, 3);
            OpenDatabaseByPath(path);
        }

        
        // Редактор внешних таблиц
        private void ForeignTablesEditor_Click(object sender, EventArgs e)
        {
            if (treeView.SelectedNode.Text == "Коллекции")
            {
                ForeignTableForm ftf = new ForeignTableForm(this, 0);
                ftf.ShowDialog();
            }

            if (treeView.SelectedNode.Parent != null)
            {
                if (treeView.SelectedNode.Parent.Text == "Коллекции")
                {
                    ForeignTableForm ftf = new ForeignTableForm(this, int.Parse(treeView.SelectedNode.Tag.ToString()));
                    ftf.ShowDialog();

                    UpdateDataGridView(int.Parse(treeView.SelectedNode.Tag.ToString()), treeView.SelectedNode.Text);
                }
            }
        }

        // Настройки
        private void tsmiSettings_Click(object sender, EventArgs e)
        {
            SettingsForm sf = new SettingsForm();
            sf.ShowDialog();
        }

        // Выход
        private void tsmlExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion События

        
    }
}
