namespace Paradox_Mod_Editor.Views
{
    partial class frmModEditor
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
            this.trvModFolderStructure = new System.Windows.Forms.TreeView();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.pnlSpecialEdit = new System.Windows.Forms.Panel();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.pnlRawEdit = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // trvModFolderStructure
            // 
            this.trvModFolderStructure.Dock = System.Windows.Forms.DockStyle.Left;
            this.trvModFolderStructure.Location = new System.Drawing.Point(0, 0);
            this.trvModFolderStructure.Name = "trvModFolderStructure";
            this.trvModFolderStructure.Size = new System.Drawing.Size(216, 450);
            this.trvModFolderStructure.TabIndex = 0;
            this.trvModFolderStructure.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvModFolderStructure_AfterSelect);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(216, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 450);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // pnlSpecialEdit
            // 
            this.pnlSpecialEdit.BackColor = System.Drawing.SystemColors.Control;
            this.pnlSpecialEdit.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSpecialEdit.Location = new System.Drawing.Point(219, 0);
            this.pnlSpecialEdit.Name = "pnlSpecialEdit";
            this.pnlSpecialEdit.Size = new System.Drawing.Size(335, 450);
            this.pnlSpecialEdit.TabIndex = 2;
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(554, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 450);
            this.splitter2.TabIndex = 3;
            this.splitter2.TabStop = false;
            // 
            // pnlRawEdit
            // 
            this.pnlRawEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRawEdit.Location = new System.Drawing.Point(557, 0);
            this.pnlRawEdit.Name = "pnlRawEdit";
            this.pnlRawEdit.Size = new System.Drawing.Size(243, 450);
            this.pnlRawEdit.TabIndex = 4;
            // 
            // frmModEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlRawEdit);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.pnlSpecialEdit);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.trvModFolderStructure);
            this.Name = "frmModEditor";
            this.ShowIcon = false;
            this.Text = "Mod Editor";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmModEditor_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView trvModFolderStructure;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel pnlSpecialEdit;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Panel pnlRawEdit;
    }
}