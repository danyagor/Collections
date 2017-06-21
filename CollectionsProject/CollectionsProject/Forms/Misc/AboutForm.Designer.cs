namespace CollectionsProject.Forms
{
    partial class AboutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.lTitle = new System.Windows.Forms.Label();
            this.lVersion = new System.Windows.Forms.Label();
            this.lAuthors = new System.Windows.Forms.Label();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.lCopyrights = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // lTitle
            // 
            this.lTitle.AutoSize = true;
            this.lTitle.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lTitle.Location = new System.Drawing.Point(98, 12);
            this.lTitle.Name = "lTitle";
            this.lTitle.Size = new System.Drawing.Size(133, 17);
            this.lTitle.TabIndex = 0;
            this.lTitle.Text = "Collections Project";
            // 
            // lVersion
            // 
            this.lVersion.AutoSize = true;
            this.lVersion.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lVersion.Location = new System.Drawing.Point(98, 36);
            this.lVersion.Name = "lVersion";
            this.lVersion.Size = new System.Drawing.Size(78, 17);
            this.lVersion.TabIndex = 1;
            this.lVersion.Text = "Версия: 1.0";
            // 
            // lAuthors
            // 
            this.lAuthors.AutoSize = true;
            this.lAuthors.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lAuthors.Location = new System.Drawing.Point(98, 58);
            this.lAuthors.Name = "lAuthors";
            this.lAuthors.Size = new System.Drawing.Size(108, 34);
            this.lAuthors.TabIndex = 2;
            this.lAuthors.Text = "Автор:\r\nДаниил Горячев";
            // 
            // pbLogo
            // 
            this.pbLogo.Image = global::CollectionsProject.Properties.Resources.Collection2;
            this.pbLogo.Location = new System.Drawing.Point(12, 12);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(80, 80);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLogo.TabIndex = 3;
            this.pbLogo.TabStop = false;
            // 
            // lCopyrights
            // 
            this.lCopyrights.AutoSize = true;
            this.lCopyrights.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lCopyrights.Location = new System.Drawing.Point(9, 105);
            this.lCopyrights.Name = "lCopyrights";
            this.lCopyrights.Size = new System.Drawing.Size(313, 17);
            this.lCopyrights.TabIndex = 4;
            this.lCopyrights.Text = "© 2015-2017 DG Company. Все права защищены.";
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 131);
            this.Controls.Add(this.lCopyrights);
            this.Controls.Add(this.pbLogo);
            this.Controls.Add(this.lAuthors);
            this.Controls.Add(this.lVersion);
            this.Controls.Add(this.lTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AboutForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "О программе";
            this.Load += new System.EventHandler(this.AboutForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lTitle;
        private System.Windows.Forms.Label lVersion;
        private System.Windows.Forms.Label lAuthors;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Label lCopyrights;
    }
}