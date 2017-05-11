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
            FillLanguagesComboBox();
        }
        
        private void FillLanguagesComboBox()
        {
            DirectoryInfo dir = new DirectoryInfo("Languages");
            FileInfo[] files = dir.GetFiles("*.xml");

            cbLanguages.Items.Clear();

            for (int i = 0; i < files.Length; i++)
                cbLanguages.Items.Add(files[i].Name);    

            if (cbLanguages.Items.Count != 0)
                cbLanguages.SelectedIndex = 0;
        }

        private void FillStringsListBox()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("Languages\\" + cbLanguages.Text);
            XmlElement xRoot = xDoc.DocumentElement;

            lbStrings.Items.Clear();

            foreach (XmlNode node in xRoot.ChildNodes)
                lbStrings.Items.Add(node.Attributes["name"].Value);
        }

        private void cbLanguages_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillStringsListBox();
        }

        private void lbStrings_SelectedIndexChanged(object sender, EventArgs e)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("Languages\\" + cbLanguages.Text);
            XmlElement xRoot = xDoc.DocumentElement;

            tbName.Text = xRoot.ChildNodes[lbStrings.SelectedIndex].Attributes["name"].Value;
            tbValue.Text = xRoot.ChildNodes[lbStrings.SelectedIndex].Attributes["value"].Value;
        }
    }
}
