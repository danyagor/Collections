using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
