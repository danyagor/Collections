namespace CollectionsEditor
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Авторы");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Переплеты");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Книги", new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5});
            this.lbFields = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbProgramName = new System.Windows.Forms.TextBox();
            this.tbBaseName = new System.Windows.Forms.TextBox();
            this.chkbForeignField = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkbNameField = new System.Windows.Forms.CheckBox();
            this.cbForeignTables = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpenCollectionFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSaveCollection = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSaveCollectionAs = new System.Windows.Forms.ToolStripMenuItem();
            this.btnBeginValues = new System.Windows.Forms.Button();
            this.tvData = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.добавитьКоллекциюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbFields
            // 
            this.lbFields.FormattingEnabled = true;
            this.lbFields.Items.AddRange(new object[] {
            "ПОЛЯ"});
            this.lbFields.Location = new System.Drawing.Point(178, 40);
            this.lbFields.Name = "lbFields";
            this.lbFields.Size = new System.Drawing.Size(120, 251);
            this.lbFields.TabIndex = 2;
            this.lbFields.Click += new System.EventHandler(this.lbFields_Click);
            this.lbFields.SelectedIndexChanged += new System.EventHandler(this.lbFields_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(304, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Имя в программе";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(304, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Имя в базе";
            // 
            // tbProgramName
            // 
            this.tbProgramName.Location = new System.Drawing.Point(307, 56);
            this.tbProgramName.Name = "tbProgramName";
            this.tbProgramName.Size = new System.Drawing.Size(257, 20);
            this.tbProgramName.TabIndex = 17;
            this.tbProgramName.Leave += new System.EventHandler(this.FieldEditEnd_Leave);
            // 
            // tbBaseName
            // 
            this.tbBaseName.Location = new System.Drawing.Point(307, 95);
            this.tbBaseName.Name = "tbBaseName";
            this.tbBaseName.Size = new System.Drawing.Size(257, 20);
            this.tbBaseName.TabIndex = 18;
            this.tbBaseName.Leave += new System.EventHandler(this.FieldEditEnd_Leave);
            // 
            // chkbForeignField
            // 
            this.chkbForeignField.AutoSize = true;
            this.chkbForeignField.Location = new System.Drawing.Point(307, 121);
            this.chkbForeignField.Name = "chkbForeignField";
            this.chkbForeignField.Size = new System.Drawing.Size(98, 17);
            this.chkbForeignField.TabIndex = 23;
            this.chkbForeignField.Text = "Внешнее поле";
            this.chkbForeignField.UseVisualStyleBackColor = true;
            this.chkbForeignField.Leave += new System.EventHandler(this.FieldEditEnd_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(304, 141);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(158, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Имя внешней таблицы в базе";
            // 
            // chkbNameField
            // 
            this.chkbNameField.AutoSize = true;
            this.chkbNameField.Location = new System.Drawing.Point(307, 185);
            this.chkbNameField.Name = "chkbNameField";
            this.chkbNameField.Size = new System.Drawing.Size(99, 17);
            this.chkbNameField.TabIndex = 22;
            this.chkbNameField.Text = "Именное поле";
            this.chkbNameField.UseVisualStyleBackColor = true;
            this.chkbNameField.Leave += new System.EventHandler(this.FieldEditEnd_Leave);
            // 
            // cbForeignTables
            // 
            this.cbForeignTables.FormattingEnabled = true;
            this.cbForeignTables.ItemHeight = 13;
            this.cbForeignTables.Location = new System.Drawing.Point(307, 158);
            this.cbForeignTables.Name = "cbForeignTables";
            this.cbForeignTables.Size = new System.Drawing.Size(257, 21);
            this.cbForeignTables.TabIndex = 24;
            this.cbForeignTables.Leave += new System.EventHandler(this.FieldEditEnd_Leave);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFile});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1175, 24);
            this.menuStrip1.TabIndex = 32;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmiFile
            // 
            this.tsmiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiOpenCollectionFile,
            this.tsmiSaveCollection,
            this.tsmiSaveCollectionAs});
            this.tsmiFile.Name = "tsmiFile";
            this.tsmiFile.Size = new System.Drawing.Size(48, 20);
            this.tsmiFile.Text = "Файл";
            // 
            // tsmiOpenCollectionFile
            // 
            this.tsmiOpenCollectionFile.Name = "tsmiOpenCollectionFile";
            this.tsmiOpenCollectionFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.tsmiOpenCollectionFile.Size = new System.Drawing.Size(259, 22);
            this.tsmiOpenCollectionFile.Text = "Открыть файл коллекций";
            this.tsmiOpenCollectionFile.Click += new System.EventHandler(this.tsmiOpenCollectionFile_Click);
            // 
            // tsmiSaveCollection
            // 
            this.tsmiSaveCollection.Name = "tsmiSaveCollection";
            this.tsmiSaveCollection.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.tsmiSaveCollection.Size = new System.Drawing.Size(259, 22);
            this.tsmiSaveCollection.Text = "Сохранить коллекции";
            this.tsmiSaveCollection.Click += new System.EventHandler(this.tsmiSaveCollection_Click);
            // 
            // tsmiSaveCollectionAs
            // 
            this.tsmiSaveCollectionAs.Name = "tsmiSaveCollectionAs";
            this.tsmiSaveCollectionAs.Size = new System.Drawing.Size(259, 22);
            this.tsmiSaveCollectionAs.Text = "Сохранить коллекции как...";
            this.tsmiSaveCollectionAs.Click += new System.EventHandler(this.tsmiSaveCollectionAs_Click);
            // 
            // btnBeginValues
            // 
            this.btnBeginValues.Location = new System.Drawing.Point(122, 352);
            this.btnBeginValues.Name = "btnBeginValues";
            this.btnBeginValues.Size = new System.Drawing.Size(257, 23);
            this.btnBeginValues.TabIndex = 33;
            this.btnBeginValues.Text = "Начальные значения таблицы";
            this.btnBeginValues.UseVisualStyleBackColor = true;
            // 
            // tvData
            // 
            this.tvData.Location = new System.Drawing.Point(12, 40);
            this.tvData.Name = "tvData";
            treeNode4.BackColor = System.Drawing.Color.Silver;
            treeNode4.Name = "Узел3";
            treeNode4.Text = "Авторы";
            treeNode5.Name = "Узел4";
            treeNode5.Text = "Переплеты";
            treeNode6.Name = "Узел0";
            treeNode6.Text = "Книги";
            this.tvData.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode6});
            this.tvData.Size = new System.Drawing.Size(160, 251);
            this.tvData.TabIndex = 34;
            this.tvData.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvData_AfterSelect);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьКоллекциюToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(193, 26);
            // 
            // добавитьКоллекциюToolStripMenuItem
            // 
            this.добавитьКоллекциюToolStripMenuItem.Name = "добавитьКоллекциюToolStripMenuItem";
            this.добавитьКоллекциюToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.добавитьКоллекциюToolStripMenuItem.Text = "Добавить коллекцию";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1175, 594);
            this.Controls.Add(this.tvData);
            this.Controls.Add(this.btnBeginValues);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.cbForeignTables);
            this.Controls.Add(this.chkbNameField);
            this.Controls.Add(this.lbFields);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.chkbForeignField);
            this.Controls.Add(this.tbBaseName);
            this.Controls.Add(this.tbProgramName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Редактор коллекций";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox lbFields;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkbForeignField;
        private System.Windows.Forms.TextBox tbBaseName;
        private System.Windows.Forms.TextBox tbProgramName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkbNameField;
        private System.Windows.Forms.ComboBox cbForeignTables;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenCollectionFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaveCollection;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaveCollectionAs;
        private System.Windows.Forms.Button btnBeginValues;
        private System.Windows.Forms.TreeView tvData;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem добавитьКоллекциюToolStripMenuItem;
    }
}

