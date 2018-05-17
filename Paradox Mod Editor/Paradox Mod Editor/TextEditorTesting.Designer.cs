namespace Paradox_Mod_Editor
{
    partial class frmTextEditorTesting
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
            this.imlAutoComplete = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // imlAutoComplete
            // 
            this.imlAutoComplete.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imlAutoComplete.ImageSize = new System.Drawing.Size(16, 16);
            this.imlAutoComplete.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // frmTextEditorTesting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "frmTextEditorTesting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TextEditorTesting";
            this.Load += new System.EventHandler(this.TextEditorTesting_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imlAutoComplete;
    }
}