using System;
using System.Windows.Forms;

namespace CollectionsProject.Forms
{
    public partial class RenameCollectionForm : Form
    {
        MainForm mf;
        string collectionName;

        public RenameCollectionForm(MainForm mf, string collectionName)
        {
            InitializeComponent();
            this.mf = mf;
            this.collectionName = collectionName;
        }

        private void btnRename_Click(object sender, EventArgs e)
        {
            if (tbNewName.Text != "")
            {
                if (!mf.CurrentDatabase.CollectionExists(tbNewName.Text))
                {
                    mf.CurrentDatabase.RenameCollection(collectionName, tbNewName.Text);
                    mf.RenameCollectionInTreeView(collectionName, tbNewName.Text);
                    Close();
                }
                else
                    MessageBox.Show("Коллекция с таким именем уже существует");
            }
            else
                MessageBox.Show("Введите новое имя в поле");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
