using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocalizationProject
{
    public partial class MainForm : Form
    {
        List<Category> categories;

        public MainForm()
        {
            InitializeComponent();
            categories = XmlHelper.GetCategoriesFromFile("english.xml");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FillCategories();
        }
        
        private void FillDataGridView(string categoryName)
        {
            dgv.Rows.Clear();

            foreach (Category category in categories)
                if (category.Name == categoryName)
                {
                    foreach (Data str in category.Strings)
                        dgv.Rows.Add(str.Key, str.Value);

                    break;
                }
        }

        private void FillCategories()
        {
            foreach (Category category in categories)
                lbCategories.Items.Add(category.Name);
        }

        private void lbCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbCategories.SelectedIndex != -1)
                FillDataGridView(lbCategories.SelectedItem.ToString());
        }

        private void dgv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                categories[lbCategories.SelectedIndex].Strings[e.RowIndex].Key = dgv[e.ColumnIndex, e.RowIndex].Value.ToString();
            }
            else if (e.ColumnIndex == 1)
            {
                categories[lbCategories.SelectedIndex].Strings[e.RowIndex].Value = dgv[e.ColumnIndex, e.RowIndex].Value.ToString();
            }
        }

        private void tsmiGenerateCode_Click(object sender, EventArgs e)
        {
            CodeGeneratorForm cgf = new CodeGeneratorForm(categories.ToArray());
            cgf.ShowDialog();
        }
    }
}
