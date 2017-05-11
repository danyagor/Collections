using System;
using System.Windows.Forms;

namespace CollectionsProject.Forms
{
    public partial class OpenEncryptedDatabaseForm : Form
    {
        MainForm form;
        string path;

        public OpenEncryptedDatabaseForm(MainForm form, string path)
        {
            InitializeComponent();
            this.form = form;
            this.path = path;
            Text = "Открытие базы коллекций \"" + System.IO.Path.GetFileName(path) + "\"";
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Database db = new Database();
            if (db.ConnectToDatabase(path, tbPassword.Text))
            {
                form.ChangeDatabase(db);
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
