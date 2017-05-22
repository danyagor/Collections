namespace CollectionsProject
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Коллекции");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.collectionsCMS = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsCreateCollection = new System.Windows.Forms.ToolStripMenuItem();
            this.treeView = new System.Windows.Forms.TreeView();
            this.mainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.innerSplitContailer = new System.Windows.Forms.SplitContainer();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.itemsCMS = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.itemsCmsAddItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemsCmsEditItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemsCmsDeleteItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rtbItemDescription = new System.Windows.Forms.RichTextBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.tsmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCreateDatabase = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpenDatabase = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLastBases = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmlExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCollections = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCreateCollection = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRenameCollection = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeleteCollection = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiItems = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAddItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEditItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeleteItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiForeignTables = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiForeignTablesEditor = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiService = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.innerCollectionsCMS = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsAddItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsRenameCollection = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsDeleteCollection = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsEditForeignTables = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.tssLabelConnectionState = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.collectionsCMS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).BeginInit();
            this.mainSplitContainer.Panel1.SuspendLayout();
            this.mainSplitContainer.Panel2.SuspendLayout();
            this.mainSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.innerSplitContailer)).BeginInit();
            this.innerSplitContailer.Panel1.SuspendLayout();
            this.innerSplitContailer.Panel2.SuspendLayout();
            this.innerSplitContailer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.itemsCMS.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.innerCollectionsCMS.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // collectionsCMS
            // 
            this.collectionsCMS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsCreateCollection});
            this.collectionsCMS.Name = "collectionsCMS";
            this.collectionsCMS.Size = new System.Drawing.Size(184, 26);
            // 
            // cmsCreateCollection
            // 
            this.cmsCreateCollection.Name = "cmsCreateCollection";
            this.cmsCreateCollection.Size = new System.Drawing.Size(183, 22);
            this.cmsCreateCollection.Text = "Создать коллекцию";
            this.cmsCreateCollection.Click += new System.EventHandler(this.CreateCollection_Click);
            // 
            // treeView
            // 
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.Location = new System.Drawing.Point(0, 0);
            this.treeView.Name = "treeView";
            treeNode1.ContextMenuStrip = this.collectionsCMS;
            treeNode1.Name = "collectionsNode";
            treeNode1.Text = "Коллекции";
            this.treeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.treeView.Size = new System.Drawing.Size(174, 490);
            this.treeView.TabIndex = 0;
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
            // 
            // mainSplitContainer
            // 
            this.mainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.mainSplitContainer.Location = new System.Drawing.Point(0, 24);
            this.mainSplitContainer.Name = "mainSplitContainer";
            // 
            // mainSplitContainer.Panel1
            // 
            this.mainSplitContainer.Panel1.Controls.Add(this.treeView);
            // 
            // mainSplitContainer.Panel2
            // 
            this.mainSplitContainer.Panel2.Controls.Add(this.innerSplitContailer);
            this.mainSplitContainer.Size = new System.Drawing.Size(1204, 490);
            this.mainSplitContainer.SplitterDistance = 174;
            this.mainSplitContainer.TabIndex = 2;
            // 
            // innerSplitContailer
            // 
            this.innerSplitContailer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.innerSplitContailer.Location = new System.Drawing.Point(0, 0);
            this.innerSplitContailer.Name = "innerSplitContailer";
            this.innerSplitContailer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // innerSplitContailer.Panel1
            // 
            this.innerSplitContailer.Panel1.Controls.Add(this.dgvItems);
            // 
            // innerSplitContailer.Panel2
            // 
            this.innerSplitContailer.Panel2.Controls.Add(this.rtbItemDescription);
            this.innerSplitContailer.Size = new System.Drawing.Size(1026, 490);
            this.innerSplitContailer.SplitterDistance = 365;
            this.innerSplitContailer.TabIndex = 0;
            // 
            // dgvItems
            // 
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AllowUserToDeleteRows = false;
            this.dgvItems.AllowUserToResizeRows = false;
            this.dgvItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvItems.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.ContextMenuStrip = this.itemsCMS;
            this.dgvItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvItems.Location = new System.Drawing.Point(0, 0);
            this.dgvItems.MultiSelect = false;
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.ReadOnly = true;
            this.dgvItems.Size = new System.Drawing.Size(1026, 365);
            this.dgvItems.TabIndex = 1;
            this.dgvItems.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItems_CellClick);
            this.dgvItems.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.EditItem_Click);
            // 
            // itemsCMS
            // 
            this.itemsCMS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemsCmsAddItem,
            this.itemsCmsEditItem,
            this.itemsCmsDeleteItem});
            this.itemsCMS.Name = "collectionsContextMenuStrip";
            this.itemsCMS.Size = new System.Drawing.Size(204, 70);
            // 
            // itemsCmsAddItem
            // 
            this.itemsCmsAddItem.Name = "itemsCmsAddItem";
            this.itemsCmsAddItem.Size = new System.Drawing.Size(203, 22);
            this.itemsCmsAddItem.Text = "Добавить предмет";
            this.itemsCmsAddItem.Click += new System.EventHandler(this.AddItem_Click);
            // 
            // itemsCmsEditItem
            // 
            this.itemsCmsEditItem.Name = "itemsCmsEditItem";
            this.itemsCmsEditItem.Size = new System.Drawing.Size(203, 22);
            this.itemsCmsEditItem.Text = "Редактировать предмет";
            this.itemsCmsEditItem.Click += new System.EventHandler(this.EditItem_Click);
            // 
            // itemsCmsDeleteItem
            // 
            this.itemsCmsDeleteItem.Name = "itemsCmsDeleteItem";
            this.itemsCmsDeleteItem.Size = new System.Drawing.Size(203, 22);
            this.itemsCmsDeleteItem.Text = "Удалить предмет";
            this.itemsCmsDeleteItem.Click += new System.EventHandler(this.DeleteItem_Click);
            // 
            // rtbItemDescription
            // 
            this.rtbItemDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbItemDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbItemDescription.Location = new System.Drawing.Point(0, 0);
            this.rtbItemDescription.Name = "rtbItemDescription";
            this.rtbItemDescription.ReadOnly = true;
            this.rtbItemDescription.Size = new System.Drawing.Size(1026, 121);
            this.rtbItemDescription.TabIndex = 0;
            this.rtbItemDescription.Text = "";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFile,
            this.tsmiCollections,
            this.tsmiItems,
            this.tsmiForeignTables,
            this.tsmiService,
            this.tsmiHelp});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1204, 24);
            this.menuStrip.TabIndex = 3;
            this.menuStrip.Text = "menuStrip1";
            // 
            // tsmiFile
            // 
            this.tsmiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCreateDatabase,
            this.tsmiOpenDatabase,
            this.tsmiLastBases,
            this.tsmlExit});
            this.tsmiFile.Name = "tsmiFile";
            this.tsmiFile.Size = new System.Drawing.Size(48, 20);
            this.tsmiFile.Text = "Файл";
            // 
            // tsmiCreateDatabase
            // 
            this.tsmiCreateDatabase.Name = "tsmiCreateDatabase";
            this.tsmiCreateDatabase.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.tsmiCreateDatabase.Size = new System.Drawing.Size(254, 22);
            this.tsmiCreateDatabase.Text = "Создать базу коллекций";
            this.tsmiCreateDatabase.Click += new System.EventHandler(this.CreateDatabase_Click);
            // 
            // tsmiOpenDatabase
            // 
            this.tsmiOpenDatabase.Name = "tsmiOpenDatabase";
            this.tsmiOpenDatabase.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.tsmiOpenDatabase.Size = new System.Drawing.Size(254, 22);
            this.tsmiOpenDatabase.Text = "Открыть базу коллекций";
            this.tsmiOpenDatabase.Click += new System.EventHandler(this.OpenDatabase_Click);
            // 
            // tsmiLastBases
            // 
            this.tsmiLastBases.Name = "tsmiLastBases";
            this.tsmiLastBases.Size = new System.Drawing.Size(254, 22);
            this.tsmiLastBases.Text = "Последние базы";
            // 
            // tsmlExit
            // 
            this.tsmlExit.Name = "tsmlExit";
            this.tsmlExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.tsmlExit.Size = new System.Drawing.Size(254, 22);
            this.tsmlExit.Text = "Выход";
            this.tsmlExit.Click += new System.EventHandler(this.tsmlExit_Click);
            // 
            // tsmiCollections
            // 
            this.tsmiCollections.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCreateCollection,
            this.tsmiRenameCollection,
            this.tsmiDeleteCollection});
            this.tsmiCollections.Name = "tsmiCollections";
            this.tsmiCollections.Size = new System.Drawing.Size(80, 20);
            this.tsmiCollections.Text = "Коллекции";
            // 
            // tsmiCreateCollection
            // 
            this.tsmiCreateCollection.Name = "tsmiCreateCollection";
            this.tsmiCreateCollection.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.K)));
            this.tsmiCreateCollection.Size = new System.Drawing.Size(268, 22);
            this.tsmiCreateCollection.Text = "Создать коллекцию";
            this.tsmiCreateCollection.Click += new System.EventHandler(this.CreateCollection_Click);
            // 
            // tsmiRenameCollection
            // 
            this.tsmiRenameCollection.Name = "tsmiRenameCollection";
            this.tsmiRenameCollection.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.tsmiRenameCollection.Size = new System.Drawing.Size(268, 22);
            this.tsmiRenameCollection.Text = "Переименовать коллекцию";
            this.tsmiRenameCollection.Click += new System.EventHandler(this.RenameCollection_Click);
            // 
            // tsmiDeleteCollection
            // 
            this.tsmiDeleteCollection.Name = "tsmiDeleteCollection";
            this.tsmiDeleteCollection.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Delete)));
            this.tsmiDeleteCollection.Size = new System.Drawing.Size(268, 22);
            this.tsmiDeleteCollection.Text = "Удалить коллекцию";
            this.tsmiDeleteCollection.Click += new System.EventHandler(this.DeleteCollection_Click);
            // 
            // tsmiItems
            // 
            this.tsmiItems.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAddItem,
            this.tsmiEditItem,
            this.tsmiDeleteItem});
            this.tsmiItems.Name = "tsmiItems";
            this.tsmiItems.Size = new System.Drawing.Size(76, 20);
            this.tsmiItems.Text = "Предметы";
            // 
            // tsmiAddItem
            // 
            this.tsmiAddItem.Name = "tsmiAddItem";
            this.tsmiAddItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.tsmiAddItem.Size = new System.Drawing.Size(250, 22);
            this.tsmiAddItem.Text = "Добавить предмет";
            this.tsmiAddItem.Click += new System.EventHandler(this.AddItem_Click);
            // 
            // tsmiEditItem
            // 
            this.tsmiEditItem.Name = "tsmiEditItem";
            this.tsmiEditItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.tsmiEditItem.Size = new System.Drawing.Size(250, 22);
            this.tsmiEditItem.Text = "Редактировать предмет";
            this.tsmiEditItem.Click += new System.EventHandler(this.EditItem_Click);
            // 
            // tsmiDeleteItem
            // 
            this.tsmiDeleteItem.Name = "tsmiDeleteItem";
            this.tsmiDeleteItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Delete)));
            this.tsmiDeleteItem.Size = new System.Drawing.Size(250, 22);
            this.tsmiDeleteItem.Text = "Удалить предмет";
            this.tsmiDeleteItem.Click += new System.EventHandler(this.DeleteItem_Click);
            // 
            // tsmiForeignTables
            // 
            this.tsmiForeignTables.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiForeignTablesEditor});
            this.tsmiForeignTables.Name = "tsmiForeignTables";
            this.tsmiForeignTables.Size = new System.Drawing.Size(94, 20);
            this.tsmiForeignTables.Text = "Справочники";
            // 
            // tsmiForeignTablesEditor
            // 
            this.tsmiForeignTablesEditor.Name = "tsmiForeignTablesEditor";
            this.tsmiForeignTablesEditor.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.tsmiForeignTablesEditor.Size = new System.Drawing.Size(247, 22);
            this.tsmiForeignTablesEditor.Text = "Редактор справочников";
            this.tsmiForeignTablesEditor.Click += new System.EventHandler(this.ForeignTablesEditor_Click);
            // 
            // tsmiService
            // 
            this.tsmiService.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSettings});
            this.tsmiService.Name = "tsmiService";
            this.tsmiService.Size = new System.Drawing.Size(59, 20);
            this.tsmiService.Text = "Сервис";
            this.tsmiService.Visible = false;
            // 
            // tsmiSettings
            // 
            this.tsmiSettings.Name = "tsmiSettings";
            this.tsmiSettings.Size = new System.Drawing.Size(152, 22);
            this.tsmiSettings.Text = "Настройки";
            this.tsmiSettings.Click += new System.EventHandler(this.tsmiSettings_Click);
            // 
            // tsmiHelp
            // 
            this.tsmiHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAbout});
            this.tsmiHelp.Name = "tsmiHelp";
            this.tsmiHelp.Size = new System.Drawing.Size(65, 20);
            this.tsmiHelp.Text = "Справка";
            // 
            // tsmiAbout
            // 
            this.tsmiAbout.Name = "tsmiAbout";
            this.tsmiAbout.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F1)));
            this.tsmiAbout.Size = new System.Drawing.Size(204, 22);
            this.tsmiAbout.Text = "О программе...";
            this.tsmiAbout.Click += new System.EventHandler(this.tsmiAbout_Click);
            // 
            // innerCollectionsCMS
            // 
            this.innerCollectionsCMS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsAddItem,
            this.cmsRenameCollection,
            this.cmsDeleteCollection,
            this.cmsEditForeignTables});
            this.innerCollectionsCMS.Name = "collectionsContextMenuStrip";
            this.innerCollectionsCMS.Size = new System.Drawing.Size(231, 92);
            // 
            // cmsAddItem
            // 
            this.cmsAddItem.Name = "cmsAddItem";
            this.cmsAddItem.Size = new System.Drawing.Size(230, 22);
            this.cmsAddItem.Text = "Добавить предмет";
            this.cmsAddItem.Click += new System.EventHandler(this.AddItem_Click);
            // 
            // cmsRenameCollection
            // 
            this.cmsRenameCollection.Name = "cmsRenameCollection";
            this.cmsRenameCollection.Size = new System.Drawing.Size(230, 22);
            this.cmsRenameCollection.Text = "Переименовать коллекцию";
            this.cmsRenameCollection.Click += new System.EventHandler(this.RenameCollection_Click);
            // 
            // cmsDeleteCollection
            // 
            this.cmsDeleteCollection.Name = "cmsDeleteCollection";
            this.cmsDeleteCollection.Size = new System.Drawing.Size(230, 22);
            this.cmsDeleteCollection.Text = "Удалить коллекцию";
            this.cmsDeleteCollection.Click += new System.EventHandler(this.DeleteCollection_Click);
            // 
            // cmsEditForeignTables
            // 
            this.cmsEditForeignTables.Name = "cmsEditForeignTables";
            this.cmsEditForeignTables.Size = new System.Drawing.Size(230, 22);
            this.cmsEditForeignTables.Text = "Редактировать справочники";
            this.cmsEditForeignTables.Click += new System.EventHandler(this.ForeignTablesEditor_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssLabelConnectionState});
            this.statusStrip.Location = new System.Drawing.Point(0, 514);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1204, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            // 
            // tssLabelConnectionState
            // 
            this.tssLabelConnectionState.Name = "tssLabelConnectionState";
            this.tssLabelConnectionState.Size = new System.Drawing.Size(98, 17);
            this.tssLabelConnectionState.Text = "Connection State";
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton4,
            this.toolStripSeparator1,
            this.toolStripButton2,
            this.toolStripSplitButton1,
            this.toolStripSeparator2});
            this.toolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1204, 53);
            this.toolStrip.Stretch = true;
            this.toolStrip.TabIndex = 4;
            this.toolStrip.Text = "toolStrip1";
            this.toolStrip.Visible = false;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.AutoSize = false;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(50, 50);
            this.toolStripButton1.Text = "Создать коллекцию";
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.AutoSize = false;
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(50, 50);
            this.toolStripButton4.Text = "Переименовать коллекцию";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.AutoSize = false;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(50, 50);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.AutoSize = false;
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(50, 50);
            this.toolStripButton2.Text = "Создать базу";
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.AutoSize = false;
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(50, 50);
            this.toolStripSplitButton1.Text = "Открыть базу";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 53);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1204, 536);
            this.Controls.Add(this.mainSplitContainer);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.statusStrip);
            this.Name = "MainForm";
            this.Text = "Коллекции";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.collectionsCMS.ResumeLayout(false);
            this.mainSplitContainer.Panel1.ResumeLayout(false);
            this.mainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).EndInit();
            this.mainSplitContainer.ResumeLayout(false);
            this.innerSplitContailer.Panel1.ResumeLayout(false);
            this.innerSplitContailer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.innerSplitContailer)).EndInit();
            this.innerSplitContailer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.itemsCMS.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.innerCollectionsCMS.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.SplitContainer mainSplitContainer;
        private System.Windows.Forms.SplitContainer innerSplitContailer;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem tsmiFile;
        private System.Windows.Forms.ToolStripMenuItem tsmlExit;
        private System.Windows.Forms.ContextMenuStrip collectionsCMS;
        private System.Windows.Forms.ToolStripMenuItem cmsCreateCollection;
        private System.Windows.Forms.ContextMenuStrip innerCollectionsCMS;
        private System.Windows.Forms.ToolStripMenuItem cmsAddItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiCreateDatabase;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel tssLabelConnectionState;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenDatabase;
        private System.Windows.Forms.ToolStripMenuItem tsmiCollections;
        private System.Windows.Forms.ToolStripMenuItem tsmiCreateCollection;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteCollection;
        private System.Windows.Forms.ToolStripMenuItem tsmiLastBases;
        private System.Windows.Forms.ToolStripMenuItem cmsRenameCollection;
        private System.Windows.Forms.ToolStripMenuItem tsmiRenameCollection;
        private System.Windows.Forms.ToolStripMenuItem cmsDeleteCollection;
        private System.Windows.Forms.ContextMenuStrip itemsCMS;
        private System.Windows.Forms.ToolStripMenuItem itemsCmsAddItem;
        private System.Windows.Forms.ToolStripMenuItem itemsCmsDeleteItem;
        private System.Windows.Forms.ToolStripMenuItem itemsCmsEditItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiItems;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteItem;
        private System.Windows.Forms.RichTextBox rtbItemDescription;
        private System.Windows.Forms.ToolStripMenuItem tsmiEditItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiForeignTables;
        private System.Windows.Forms.ToolStripMenuItem tsmiForeignTablesEditor;
        private System.Windows.Forms.ToolStripMenuItem cmsEditForeignTables;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmiService;
        private System.Windows.Forms.ToolStripMenuItem tsmiSettings;
        private System.Windows.Forms.ToolStripMenuItem tsmiHelp;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.ToolStripMenuItem tsmiAbout;
    }
}

