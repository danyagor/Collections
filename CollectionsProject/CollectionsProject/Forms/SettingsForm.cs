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
    }
}
