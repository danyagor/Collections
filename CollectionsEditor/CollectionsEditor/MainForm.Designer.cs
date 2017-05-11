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
            this.lbCollections = new System.Windows.Forms.ListBox();
            this.lbFields = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbProgramName = new System.Windows.Forms.TextBox();
            this.tbBaseName = new System.Windows.Forms.TextBox();
            this.tbWidth = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chkbRequiredField = new System.Windows.Forms.CheckBox();
            this.chkbForeignField = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.lbTables = new System.Windows.Forms.ListBox();
            this.chkbNameField = new System.Windows.Forms.CheckBox();
            this.btnAddCollection = new System.Windows.Forms.Button();
            this.btnDeleteCollection = new System.Windows.Forms.Button();
            this.btnAddTable = new System.Windows.Forms.Button();
            this.btnDeleteTable = new System.Windows.Forms.Button();
            this.btnAddField = new System.Windows.Forms.Button();
            this.btnDeleteField = new System.Windows.Forms.Button();
            this.btnFieldDown = new System.Windows.Forms.Button();
            this.btnFieldUp = new System.Windows.Forms.Button();
            this.cbForeignTables = new System.Windows.Forms.ComboBox();
            this.btnCollectionRename = new System.Windows.Forms.Button();
            this.btnTableRename = new System.Windows.Forms.Button();
            this.tbTypeLimit = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpenCollectionFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSaveCollection = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSaveCollectionAs = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbCollections
            // 
            this.lbCollections.FormattingEnabled = true;
            this.lbCollections.Items.AddRange(new object[] {
            "КОЛЛЕКЦИИ"});
            this.lbCollections.Location = new System.Drawing.Point(15, 40);
            this.lbCollections.Name = "lbCollections";
            this.lbCollections.Size = new System.Drawing.Size(120, 251);
            this.lbCollections.TabIndex = 0;
            this.lbCollections.Click += new System.EventHandler(this.lbCollections_Click);
            // 
            // lbFields
            // 
            this.lbFields.FormattingEnabled = true;
            this.lbFields.Items.AddRange(new object[] {
            "ПОЛЯ"});
            this.lbFields.Location = new System.Drawing.Point(267, 40);
            this.lbFields.Name = "lbFields";
            this.lbFields.Size = new System.Drawing.Size(120, 251);
            this.lbFields.TabIndex = 2;
            this.lbFields.Click += new System.EventHandler(this.lbFields_Click);
            this.lbFields.SelectedIndexChanged += new System.EventHandler(this.lbFields_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(394, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Имя в программе";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(394, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Имя в базе";
            // 
            // tbProgramName
            // 
            this.tbProgramName.Location = new System.Drawing.Point(397, 40);
            this.tbProgramName.Name = "tbProgramName";
            this.tbProgramName.Size = new System.Drawing.Size(257, 20);
            this.tbProgramName.TabIndex = 17;
            this.tbProgramName.Leave += new System.EventHandler(this.FieldEditEnd_Leave);
            // 
            // tbBaseName
            // 
            this.tbBaseName.Location = new System.Drawing.Point(397, 79);
            this.tbBaseName.Name = "tbBaseName";
            this.tbBaseName.Size = new System.Drawing.Size(257, 20);
            this.tbBaseName.TabIndex = 18;
            this.tbBaseName.Leave += new System.EventHandler(this.FieldEditEnd_Leave);
            // 
            // tbWidth
            // 
            this.tbWidth.Location = new System.Drawing.Point(397, 159);
            this.tbWidth.Name = "tbWidth";
            this.tbWidth.Size = new System.Drawing.Size(257, 20);
            this.tbWidth.TabIndex = 20;
            this.tbWidth.Leave += new System.EventHandler(this.FieldEditEnd_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(394, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Тип данных";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(394, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Ширина поля в программе";
            // 
            // chkbRequiredField
            // 
            this.chkbRequiredField.AutoSize = true;
            this.chkbRequiredField.Location = new System.Drawing.Point(397, 185);
            this.chkbRequiredField.Name = "chkbRequiredField";
            this.chkbRequiredField.Size = new System.Drawing.Size(126, 17);
            this.chkbRequiredField.TabIndex = 21;
            this.chkbRequiredField.Text = "Обязательное поле";
            this.chkbRequiredField.UseVisualStyleBackColor = true;
            this.chkbRequiredField.Leave += new System.EventHandler(this.FieldEditEnd_Leave);
            // 
            // chkbForeignField
            // 
            this.chkbForeignField.AutoSize = true;
            this.chkbForeignField.Location = new System.Drawing.Point(397, 208);
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
            this.label5.Location = new System.Drawing.Point(394, 228);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(158, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Имя внешней таблицы в базе";
            // 
            // cbType
            // 
            this.cbType.FormattingEnabled = true;
            this.cbType.Location = new System.Drawing.Point(397, 119);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(126, 21);
            this.cbType.TabIndex = 19;
            this.cbType.Leave += new System.EventHandler(this.FieldEditEnd_Leave);
            // 
            // lbTables
            // 
            this.lbTables.FormattingEnabled = true;
            this.lbTables.Items.AddRange(new object[] {
            "ТАБЛИЦЫ"});
            this.lbTables.Location = new System.Drawing.Point(141, 40);
            this.lbTables.Name = "lbTables";
            this.lbTables.Size = new System.Drawing.Size(120, 251);
            this.lbTables.TabIndex = 1;
            this.lbTables.Click += new System.EventHandler(this.lbTables_Click);
            // 
            // chkbNameField
            // 
            this.chkbNameField.AutoSize = true;
            this.chkbNameField.Location = new System.Drawing.Point(397, 272);
            this.chkbNameField.Name = "chkbNameField";
            this.chkbNameField.Size = new System.Drawing.Size(99, 17);
            this.chkbNameField.TabIndex = 22;
            this.chkbNameField.Text = "Именное поле";
            this.chkbNameField.UseVisualStyleBackColor = true;
            this.chkbNameField.Leave += new System.EventHandler(this.FieldEditEnd_Leave);
            // 
            // btnAddCollection
            // 
            this.btnAddCollection.Location = new System.Drawing.Point(16, 297);
            this.btnAddCollection.Name = "btnAddCollection";
            this.btnAddCollection.Size = new System.Drawing.Size(120, 23);
            this.btnAddCollection.TabIndex = 3;
            this.btnAddCollection.Text = "Добавить";
            this.btnAddCollection.UseVisualStyleBackColor = true;
            this.btnAddCollection.Click += new System.EventHandler(this.btnAddCollection_Click);
            // 
            // btnDeleteCollection
            // 
            this.btnDeleteCollection.Location = new System.Drawing.Point(16, 355);
            this.btnDeleteCollection.Name = "btnDeleteCollection";
            this.btnDeleteCollection.Size = new System.Drawing.Size(120, 23);
            this.btnDeleteCollection.TabIndex = 5;
            this.btnDeleteCollection.Text = "Удалить";
            this.btnDeleteCollection.UseVisualStyleBackColor = true;
            this.btnDeleteCollection.Click += new System.EventHandler(this.btnDeleteCollection_Click);
            // 
            // btnAddTable
            // 
            this.btnAddTable.Location = new System.Drawing.Point(142, 297);
            this.btnAddTable.Name = "btnAddTable";
            this.btnAddTable.Size = new System.Drawing.Size(120, 23);
            this.btnAddTable.TabIndex = 8;
            this.btnAddTable.Text = "Добавить";
            this.btnAddTable.UseVisualStyleBackColor = true;
            this.btnAddTable.Click += new System.EventHandler(this.btnAddTable_Click);
            // 
            // btnDeleteTable
            // 
            this.btnDeleteTable.Location = new System.Drawing.Point(142, 355);
            this.btnDeleteTable.Name = "btnDeleteTable";
            this.btnDeleteTable.Size = new System.Drawing.Size(120, 23);
            this.btnDeleteTable.TabIndex = 10;
            this.btnDeleteTable.Text = "Удалить";
            this.btnDeleteTable.UseVisualStyleBackColor = true;
            this.btnDeleteTable.Click += new System.EventHandler(this.btnDeleteTable_Click);
            // 
            // btnAddField
            // 
            this.btnAddField.Location = new System.Drawing.Point(268, 297);
            this.btnAddField.Name = "btnAddField";
            this.btnAddField.Size = new System.Drawing.Size(120, 23);
            this.btnAddField.TabIndex = 13;
            this.btnAddField.Text = "Добавить";
            this.btnAddField.UseVisualStyleBackColor = true;
            this.btnAddField.Click += new System.EventHandler(this.btnAddField_Click);
            // 
            // btnDeleteField
            // 
            this.btnDeleteField.Location = new System.Drawing.Point(268, 326);
            this.btnDeleteField.Name = "btnDeleteField";
            this.btnDeleteField.Size = new System.Drawing.Size(120, 23);
            this.btnDeleteField.TabIndex = 14;
            this.btnDeleteField.Text = "Удалить";
            this.btnDeleteField.UseVisualStyleBackColor = true;
            this.btnDeleteField.Click += new System.EventHandler(this.btnDeleteField_Click);
            // 
            // btnFieldDown
            // 
            this.btnFieldDown.Location = new System.Drawing.Point(268, 384);
            this.btnFieldDown.Name = "btnFieldDown";
            this.btnFieldDown.Size = new System.Drawing.Size(120, 23);
            this.btnFieldDown.TabIndex = 16;
            this.btnFieldDown.Text = "Вниз";
            this.btnFieldDown.UseVisualStyleBackColor = true;
            this.btnFieldDown.Click += new System.EventHandler(this.btnFieldDown_Click);
            // 
            // btnFieldUp
            // 
            this.btnFieldUp.Location = new System.Drawing.Point(268, 355);
            this.btnFieldUp.Name = "btnFieldUp";
            this.btnFieldUp.Size = new System.Drawing.Size(120, 23);
            this.btnFieldUp.TabIndex = 15;
            this.btnFieldUp.Text = "Вверх";
            this.btnFieldUp.UseVisualStyleBackColor = true;
            this.btnFieldUp.Click += new System.EventHandler(this.btnFieldUp_Click);
            // 
            // cbForeignTables
            // 
            this.cbForeignTables.FormattingEnabled = true;
            this.cbForeignTables.ItemHeight = 13;
            this.cbForeignTables.Location = new System.Drawing.Point(397, 245);
            this.cbForeignTables.Name = "cbForeignTables";
            this.cbForeignTables.Size = new System.Drawing.Size(257, 21);
            this.cbForeignTables.TabIndex = 24;
            this.cbForeignTables.Leave += new System.EventHandler(this.FieldEditEnd_Leave);
            // 
            // btnCollectionRename
            // 
            this.btnCollectionRename.Location = new System.Drawing.Point(16, 326);
            this.btnCollectionRename.Name = "btnCollectionRename";
            this.btnCollectionRename.Size = new System.Drawing.Size(120, 23);
            this.btnCollectionRename.TabIndex = 4;
            this.btnCollectionRename.Text = "Переименовать";
            this.btnCollectionRename.UseVisualStyleBackColor = true;
            this.btnCollectionRename.Click += new System.EventHandler(this.btnCollectionRename_Click);
            // 
            // btnTableRename
            // 
            this.btnTableRename.Location = new System.Drawing.Point(142, 326);
            this.btnTableRename.Name = "btnTableRename";
            this.btnTableRename.Size = new System.Drawing.Size(120, 23);
            this.btnTableRename.TabIndex = 9;
            this.btnTableRename.Text = "Переименовать";
            this.btnTableRename.UseVisualStyleBackColor = true;
            this.btnTableRename.Click += new System.EventHandler(this.btnTableRename_Click);
            // 
            // tbTypeLimit
            // 
            this.tbTypeLimit.Location = new System.Drawing.Point(529, 119);
            this.tbTypeLimit.Name = "tbTypeLimit";
            this.tbTypeLimit.Size = new System.Drawing.Size(125, 20);
            this.tbTypeLimit.TabIndex = 27;
            this.tbTypeLimit.Leave += new System.EventHandler(this.FieldEditEnd_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(526, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "Ограничение";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 29;
            this.label7.Text = "Коллекции";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(139, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 30;
            this.label8.Text = "Таблицы";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(265, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 13);
            this.label9.TabIndex = 31;
            this.label9.Text = "Поля";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFile});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(661, 24);
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 417);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbTypeLimit);
            this.Controls.Add(this.btnTableRename);
            this.Controls.Add(this.btnCollectionRename);
            this.Controls.Add(this.cbForeignTables);
            this.Controls.Add(this.btnFieldDown);
            this.Controls.Add(this.btnFieldUp);
            this.Controls.Add(this.btnDeleteField);
            this.Controls.Add(this.btnAddField);
            this.Controls.Add(this.btnDeleteTable);
            this.Controls.Add(this.btnAddTable);
            this.Controls.Add(this.btnDeleteCollection);
            this.Controls.Add(this.btnAddCollection);
            this.Controls.Add(this.chkbNameField);
            this.Controls.Add(this.lbTables);
            this.Controls.Add(this.lbFields);
            this.Controls.Add(this.lbCollections);
            this.Controls.Add(this.cbType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.chkbForeignField);
            this.Controls.Add(this.chkbRequiredField);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbWidth);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox lbCollections;
        private System.Windows.Forms.ListBox lbFields;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkbForeignField;
        private System.Windows.Forms.CheckBox chkbRequiredField;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbWidth;
        private System.Windows.Forms.TextBox tbBaseName;
        private System.Windows.Forms.TextBox tbProgramName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbTables;
        private System.Windows.Forms.CheckBox chkbNameField;
        private System.Windows.Forms.Button btnAddCollection;
        private System.Windows.Forms.Button btnDeleteCollection;
        private System.Windows.Forms.Button btnAddTable;
        private System.Windows.Forms.Button btnDeleteTable;
        private System.Windows.Forms.Button btnAddField;
        private System.Windows.Forms.Button btnDeleteField;
        private System.Windows.Forms.Button btnFieldDown;
        private System.Windows.Forms.Button btnFieldUp;
        private System.Windows.Forms.ComboBox cbForeignTables;
        private System.Windows.Forms.Button btnCollectionRename;
        private System.Windows.Forms.Button btnTableRename;
        private System.Windows.Forms.TextBox tbTypeLimit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenCollectionFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaveCollection;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaveCollectionAs;
    }
}

