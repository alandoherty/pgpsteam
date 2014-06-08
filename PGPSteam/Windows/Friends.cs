using Steam4NET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PGPSteam
{
    public partial class Friends : Form
    {
        #region Methods
        private App m_App;
        #endregion

        #region Constructors
        /// <summary>
        /// Create a new friends window
        /// </summary>
        /// <param name="app">Application</param>
        public Friends(App app)
        {
            // init components
            InitializeComponent();

            // load app context
            m_App = app;

            // get friends
            CSteamID[] friends = app.Friends;

            // build list
            int h = 10;

            foreach(CSteamID friend in friends)
            {
                // create panel
                Panel p = new Panel();
                p.Size = new Size(244, 50);
                p.Location = new Point(10, h);
                p.BackColor = Color.Black;
                p.Tag = friend;
                p.Click += new EventHandler(p_UsernameClicked);

                // contents
                PictureBox pAvatar = new PictureBox();
                pAvatar.SizeMode = PictureBoxSizeMode.StretchImage;
                pAvatar.Size = new System.Drawing.Size(48, 48);
                pAvatar.Location = new Point(2, 2);
                pAvatar.Click += new EventHandler(p_UsernameClicked);
                pAvatar.Tag = friend;

                int avatarImage = app.SteamFriends.GetSmallFriendAvatar(friend);
                pAvatar.Image = m_App.GetImage(avatarImage);

                Label pUsername = new Label();
                pUsername.AutoSize = true;
                pUsername.Text = m_App.GetPersona(friend);
                pUsername.Font = new Font("Arial", 12.0f, FontStyle.Regular);
                pUsername.ForeColor = Color.White;
                pUsername.Location = new Point(68, 10);
                pUsername.Click += new EventHandler(p_UsernameClicked);
                pUsername.Tag = friend;

                Button pRequestPublicKey = new Button();
                pRequestPublicKey.ForeColor = Color.White;
                pRequestPublicKey.Text = "Key";
                pRequestPublicKey.Size = new System.Drawing.Size(48, 48);
                pRequestPublicKey.Location = new Point(196, 2);
                pRequestPublicKey.Click += new EventHandler(p_RequestPublicKey);
                pRequestPublicKey.Tag = friend;

                p.Controls.Add(pRequestPublicKey);
                p.Controls.Add(pUsername);
                p.Controls.Add(pAvatar);
                pnlFriends.Controls.Add(p);
                
                h = h + 55;
            }
        }
        #endregion

        #region Events
        public void p_UsernameClicked(object sender, EventArgs e)
        {
            // open chat window
            m_App.Chat((CSteamID)((Control)sender).Tag);
        }

        public void p_RequestPublicKey(object sender, EventArgs e)
        {
            // send public key request
            m_App.RequestPublicKey((CSteamID)((Control)sender).Tag);
        }

        private void Friends_FormClosing(object sender, FormClosingEventArgs e)
        {
            // ensure application closes
            // weird bug keeps thread open sometimes
            Environment.Exit(0);
        }
        #endregion
    }
}
