using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CollectionsEditor
{
    public partial class EditTable : Form
    {
        MainForm mf;
        int collectionId;
        int tableId;
        bool rename;

        public EditTable(MainForm mf, int collectionId, int tableId)
        {
            InitializeComponent();
            this.mf = mf;
            this.collectionId = collectionId;
            this.tableId = tableId;

            Text = "Добавление таблицы";
        }

        public EditTable(MainForm mf, int collectionId, int tableId, bool rename)
        {
            InitializeComponent();
            this.mf = mf;
            this.collectionId = collectionId;
            this.tableId = tableId;
            this.rename = rename;

            tbProgramName.Text = mf.Collections[collectionId].Tables[tableId].ProgramName;
            tbBaseName.Text = mf.Collections[collectionId].Tables[tableId].BaseName;

            Text = "Переименование таблицы";
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!rename)
            {
                bool foreign = true;
                if (tableId == -1)
                    foreign = false;

                mf.Collections[collectionId].Tables.Add(new Table(tbProgramName.Text, tbBaseName.Text, foreign, new List<Field>()));
            }
            else
            {
                foreach (Field field in mf.Collections[collectionId].Tables[0].Fields)
                    if (field.ForeignTable == mf.Collections[collectionId].Tables[tableId].ProgramName)
                        field.ForeignTable = tbProgramName.Text;

                mf.Collections[collectionId].Tables[tableId].ProgramName = tbProgramName.Text;
                mf.Collections[collectionId].Tables[tableId].BaseName = tbBaseName.Text;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
