using System;
using System.Windows.Forms;

namespace CollectionsProject.Forms
{
    public partial class CreateCollectionForm : Form
    {
        MainForm mf;

        // Конструктор
        public CreateCollectionForm(MainForm mainForm)
        {
            InitializeComponent();
            mf = mainForm;
        }

        // Загрузка формы
        private void CreateCollectionForm_Load(object sender, EventArgs e)
        {
            // Добавление известных типов коллекций в ComboBox
            cbCollectionType.Items.Clear();
            foreach (Collection collection in CollectionTypes.Collections)
                cbCollectionType.Items.Add(collection.Name);

            cbCollectionType.SelectedIndex = 0;
        }

        // Клик на "Создать"
        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (!mf.CurrentDatabase.CollectionExists(tbName.Text))
            {
                mf.CurrentDatabase.CreateCollection(tbName.Text, cbCollectionType.SelectedIndex + 1);
                mf.AddCollectionInTreeView(new UserCollection(CollectionTypes.GetCollection(cbCollectionType.SelectedIndex + 1), tbName.Text));
                DialogResult = DialogResult.OK;
                Close();
            }
            else
                MessageBox.Show("Коллекция с таким именем уже есть.");
        }

        // Клик на "Отмена"
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
