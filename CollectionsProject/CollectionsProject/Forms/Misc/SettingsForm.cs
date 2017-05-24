using System;
using System.Windows.Forms;

namespace CollectionsProject.Forms
{

    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();

            // Язык
            cbLanguage.DisplayMember = "lang";
            cbLanguage.ValueMember = "file";
            cbLanguage.DataSource = XmlHelper.GetLanguages();
            cbLanguage.SelectedValue = Settings.Language;
            
            // Размер загружаемых в базу фото
            cbPhotosSize.Items.Add("Маленький");
            cbPhotosSize.Items.Add("Средний");
            cbPhotosSize.Items.Add("Большой");

            if (Settings.PhotosSize == 400)
                cbPhotosSize.SelectedIndex = 0;
            else if (Settings.PhotosSize == 500)
                cbPhotosSize.SelectedIndex = 1;
            else if (Settings.PhotosSize == 600)
                cbPhotosSize.SelectedIndex = 2;

            // Размер иконок на главной форме
            cbIconsSize.Items.Add("Маленький");
            cbIconsSize.Items.Add("Средний");
            cbIconsSize.Items.Add("Большой");
            cbIconsSize.SelectedIndex = 0;

            if (Settings.IconsSize == 30)
                cbIconsSize.SelectedIndex = 0;
            else if (Settings.IconsSize == 40)
                cbIconsSize.SelectedIndex = 1;
            else if (Settings.IconsSize == 50)
                cbIconsSize.SelectedIndex = 2;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Settings.Language = cbLanguage.SelectedValue.ToString();

            if (cbPhotosSize.SelectedIndex == 0)
                Settings.PhotosSize = 400;
            else if (cbPhotosSize.SelectedIndex == 1)
                Settings.PhotosSize = 500;
            else if (cbPhotosSize.SelectedIndex == 2)
                Settings.PhotosSize = 600;

            if (cbIconsSize.SelectedIndex == 0)
                Settings.IconsSize = 30;
            else if (cbIconsSize.SelectedIndex == 1)
                Settings.IconsSize = 40;
            else if (cbIconsSize.SelectedIndex == 2)
                Settings.IconsSize = 50;

            XmlHelper.SaveSettings();

            Close();
        }
    }
}
