using System;
using System.Linq;
using System.Windows.Forms;

namespace CollectionsProject.CustomComponents
{
    public partial class TextField : UserControl
    {
        TextBox tb;
        ComboBox cb;
        bool id;
        string baseName;

        public TextField()
        {
            InitializeComponent();
        }

        public TextField(string text, string baseName, bool id)
        {
            InitializeComponent();
            labelName.Text = text;
            this.baseName = baseName;
            this.id = id;

            if (id)
            {
                cb = new ComboBox();
                cb.Dock = DockStyle.Bottom;
                Controls.Add(cb);
            }
            else
            {
                tb = new TextBox();
                tb.Dock = DockStyle.Bottom;
                Controls.Add(tb);
            }
        }

        public string Value
        {
            get
            {
                if (id)
                    return cb.Text;
                else
                    return tb.Text;
            }

            set
            {
                if (id)
                    cb.Text = value;
                else
                    tb.Text = value;
            }
        }

        public string[] Items
        {
            get
            {
                if (id)
                    return cb.Items.Cast<string>().ToArray();
                else
                    return null;
            }
            set
            {
                if (id)
                {
                    cb.Items.Clear();
                    cb.Items.AddRange(value);
                }
            }
        }

        public bool Identificated { get { return id; } }

        public string BaseName { get { return baseName; } }

        public TextBox TB { get { return tb; } }

        public ComboBox CB { get { return cb; } }

        public string LabelText { get { return labelName.Text; } }
    }
}
