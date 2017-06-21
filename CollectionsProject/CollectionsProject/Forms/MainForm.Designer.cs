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
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Коллекции");
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
            this.ItemInformation = new System.Windows.Forms.SplitContainer();
            this.tcPhotos = new System.Windows.Forms.TabControl();
            this.photo1 = new System.Windows.Forms.TabPage();
            this.pbPhoto1 = new System.Windows.Forms.PictureBox();
            this.photo2 = new System.Windows.Forms.TabPage();
            this.pbPhoto2 = new System.Windows.Forms.PictureBox();
            this.photo3 = new System.Windows.Forms.TabPage();
            this.pbPhoto3 = new System.Windows.Forms.PictureBox();
            this.photo4 = new System.Windows.Forms.TabPage();
            this.pbPhoto4 = new System.Windows.Forms.PictureBox();
            this.rtbItemDescription = new System.Windows.Forms.RichTextBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.tsmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCreateDatabase = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpenDatabase = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLastBases = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCollections = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCreateCollection = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRenameCollection = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeleteCollection = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiItems = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAddItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEditItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeleteItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSearchItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiView = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPhotoPanel = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDescriptionPanel = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiIconsPanel = new System.Windows.Forms.ToolStripMenuItem();
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
            this.tsbCreateBase = new System.Windows.Forms.ToolStripButton();
            this.tsbOpenBase = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbCreateCollection = new System.Windows.Forms.ToolStripButton();
            this.tsbRenameCollection = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbAddItem = new System.Windows.Forms.ToolStripButton();
            this.tsbEditItem = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSearch = new System.Windows.Forms.ToolStripButton();
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
            ((System.ComponentModel.ISupportInitialize)(this.ItemInformation)).BeginInit();
            this.ItemInformation.Panel1.SuspendLayout();
            this.ItemInformation.Panel2.SuspendLayout();
            this.ItemInformation.SuspendLayout();
            this.tcPhotos.SuspendLayout();
            this.photo1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto1)).BeginInit();
            this.photo2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto2)).BeginInit();
            this.photo3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto3)).BeginInit();
            this.photo4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto4)).BeginInit();
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
            treeNode3.ContextMenuStrip = this.collectionsCMS;
            treeNode3.Name = "collectionsNode";
            treeNode3.Text = "Коллекции";
            this.treeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3});
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
            this.innerSplitContailer.Panel2.Controls.Add(this.ItemInformation);
            this.innerSplitContailer.Size = new System.Drawing.Size(1026, 490);
            this.innerSplitContailer.SplitterDistance = 307;
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
            this.dgvItems.Size = new System.Drawing.Size(1026, 307);
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
            // ItemInformation
            // 
            this.ItemInformation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ItemInformation.Location = new System.Drawing.Point(0, 0);
            this.ItemInformation.Name = "ItemInformation";
            // 
            // ItemInformation.Panel1
            // 
            this.ItemInformation.Panel1.Controls.Add(this.tcPhotos);
            // 
            // ItemInformation.Panel2
            // 
            this.ItemInformation.Panel2.Controls.Add(this.rtbItemDescription);
            this.ItemInformation.Size = new System.Drawing.Size(1026, 179);
            this.ItemInformation.SplitterDistance = 342;
            this.ItemInformation.TabIndex = 1;
            // 
            // tcPhotos
            // 
            this.tcPhotos.Controls.Add(this.photo1);
            this.tcPhotos.Controls.Add(this.photo2);
            this.tcPhotos.Controls.Add(this.photo3);
            this.tcPhotos.Controls.Add(this.photo4);
            this.tcPhotos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcPhotos.Location = new System.Drawing.Point(0, 0);
            this.tcPhotos.Name = "tcPhotos";
            this.tcPhotos.SelectedIndex = 0;
            this.tcPhotos.Size = new System.Drawing.Size(342, 179);
            this.tcPhotos.TabIndex = 0;
            // 
            // photo1
            // 
            this.photo1.Controls.Add(this.pbPhoto1);
            this.photo1.Location = new System.Drawing.Point(4, 22);
            this.photo1.Name = "photo1";
            this.photo1.Size = new System.Drawing.Size(334, 153);
            this.photo1.TabIndex = 0;
            this.photo1.Text = "Фото 1";
            this.photo1.UseVisualStyleBackColor = true;
            // 
            // pbPhoto1
            // 
            this.pbPhoto1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPhoto1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbPhoto1.Location = new System.Drawing.Point(0, 0);
            this.pbPhoto1.Margin = new System.Windows.Forms.Padding(0);
            this.pbPhoto1.Name = "pbPhoto1";
            this.pbPhoto1.Size = new System.Drawing.Size(334, 153);
            this.pbPhoto1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPhoto1.TabIndex = 0;
            this.pbPhoto1.TabStop = false;
            // 
            // photo2
            // 
            this.photo2.Controls.Add(this.pbPhoto2);
            this.photo2.Location = new System.Drawing.Point(4, 22);
            this.photo2.Name = "photo2";
            this.photo2.Size = new System.Drawing.Size(334, 153);
            this.photo2.TabIndex = 1;
            this.photo2.Text = "Фото 2";
            this.photo2.UseVisualStyleBackColor = true;
            // 
            // pbPhoto2
            // 
            this.pbPhoto2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPhoto2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbPhoto2.Location = new System.Drawing.Point(0, 0);
            this.pbPhoto2.Margin = new System.Windows.Forms.Padding(0);
            this.pbPhoto2.Name = "pbPhoto2";
            this.pbPhoto2.Size = new System.Drawing.Size(334, 153);
            this.pbPhoto2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPhoto2.TabIndex = 1;
            this.pbPhoto2.TabStop = false;
            // 
            // photo3
            // 
            this.photo3.Controls.Add(this.pbPhoto3);
            this.photo3.Location = new System.Drawing.Point(4, 22);
            this.photo3.Name = "photo3";
            this.photo3.Size = new System.Drawing.Size(334, 153);
            this.photo3.TabIndex = 2;
            this.photo3.Text = "Фото 3";
            this.photo3.UseVisualStyleBackColor = true;
            // 
            // pbPhoto3
            // 
            this.pbPhoto3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPhoto3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbPhoto3.Location = new System.Drawing.Point(0, 0);
            this.pbPhoto3.Name = "pbPhoto3";
            this.pbPhoto3.Size = new System.Drawing.Size(334, 153);
            this.pbPhoto3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPhoto3.TabIndex = 1;
            this.pbPhoto3.TabStop = false;
            // 
            // photo4
            // 
            this.photo4.Controls.Add(this.pbPhoto4);
            this.photo4.Location = new System.Drawing.Point(4, 22);
            this.photo4.Name = "photo4";
            this.photo4.Size = new System.Drawing.Size(334, 153);
            this.photo4.TabIndex = 3;
            this.photo4.Text = "Фото 4";
            this.photo4.UseVisualStyleBackColor = true;
            // 
            // pbPhoto4
            // 
            this.pbPhoto4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPhoto4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbPhoto4.Location = new System.Drawing.Point(0, 0);
            this.pbPhoto4.Name = "pbPhoto4";
            this.pbPhoto4.Size = new System.Drawing.Size(334, 153);
            this.pbPhoto4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPhoto4.TabIndex = 1;
            this.pbPhoto4.TabStop = false;
            // 
            // rtbItemDescription
            // 
            this.rtbItemDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbItemDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbItemDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rtbItemDescription.Location = new System.Drawing.Point(0, 0);
            this.rtbItemDescription.Name = "rtbItemDescription";
            this.rtbItemDescription.Size = new System.Drawing.Size(680, 179);
            this.rtbItemDescription.TabIndex = 0;
            this.rtbItemDescription.Text = "";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFile,
            this.tsmiCollections,
            this.tsmiItems,
            this.tsmiView,
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
            this.tsmiExit});
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
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.tsmiExit.Size = new System.Drawing.Size(254, 22);
            this.tsmiExit.Text = "Выход";
            this.tsmiExit.Click += new System.EventHandler(this.tsmlExit_Click);
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
            this.tsmiDeleteItem,
            this.tsmiSearchItem});
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
            // tsmiSearchItem
            // 
            this.tsmiSearchItem.Name = "tsmiSearchItem";
            this.tsmiSearchItem.Size = new System.Drawing.Size(250, 22);
            this.tsmiSearchItem.Text = "Поиск предмета";
            this.tsmiSearchItem.Click += new System.EventHandler(this.tsmiSearchItem_Click);
            // 
            // tsmiView
            // 
            this.tsmiView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiPhotoPanel,
            this.tsmiDescriptionPanel,
            this.tsmiIconsPanel});
            this.tsmiView.Name = "tsmiView";
            this.tsmiView.Size = new System.Drawing.Size(39, 20);
            this.tsmiView.Text = "Вид";
            // 
            // tsmiPhotoPanel
            // 
            this.tsmiPhotoPanel.Checked = true;
            this.tsmiPhotoPanel.CheckOnClick = true;
            this.tsmiPhotoPanel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiPhotoPanel.Name = "tsmiPhotoPanel";
            this.tsmiPhotoPanel.Size = new System.Drawing.Size(187, 22);
            this.tsmiPhotoPanel.Text = "Панель фотографий";
            this.tsmiPhotoPanel.Click += new System.EventHandler(this.tsmiPhotoPanel_Click);
            // 
            // tsmiDescriptionPanel
            // 
            this.tsmiDescriptionPanel.Checked = true;
            this.tsmiDescriptionPanel.CheckOnClick = true;
            this.tsmiDescriptionPanel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiDescriptionPanel.Name = "tsmiDescriptionPanel";
            this.tsmiDescriptionPanel.Size = new System.Drawing.Size(187, 22);
            this.tsmiDescriptionPanel.Text = "Панель описания";
            this.tsmiDescriptionPanel.Click += new System.EventHandler(this.tsmiDescriptionPanel_Click);
            // 
            // tsmiIconsPanel
            // 
            this.tsmiIconsPanel.Checked = true;
            this.tsmiIconsPanel.CheckOnClick = true;
            this.tsmiIconsPanel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiIconsPanel.Name = "tsmiIconsPanel";
            this.tsmiIconsPanel.Size = new System.Drawing.Size(187, 22);
            this.tsmiIconsPanel.Text = "Панель иконок";
            this.tsmiIconsPanel.Visible = false;
            this.tsmiIconsPanel.Click += new System.EventHandler(this.tsmiIconsPanel_Click);
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
            // 
            // tsmiSettings
            // 
            this.tsmiSettings.Name = "tsmiSettings";
            this.tsmiSettings.Size = new System.Drawing.Size(134, 22);
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
            this.tsbCreateBase,
            this.tsbOpenBase,
            this.toolStripSeparator1,
            this.tsbCreateCollection,
            this.tsbRenameCollection,
            this.toolStripSeparator3,
            this.tsbAddItem,
            this.tsbEditItem,
            this.toolStripSeparator2,
            this.tsbSearch});
            this.toolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1204, 53);
            this.toolStrip.Stretch = true;
            this.toolStrip.TabIndex = 4;
            this.toolStrip.Text = "toolStrip1";
            this.toolStrip.Visible = false;
            // 
            // tsbCreateBase
            // 
            this.tsbCreateBase.AutoSize = false;
            this.tsbCreateBase.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCreateBase.Image = ((System.Drawing.Image)(resources.GetObject("tsbCreateBase.Image")));
            this.tsbCreateBase.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCreateBase.Name = "tsbCreateBase";
            this.tsbCreateBase.Size = new System.Drawing.Size(50, 50);
            this.tsbCreateBase.Text = "Создать базу";
            this.tsbCreateBase.Click += new System.EventHandler(this.CreateDatabase_Click);
            // 
            // tsbOpenBase
            // 
            this.tsbOpenBase.AutoSize = false;
            this.tsbOpenBase.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbOpenBase.Image = ((System.Drawing.Image)(resources.GetObject("tsbOpenBase.Image")));
            this.tsbOpenBase.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOpenBase.Name = "tsbOpenBase";
            this.tsbOpenBase.Size = new System.Drawing.Size(50, 50);
            this.tsbOpenBase.Text = "Открыть базу";
            this.tsbOpenBase.ButtonClick += new System.EventHandler(this.OpenDatabase_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.AutoSize = false;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(20, 50);
            // 
            // tsbCreateCollection
            // 
            this.tsbCreateCollection.AutoSize = false;
            this.tsbCreateCollection.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCreateCollection.Image = ((System.Drawing.Image)(resources.GetObject("tsbCreateCollection.Image")));
            this.tsbCreateCollection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCreateCollection.Name = "tsbCreateCollection";
            this.tsbCreateCollection.Size = new System.Drawing.Size(50, 50);
            this.tsbCreateCollection.Text = "Создать коллекцию";
            this.tsbCreateCollection.Click += new System.EventHandler(this.CreateCollection_Click);
            // 
            // tsbRenameCollection
            // 
            this.tsbRenameCollection.AutoSize = false;
            this.tsbRenameCollection.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRenameCollection.Image = ((System.Drawing.Image)(resources.GetObject("tsbRenameCollection.Image")));
            this.tsbRenameCollection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRenameCollection.Name = "tsbRenameCollection";
            this.tsbRenameCollection.Size = new System.Drawing.Size(50, 50);
            this.tsbRenameCollection.Text = "Переименовать коллекцию";
            this.tsbRenameCollection.Click += new System.EventHandler(this.RenameCollection_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.AutoSize = false;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(20, 50);
            // 
            // tsbAddItem
            // 
            this.tsbAddItem.AutoSize = false;
            this.tsbAddItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAddItem.Image = ((System.Drawing.Image)(resources.GetObject("tsbAddItem.Image")));
            this.tsbAddItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAddItem.Name = "tsbAddItem";
            this.tsbAddItem.Size = new System.Drawing.Size(50, 50);
            this.tsbAddItem.Text = "Добавить предмет";
            this.tsbAddItem.Click += new System.EventHandler(this.AddItem_Click);
            // 
            // tsbEditItem
            // 
            this.tsbEditItem.AutoSize = false;
            this.tsbEditItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEditItem.Image = ((System.Drawing.Image)(resources.GetObject("tsbEditItem.Image")));
            this.tsbEditItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEditItem.Name = "tsbEditItem";
            this.tsbEditItem.Size = new System.Drawing.Size(50, 50);
            this.tsbEditItem.Text = "Редактировать предмет";
            this.tsbEditItem.Click += new System.EventHandler(this.EditItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.AutoSize = false;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(20, 50);
            // 
            // tsbSearch
            // 
            this.tsbSearch.AutoSize = false;
            this.tsbSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSearch.Image = ((System.Drawing.Image)(resources.GetObject("tsbSearch.Image")));
            this.tsbSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSearch.Name = "tsbSearch";
            this.tsbSearch.Size = new System.Drawing.Size(50, 50);
            this.tsbSearch.Text = "Поиск";
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
            this.ItemInformation.Panel1.ResumeLayout(false);
            this.ItemInformation.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ItemInformation)).EndInit();
            this.ItemInformation.ResumeLayout(false);
            this.tcPhotos.ResumeLayout(false);
            this.photo1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto1)).EndInit();
            this.photo2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto2)).EndInit();
            this.photo3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto3)).EndInit();
            this.photo4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto4)).EndInit();
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
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
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
        private System.Windows.Forms.ToolStripButton tsbCreateBase;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbCreateCollection;
        private System.Windows.Forms.ToolStripButton tsbRenameCollection;
        private System.Windows.Forms.ToolStripSplitButton tsbOpenBase;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmiService;
        private System.Windows.Forms.ToolStripMenuItem tsmiSettings;
        private System.Windows.Forms.ToolStripMenuItem tsmiHelp;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.ToolStripMenuItem tsmiAbout;
        private System.Windows.Forms.ToolStripMenuItem tsmiSearchItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbAddItem;
        private System.Windows.Forms.ToolStripButton tsbEditItem;
        private System.Windows.Forms.ToolStripButton tsbSearch;
        private System.Windows.Forms.SplitContainer ItemInformation;
        private System.Windows.Forms.TabControl tcPhotos;
        private System.Windows.Forms.TabPage photo1;
        private System.Windows.Forms.TabPage photo2;
        private System.Windows.Forms.PictureBox pbPhoto1;
        private System.Windows.Forms.PictureBox pbPhoto2;
        private System.Windows.Forms.TabPage photo3;
        private System.Windows.Forms.PictureBox pbPhoto3;
        private System.Windows.Forms.TabPage photo4;
        private System.Windows.Forms.PictureBox pbPhoto4;
        private System.Windows.Forms.ToolStripMenuItem tsmiView;
        private System.Windows.Forms.ToolStripMenuItem tsmiPhotoPanel;
        private System.Windows.Forms.ToolStripMenuItem tsmiDescriptionPanel;
        private System.Windows.Forms.ToolStripMenuItem tsmiIconsPanel;
    }
}

