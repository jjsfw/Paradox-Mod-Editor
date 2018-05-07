namespace Paradox_Mod_Editor
{
    partial class frmGameSelection
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
            this.btnCK2 = new System.Windows.Forms.Button();
            this.btnEU4 = new System.Windows.Forms.Button();
            this.btnHOI4 = new System.Windows.Forms.Button();
            this.btnStellaris = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCK2
            // 
            this.btnCK2.Location = new System.Drawing.Point(12, 12);
            this.btnCK2.Name = "btnCK2";
            this.btnCK2.Size = new System.Drawing.Size(123, 23);
            this.btnCK2.TabIndex = 0;
            this.btnCK2.Text = "Crusader Kings II";
            this.btnCK2.UseVisualStyleBackColor = true;
            this.btnCK2.Click += new System.EventHandler(this.btnCK2_Click);
            // 
            // btnEU4
            // 
            this.btnEU4.Location = new System.Drawing.Point(12, 41);
            this.btnEU4.Name = "btnEU4";
            this.btnEU4.Size = new System.Drawing.Size(123, 23);
            this.btnEU4.TabIndex = 1;
            this.btnEU4.Text = "Europa Universalis IV";
            this.btnEU4.UseVisualStyleBackColor = true;
            this.btnEU4.Click += new System.EventHandler(this.btnEU4_Click);
            // 
            // btnHOI4
            // 
            this.btnHOI4.Location = new System.Drawing.Point(12, 70);
            this.btnHOI4.Name = "btnHOI4";
            this.btnHOI4.Size = new System.Drawing.Size(123, 23);
            this.btnHOI4.TabIndex = 2;
            this.btnHOI4.Text = "Hearts of Iron IV";
            this.btnHOI4.UseVisualStyleBackColor = true;
            this.btnHOI4.Click += new System.EventHandler(this.btnHOI4_Click);
            // 
            // btnStellaris
            // 
            this.btnStellaris.Location = new System.Drawing.Point(12, 99);
            this.btnStellaris.Name = "btnStellaris";
            this.btnStellaris.Size = new System.Drawing.Size(123, 23);
            this.btnStellaris.TabIndex = 3;
            this.btnStellaris.Text = "Stellaris";
            this.btnStellaris.UseVisualStyleBackColor = true;
            this.btnStellaris.Click += new System.EventHandler(this.btnStellaris_Click);
            // 
            // frmGameSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(147, 132);
            this.Controls.Add(this.btnStellaris);
            this.Controls.Add(this.btnHOI4);
            this.Controls.Add(this.btnEU4);
            this.Controls.Add(this.btnCK2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmGameSelection";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Paradox Mod Editor";
            this.Load += new System.EventHandler(this.frmGameSelection_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCK2;
        private System.Windows.Forms.Button btnEU4;
        private System.Windows.Forms.Button btnHOI4;
        private System.Windows.Forms.Button btnStellaris;
    }
}

