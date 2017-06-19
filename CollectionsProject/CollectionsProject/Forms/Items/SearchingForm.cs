using System;
using System.Windows.Forms;

namespace CollectionsProject
{
    public partial class SearchingForm : Form
    {
        MainForm mf;
        UserCollection collection;

        public SearchingForm(MainForm mf, UserCollection collection)
        {
            InitializeComponent();
            this.mf = mf;
            this.collection = collection;
            Text = "Поиск предмета в коллекции \"" + collection.Name + "\"";
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (collection != null)
                mf.SearchItems(tbSearchText.Text, collection);
            else
                mf.SearchItems(tbSearchText.Text);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
