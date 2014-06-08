namespace PGPSteam
{
    partial class Login
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
            this.txtPassphrase = new System.Windows.Forms.TextBox();
            this.lblIdendity = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnRegenerate = new System.Windows.Forms.Button();
            this.grpKeyPair.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpKeyPair
            // 
            this.grpKeyPair.Controls.Add(this.txtPassphrase);
            this.grpKeyPair.Controls.Add(this.lblIdendity);
            this.grpKeyPair.Location = new System.Drawing.Point(12, 12);
            this.grpKeyPair.Name = "grpKeyPair";
            this.grpKeyPair.Size = new System.Drawing.Size(285, 70);
            this.grpKeyPair.TabIndex = 0;
            this.grpKeyPair.TabStop = false;
            this.grpKeyPair.Text = "Login Keypair";
            // 
            // txtPassphrase
            // 
            this.txtPassphrase.Location = new System.Drawing.Point(90, 30);
            this.txtPassphrase.Name = "txtPassphrase";
            this.txtPassphrase.Size = new System.Drawing.Size(189, 20);
            this.txtPassphrase.TabIndex = 1;
            // 
            // lblIdendity
            // 
            this.lblIdendity.AutoSize = true;
            this.lblIdendity.Location = new System.Drawing.Point(19, 33);
            this.lblIdendity.Name = "lblIdendity";
            this.lblIdendity.Size = new System.Drawing.Size(65, 13);
            this.lblIdendity.TabIndex = 0;
            this.lblIdendity.Text = "Passphrase:";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(222, 88);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 1;
            this.btnGenerate.Text = "Login";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(12, 88);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(75, 23);
            this.btnQuit.TabIndex = 2;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // btnRegenerate
            // 
            this.btnRegenerate.Location = new System.Drawing.Point(141, 88);
            this.btnRegenerate.Name = "btnRegenerate";
            this.btnRegenerate.Size = new System.Drawing.Size(75, 23);
            this.btnRegenerate.TabIndex = 3;
            this.btnRegenerate.Text = "Regenerate";
            this.btnRegenerate.UseVisualStyleBackColor = true;
            this.btnRegenerate.Click += new System.EventHandler(this.btnRegenerate_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 117);
            this.ControlBox = false;
            this.Controls.Add(this.btnRegenerate);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.grpKeyPair);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.grpKeyPair.ResumeLayout(false);
            this.grpKeyPair.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpKeyPair;
        private System.Windows.Forms.Label lblIdendity;
        private System.Windows.Forms.TextBox txtPassphrase;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Button btnRegenerate;
    }
}