using Steam4NET;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace PGPSteam
{
    public class App
    {
        #region Fields
        private ISteamClient010 m_SteamClient;
        private ISteamUser016 m_SteamUser;
        private ISteamFriends009 m_SteamFriends;
        private ISteamFriends002 m_SteamFriends002;
        private ISteamApps004 m_SteamApps;
        private ISteamUtils005 m_SteamUtils;
        private int m_Pipe;
        private int m_User;

        private Friends m_FriendsWindow;
        private Dictionary<CSteamID, Chat> m_ChatWindows;

        private Thread m_CallbackThread;
        private PGPLib m_PGP;
        #endregion

        #region Properties
        /// <summary>
        /// Gets the steam user
        /// </summary>
        public ISteamUser016 SteamUser
        {
            get
            {
                return m_SteamUser;
            }
        }

        /// <summary>
        /// Gets the steam client
        /// </summary>
        public ISteamClient010 SteamClient
        {
            get
            {
                return m_SteamClient;
            }
        }

        /// <summary>
        /// Gets the steam friends
        /// </summary>
        public ISteamFriends009 SteamFriends
        {
            get
            {
                return m_SteamFriends;
            }
        }

        /// <summary>
        /// Gets the steam apps
        /// </summary>
        public ISteamApps004 SteamApps
        {
            get
            {
                return m_SteamApps;
            }
        }

        /// <summary>
        /// Gets the steam utils
        /// </summary>
        public ISteamUtils005 SteamUtils
        {
            get
            {
                return m_SteamUtils;
            }
        }

        /// <summary>
        /// Get all friends
        /// </summary>
        public CSteamID[] Friends
        {
            get
            {
                // find friend count
                int friendCount = m_SteamFriends.GetFriendCount((int)EFriendFlags.k_EFriendFlagImmediate);

                // setup buffer
                CSteamID[] friends = new CSteamID[friendCount];

                // get all friends
                for (int i = 0; i < friendCount; i++)
                {
                    friends[i] = m_SteamFriends.GetFriendByIndex(i, (int)EFriendFlags.k_EFriendFlagImmediate);
                }

                return friends;
            }
        }

        /// <summary>
        /// Gets the persona
        /// </summary>
        public String Persona
        {
            get
            {
                // weird bug when getting persona while debugging :?
                if (System.Diagnostics.Debugger.IsAttached)
                {
                    return "Myself";
                }
                else
                {
                    return SteamFriends.GetPersonaName();
                }
            }
        }

        /// <summary>
        /// Gets the public key
        /// </summary>
        public String PublicKey
        {
            get
            {
                return File.ReadAllText("key_local/public.key");
            }
        }

        /// <summary>
        /// Gets the private key
        /// </summary>
        public String PrivateKey
        {
            get
            {
                return File.ReadAllText("key_local/private.key");
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Initialize steam stuff
        /// </summary>
        private void Init()
        {
            // load library
            if (!Steamworks.Load())
            {
                Error("Unable to load steam library");
            }

            // load client
            if (m_SteamClient == null)
            {
                m_SteamClient = Steamworks.CreateInterface<ISteamClient010>();

                if (m_SteamClient == null)
                {
                    Error("Unable to create steam client interface");
                }
            }

            // load tube
            if (m_Pipe == 0)
            {
                m_Pipe = m_SteamClient.CreateSteamPipe();

                if (m_Pipe == 0)
                {
                    Error("Unable to create tube");
                }
            }

            // load user
            if (m_User == 0)
            {
                m_User = m_SteamClient.ConnectToGlobalUser(m_Pipe);

                if (m_User == 0)
                {
                    Error("Unable to connect to user");
                }
            }

            // load steam user
            if (m_SteamUser == null)
            {
                m_SteamUser = m_SteamClient.GetISteamUser<ISteamUser016>(m_User, m_Pipe);

                if (m_SteamUser == null)
                {
                    Error("Unable to create steam user interface");
                }
            }

            // load steam friends
            if (m_SteamFriends == null)
            {
                m_SteamFriends = m_SteamClient.GetISteamFriends<ISteamFriends009>(m_User, m_Pipe);

                if (m_SteamFriends == null)
                {
                    Error("Unable to create steam friends interface");
                }
            }

            // load steam friends 002
            if (m_SteamFriends002 == null)
            {
                m_SteamFriends002 = m_SteamClient.GetISteamFriends<ISteamFriends002>(m_User, m_Pipe);

                if (m_SteamFriends002 == null)
                {
                    Error("Unable to create steam friends (002) interface");
                }
            }


            // load steam apps
            if (m_SteamApps == null)
            {
                m_SteamApps = m_SteamClient.GetISteamApps<ISteamApps004>(m_User, m_Pipe);

                if (m_SteamApps == null)
                {
                    Error("Unable to create steam apps interface");
                }
            }

            // load steam utils
            if (m_SteamUtils == null)
            {
                m_SteamUtils = m_SteamClient.GetISteamUtils<ISteamUtils005>(m_Pipe);

                if (m_SteamUtils == null)
                {
                    Error("Unable to create steam utils interface");
                }
            }
        }

        /// <summary>
        /// Runs the application
        /// </summary>
        public void Run()
        {
            // load pgp stuff
            m_PGP = new PGPLib(PublicKey, PrivateKey);

            // init steamworks stuff
            Init();

            // open friends window
            m_FriendsWindow = new Friends(this);

            // create stuff
            m_ChatWindows = new Dictionary<CSteamID, PGPSteam.Chat>();

            // start callback thread
            m_CallbackThread = new Thread(new ThreadStart(HandleCallback));
            m_CallbackThread.Start();
            
            // run application
            Application.Run(m_FriendsWindow);

            // abort callback thread
            m_CallbackThread.Abort();
        }

        /// <summary>
        /// Gets the image data
        /// </summary>
        /// <returns></returns>
        public Bitmap GetImage(int imageId)
        {
            // get image data from steam
            uint imageWidth = 0;
            uint imageHeight = 0;
            this.SteamUtils.GetImageSize(imageId, ref imageWidth, ref imageHeight);
            byte[] imageData = new byte[imageWidth * imageHeight];
            this.SteamUtils.GetImageRGBA(imageId, imageData, (int)imageWidth * (int)imageHeight);

            // convert to a bitmap
            Bitmap bitmap = new Bitmap((int)imageWidth, (int)imageHeight);
            Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            BitmapData bitmapData = bitmap.LockBits(rect, ImageLockMode.ReadWrite, bitmap.PixelFormat);
            IntPtr pointer = bitmapData.Scan0;
            Marshal.Copy(imageData, 0, pointer, imageData.Length);
            bitmap.UnlockBits(bitmapData);

            return bitmap;
        }

        /// <summary>
        /// Gets the persona of a steam user
        /// </summary>
        /// <param name="user">User</param>
        /// <returns></returns>
        public String GetPersona(CSteamID user)
        {
            // weird bug when getting persona while debugging :?
            if (System.Diagnostics.Debugger.IsAttached)
            {
                return "Friend";
            }
            else
            {
                return SteamFriends.GetFriendPersonaName(user);
            }
        }

        /// <summary>
        /// Opens a chat window for a friend
        /// </summary>
        /// <param name="friend">Friend</param>
        public void Chat(CSteamID friend)
        {
            if (!HasPublicKey(friend))
            {
                // warn user
                MessageBox.Show("No public key available for user!\n\nYou should request that the user sends you his/her public key", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (m_ChatWindows.ContainsKey(friend))
            {
                // focus existing window
                m_ChatWindows[friend].Focus();
            }
            else
            {
                // open new window
                PGPSteam.Chat chatWindow = new Chat(this, friend);
                chatWindow.Show();

                m_ChatWindows[friend] = chatWindow;
            }
        }

        /// <summary>
        /// Show a fatal error
        /// </summary>
        public void Error(String msg)
        {
            MessageBox.Show("Error: " + msg + "\n\n" + Environment.StackTrace, "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Application.Exit();
        }

        /// <summary>
        /// Send a message to a client
        /// </summary>
        /// <param name="client">Client</param>
        /// <param name="msg">Message</param>
        public void Send(CSteamID client, String msg)
        {
            byte[] bMsg = Encoding.UTF8.GetBytes(msg);
            m_SteamFriends002.SendMsgToFriend(client, EChatEntryType.k_EChatEntryTypeChatMsg, bMsg);
        }

        /// <summary>
        /// Send public key to client
        /// </summary>
        /// <param name="client">Client</param>
        public void SendKey(CSteamID client)
        {
            Send(client, PublicKey);
        }

        /// <summary>
        /// Request public key
        /// </summary>
        /// <param name="client">Client</param>
        public void RequestPublicKey(CSteamID client)
        {
            Send(client, "PGPSTEAM_REQUEST_KEY");
        }

        /// <summary>
        /// Check if public key cached
        /// </summary>
        /// <param name="client">Client</param>
        /// <returns>If has key</returns>
        public bool HasPublicKey(CSteamID client)
        {
            return File.Exists("key_cache/" + client.AccountID + ".key");
        }
        #endregion

        #region Constructors

        #endregion

        #region Events
        private void HandleCallback()
        {
            // cache for callback
            CallbackMsg_t callbackMsg = new CallbackMsg_t();

            while (true)
            {
                // get callback if available
                bool callbackAvailable = Steamworks.GetCallback(m_Pipe, ref callbackMsg);

                if (callbackAvailable)
                {
                    // process callback
                    switch(callbackMsg.m_iCallback)
                    {
                        case 805:
                            // convert to chat message callback
                            FriendChatMsg_t chatMsg = (FriendChatMsg_t)Marshal.PtrToStructure(callbackMsg.m_pubParam, typeof(FriendChatMsg_t));
                            
                            // setup buffers
                            byte[] bMsg = new byte[1024];
                            EChatEntryType eChatEntryType = (EChatEntryType)0;

                            // get chat message
                            int len = m_SteamFriends002.GetChatMessage((CSteamID)chatMsg.m_ulSender, (int)chatMsg.m_iChatID, bMsg, ref eChatEntryType);
                           
                            // get sender
                            CSteamID sender = (CSteamID)chatMsg.m_ulSender;

                            if (len > 0 && eChatEntryType == EChatEntryType.k_EChatEntryTypeChatMsg)
                            {
                                // decode message (excluding null terminator)
                                string msg = Encoding.UTF8.GetString(bMsg, 0, len - 1);

                                if (msg == "PGPSTEAM_REQUEST_KEY")
                                {
                                    // send public key
                                    SendKey(sender);
                                    break;
                                }
                                else if (msg.StartsWith("-----BEGIN PGP PUBLIC KEY BLOCK-----"))
                                {
                                    // cache public key
                                    File.WriteAllText("key_cache/" + sender.AccountID.ToString() + ".key", msg);
                                    break;
                                }
                                
                                
                                if (m_ChatWindows.ContainsKey((CSteamID)chatMsg.m_ulSender))
                                {
                                    // inject chat message
                                    m_ChatWindows[(CSteamID)chatMsg.m_ulSender].Message(msg);
                                }
                                else
                                {
                                    // open chat window
                                    Chat(sender);

                                    // inject chat message
                                    if (m_ChatWindows.ContainsKey(sender))
                                    {
                                        m_ChatWindows[sender].Message(msg);
                                    }
                                }
                            }
                            break;
                    }

                    // free callback
                    Steamworks.FreeLastCallback(m_Pipe);
                }
            }
        }
        #endregion
    }
}
