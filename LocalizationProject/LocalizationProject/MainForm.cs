using System;
using System.Windows.Forms;

namespace LocalizationProject
{
    public partial class MainForm : Form
    {
        Data[] strings;

        public MainForm()
        {
            InitializeComponent();
            strings = XmlHelper.
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FillCategories();
        }
        
        private void FillDataGridView(string category)
        {
            dgv.Rows.Clear();

            Data[] data = XmlHelper.GetDataFromFile(category);
            foreach (Data dat in data)
            {
                dgv.Rows.Add(dat.key, dat.value);
            }
        }

        private void FillCategories()
        {
            foreach (string category in XmlHelper.GetCategories())
                lbCategories.Items.Add(category);
        }

        private void lbCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbCategories.SelectedIndex != -1)
                FillDataGridView(lbCategories.SelectedItem.ToString());
        }
    }
}
