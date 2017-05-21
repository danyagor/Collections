namespace CollectionsProject.Forms
{
    partial class ForeignTableForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cmsItems = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsAddItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsEditItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsDeleteItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.tsmiItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAddItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEditItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeleteItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeView = new System.Windows.Forms.TreeView();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.rtbDescription = new System.Windows.Forms.RichTextBox();
            this.cmsTvAddItem = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsItems.SuspendLayout();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.cmsTvAddItem.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmsItems
            // 
            this.cmsItems.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsAddItem,
            this.cmsEditItem,
            this.cmsDeleteItem});
            this.cmsItems.Name = "cmsItems";
            this.cmsItems.Size = new System.Drawing.Size(204, 70);
            // 
            // cmsAddItem
            // 
            this.cmsAddItem.Name = "cmsAddItem";
            this.cmsAddItem.Size = new System.Drawing.Size(203, 22);
            this.cmsAddItem.Text = "Добавить предмет";
            this.cmsAddItem.Click += new System.EventHandler(this.AddItem_Click);
            // 
            // cmsEditItem
            // 
            this.cmsEditItem.Name = "cmsEditItem";
            this.cmsEditItem.Size = new System.Drawing.Size(203, 22);
            this.cmsEditItem.Text = "Редактировать предмет";
            this.cmsEditItem.Click += new System.EventHandler(this.EditItem_Click);
            // 
            // cmsDeleteItem
            // 
            this.cmsDeleteItem.Name = "cmsDeleteItem";
            this.cmsDeleteItem.Size = new System.Drawing.Size(203, 22);
            this.cmsDeleteItem.Text = "Удалить предмет";
            this.cmsDeleteItem.Click += new System.EventHandler(this.DeleteItem_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(777, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // tsmiItem
            // 
            this.tsmiItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAddItem,
            this.tsmiEditItem,
            this.tsmiDeleteItem});
            this.tsmiItem.Name = "tsmiItem";
            this.tsmiItem.Size = new System.Drawing.Size(67, 20);
            this.tsmiItem.Text = "Предмет";
            // 
            // tsmiAddItem
            // 
            this.tsmiAddItem.Name = "tsmiAddItem";
            this.tsmiAddItem.Size = new System.Drawing.Size(203, 22);
            this.tsmiAddItem.Text = "Добавить предмет";
            this.tsmiAddItem.Click += new System.EventHandler(this.AddItem_Click);
            // 
            // tsmiEditItem
            // 
            this.tsmiEditItem.Name = "tsmiEditItem";
            this.tsmiEditItem.Size = new System.Drawing.Size(203, 22);
            this.tsmiEditItem.Text = "Редактировать предмет";
            this.tsmiEditItem.Click += new System.EventHandler(this.EditItem_Click);
            // 
            // tsmiDeleteItem
            // 
            this.tsmiDeleteItem.Name = "tsmiDeleteItem";
            this.tsmiDeleteItem.Size = new System.Drawing.Size(203, 22);
            this.tsmiDeleteItem.Text = "Удалить предмет";
            this.tsmiDeleteItem.Click += new System.EventHandler(this.DeleteItem_Click);
            // 
            // treeView
            // 
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.Location = new System.Drawing.Point(0, 0);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(157, 437);
            this.treeView.TabIndex = 2;
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
            this.treeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_NodeMouseClick);
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 24);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.treeView);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainer.Size = new System.Drawing.Size(777, 437);
            this.splitContainer.SplitterDistance = 157;
            this.splitContainer.TabIndex = 3;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvItems);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.rtbDescription);
            this.splitContainer1.Size = new System.Drawing.Size(616, 437);
            this.splitContainer1.SplitterDistance = 332;
            this.splitContainer1.TabIndex = 1;
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
            this.dgvItems.ContextMenuStrip = this.cmsItems;
            this.dgvItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvItems.Location = new System.Drawing.Point(0, 0);
            this.dgvItems.MultiSelect = false;
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.ReadOnly = true;
            this.dgvItems.Size = new System.Drawing.Size(616, 332);
            this.dgvItems.TabIndex = 2;
            this.dgvItems.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItems_CellClick);
            this.dgvItems.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.EditItem_Click);
            // 
            // rtbDescription
            // 
            this.rtbDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbDescription.Location = new System.Drawing.Point(0, 0);
            this.rtbDescription.Name = "rtbDescription";
            this.rtbDescription.Size = new System.Drawing.Size(616, 101);
            this.rtbDescription.TabIndex = 0;
            this.rtbDescription.Text = "";
            // 
            // cmsTvAddItem
            // 
            this.cmsTvAddItem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.cmsTvAddItem.Name = "cmsItems";
            this.cmsTvAddItem.Size = new System.Drawing.Size(176, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(175, 22);
            this.toolStripMenuItem1.Text = "Добавить предмет";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.AddItem_Click);
            // 
            // ForeignTableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 461);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "ForeignTableForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ФОРМА РЕДАКТИРОВАНИЯ ВНЕШНИХ ТАБЛИЦ";
            this.Load += new System.EventHandler(this.ForeignTableForm_Load);
            this.cmsItems.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.cmsTvAddItem.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem tsmiItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiEditItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteItem;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.ContextMenuStrip cmsItems;
        private System.Windows.Forms.ToolStripMenuItem cmsAddItem;
        private System.Windows.Forms.ToolStripMenuItem cmsEditItem;
        private System.Windows.Forms.ToolStripMenuItem cmsDeleteItem;
        private System.Windows.Forms.ContextMenuStrip cmsTvAddItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox rtbDescription;
        private System.Windows.Forms.DataGridView dgvItems;
    }
}