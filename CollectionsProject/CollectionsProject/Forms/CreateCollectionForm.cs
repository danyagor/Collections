using System;
using System.Windows.Forms;

namespace CollectionsProject.Forms
{
    public partial class CreateCollectionForm : Form
    {
        MainForm mf;

        public CreateCollectionForm(MainForm mainForm)
        {
            InitializeComponent();
            mf = mainForm;
        }

        private void CreateCollectionForm_Load(object sender, EventArgs e)
        {
            // Добавление известных типов коллекций в ComboBox
            cbCollectionType.Items.Clear();
            foreach (Collection collection in CollectionTypes.Collections)
                cbCollectionType.Items.Add(collection.Name);

            cbCollectionType.SelectedIndex = 0;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (!mf.CurrentDatabase.CollectionExists(tbName.Text))
            {
                mf.CurrentDatabase.CreateCollection(tbName.Text, cbCollectionType.SelectedIndex + 1);
                mf.AddCollectionInTreeView(tbName.Text, cbCollectionType.SelectedIndex + 1);
                Close();
            }
            else
                MessageBox.Show("Коллекция с таким именем уже есть.");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
