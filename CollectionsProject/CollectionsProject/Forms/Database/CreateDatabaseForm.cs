using System;
using System.Windows.Forms;

namespace CollectionsProject.Forms
{
    public partial class CreateDatabaseForm : Form
    {
        MainForm form;
        string dbPath;

        // Конструктор
        public CreateDatabaseForm(MainForm form)
        {
            InitializeComponent();
            this.form = form;
        }

        // Загрузка формы
        private void CreateDatabaseForm_Load(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Файлы коллекций (*.cdb)| *.cdb";
            if (sfd.ShowDialog() == DialogResult.OK)
                dbPath = sfd.FileName;
            else
                Close();
        }

        // Клик на кнопку "Создать"
        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (tbUserName.Text != "" && tbUserEmail.Text != "" && tbPassword.Text == tbRepPassword.Text)
            {
                form.ChangeDatabase(new Database(dbPath, tbUserName.Text, tbUserEmail.Text, tbPassword.Text));
                DialogResult = DialogResult.OK;
                Close();
            }
            else
                MessageBox.Show("Введены не все данные или пароли не совпадают", "Ошибка");
        }

        // Клик на кнопку "Отмена"
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
