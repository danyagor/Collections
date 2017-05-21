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

    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();

            cbPhotosSize.Items.Add("Маленький");
            cbPhotosSize.Items.Add("Средний");
            cbPhotosSize.Items.Add("Большой");
            cbPhotosSize.SelectedIndex = 0;

            cbIconsSize.Items.Add("Маленький");
            cbIconsSize.Items.Add("Средний");
            cbIconsSize.Items.Add("Большой");
            cbIconsSize.SelectedIndex = 0;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (cbPhotosSize.SelectedIndex == 0)
                Settings.PhotosSize = 200;
            else if (cbPhotosSize.SelectedIndex == 1)
                Settings.PhotosSize = 400;
            else if (cbPhotosSize.SelectedIndex == 2)
                Settings.PhotosSize = 600;

            if (cbIconsSize.SelectedIndex == 0)
                Settings.IconsSize = 30;
            else if (cbIconsSize.SelectedIndex == 1)
                Settings.IconsSize = 40;
            else if (cbIconsSize.SelectedIndex == 2)
                Settings.IconsSize = 50;
        }
    }
}
