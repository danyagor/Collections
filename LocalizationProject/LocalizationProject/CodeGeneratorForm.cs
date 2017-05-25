using System.Windows.Forms;

namespace LocalizationProject
{
    public partial class CodeGeneratorForm : Form
    {
        Category[] categories;

        public CodeGeneratorForm(Category[] categories)
        {
            InitializeComponent();
            this.categories = categories;
        }

        private void CodeGeneratorForm_Load(object sender, System.EventArgs e)
        {
            foreach (Category category in categories)
                foreach (Data str in category.Strings)
                    rtbCode.Text += "public static string " + str.Key + " { get { return GetValue(\"" + str.Key + "\"); } }\n";
        }
    }
}
