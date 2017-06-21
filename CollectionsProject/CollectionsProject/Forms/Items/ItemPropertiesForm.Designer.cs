namespace CollectionsProject.Forms
{
    partial class ItemPropertiesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemPropertiesForm));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.mainPage = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.notePage = new System.Windows.Forms.TabPage();
            this.tbNote = new System.Windows.Forms.TextBox();
            this.photosPage = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.tbComment = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnAssign = new System.Windows.Forms.Button();
            this.lbPhotos = new System.Windows.Forms.ListBox();
            this.pbPhoto = new System.Windows.Forms.PictureBox();
            this.btnEditItem = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.mainPage.SuspendLayout();
            this.notePage.SuspendLayout();
            this.photosPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.mainPage);
            this.tabControl.Controls.Add(this.notePage);
            this.tabControl.Controls.Add(this.photosPage);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(384, 561);
            this.tabControl.TabIndex = 500;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // mainPage
            // 
            this.mainPage.BackColor = System.Drawing.Color.Transparent;
            this.mainPage.Controls.Add(this.flowLayoutPanel);
            this.mainPage.Location = new System.Drawing.Point(4, 22);
            this.mainPage.Name = "mainPage";
            this.mainPage.Padding = new System.Windows.Forms.Padding(3);
            this.mainPage.Size = new System.Drawing.Size(376, 535);
            this.mainPage.TabIndex = 0;
            this.mainPage.Text = "Общие";
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(370, 529);
            this.flowLayoutPanel.TabIndex = 501;
            this.flowLayoutPanel.WrapContents = false;
            this.flowLayoutPanel.Resize += new System.EventHandler(this.flowLayoutPanel_Resize);
            // 
            // notePage
            // 
            this.notePage.Controls.Add(this.tbNote);
            this.notePage.Location = new System.Drawing.Point(4, 22);
            this.notePage.Name = "notePage";
            this.notePage.Padding = new System.Windows.Forms.Padding(3);
            this.notePage.Size = new System.Drawing.Size(376, 535);
            this.notePage.TabIndex = 1;
            this.notePage.Text = "Описание";
            // 
            // tbNote
            // 
            this.tbNote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbNote.Location = new System.Drawing.Point(3, 3);
            this.tbNote.Multiline = true;
            this.tbNote.Name = "tbNote";
            this.tbNote.Size = new System.Drawing.Size(370, 529);
            this.tbNote.TabIndex = 503;
            // 
            // photosPage
            // 
            this.photosPage.Controls.Add(this.label1);
            this.photosPage.Controls.Add(this.tbComment);
            this.photosPage.Controls.Add(this.btnClear);
            this.photosPage.Controls.Add(this.btnAssign);
            this.photosPage.Controls.Add(this.lbPhotos);
            this.photosPage.Controls.Add(this.pbPhoto);
            this.photosPage.Location = new System.Drawing.Point(4, 22);
            this.photosPage.Name = "photosPage";
            this.photosPage.Size = new System.Drawing.Size(376, 535);
            this.photosPage.TabIndex = 2;
            this.photosPage.Text = "Фотографии";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 462);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Комментарий";
            // 
            // tbComment
            // 
            this.tbComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbComment.Location = new System.Drawing.Point(8, 478);
            this.tbComment.Name = "tbComment";
            this.tbComment.Size = new System.Drawing.Size(360, 20);
            this.tbComment.TabIndex = 505;
            this.tbComment.Leave += new System.EventHandler(this.tbComment_Leave);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(293, 504);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 507;
            this.btnClear.Text = "Очистить";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnAssign
            // 
            this.btnAssign.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAssign.Location = new System.Drawing.Point(8, 504);
            this.btnAssign.Name = "btnAssign";
            this.btnAssign.Size = new System.Drawing.Size(75, 23);
            this.btnAssign.TabIndex = 506;
            this.btnAssign.Text = "Загрузить";
            this.btnAssign.UseVisualStyleBackColor = true;
            this.btnAssign.Click += new System.EventHandler(this.btnAssign_Click);
            // 
            // lbPhotos
            // 
            this.lbPhotos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbPhotos.FormattingEnabled = true;
            this.lbPhotos.Items.AddRange(new object[] {
            "Фотография 1",
            "Фотография 2",
            "Фотография 3",
            "Фотография 4"});
            this.lbPhotos.Location = new System.Drawing.Point(8, 390);
            this.lbPhotos.Name = "lbPhotos";
            this.lbPhotos.Size = new System.Drawing.Size(360, 56);
            this.lbPhotos.TabIndex = 504;
            this.lbPhotos.SelectedIndexChanged += new System.EventHandler(this.lbPhotos_SelectedIndexChanged);
            // 
            // pbPhoto
            // 
            this.pbPhoto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPhoto.Location = new System.Drawing.Point(0, 0);
            this.pbPhoto.Name = "pbPhoto";
            this.pbPhoto.Size = new System.Drawing.Size(376, 384);
            this.pbPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPhoto.TabIndex = 1;
            this.pbPhoto.TabStop = false;
            // 
            // btnEditItem
            // 
            this.btnEditItem.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnEditItem.Location = new System.Drawing.Point(0, 561);
            this.btnEditItem.Name = "btnEditItem";
            this.btnEditItem.Size = new System.Drawing.Size(384, 23);
            this.btnEditItem.TabIndex = 502;
            this.btnEditItem.Text = "Редактирование предмета";
            this.btnEditItem.UseVisualStyleBackColor = true;
            this.btnEditItem.Click += new System.EventHandler(this.btnEditItem_Click);
            // 
            // ItemPropertiesForm
            // 
            this.AcceptButton = this.btnEditItem;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 584);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.btnEditItem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ItemPropertiesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Редактирование элемента";
            this.tabControl.ResumeLayout(false);
            this.mainPage.ResumeLayout(false);
            this.notePage.ResumeLayout(false);
            this.notePage.PerformLayout();
            this.photosPage.ResumeLayout(false);
            this.photosPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage mainPage;
        private System.Windows.Forms.TabPage notePage;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.TextBox tbNote;
        private System.Windows.Forms.Button btnEditItem;
        private System.Windows.Forms.TabPage photosPage;
        private System.Windows.Forms.PictureBox pbPhoto;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnAssign;
        private System.Windows.Forms.ListBox lbPhotos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbComment;
    }
}