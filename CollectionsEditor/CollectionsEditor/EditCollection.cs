using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CollectionsEditor
{
    public partial class EditCollection : Form
    {
        MainForm mf;
        int collectionId;

        public EditCollection(MainForm mf)
        {
            InitializeComponent();
            this.mf = mf;
            collectionId = -1;

            Text = "Добавление коллекции";
        }

        public EditCollection(MainForm mf, int collectionId)
        {
            InitializeComponent();
            this.mf = mf;
            this.collectionId = collectionId;

            tbName.Text = mf.Collections[collectionId].Name;

            Text = "Переименование коллекции";
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //if (collectionId == -1)
            //    mf.Collections.Add(new Collection(tbName.Text, new List<Table>()));
            //else
            //    mf.Collections[collectionId].Name = tbName.Text;

            //DialogResult = DialogResult.OK;
            //Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
