namespace PGPSteam
{
    partial class Generate
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
            this.grpKeyPair = new System.Windows.Forms.GroupBox();
            this.lblIdendity = new System.Windows.Forms.Label();
            this.txtIdendity = new System.Windows.Forms.TextBox();
            this.txtPassphrase = new System.Windows.Forms.TextBox();
            this.lblPassphrase = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.grpKeyPair.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpKeyPair
            // 
            this.grpKeyPair.Controls.Add(this.txtPassphrase);
            this.grpKeyPair.Controls.Add(this.lblPassphrase);
            this.grpKeyPair.Controls.Add(this.txtIdendity);
            this.grpKeyPair.Controls.Add(this.lblIdendity);
            this.grpKeyPair.Location = new System.Drawing.Point(12, 12);
            this.grpKeyPair.Name = "grpKeyPair";
            this.grpKeyPair.Size = new System.Drawing.Size(285, 107);
            this.grpKeyPair.TabIndex = 0;
            this.grpKeyPair.TabStop = false;
            this.grpKeyPair.Text = "Generate Keypair";
            // 
            // lblIdendity
            // 
            this.lblIdendity.AutoSize = true;
            this.lblIdendity.Location = new System.Drawing.Point(19, 33);
            this.lblIdendity.Name = "lblIdendity";
            this.lblIdendity.Size = new System.Drawing.Size(50, 13);
            this.lblIdendity.TabIndex = 0;
            this.lblIdendity.Text = "Idendity: ";
            // 
            // txtIdendity
            // 
            this.txtIdendity.Location = new System.Drawing.Point(75, 30);
            this.txtIdendity.Name = "txtIdendity";
            this.txtIdendity.Size = new System.Drawing.Size(204, 20);
            this.txtIdendity.TabIndex = 1;
            // 
            // txtPassphrase
            // 
            this.txtPassphrase.Location = new System.Drawing.Point(90, 65);
            this.txtPassphrase.Name = "txtPassphrase";
            this.txtPassphrase.PasswordChar = '•';
            this.txtPassphrase.Size = new System.Drawing.Size(189, 20);
            this.txtPassphrase.TabIndex = 3;
            // 
            // lblPassphrase
            // 
            this.lblPassphrase.AutoSize = true;
            this.lblPassphrase.Location = new System.Drawing.Point(19, 68);
            this.lblPassphrase.Name = "lblPassphrase";
            this.lblPassphrase.Size = new System.Drawing.Size(65, 13);
            this.lblPassphrase.TabIndex = 2;
            this.lblPassphrase.Text = "Passphrase:";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(222, 126);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 1;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(12, 126);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(75, 23);
            this.btnQuit.TabIndex = 2;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // Generate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 161);
            this.ControlBox = false;
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.grpKeyPair);
            this.Name = "Generate";
            this.Text = "Generate";
            this.grpKeyPair.ResumeLayout(false);
            this.grpKeyPair.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpKeyPair;
        private System.Windows.Forms.Label lblIdendity;
        private System.Windows.Forms.TextBox txtIdendity;
        private System.Windows.Forms.TextBox txtPassphrase;
        private System.Windows.Forms.Label lblPassphrase;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnQuit;
    }
}