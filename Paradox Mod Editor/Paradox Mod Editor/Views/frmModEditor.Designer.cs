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
            this.mnsMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mniNewFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mniSave = new System.Windows.Forms.ToolStripMenuItem();
            this.mniSaveAll = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.lineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bookmarkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.foldToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wrapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.findNextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findPreviousToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.replaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.highlightingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.coloursToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readOnlyBlocksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.mnsMenu.SuspendLayout();
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
            this.lstScriptObjects.SelectedIndexChanged += new System.EventHandler(this.lstScriptObjects_SelectedIndexChanged);
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
            this.pgrEditor.Enabled = false;
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
            // mnsMenu
            // 
            this.mnsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.findToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.preferencesToolStripMenuItem});
            this.mnsMenu.Location = new System.Drawing.Point(0, 0);
            this.mnsMenu.Name = "mnsMenu";
            this.mnsMenu.Size = new System.Drawing.Size(800, 24);
            this.mnsMenu.TabIndex = 5;
            this.mnsMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniNewFile,
            this.mniSave,
            this.saveAsToolStripMenuItem,
            this.mniSaveAll});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // mniNewFile
            // 
            this.mniNewFile.Name = "mniNewFile";
            this.mniNewFile.Size = new System.Drawing.Size(180, 22);
            this.mniNewFile.Text = "New";
            // 
            // mniSave
            // 
            this.mniSave.Name = "mniSave";
            this.mniSave.Size = new System.Drawing.Size(180, 22);
            this.mniSave.Text = "Save";
            // 
            // mniSaveAll
            // 
            this.mniSaveAll.Name = "mniSaveAll";
            this.mniSaveAll.Size = new System.Drawing.Size(180, 22);
            this.mniSaveAll.Text = "Save All";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.toolStripSeparator1,
            this.copyToolStripMenuItem,
            this.cutToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.toolStripSeparator2,
            this.lineToolStripMenuItem,
            this.commentToolStripMenuItem,
            this.textToolStripMenuItem,
            this.bookmarkToolStripMenuItem,
            this.foldToolStripMenuItem,
            this.wrapToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.redoToolStripMenuItem.Text = "Redo";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cutToolStripMenuItem.Text = "Cut";
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // lineToolStripMenuItem
            // 
            this.lineToolStripMenuItem.Name = "lineToolStripMenuItem";
            this.lineToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.lineToolStripMenuItem.Text = "Line";
            // 
            // commentToolStripMenuItem
            // 
            this.commentToolStripMenuItem.Name = "commentToolStripMenuItem";
            this.commentToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.commentToolStripMenuItem.Text = "Comment";
            // 
            // textToolStripMenuItem
            // 
            this.textToolStripMenuItem.Name = "textToolStripMenuItem";
            this.textToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.textToolStripMenuItem.Text = "Text";
            // 
            // bookmarkToolStripMenuItem
            // 
            this.bookmarkToolStripMenuItem.Name = "bookmarkToolStripMenuItem";
            this.bookmarkToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.bookmarkToolStripMenuItem.Text = "Bookmark";
            // 
            // foldToolStripMenuItem
            // 
            this.foldToolStripMenuItem.Name = "foldToolStripMenuItem";
            this.foldToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.foldToolStripMenuItem.Text = "Fold";
            // 
            // wrapToolStripMenuItem
            // 
            this.wrapToolStripMenuItem.Name = "wrapToolStripMenuItem";
            this.wrapToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.wrapToolStripMenuItem.Text = "Wrap";
            // 
            // findToolStripMenuItem
            // 
            this.findToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.findToolStripMenuItem1,
            this.findNextToolStripMenuItem,
            this.findPreviousToolStripMenuItem,
            this.toolStripSeparator3,
            this.replaceToolStripMenuItem});
            this.findToolStripMenuItem.Name = "findToolStripMenuItem";
            this.findToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.findToolStripMenuItem.Text = "Find";
            // 
            // findToolStripMenuItem1
            // 
            this.findToolStripMenuItem1.Name = "findToolStripMenuItem1";
            this.findToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.findToolStripMenuItem1.Text = "Find...";
            // 
            // findNextToolStripMenuItem
            // 
            this.findNextToolStripMenuItem.Name = "findNextToolStripMenuItem";
            this.findNextToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.findNextToolStripMenuItem.Text = "Find Next";
            // 
            // findPreviousToolStripMenuItem
            // 
            this.findPreviousToolStripMenuItem.Name = "findPreviousToolStripMenuItem";
            this.findPreviousToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.findPreviousToolStripMenuItem.Text = "Find Previous";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(177, 6);
            // 
            // replaceToolStripMenuItem
            // 
            this.replaceToolStripMenuItem.Name = "replaceToolStripMenuItem";
            this.replaceToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.replaceToolStripMenuItem.Text = "Replace...";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.highlightingToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // highlightingToolStripMenuItem
            // 
            this.highlightingToolStripMenuItem.Name = "highlightingToolStripMenuItem";
            this.highlightingToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.highlightingToolStripMenuItem.Text = "Highlighting";
            // 
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.coloursToolStripMenuItem,
            this.readOnlyBlocksToolStripMenuItem});
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.preferencesToolStripMenuItem.Text = "Preferences";
            // 
            // coloursToolStripMenuItem
            // 
            this.coloursToolStripMenuItem.Name = "coloursToolStripMenuItem";
            this.coloursToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.coloursToolStripMenuItem.Text = "Colours";
            // 
            // readOnlyBlocksToolStripMenuItem
            // 
            this.readOnlyBlocksToolStripMenuItem.Name = "readOnlyBlocksToolStripMenuItem";
            this.readOnlyBlocksToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.readOnlyBlocksToolStripMenuItem.Text = "Read-Only Blocks";
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
            this.Controls.Add(this.mnsMenu);
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
            this.mnsMenu.ResumeLayout(false);
            this.mnsMenu.PerformLayout();
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
        private System.Windows.Forms.MenuStrip mnsMenu;
        private System.Windows.Forms.SplitContainer spcListButtons;
        private System.Windows.Forms.ListBox lstScriptObjects;
        private System.Windows.Forms.SplitContainer spcButtons;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mniNewFile;
        private System.Windows.Forms.ToolStripMenuItem mniSave;
        private System.Windows.Forms.ToolStripMenuItem mniSaveAll;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem lineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem commentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem textToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bookmarkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem foldToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wrapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem findNextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findPreviousToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem replaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem highlightingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem coloursToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem readOnlyBlocksToolStripMenuItem;
    }
}