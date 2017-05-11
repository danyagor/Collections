using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CollectionsProject.Forms
{
    public partial class CreateDatabaseForm : Form
    {
        MainForm form;
        string dbPath;

        public CreateDatabaseForm(MainForm form)
        {
            InitializeComponent();
            this.form = form;
        }

        private void CreateDatabaseForm_Load(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Файлы коллекций (*.cdb)| *.cdb";
            if (sfd.ShowDialog() == DialogResult.OK)
                dbPath = sfd.FileName;
            else
                Close();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (tbUserName.Text != "" && tbUserEmail.Text != "" && tbPassword.Text == tbRepPassword.Text)
            {
                form.ChangeDatabase(new Database(dbPath, tbUserName.Text, tbUserEmail.Text, tbPassword.Text));
                Close();
            }
            else
                MessageBox.Show("Введены не все данные или пароли не совпадают", "Ошибка");
        }  
    }
}
