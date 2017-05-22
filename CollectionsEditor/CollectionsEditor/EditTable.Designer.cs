namespace CollectionsEditor
{
    partial class EditTable
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
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbProgramName = new System.Windows.Forms.TextBox();
            this.tbBaseName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbFixedTable = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(120, 116);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(201, 116);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Имя в программе";
            // 
            // tbProgramName
            // 
            this.tbProgramName.Location = new System.Drawing.Point(15, 25);
            this.tbProgramName.Name = "tbProgramName";
            this.tbProgramName.Size = new System.Drawing.Size(261, 20);
            this.tbProgramName.TabIndex = 3;
            // 
            // tbBaseName
            // 
            this.tbBaseName.Location = new System.Drawing.Point(15, 64);
            this.tbBaseName.Name = "tbBaseName";
            this.tbBaseName.Size = new System.Drawing.Size(261, 20);
            this.tbBaseName.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Имя в базе";
            // 
            // cbFixedTable
            // 
            this.cbFixedTable.AutoSize = true;
            this.cbFixedTable.Location = new System.Drawing.Point(15, 90);
            this.cbFixedTable.Name = "cbFixedTable";
            this.cbFixedTable.Size = new System.Drawing.Size(153, 17);
            this.cbFixedTable.TabIndex = 6;
            this.cbFixedTable.Text = "Фиксированная таблица";
            this.cbFixedTable.UseVisualStyleBackColor = true;
            // 
            // EditTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 152);
            this.Controls.Add(this.cbFixedTable);
            this.Controls.Add(this.tbBaseName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbProgramName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "EditTable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ФОРМА РЕДАКТИРОВАНИЯ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbProgramName;
        private System.Windows.Forms.TextBox tbBaseName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbFixedTable;
    }
}