#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using System.Configuration;
using Gizmox.WebGUI.Forms.Authentication;

#endregion

namespace VWG.Firebase.WebAuthTest
{
    public partial class Signin : LogonForm
    {
        #region private properties
        private String _FormId;
        #endregion

        public Signin()
        {
            InitializeComponent();
        }

        private void Signin_Load(object sender, EventArgs e)
        {
            _FormId = ((RegisteredComponent)sender).ID.ToString();

            LoadAuthControl();
        }

        private void LoadAuthControl()
        {
            Authentication auth = new Authentication();

            //auth.BorderColor = Color.Gainsboro;
            //auth.BorderStyle = BorderStyle.FixedSingle;
            //auth.BorderWidth = new BorderWidth(1);
            auth.Dock = DockStyle.Fill;

            auth.OnSignInResult += Auth_OnSignInResult;
            pnlHeader.Controls.Add(auth);
        }

        private void Auth_OnSignInResult(object sender, EventArgs e)
        {
            Authentication auth = (Authentication)sender;
            if (auth.FbSignInOk)
            {
                // Sign In
                this.Context.Session.IsLoggedOn = true;
                VWGContext.Current.Transfer(new Desktop());
            }
            else
            {
                // Sign Out
            }
        }

        private void DoSignInWithEmail()
        {
            if ((txtUser.Text.Trim() != String.Empty) && (txtPassword.Text.Trim() != String.Empty))
            {
                Authentication auth = (Authentication)pnlHeader.Controls[0];
                auth.FbSignInMode = FirebaseSignInMode.Email;
                auth.SignInWithEmail(txtUser.Text, txtPassword.Text);
            }
        }

        private void txtUser_EnterKeyDown(object objSender, KeyEventArgs objArgs)
        {
            DoSignInWithEmail();
        }

        private void txtPassword_EnterKeyDown(object objSender, KeyEventArgs objArgs)
        {
            DoSignInWithEmail();
        }

        private void cmdSignInEmail_Click(object sender, EventArgs e)
        {
            DoSignInWithEmail();
        }

        private void cmdSignInFacebook_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not yet implemented...");
        }

        private void cmdSignInGoogle_Click(object sender, EventArgs e)
        {
            Authentication auth = (Authentication)pnlHeader.Controls[0];
            auth.FbSignInMode = FirebaseSignInMode.Google;
            auth.SignInWithGoogle();
        }
    }
}