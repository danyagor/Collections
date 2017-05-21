using System;
using System.Windows.Forms;

namespace CollectionsProject.Forms
{
    public partial class RenameCollectionForm : Form
    {
        MainForm mf;
        string collectionName;

        // Конструктор
        public RenameCollectionForm(MainForm mf, string collectionName)
        {
            InitializeComponent();
            this.mf = mf;
            this.collectionName = collectionName;
        }

        // Клик на кнопку "Переименовать"
        private void btnRename_Click(object sender, EventArgs e)
        {
            if (tbNewName.Text != "")
            {
                if (!mf.CurrentDatabase.CollectionExists(tbNewName.Text))
                {
                    mf.CurrentDatabase.RenameCollection(collectionName, tbNewName.Text);
                    mf.RenameCollectionInTreeView(collectionName, tbNewName.Text);
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                    MessageBox.Show("Коллекция с таким именем уже существует");
            }
            else
                MessageBox.Show("Введите новое имя в поле");
        }

        // Клик на кнопку "Отмена"
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
