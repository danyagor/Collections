using System;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace LocalizationProject
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FillDataGridView();
        }
        
        private void FillDataGridView()
        {
            Data[] data = XmlHelper.GetDataFromFile();
            foreach (Data dat in data)
            {
                dgv.Rows.Add(dat.key, dat.value);
            }
        }
    }
}
