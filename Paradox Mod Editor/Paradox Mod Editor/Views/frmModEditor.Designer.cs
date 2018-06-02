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
            this.spcPropertiesList = new System.Windows.Forms.SplitContainer();
            this.spcListButtons = new System.Windows.Forms.SplitContainer();
            this.lstScriptObjects = new System.Windows.Forms.ListBox();
            this.spcButtons = new System.Windows.Forms.SplitContainer();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.pgrEditor = new System.Windows.Forms.PropertyGrid();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.pnlRawEdit = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.pnlSpecialEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcPropertiesList)).BeginInit();
            this.spcPropertiesList.Panel1.SuspendLayout();
            this.spcPropertiesList.Panel2.SuspendLayout();
            this.spcPropertiesList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcListButtons)).BeginInit();
            this.spcListButtons.Panel1.SuspendLayout();
            this.spcListButtons.Panel2.SuspendLayout();
            this.spcListButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcButtons)).BeginInit();
            this.spcButtons.Panel1.SuspendLayout();
            this.spcButtons.Panel2.SuspendLayout();
            this.spcButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // trvModFolderStructure
            // 
            this.trvModFolderStructure.Dock = System.Windows.Forms.DockStyle.Left;
            this.trvModFolderStructure.Location = new System.Drawing.Point(0, 24);
            this.trvModFolderStructure.Name = "trvModFolderStructure";
            this.trvModFolderStructure.Size = new System.Drawing.Size(216, 426);
            this.trvModFolderStructure.TabIndex = 0;
            this.trvModFolderStructure.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvModFolderStructure_AfterSelect);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(216, 24);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 426);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // pnlSpecialEdit
            // 
            this.pnlSpecialEdit.BackColor = System.Drawing.SystemColors.Control;
            this.pnlSpecialEdit.Controls.Add(this.spcPropertiesList);
            this.pnlSpecialEdit.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSpecialEdit.Location = new System.Drawing.Point(219, 24);
            this.pnlSpecialEdit.Name = "pnlSpecialEdit";
            this.pnlSpecialEdit.Size = new System.Drawing.Size(335, 426);
            this.pnlSpecialEdit.TabIndex = 2;
            // 
            // spcPropertiesList
            // 
            this.spcPropertiesList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcPropertiesList.Location = new System.Drawing.Point(0, 0);
            this.spcPropertiesList.Name = "spcPropertiesList";
            this.spcPropertiesList.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcPropertiesList.Panel1
            // 
            this.spcPropertiesList.Panel1.Controls.Add(this.spcListButtons);
            this.spcPropertiesList.Panel1MinSize = 50;
            // 
            // spcPropertiesList.Panel2
            // 
            this.spcPropertiesList.Panel2.Controls.Add(this.pgrEditor);
            this.spcPropertiesList.Panel2MinSize = 50;
            this.spcPropertiesList.Size = new System.Drawing.Size(335, 426);
            this.spcPropertiesList.SplitterDistance = 80;
            this.spcPropertiesList.SplitterWidth = 1;
            this.spcPropertiesList.TabIndex = 0;
            // 
            // spcListButtons
            // 
            this.spcListButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcListButtons.IsSplitterFixed = true;
            this.spcListButtons.Location = new System.Drawing.Point(0, 0);
            this.spcListButtons.Name = "spcListButtons";
            this.spcListButtons.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcListButtons.Panel1
            // 
            this.spcListButtons.Panel1.Controls.Add(this.lstScriptObjects);
            // 
            // spcListButtons.Panel2
            // 
            this.spcListButtons.Panel2.Controls.Add(this.spcButtons);
            this.spcListButtons.Size = new System.Drawing.Size(335, 80);
            this.spcListButtons.SplitterDistance = 51;
            this.spcListButtons.SplitterWidth = 1;
            this.spcListButtons.TabIndex = 0;
            this.spcListButtons.SizeChanged += new System.EventHandler(this.spcListButtons_SizeChanged);
            // 
            // lstScriptObjects
            // 
            this.lstScriptObjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstScriptObjects.FormattingEnabled = true;
            this.lstScriptObjects.Location = new System.Drawing.Point(0, 0);
            this.lstScriptObjects.Name = "lstScriptObjects";
            this.lstScriptObjects.Size = new System.Drawing.Size(335, 51);
            this.lstScriptObjects.TabIndex = 0;
            // 
            // spcButtons
            // 
            this.spcButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcButtons.IsSplitterFixed = true;
            this.spcButtons.Location = new System.Drawing.Point(0, 0);
            this.spcButtons.Name = "spcButtons";
            // 
            // spcButtons.Panel1
            // 
            this.spcButtons.Panel1.Controls.Add(this.btnAdd);
            // 
            // spcButtons.Panel2
            // 
            this.spcButtons.Panel2.Controls.Add(this.btnRemove);
            this.spcButtons.Size = new System.Drawing.Size(335, 28);
            this.spcButtons.SplitterDistance = 167;
            this.spcButtons.SplitterWidth = 1;
            this.spcButtons.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAdd.Location = new System.Drawing.Point(0, 0);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(167, 28);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add New";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRemove.Location = new System.Drawing.Point(0, 0);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(167, 28);
            this.btnRemove.TabIndex = 1;
            this.btnRemove.Text = "Remove Selected";
            this.btnRemove.UseVisualStyleBackColor = true;
            // 
            // pgrEditor
            // 
            this.pgrEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgrEditor.Location = new System.Drawing.Point(0, 0);
            this.pgrEditor.Name = "pgrEditor";
            this.pgrEditor.Size = new System.Drawing.Size(335, 345);
            this.pgrEditor.TabIndex = 0;
            this.pgrEditor.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.pgrEditor_PropertyValueChanged);
            this.pgrEditor.Click += new System.EventHandler(this.pgrEditor_Click);
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(554, 24);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 426);
            this.splitter2.TabIndex = 3;
            this.splitter2.TabStop = false;
            // 
            // pnlRawEdit
            // 
            this.pnlRawEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRawEdit.Location = new System.Drawing.Point(557, 24);
            this.pnlRawEdit.Name = "pnlRawEdit";
            this.pnlRawEdit.Size = new System.Drawing.Size(243, 426);
            this.pnlRawEdit.TabIndex = 4;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
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
            this.Controls.Add(this.menuStrip1);
            this.Name = "frmModEditor";
            this.ShowIcon = false;
            this.Text = "Mod Editor";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmModEditor_Load);
            this.pnlSpecialEdit.ResumeLayout(false);
            this.spcPropertiesList.Panel1.ResumeLayout(false);
            this.spcPropertiesList.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcPropertiesList)).EndInit();
            this.spcPropertiesList.ResumeLayout(false);
            this.spcListButtons.Panel1.ResumeLayout(false);
            this.spcListButtons.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcListButtons)).EndInit();
            this.spcListButtons.ResumeLayout(false);
            this.spcButtons.Panel1.ResumeLayout(false);
            this.spcButtons.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcButtons)).EndInit();
            this.spcButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView trvModFolderStructure;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel pnlSpecialEdit;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Panel pnlRawEdit;
        private System.Windows.Forms.PropertyGrid pgrEditor;
        private System.Windows.Forms.SplitContainer spcPropertiesList;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.SplitContainer spcListButtons;
        private System.Windows.Forms.ListBox lstScriptObjects;
        private System.Windows.Forms.SplitContainer spcButtons;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
    }
}