namespace PGPSteam
{
    partial class Friends
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
            this.pnlFriends = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnlFriends
            // 
            this.pnlFriends.AutoScroll = true;
            this.pnlFriends.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFriends.Location = new System.Drawing.Point(0, 0);
            this.pnlFriends.Name = "pnlFriends";
            this.pnlFriends.Size = new System.Drawing.Size(284, 361);
            this.pnlFriends.TabIndex = 0;
            // 
            // Friends
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 361);
            this.Controls.Add(this.pnlFriends);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Friends";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Friends";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Friends_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFriends;
    }
}