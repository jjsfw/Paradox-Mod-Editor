namespace Paradox_Mod_Editor
{
    partial class frmModSelect
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
            this.radNew = new System.Windows.Forms.RadioButton();
            this.radEdit = new System.Windows.Forms.RadioButton();
            this.txtModDirectory = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.fbdModDirectory = new System.Windows.Forms.FolderBrowserDialog();
            this.btnCreateLoad = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // radNew
            // 
            this.radNew.AutoSize = true;
            this.radNew.Checked = true;
            this.radNew.Location = new System.Drawing.Point(13, 13);
            this.radNew.Name = "radNew";
            this.radNew.Size = new System.Drawing.Size(71, 17);
            this.radNew.TabIndex = 0;
            this.radNew.TabStop = true;
            this.radNew.Text = "New Mod";
            this.radNew.UseVisualStyleBackColor = true;
            this.radNew.CheckedChanged += new System.EventHandler(this.radNew_CheckedChanged);
            // 
            // radEdit
            // 
            this.radEdit.AutoSize = true;
            this.radEdit.Location = new System.Drawing.Point(13, 36);
            this.radEdit.Name = "radEdit";
            this.radEdit.Size = new System.Drawing.Size(67, 17);
            this.radEdit.TabIndex = 1;
            this.radEdit.Text = "Edit Mod";
            this.radEdit.UseVisualStyleBackColor = true;
            // 
            // txtModDirectory
            // 
            this.txtModDirectory.Location = new System.Drawing.Point(92, 56);
            this.txtModDirectory.Name = "txtModDirectory";
            this.txtModDirectory.Size = new System.Drawing.Size(602, 20);
            this.txtModDirectory.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Mod Directory:";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(700, 55);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(88, 22);
            this.btnBrowse.TabIndex = 4;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // fbdModDirectory
            // 
            this.fbdModDirectory.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // btnCreateLoad
            // 
            this.btnCreateLoad.Location = new System.Drawing.Point(13, 82);
            this.btnCreateLoad.Name = "btnCreateLoad";
            this.btnCreateLoad.Size = new System.Drawing.Size(775, 23);
            this.btnCreateLoad.TabIndex = 5;
            this.btnCreateLoad.Text = "Create Mod";
            this.btnCreateLoad.UseVisualStyleBackColor = true;
            this.btnCreateLoad.Click += new System.EventHandler(this.btnCreateLoad_Click);
            // 
            // frmModSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 121);
            this.Controls.Add(this.btnCreateLoad);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtModDirectory);
            this.Controls.Add(this.radEdit);
            this.Controls.Add(this.radNew);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmModSelect";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmModSelect";
            this.Load += new System.EventHandler(this.frmModSelect_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radNew;
        private System.Windows.Forms.RadioButton radEdit;
        private System.Windows.Forms.TextBox txtModDirectory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.FolderBrowserDialog fbdModDirectory;
        private System.Windows.Forms.Button btnCreateLoad;
    }
}