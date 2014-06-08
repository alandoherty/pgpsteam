using Org.BouncyCastle.Bcpg;
using Org.BouncyCastle.Bcpg.OpenPgp;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PGPSteam
{
    public class PGPLib
    {
        #region Methods
        String m_PublicKey = null;
        String m_PrivateKey = null;
        String m_PrivateKeyPassword = null;
        #endregion

        #region Methods
        /// <summary>
        /// Encrypt some data using public key
        /// </summary>
        /// <param name="data">Data</param>
        public String Encrypt(String data)
        {
            using (Stream stream = m_PublicKey.Streamify())
            {
                var key = stream.ImportPublicKey();
                using (var clearStream = data.Streamify())
                using (var cryptoStream = new MemoryStream())
                {
                    clearStream.PgpEncrypt(cryptoStream, key);
                    cryptoStream.Position = 0;
                    return cryptoStream.Stringify();
                }
            }
        }

        /// <summary>
        /// Decrypt some data using private key
        /// </summary>
        /// <param name="data">Data</param>
        public String Decrypt(String data)
        {
            using (var cryptoStream = data.Streamify())
            using (var clearStream = new MemoryStream())
            {
                cryptoStream.PgpDecrypt(m_PrivateKey, m_PrivateKeyPassword);
                return cryptoStream.Stringify();
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Create a PGP Library instance
        /// </summary>
        /// <param name="publicKey">Public key</param>
        public PGPLib(String publicKey)
        {
            m_PublicKey = publicKey;
        }

        /// <summary>
        /// Create a PGP Library instance
        /// </summary>
        /// <param name="publicKey">Public key</param>
        /// <param name="privateKey">Private key</param>
        /// <param name="privateKeyPassword">Private key password</param>
        public PGPLib(String publicKey, String privateKey, String privateKeyPassword)
        {
            m_PublicKey = publicKey;
            m_PrivateKey = privateKey;
            m_PrivateKeyPassword = privateKeyPassword;
        }
        #endregion
    }
}
