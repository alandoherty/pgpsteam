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
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PGPSteam
{
    public partial class Generate : Form
    {
        #region Fields
        private String m_Idendity;
        private String m_Passphrase;
        #endregion

        #region Properties
        /// <summary>
        /// Gets the idendity
        /// </summary>
        public String Idendity
        {
            get
            {
                return m_Idendity;
            }
        }

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
        /// Generate a private/public keypair
        /// </summary>
        /// <param name="privatePath">Private Path</param>
        /// <param name="publicPath">Public Path</param>
        public static bool GenerateKeypair(String privatePath, String publicPath)
        {
            Generate gen = new Generate();
            gen.ShowDialog();

            if (gen.DialogResult == System.Windows.Forms.DialogResult.Cancel)
            {
                return false;
            }
            else
            {
                IAsymmetricCipherKeyPairGenerator kpg = new RsaKeyPairGenerator();
                kpg.Init(new RsaKeyGenerationParameters(BigInteger.ValueOf(0x13), new SecureRandom(), 1024, 8));
                AsymmetricCipherKeyPair kp = kpg.GenerateKeyPair();

                FileStream privOut = new FileInfo(privatePath).OpenWrite();
                FileStream pubOut = new FileInfo(publicPath).OpenWrite();

                Stream privateOut = new ArmoredOutputStream(privOut);
                Stream publicOut = pubOut;

                PgpSecretKey privateKey = new PgpSecretKey(
                    PgpSignature.DefaultCertification,
                    PublicKeyAlgorithmTag.RsaGeneral,
                    kp.Public,
                    kp.Private,
                    DateTime.Now,
                    gen.Idendity,
                    SymmetricKeyAlgorithmTag.Cast5,
                    gen.Passphrase.ToCharArray(),
                    null,
                    null,
                     new SecureRandom()
                );

                privateKey.Encode(privateOut);
                privOut.Close();

                publicOut = new ArmoredOutputStream(publicOut);
                PgpPublicKey key = privateKey.PublicKey;
                key.Encode(publicOut);

                pubOut.Close();
                return true;
            }
        }
        #endregion

        #region Constructors
        public Generate()
        {
            InitializeComponent();
        }
        #endregion

        #region Events
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            m_Idendity = txtIdendity.Text;
            m_Passphrase = txtPassphrase.Text;
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }
        #endregion
    }
}
