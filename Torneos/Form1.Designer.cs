namespace Torneos {
    partial class Main {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent() {
            this.newT = new System.Windows.Forms.Button();
            this.openFile = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // newT
            // 
            this.newT.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.newT.Location = new System.Drawing.Point(322, 214);
            this.newT.Name = "newT";
            this.newT.Size = new System.Drawing.Size(75, 23);
            this.newT.TabIndex = 0;
            this.newT.Text = "New";
            this.newT.UseVisualStyleBackColor = true;
            this.newT.Click += new System.EventHandler(this.newT_Click);
            // 
            // openFile
            // 
            this.openFile.Location = new System.Drawing.Point(403, 214);
            this.openFile.Name = "openFile";
            this.openFile.Size = new System.Drawing.Size(75, 23);
            this.openFile.TabIndex = 1;
            this.openFile.Text = "Open";
            this.openFile.UseVisualStyleBackColor = true;
            this.openFile.Click += new System.EventHandler(this.openFile_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.openFile);
            this.Controls.Add(this.newT);
            this.Name = "Main";
            this.Text = "Main";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button newT;
        private System.Windows.Forms.Button openFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

