﻿using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using CollectionsProject.Forms;
using System.Drawing;

namespace CollectionsProject
{
    public partial class MainForm : Form
    {
        private Database currentDatabase;

        public MainForm()
        {
            InitializeComponent();
            XmlHelper.OpenSettingsFromFile();
            InitializeFormText();
            CollectionTypes.Collections = XmlHelper.GetAllCollections();
            CollectionTypes.ForeignTables = XmlHelper.GetAllForeignTables();
            UpdateIconsSize();
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
                AddCollectionInTreeView(new UserCollection(CollectionTypes.GetCollection(collectionsTypes[i]), collectionsNames[i]));

            // Очистка всех данных из ListView
            dgvItems.Columns.Clear();
            dgvItems.Rows.Clear();
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
        public void AddCollectionInTreeView(UserCollection collection)
        {
            TreeNode newNode = new TreeNode(collection.Name);
            newNode.Tag = collection;
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
        private void UpdateListViewColumns(UserCollection collection)
        {
            dgvItems.Rows.Clear();
            dgvItems.Columns.Clear();

            dgvItems.Columns.Add("id", "№");

            foreach (Field field in collection.CollectionType.MainTable.Fields)
                dgvItems.Columns.Add(field.BaseName, field.ProgramName);

            dgvItems.Columns.Add("uploadDate", "Дата добавления");
            dgvItems.Columns.Add("changeDate", "Дата изменения");
        }

        // Обновить данные в DataGridView о коллекции
        private void UpdateDataGridView(UserCollection collection)
        {
            dgvItems.Rows.Clear();
            DataTable dt = CurrentDatabase.GetItemsFromCollection(collection.CollectionType.Id, collection.Name);
            Field[] fields = collection.CollectionType.MainTable.Fields;
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
                                items[i] = CurrentDatabase.GetNameFieldItem(collection.CollectionType.Id, fields[fieldsCounter].ForeignTable, int.Parse(row.ItemArray[i].ToString()));
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
        private void AddItem(UserCollection collection)
        {
            ItemPropertiesForm ipf = new ItemPropertiesForm(this, collection);
            ipf.ShowDialog();

            UpdateDataGridView(collection);
        }

        // Редактирование предмета
        private void EditItem(UserCollection collection, int itemId)
        {
            ItemPropertiesForm ipf = new ItemPropertiesForm(this, collection, itemId);
            ipf.ShowDialog();

            UpdateDataGridView(collection);
        }

        // Удаление предмета из коллекции
        private void DeleteItem(UserCollection collection, int itemId)
        {
            currentDatabase.DeleteItem(collection.CollectionType.Id, itemId, collection.Name);

            UpdateDataGridView(collection);
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
        private void FormDescriptionOfItem(UserCollection collection, int itemId)
        {
            rtbItemDescription.Text = "";
            pbPhoto1.Image = null;
            pbPhoto2.Image = null;
            pbPhoto3.Image = null;
            pbPhoto4.Image = null;

            string description = Localization.DESCRIPTION + ":\n";
            description += CurrentDatabase.GetNoteFromItem(collection.CollectionType.Id, itemId, collection.Name) + "\n";
            rtbItemDescription.Text = description;

            Image[] images = CurrentDatabase.GetImagesFromItem(collection.CollectionType.Id, itemId, collection.Name);
            pbPhoto1.Image = images[0];
            pbPhoto2.Image = images[1];
            pbPhoto3.Image = images[2];
            pbPhoto4.Image = images[3];

            // TODO: При выделении предмета в ноде "Коллекции" дописать после описания все главные поля и их значения
        }

        // Поиск предметов по определенной коллекции
        public void SearchItems(string searchText, UserCollection collection)
        {
            UpdateListViewColumns(collection);

            dgvItems.Rows.Clear();
            DataTable dt = CurrentDatabase.SearchItems(searchText, collection);
            Field[] fields = collection.CollectionType.MainTable.Fields;
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
                                items[i] = CurrentDatabase.GetNameFieldItem(collection.CollectionType.Id, fields[fieldsCounter].ForeignTable, int.Parse(row.ItemArray[i].ToString()));
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

        // Поиск предметов по всем коллекциям
        public void SearchItems(string searchText)
        {
            CurrentDatabase.SearchItems(searchText);
            UpdateListViewAllItems();

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
            tsbOpenBase.DropDownItems.Clear();

            string[] files = XmlHelper.GetLastFiles();
            for (int i = 0; i < files.Length; i++)
            {
                tsmiLastBases.DropDownItems.Add((i + 1) + ". " + files[i]);
                tsmiLastBases.DropDownItems[i].Click += LastBases_Click;

                tsbOpenBase.DropDownItems.Add((i + 1) + ". " + files[i]);
                tsbOpenBase.DropDownItems[i].Click += LastBases_Click;
            }
        }

        #endregion Последние файлы
  


        #region Вспомогательные методы

        // Проверка на зашифрованность файла базы
        public bool FileEncrypted(string path)
        {
            File.ReadAllBytes(path);
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
                tssLabelConnectionState.Text = Localization.CONNECTED + " \"" + CurrentDatabase.BaseName + "\"";
                Text = Localization.PROGRAM_TITLE + " - \"" +CurrentDatabase.BaseName + "\"";

                // Включение кнопок
                ChangeButtonsState(true);

                tsmiForeignTablesEditor.Enabled = true;
            }
            else
            {
                tssLabelConnectionState.Text = Localization.DISCONNECTED;
                Text = Localization.PROGRAM_TITLE;

                // Выключение кнопок кнопок
                ChangeButtonsState(false);
                tsmiCreateCollection.Enabled = false;
                tsmiForeignTablesEditor.Enabled = false;
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

        private void UpdateIconsSize()
        {
            foreach (ToolStripItem item in toolStrip.Items)
                item.Size = new Size(Settings.IconsSize, Settings.IconsSize);
        }

        private void ClearItemInformation()
        {
            rtbItemDescription.Text = "";
            pbPhoto1.Image = null;
            pbPhoto2.Image = null;
            pbPhoto3.Image = null;
            pbPhoto4.Image = null;
        }

        private void InitializeFormText()
        {
            CheckDatabaseConnection();

            // Файл
            tsmiFile.Text = Localization.FILE;
            tsmiCreateDatabase.Text = Localization.CREATE_BASE;
            tsmiOpenDatabase.Text = Localization.OPEN_BASE;
            tsmiLastBases.Text = Localization.LAST_BASES;
            tsmiExit.Text = Localization.EXIT;

            // Коллекции
            tsmiCollections.Text = Localization.COLLECTIONS;
            tsmiCreateCollection.Text = Localization.CREATE_COLLECTION;
            tsmiRenameCollection.Text = Localization.RENAME_COLLECTION;
            tsmiDeleteCollection.Text = Localization.DELETE_COLLECTION;

            // Предметы
            tsmiItems.Text = Localization.ITEMS;
            tsmiAddItem.Text = Localization.ADD_ITEM;
            tsmiEditItem.Text = Localization.EDIT_ITEM;
            tsmiDeleteItem.Text = Localization.DELETE_ITEM;
            tsmiSearchItem.Text = Localization.SEARCH_ITEM;

            // Вид
            tsmiView.Text = Localization.VIEW;
            tsmiPhotoPanel.Text = Localization.PHOTOS_PANEL;
            tsmiDescriptionPanel.Text = Localization.DESCRIPTION_PANEL;
            tsmiIconsPanel.Text = Localization.ICONS_PANEL;

            // Справочники
            tsmiForeignTables.Text = Localization.CATALOGS;
            tsmiForeignTablesEditor.Text = Localization.CATALOGS_EDITOR;

            // Сервис
            tsmiService.Text = Localization.SERVICE;
            tsmiSettings.Text = Localization.SETTINGS;

            // Справка
            tsmiHelp.Text = Localization.HELP;
            tsmiAbout.Text = Localization.ABOUT;

            // TabControl Фотографии
            tcPhotos.TabPages[0].Text = Localization.PHOTO + " 1";
            tcPhotos.TabPages[1].Text = Localization.PHOTO + " 2";
            tcPhotos.TabPages[2].Text = Localization.PHOTO + " 3";
            tcPhotos.TabPages[3].Text = Localization.PHOTO + " 4";

            treeView.Nodes[0].Text = Localization.COLLECTIONS;
        }

        #endregion Вспомогательные методы



        #region События

        // Загрузка формы
        private void MainForm_Load(object sender, EventArgs e)
        {
            CheckDatabaseConnection();
            UpdateLastFilesMenuItem();
        }


        #region База данных

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

        #endregion База данных

        #region Коллекции

        // Создание коллекции
        private void CreateCollection_Click(object sender, EventArgs e)
        {
            CreateCollection();
        }

        // Переименование коллекции
        private void RenameCollection_Click(object sender, EventArgs e)
        {
            if (treeView.SelectedNode.Parent != null)
                if (treeView.SelectedNode.Parent.Text == Localization.COLLECTIONS)
                    RenameCollection(treeView.SelectedNode.Text);
        }

        // Удаление коллекции
        private void DeleteCollection_Click(object sender, EventArgs e)
        {
            if (treeView.SelectedNode.Parent != null)
                if (treeView.SelectedNode.Parent.Text == Localization.COLLECTIONS)
                    DeleteCollection(treeView.SelectedNode.Text);
        }

        #endregion Коллекции

        #region Предметы

        // Добавление предмета
        private void AddItem_Click(object sender, EventArgs e)
        {
            if (treeView.SelectedNode.Parent != null)
                if (treeView.SelectedNode.Parent.Text == Localization.COLLECTIONS)
                    AddItem((UserCollection)treeView.SelectedNode.Tag);
        }

        // Редактирование предмета
        private void EditItem_Click(object sender, EventArgs e)
        {
            if (treeView.SelectedNode.Parent != null && dgvItems.SelectedCells.Count != 0)
                if (treeView.SelectedNode.Parent.Text == Localization.COLLECTIONS)
                    EditItem((UserCollection)treeView.SelectedNode.Tag, int.Parse(dgvItems.CurrentRow.Tag.ToString()));
        }

        // Удаление предмета
        private void DeleteItem_Click(object sender, EventArgs e)
        {
            if (treeView.SelectedNode.Parent != null && dgvItems.SelectedCells.Count != 0)
                if (treeView.SelectedNode.Parent.Text == Localization.COLLECTIONS)
                    DeleteItem((UserCollection)treeView.SelectedNode.Tag, int.Parse(dgvItems.CurrentRow.Tag.ToString()));
        }

        #endregion Предметы

        // Клик на ячейку DataGridView
        private void dgvItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (treeView.SelectedNode.Text != Localization.COLLECTIONS)
                FormDescriptionOfItem((UserCollection)treeView.SelectedNode.Tag, int.Parse(dgvItems.CurrentRow.Tag.ToString()));
            else
                ClearItemInformation();
        }

        // Выбор нода в TreeView
        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // Обновление колонок в ListView
            if (treeView.SelectedNode.Tag != null)
                UpdateListViewColumns((UserCollection)treeView.SelectedNode.Tag);

            // Обновление ListView для отображения всех предметов из всех коллекций
            if (treeView.SelectedNode.Text == Localization.COLLECTIONS && CurrentDatabase != null)
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
                if (treeView.SelectedNode.Parent.Text == Localization.COLLECTIONS)
                    UpdateDataGridView((UserCollection)treeView.SelectedNode.Tag);
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
            if (treeView.SelectedNode.Text == Localization.COLLECTIONS)
            {
                ForeignTableForm ftf = new ForeignTableForm(this, new UserCollection(null, ""));
                ftf.ShowDialog();
            }

            if (treeView.SelectedNode.Parent != null)
            {
                if (treeView.SelectedNode.Parent.Text == Localization.COLLECTIONS)
                {
                    ForeignTableForm ftf = new ForeignTableForm(this, (UserCollection)treeView.SelectedNode.Tag);
                    ftf.ShowDialog();

                    UpdateDataGridView((UserCollection)treeView.SelectedNode.Tag);
                }
            }
        }

        // Настройки
        private void tsmiSettings_Click(object sender, EventArgs e)
        {
            SettingsForm sf = new SettingsForm();
            sf.ShowDialog();
            UpdateIconsSize();
            InitializeFormText();
        }

        // О программе
        private void tsmiAbout_Click(object sender, EventArgs e)
        {
            AboutForm af = new AboutForm();
            af.ShowDialog();
        }

        // Выход
        private void tsmlExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion События        

        private void tsmiPhotoPanel_Click(object sender, EventArgs e)
        {
            ItemInformation.Panel1Collapsed = !tsmiPhotoPanel.Checked;

            if (!tsmiPhotoPanel.Checked && !tsmiDescriptionPanel.Checked)
                ItemInformation.Visible = false;
            else
                ItemInformation.Visible = true;

            
        }

        private void tsmiDescriptionPanel_Click(object sender, EventArgs e)
        {
            ItemInformation.Panel2Collapsed = !tsmiDescriptionPanel.Checked;

            if (!tsmiPhotoPanel.Checked && !tsmiDescriptionPanel.Checked)
                ItemInformation.Visible = false;
            else
                ItemInformation.Visible = true;
        }

        private void tsmiIconsPanel_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = tsmiIconsPanel.Checked;
        }

        private void tsmiSearchItem_Click(object sender, EventArgs e)
        {
            SearchingForm sf = new SearchingForm(this, (UserCollection)treeView.SelectedNode.Tag);
            sf.ShowDialog();
        }
    }
}
