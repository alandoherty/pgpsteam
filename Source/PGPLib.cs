using System;
using System.IO;

namespace PGPSteam
{
    public class PGPLib
    {
        #region Methods
        String m_PublicKey = null;
        String m_PrivateKey = null;
        #endregion

        #region Methods
        /// <summary>
        /// Encrypt some data using public key
        /// </summary>
        /// <param name="data">Data</param>
        public void Encrypt(byte[] data)
        {

        }

        /// <summary>
        /// Decrypt some data using private key
        /// </summary>
        /// <param name="data">Data</param>
        public void Decrypt(byte[] data)
        {

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
        public PGPLib(String publicKey, String privateKey)
        {
            m_PublicKey = publicKey;
            m_PrivateKey = privateKey;
        }
        #endregion
    }
}
