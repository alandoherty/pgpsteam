using Org.BouncyCastle.Bcpg;
using Org.BouncyCastle.Bcpg.OpenPgp;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace PGPSteam
{
    public partial class Login : Form
    {
        #region Fields
        private String m_Passphrase;
        #endregion

        #region Properties

        /// <summary>
        /// Gets the passphrase
        /// </summary>
        public string Passphrase
        {
            get
            {
                return m_Passphrase;
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Login and get passphrase
        /// </summary>
        public static String LoginKeypair()
        {
            Login log = new Login();
            log.ShowDialog();

            if (log.DialogResult == System.Windows.Forms.DialogResult.Cancel)
            {
                return null;
            }
            else
            {
                return log.Passphrase;
            }
        }
        #endregion

        #region Constructors
        public Login()
        {
            InitializeComponent();
        }
        #endregion

        #region Events
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            m_Passphrase = txtPassphrase.Text;
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void btnRegenerate_Click(object sender, EventArgs e)
        {
            Hide();

            // delete existing
            File.Delete("key_local/private.key");
            File.Delete("key_local/public.key");

            // regenerate
            bool valid = Generate.GenerateKeypair("key_local/private.key", "key_local/public.key");

            Show();
        }
        #endregion
    }
}
