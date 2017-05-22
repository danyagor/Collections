﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CollectionsEditor
{
    public partial class MainForm : Form
    {
        List<Collection> collections;
        public List<Collection> Collections { get { return collections; } }

        private string filePath;

        private Collection SelectedCollection
        {
            get
            {
                if (lbCollections.SelectedIndex != -1)
                    return collections[lbCollections.SelectedIndex];

                return null;
            }
        }
        private Table SelectedTable
        {
            get
            {
                if (lbCollections.SelectedIndex != -1 && lbTables.SelectedIndex != -1)
                {
                    if (lbTables.SelectedIndex == 0)
                        return collections[lbCollections.SelectedIndex].MainTable;
                    else
                        return collections[lbCollections.SelectedIndex][lbCollections.SelectedIndex + 1];
                }

                return null;
            }
        }
        private Field SelectedField
        {
            get
            {
                if (lbCollections.SelectedIndex != -1 && lbTables.SelectedIndex != -1 && lbFields.SelectedIndex != -1)
                {
                    if (lbTables.SelectedIndex == 0)
                        return collections[lbCollections.SelectedIndex].MainTable[lbFields.SelectedIndex];
                    else
                        return collections[lbCollections.SelectedIndex][lbCollections.SelectedIndex + 1][lbFields.SelectedIndex];
                }
  
                return null;
            }
        }

        public MainForm()
        {
            InitializeComponent();
            OpenCollectionFile();
        }

        #region Заполнение данных

        private void FillTreeView()
        {
            foreach (var item in collection)
            {

            }
        }


        // Заполняет ListBox коллекций
        private void FillCollections()
        {
            lbCollections.Items.Clear();
            lbTables.Items.Clear();
            lbFields.Items.Clear();

            foreach (Collection collection in collections)
                lbCollections.Items.Add(collection.Name);

            if (lbCollections.Items.Count != 0)
                lbCollections.SelectedIndex = 0;
        }

        // Заполняет ListBox таблиц
        private void FillTables()
        {
            lbTables.Items.Clear();
            lbFields.Items.Clear();

            lbTables.Items.Add(SelectedCollection.MainTable.ProgramName);

            foreach (Table table in SelectedCollection.ForeignTables)
                lbTables.Items.Add(table.ProgramName);

            if (lbTables.Items.Count != 0)
                lbTables.SelectedIndex = 0;
        }

        // Заполняет ListBox полей
        private void FillFields()
        {
            lbFields.Items.Clear();

            foreach (Field field in SelectedTable.Fields)
                lbFields.Items.Add(field.ProgramName);

            if (SelectedTable.Foreign)
            {
                chkbNameField.Enabled = true;
                chkbForeignField.Enabled = false;
                cbForeignTables.Text = "";
                cbForeignTables.Enabled = false;
            }
            else
            {
                chkbNameField.Checked = false;
                chkbNameField.Enabled = false;
                chkbForeignField.Enabled = true;
                cbForeignTables.Enabled = true;
            }

            if (lbFields.Items.Count > 0)
            {
                lbFields.SelectedIndex = 0;
                FillFieldInfo();
            }
        }

        // Заполняет информацию о выделенном поле
        private void FillFieldInfo()
        {
            tbProgramName.Text = SelectedField.ProgramName;
            tbBaseName.Text = SelectedField.BaseName;
            chkbForeignField.Checked = SelectedField.ForeignKey;
            chkbNameField.Checked = SelectedField.NameField;
            cbForeignTables.Text = SelectedField.ForeignTable;
        }

        // Заполнение внешних таблиц
        private void FillForeignTables()
        {
            cbForeignTables.Items.Clear();

            foreach (Table table in SelectedCollection.ForeignTables)
                cbForeignTables.Items.Add(table.BaseName);
        }

        // Очищение информации о поле
        private void ClearFieldInfo()
        {
            tbProgramName.Text = "";
            tbBaseName.Text = "";
            chkbForeignField.Checked = false;
            chkbNameField.Checked = false;
            cbForeignTables.Text = "";
        }

        #endregion Заполнение данных



        #region Коллекции

        private void AddCollection()
        {
            EditCollection ef = new EditCollection(this);
            if (ef.ShowDialog() == DialogResult.OK)
            {
                FillCollections();
                lbCollections.SelectedIndex = lbCollections.Items.Count - 1;
            }
        }
        private void RenameCollection()
        {
            EditCollection ef = new EditCollection(this, lbCollections.SelectedIndex);
            ef.ShowDialog();

            FillCollections();
        }
        private void RemoveCollection()
        {
            collections.RemoveAt(lbCollections.SelectedIndex);

            FillCollections();
        }

        #endregion Коллекции



        #region Таблицы

        private void AddTable()
        {
            EditTable et = new EditTable(this, lbCollections.SelectedIndex, lbTables.SelectedIndex);
            if (et.ShowDialog() == DialogResult.OK)
            {
                FillTables();
                lbTables.SelectedIndex = lbTables.Items.Count - 1;
                ClearFieldInfo();
            }
        }
        private void RenameTable()
        {
            EditTable et = new EditTable(this, lbCollections.SelectedIndex, lbTables.SelectedIndex, true);
            et.ShowDialog();

            FillTables();
        }
        private void RemoveTable()
        {
            if (lbTables.SelectedIndex != 0)
            {
                SelectedCollection.ForeignTables.RemoveAt(lbTables.SelectedIndex);
                FillTables();
            }
            else
                MessageBox.Show("Главную таблицу нельзя удалить.");
        }

        #endregion Таблицы



        #region Поля

        private void AddField()
        {
            SelectedTable.Fields.Add(new Field("Название", "name", false, ""));

            FillFields();
            lbFields.SelectedIndex = lbFields.Items.Count - 1;
            FillFieldInfo();
        }
        private void RemoveField()
        {
            SelectedTable.Fields.RemoveAt(lbFields.SelectedIndex);

            FillFields();
        }

        private void UpdateField()
        {
            if (SelectedField != null)
            {
                SelectedField.ProgramName = tbProgramName.Text;
                SelectedField.BaseName = tbBaseName.Text;
                SelectedField.ForeignKey = chkbForeignField.Checked;
                SelectedField.ForeignTable = cbForeignTables.Text;
                SelectedField.NameField = chkbNameField.Checked;

                lbFields.Items[lbFields.SelectedIndex] = SelectedField.ProgramName;
            }
        }

        private void UpField()
        {
            Field tempField = SelectedField;
            SelectedTable.Fields[lbFields.SelectedIndex] = SelectedTable.Fields[lbFields.SelectedIndex - 1];
            SelectedTable.Fields[lbFields.SelectedIndex - 1] = tempField;

            int selectedIndex = lbFields.SelectedIndex;
            FillFields();
            lbFields.SelectedIndex = selectedIndex - 1;
            FillFieldInfo();
        }

        private void DownField()
        {
            Field tempField = SelectedField;
            SelectedTable.Fields[lbFields.SelectedIndex] = SelectedTable.Fields[lbFields.SelectedIndex + 1];
            SelectedTable.Fields[lbFields.SelectedIndex + 1] = tempField;

            int selectedIndex = lbFields.SelectedIndex;
            FillFields();
            lbFields.SelectedIndex = selectedIndex + 1;

            FillFieldInfo();
        }

        #endregion Поля



        #region Вспомогательные методы

        private void OpenCollectionFile()
        {
            //OpenFileDialog ofd = new OpenFileDialog();
            //ofd.Filter = "Файлы коллекций | *.xml";
            //ofd.FileName = "collections.xml";
            //if (ofd.ShowDialog() == DialogResult.OK)
            //{
                collections = XmlHelper.GetAllCollections();
                //filePath = ofd.FileName;
                FillCollections();
            //}
        }

        private void SaveCollection()
        {
            XmlHelper.SaveCollectionFile(collections.ToArray(), filePath);
        }

        private void SaveCollectionAs()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Файлы коллекций | *.xml";
            sfd.FileName = "collections.xml";
            if (sfd.ShowDialog() == DialogResult.OK)
                XmlHelper.SaveCollectionFile(collections.ToArray(), sfd.FileName);
        }

        #endregion Вспомогательные методы



        #region События

        private void MainForm_Load(object sender, EventArgs e)
        {
        }


        /************************************************************************************/
        private void lbCollections_Click(object sender, EventArgs e)
        {
            FillTables();
            FillForeignTables();
            ClearFieldInfo();
        }

        private void lbTables_Click(object sender, EventArgs e)
        {
            ClearFieldInfo();
            FillFields();
            FillForeignTables();
        }

        private void lbFields_Click(object sender, EventArgs e)
        {
            FillFieldInfo();
        }
        /************************************************************************************/


        /************************************************************************************/
        private void btnAddCollection_Click(object sender, EventArgs e)
        {
            AddCollection();
        }

        private void btnCollectionRename_Click(object sender, EventArgs e)
        {
            RenameCollection();
        }

        private void btnDeleteCollection_Click(object sender, EventArgs e)
        {
            RemoveCollection();
        }
        /************************************************************************************/


        /************************************************************************************/
        private void btnAddTable_Click(object sender, EventArgs e)
        {
            AddTable();
        }

        private void btnTableRename_Click(object sender, EventArgs e)
        {
            RenameTable();
        }

        private void btnDeleteTable_Click(object sender, EventArgs e)
        {
            RemoveTable();
        }
        /************************************************************************************/


        /************************************************************************************/
        private void btnAddField_Click(object sender, EventArgs e)
        {
            AddField();
        }

        private void btnDeleteField_Click(object sender, EventArgs e)
        {
            RemoveField();
        }
        /************************************************************************************/


        private void tsmiOpenCollectionFile_Click(object sender, EventArgs e)
        {
            OpenCollectionFile();
        }

        private void tsmiSaveCollection_Click(object sender, EventArgs e)
        {
            SaveCollection();
        }

        private void tsmiSaveCollectionAs_Click(object sender, EventArgs e)
        {
            SaveCollectionAs();
        }

        private void FieldEditEnd_Leave(object sender, EventArgs e)
        {
            UpdateField();
        }

        private void btnFieldUp_Click(object sender, EventArgs e)
        {
            UpField();
        }

        private void btnFieldDown_Click(object sender, EventArgs e)
        {
            DownField();
        }

        private void lbFields_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbFields.SelectedIndex == 0)
                btnFieldUp.Enabled = false;
            else
                if (!btnFieldUp.Enabled)
                btnFieldUp.Enabled = true;

            if (lbFields.SelectedIndex == lbFields.Items.Count - 1)
                btnFieldDown.Enabled = false;
            else
                if (!btnFieldDown.Enabled)
                btnFieldDown.Enabled = true;
        }

        #endregion События 
    }
}
