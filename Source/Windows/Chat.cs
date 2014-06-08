using Steam4NET;
using System;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;

namespace PGPSteam
{
    public partial class Chat : Form
    {
        #region Fields
        private App m_App;
        private CSteamID m_Friend;
        #endregion

        #region Properties
        /// <summary>
        /// Gets the friend for this chat window
        /// </summary>
        public CSteamID Friend
        {
            get
            {
                return m_Friend;
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Inject a message
        /// </summary>
        /// <param name="msg">Message</param>
        public void Message(String msg)
        {
            txtChatLog.Text += m_App.GetPersona(m_Friend) + ": " + msg + Environment.NewLine;
        }

        /// <summary>
        /// Send a message
        /// </summary>
        /// <param name="msg">Message</param>
        public void Send(String msg)
        {
            txtChatLog.Text += m_App.Persona + ": " + msg + Environment.NewLine;
            msg = Convert.ToBase64String(Encoding.UTF8.GetBytes(msg));
            m_App.Send(m_Friend, msg);
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Create a new chat window
        /// </summary>
        /// <param name="app">Application</param>
        /// <param name="friend">Friend</param>
        public Chat(App app, CSteamID friend)
        {
            // init components
            InitializeComponent();

            // load app context
            m_App = app;

            // load friend context
            m_Friend = friend;

            // set title
            Text = "Chat - " + m_App.GetPersona(friend);
        }
        #endregion

        #region Events
        private void btnSend_Click(object sender, EventArgs e)
        {
            Send(txtMessage.Text);
            txtMessage.Text = "";
        }

        private void txtMessage_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Send(txtMessage.Text);
                txtMessage.Text = "";
            }
        }
        #endregion
    }
}
