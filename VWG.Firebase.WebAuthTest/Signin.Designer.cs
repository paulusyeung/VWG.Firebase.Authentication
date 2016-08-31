namespace VWG.Firebase.WebAuthTest
{
    partial class Signin
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

        #region Visual WebGui Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Signin));
            this.cmdSignInEmail = new Gizmox.WebGUI.Forms.Button();
            this.cmdSignInFacebook = new Gizmox.WebGUI.Forms.Button();
            this.cmdSignInGoogle = new Gizmox.WebGUI.Forms.Button();
            this.txtPassword = new Gizmox.WebGUI.Forms.TextBox();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.txtUser = new Gizmox.WebGUI.Forms.TextBox();
            this.gbxSignIn = new Gizmox.WebGUI.Forms.GroupBox();
            this.pnlHeader = new Gizmox.WebGUI.Forms.Panel();
            this.gbxSignIn.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdSignInEmail
            // 
            this.cmdSignInEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(68)))), ((int)(((byte)(55)))));
            this.cmdSignInEmail.CustomStyle = "F";
            this.cmdSignInEmail.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.cmdSignInEmail.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cmdSignInEmail.ForeColor = System.Drawing.Color.White;
            this.cmdSignInEmail.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("cmdSignInEmail.Image"));
            this.cmdSignInEmail.Location = new System.Drawing.Point(45, 178);
            this.cmdSignInEmail.Name = "cmdSignInEmail";
            this.cmdSignInEmail.Padding = new Gizmox.WebGUI.Forms.Padding(10, 0, 10, 0);
            this.cmdSignInEmail.Size = new System.Drawing.Size(220, 40);
            this.cmdSignInEmail.TabIndex = 4;
            this.cmdSignInEmail.Text = " Sign in                     ";
            this.cmdSignInEmail.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSignInEmail.Click += new System.EventHandler(this.cmdSignInEmail_Click);
            // 
            // cmdSignInFacebook
            // 
            this.cmdSignInFacebook.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.cmdSignInFacebook.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cmdSignInFacebook.ForeColor = System.Drawing.Color.White;
            this.cmdSignInFacebook.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("cmdSignInFacebook.Image"));
            this.cmdSignInFacebook.Location = new System.Drawing.Point(45, 282);
            this.cmdSignInFacebook.Name = "cmdSignInFacebook";
            this.cmdSignInFacebook.Padding = new Gizmox.WebGUI.Forms.Padding(10, 0, 10, 0);
            this.cmdSignInFacebook.Size = new System.Drawing.Size(220, 40);
            this.cmdSignInFacebook.TabIndex = 6;
            this.cmdSignInFacebook.Text = " Sign in with Facebook";
            this.cmdSignInFacebook.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSignInFacebook.Click += new System.EventHandler(this.cmdSignInFacebook_Click);
            // 
            // cmdSignInGoogle
            // 
            this.cmdSignInGoogle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmdSignInGoogle.CustomStyle = "F";
            this.cmdSignInGoogle.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.cmdSignInGoogle.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cmdSignInGoogle.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("cmdSignInGoogle.Image"));
            this.cmdSignInGoogle.Location = new System.Drawing.Point(45, 232);
            this.cmdSignInGoogle.Name = "cmdSignInGoogle";
            this.cmdSignInGoogle.Padding = new Gizmox.WebGUI.Forms.Padding(10, 0, 10, 0);
            this.cmdSignInGoogle.Size = new System.Drawing.Size(220, 40);
            this.cmdSignInGoogle.TabIndex = 5;
            this.cmdSignInGoogle.Text = " Sign in with Google   ";
            this.cmdSignInGoogle.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSignInGoogle.Click += new System.EventHandler(this.cmdSignInGoogle_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtPassword.Location = new System.Drawing.Point(45, 128);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(220, 36);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.EnterKeyDown += new Gizmox.WebGUI.Forms.KeyEventHandler(this.txtPassword_EnterKeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(45, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(45, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "User";
            // 
            // txtUser
            // 
            this.txtUser.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtUser.Location = new System.Drawing.Point(45, 55);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(220, 36);
            this.txtUser.TabIndex = 1;
            this.txtUser.EnterKeyDown += new Gizmox.WebGUI.Forms.KeyEventHandler(this.txtUser_EnterKeyDown);
            // 
            // gbxSignIn
            // 
            this.gbxSignIn.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.gbxSignIn.Controls.Add(this.cmdSignInEmail);
            this.gbxSignIn.Controls.Add(this.cmdSignInFacebook);
            this.gbxSignIn.Controls.Add(this.cmdSignInGoogle);
            this.gbxSignIn.Controls.Add(this.txtPassword);
            this.gbxSignIn.Controls.Add(this.label2);
            this.gbxSignIn.Controls.Add(this.txtUser);
            this.gbxSignIn.Controls.Add(this.label1);
            this.gbxSignIn.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.gbxSignIn.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gbxSignIn.Location = new System.Drawing.Point(82, 122);
            this.gbxSignIn.Name = "gbxSignIn";
            this.gbxSignIn.Size = new System.Drawing.Size(306, 357);
            this.gbxSignIn.TabIndex = 0;
            this.gbxSignIn.TabStop = false;
            this.gbxSignIn.Text = "x5 Sign In";
            // 
            // pnlHeader
            // 
            this.pnlHeader.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(468, 47);
            this.pnlHeader.TabIndex = 1;
            // 
            // Signin
            // 
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.gbxSignIn);
            this.Size = new System.Drawing.Size(468, 640);
            this.Text = "Signin";
            this.Load += new System.EventHandler(this.Signin_Load);
            this.gbxSignIn.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Button cmdSignInEmail;
        private Gizmox.WebGUI.Forms.Button cmdSignInFacebook;
        private Gizmox.WebGUI.Forms.Button cmdSignInGoogle;
        private Gizmox.WebGUI.Forms.TextBox txtPassword;
        private Gizmox.WebGUI.Forms.Label label2;
        private Gizmox.WebGUI.Forms.Label label1;
        private Gizmox.WebGUI.Forms.TextBox txtUser;
        private Gizmox.WebGUI.Forms.GroupBox gbxSignIn;
        private Gizmox.WebGUI.Forms.Panel pnlHeader;
    }
}