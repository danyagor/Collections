using System;
using System.Data;
using System.Windows.Forms;

namespace CollectionsProject.Forms
{
    public partial class ForeignTableForm : Form
    {
        MainForm mf;
        int collectionType;

        // Конструктор
        public ForeignTableForm(MainForm mf, int collectionType)
        {
            InitializeComponent();
            this.mf = mf;
            this.collectionType = collectionType;

            Text = "Редактор справочников";
        }

        #region Свойства

        // Выделенный ID коллекции в TreeView
        private int SelectedCollectionId
        {
            get
            {
                if (treeView.SelectedNode.Parent == null)
                    return int.Parse(treeView.SelectedNode.Tag.ToString());
                else
                    return int.Parse(treeView.SelectedNode.Parent.Tag.ToString());
            }
        }

        // Выделенная внешняя таблица в TreeView
        private string SelectedForeignTable
        {
            get
            {
                if (treeView.SelectedNode.Parent != null)
                    return treeView.SelectedNode.Tag.ToString();
                else
                    return treeView.SelectedNode.Nodes[0].Tag.ToString();
            }
        }

        // Выделенный элемент в ListView
        private int SelectedItemId
        {
            get
            {
                return int.Parse(lvItems.SelectedItems[0].Tag.ToString());
            }
        }

        #endregion Свойства



        #region Методы

        // Заполнние TreeView коллекциями и их внешними таблицами
        private void FillTreeView()
        {
            foreach (Collection collection in CollectionTypes.Collections)
            {
                TreeNode collectionNode = new TreeNode(collection.Name);
                collectionNode.Tag = collection.Id;
                collectionNode.ContextMenuStrip = cmsTvAddItem;

                foreach (Table table in CollectionTypes.GetCollection(collection.Id).ForeignTables)
                {
                    TreeNode tableNode = new TreeNode(table.ProgramName);
                    tableNode.Tag = table.BaseName;
                    tableNode.ContextMenuStrip = cmsTvAddItem;
                    collectionNode.Nodes.Add(tableNode);
                }
                treeView.Nodes.Add(collectionNode);
            }

            treeView.ExpandAll();

            FillItems(int.Parse(treeView.Nodes[0].Tag.ToString()), treeView.Nodes[0].Nodes[0].Tag.ToString());
        }

        // Заполнение предметов в ListView по типу коллекции и имени внешней таблицы
        private void FillItems(int collectionType, string foreignTable)
        {
            lvItems.Columns.Clear();
            lvItems.Items.Clear();

            lvItems.Columns.Add("№");

            foreach (Field field in CollectionTypes.GetCollection(collectionType)[foreignTable].Fields)
                lvItems.Columns.Add(field.ProgramName).Width = int.Parse(field.Width);

            DataTable dt = mf.CurrentDatabase.GetItemsFromCollection(collectionType, "", foreignTable);
            string[] items = new string[dt.Columns.Count];
            foreach (DataRow row in dt.Rows)
            {
                for (int i = 0; i < row.ItemArray.Length; i++)
                    items[i] = row.ItemArray[i].ToString();

                ListViewItem lvi = new ListViewItem(items);
                lvi.Tag = row.ItemArray[0]; // ID
                lvItems.Items.Add(lvi);
            }
        }

        #endregion Методы



        #region События

        // Загрузка формы
        private void ForeignTableForm_Load(object sender, EventArgs e)
        {
            FillTreeView();
        }

        // Клик на нод в TreeView
        private void treeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            
        }

        // Клик на добавление предмета
        private void AddItem_Click(object sender, EventArgs e)
        {
            ItemPropertiesForm ipf = new ItemPropertiesForm(mf, SelectedCollectionId, "", SelectedForeignTable);
            ipf.ShowDialog();

            FillItems(SelectedCollectionId, SelectedForeignTable);
        }

        // Клик на редактирование предмета
        private void EditItem_Click(object sender, EventArgs e)
        {
            ItemPropertiesForm ipf = new ItemPropertiesForm(mf, SelectedCollectionId, "", SelectedItemId, SelectedForeignTable);
            ipf.ShowDialog();

            FillItems(SelectedCollectionId, SelectedForeignTable);
        }

        // Клик на удаление предмета
        private void DeleteItem_Click(object sender, EventArgs e)
        {
            if (!mf.CurrentDatabase.ItemExists(SelectedItemId, SelectedCollectionId, SelectedForeignTable))
            {
                mf.CurrentDatabase.DeleteItem(SelectedCollectionId, SelectedItemId, "", SelectedForeignTable);

                FillItems(SelectedCollectionId, SelectedForeignTable);
            }
            else
                MessageBox.Show("Данный элемент привязан к одному или нескольким предметам, поэтому произвести операцию удаления невозможно.", "Удаление невозможно");
        }

        // Клик на TreeView
        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            FillItems(SelectedCollectionId, SelectedForeignTable);
        }

        // Клик на элемент в ListView
        private void lvItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Получение описания о предмете
            if (lvItems.SelectedItems.Count != 0)
            {
                string description = "Описание:\n";
                description += mf.CurrentDatabase.GetNoteFromItem(SelectedCollectionId, SelectedItemId, "", SelectedForeignTable);
                rtbDescription.Text = description;
            }

            if (lvItems.SelectedItems.Count == 0)
            {
                tsmiEditItem.Enabled = false;
                tsmiDeleteItem.Enabled = false;

                cmsEditItem.Enabled = false;
                cmsDeleteItem.Enabled = false;
            }
            else
            {
                tsmiEditItem.Enabled = true;
                tsmiDeleteItem.Enabled = true;

                cmsEditItem.Enabled = true;
                cmsDeleteItem.Enabled = true;
            }
        }

        #endregion События
    }
}
