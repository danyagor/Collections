using System;
using System.Data;
using System.Windows.Forms;

namespace CollectionsProject.Forms
{
    public partial class ForeignTableForm : Form
    {
        MainForm mf;
        int collectionType;
        string collectionName;

        int collectionNumber;

        private int SelectedCollectionId
        {
            get
            {
                if (treeView.SelectedNode.Parent != null)
                    return int.Parse(treeView.SelectedNode.Tag.ToString());

                return 0;
            }
        }

        public ForeignTableForm(MainForm mf, int collectionType, string collectionName = "")
        {
            InitializeComponent();
            this.mf = mf;
            this.collectionType = collectionType;
            this.collectionName = collectionName;

            if (collectionName != "")
                collectionNumber = mf.CurrentDatabase.GetCollectionNumber(collectionName);

            Text = "Редактор справочников";
        }

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

            if (collectionName != "")
                FillItems(int.Parse(treeView.Nodes[0].Tag.ToString()), treeView.Nodes[0].Nodes[0].Tag.ToString());
        }

        private void FillItems(int collectionType, string foreignTable)
        {
            lvItems.Columns.Clear();
            lvItems.Items.Clear();

            lvItems.Columns.Add("№");

            foreach (Field field in CollectionTypes.GetCollection(collectionType)[foreignTable].Fields)
                lvItems.Columns.Add(field.ProgramName).Width = int.Parse(field.Width);

            DataTable dt = mf.CurrentDatabase.GetItemsFromCollection(collectionType, collectionName, foreignTable);
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

        private void ForeignTableForm_Load(object sender, EventArgs e)
        {
            FillTreeView();
        }

        private void treeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            
        }


        private void AddItem_Click(object sender, EventArgs e)
        {
            ItemPropertiesForm ipf = new ItemPropertiesForm(mf, int.Parse(treeView.SelectedNode.Parent.Tag.ToString()), treeView.SelectedNode.Tag.ToString());
            ipf.ShowDialog();

            if (treeView.SelectedNode.Parent != null)
                FillItems(int.Parse(treeView.SelectedNode.Parent.Tag.ToString()), treeView.SelectedNode.Tag.ToString());
        }
        
        private void EditItem_Click(object sender, EventArgs e)
        {
            ItemPropertiesForm ipf = new ItemPropertiesForm(mf, collectionType, collectionName, int.Parse(lvItems.SelectedItems[0].Tag.ToString()), treeView.SelectedNode.Tag.ToString());
            ipf.ShowDialog();

            if (treeView.SelectedNode.Parent != null)
                FillItems(int.Parse(treeView.SelectedNode.Parent.Tag.ToString()), treeView.SelectedNode.Tag.ToString());
        }

        private void DeleteItem_Click(object sender, EventArgs e)
        {
            if (!mf.CurrentDatabase.ItemExists(int.Parse(lvItems.SelectedItems[0].Tag.ToString()), collectionType, treeView.SelectedNode.Tag.ToString()))
            {
                mf.CurrentDatabase.DeleteItem(collectionType, int.Parse(lvItems.SelectedItems[0].Tag.ToString()), collectionName, treeView.SelectedNode.Tag.ToString());
                if (treeView.SelectedNode.Parent != null)
                    FillItems(int.Parse(treeView.SelectedNode.Parent.Tag.ToString()), treeView.SelectedNode.Tag.ToString());
            }
            else
                MessageBox.Show("Данный элемент привязан к одному или нескольким предметам, поэтому произвести операцию удаления невозможно.", "Удаление невозможно");
        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeView.SelectedNode.Parent != null)
                FillItems(int.Parse(treeView.SelectedNode.Parent.Tag.ToString()), treeView.SelectedNode.Tag.ToString());
        }

        private void lvItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvItems.SelectedItems.Count != 0)
            {
                string description = "Описание:\n";
                description += mf.CurrentDatabase.GetNoteFromItem(collectionType, int.Parse(lvItems.SelectedItems[0].Tag.ToString()), collectionName, treeView.SelectedNode.Tag.ToString());
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
    }
}
