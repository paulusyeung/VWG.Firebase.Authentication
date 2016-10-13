namespace VWG.Firebase.WebPushTest
{
    partial class Form1
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
            this.lblDeviceId = new Gizmox.WebGUI.Forms.Label();
            this.txtDeviceId = new Gizmox.WebGUI.Forms.TextBox();
            this.txtMessage = new Gizmox.WebGUI.Forms.TextBox();
            this.lblMessage = new Gizmox.WebGUI.Forms.Label();
            this.cmdSubmit = new Gizmox.WebGUI.Forms.Button();
            this.cmdViaPushSharp = new Gizmox.WebGUI.Forms.Button();
            this.txtUserAuth = new Gizmox.WebGUI.Forms.TextBox();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.txtUseKey = new Gizmox.WebGUI.Forms.TextBox();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.cmdWebPushPayload = new Gizmox.WebGUI.Forms.Button();
            this.SuspendLayout();
            // 
            // lblDeviceId
            // 
            this.lblDeviceId.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.lblDeviceId.AutoSize = true;
            this.lblDeviceId.Location = new System.Drawing.Point(78, 72);
            this.lblDeviceId.Name = "lblDeviceId";
            this.lblDeviceId.Size = new System.Drawing.Size(35, 13);
            this.lblDeviceId.TabIndex = 0;
            this.lblDeviceId.Text = "Device Id:";
            // 
            // txtDeviceId
            // 
            this.txtDeviceId.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.txtDeviceId.Location = new System.Drawing.Point(164, 69);
            this.txtDeviceId.Name = "txtDeviceId";
            this.txtDeviceId.Size = new System.Drawing.Size(391, 20);
            this.txtDeviceId.TabIndex = 1;
            // 
            // txtMessage
            // 
            this.txtMessage.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.txtMessage.Location = new System.Drawing.Point(164, 106);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Vertical;
            this.txtMessage.Size = new System.Drawing.Size(391, 99);
            this.txtMessage.TabIndex = 3;
            // 
            // lblMessage
            // 
            this.lblMessage.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(78, 109);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(35, 13);
            this.lblMessage.TabIndex = 2;
            this.lblMessage.Text = "Message:";
            // 
            // cmdSubmit
            // 
            this.cmdSubmit.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.cmdSubmit.Location = new System.Drawing.Point(446, 300);
            this.cmdSubmit.Name = "cmdSubmit";
            this.cmdSubmit.Size = new System.Drawing.Size(109, 31);
            this.cmdSubmit.TabIndex = 10;
            this.cmdSubmit.Text = "Submit";
            this.cmdSubmit.Click += new System.EventHandler(this.cmdSubmit_Click);
            // 
            // cmdViaPushSharp
            // 
            this.cmdViaPushSharp.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.cmdViaPushSharp.Location = new System.Drawing.Point(446, 346);
            this.cmdViaPushSharp.Name = "cmdViaPushSharp";
            this.cmdViaPushSharp.Size = new System.Drawing.Size(109, 31);
            this.cmdViaPushSharp.TabIndex = 11;
            this.cmdViaPushSharp.Text = "Push Sharp";
            this.cmdViaPushSharp.Click += new System.EventHandler(this.cmdViaPushSharp_Click);
            // 
            // txtUserAuth
            // 
            this.txtUserAuth.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.txtUserAuth.Location = new System.Drawing.Point(164, 221);
            this.txtUserAuth.Name = "txtUserAuth";
            this.txtUserAuth.Size = new System.Drawing.Size(391, 20);
            this.txtUserAuth.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 224);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "User Auth:";
            // 
            // txtUseKey
            // 
            this.txtUseKey.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.txtUseKey.Location = new System.Drawing.Point(164, 258);
            this.txtUseKey.Name = "txtUseKey";
            this.txtUseKey.Size = new System.Drawing.Size(391, 20);
            this.txtUseKey.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(78, 261);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "User Key";
            // 
            // cmdWebPushPayload
            // 
            this.cmdWebPushPayload.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.cmdWebPushPayload.Location = new System.Drawing.Point(164, 300);
            this.cmdWebPushPayload.Name = "cmdWebPushPayload";
            this.cmdWebPushPayload.Size = new System.Drawing.Size(109, 31);
            this.cmdWebPushPayload.TabIndex = 9;
            this.cmdWebPushPayload.Text = "Push (Payload)";
            this.cmdWebPushPayload.Click += new System.EventHandler(this.cmdWebPushPayload_Click);
            // 
            // Form1
            // 
            this.Controls.Add(this.cmdWebPushPayload);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUseKey);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtUserAuth);
            this.Controls.Add(this.cmdViaPushSharp);
            this.Controls.Add(this.cmdSubmit);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.txtDeviceId);
            this.Controls.Add(this.lblDeviceId);
            this.Size = new System.Drawing.Size(640, 480);
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label lblDeviceId;
        private Gizmox.WebGUI.Forms.TextBox txtDeviceId;
        private Gizmox.WebGUI.Forms.TextBox txtMessage;
        private Gizmox.WebGUI.Forms.Label lblMessage;
        private Gizmox.WebGUI.Forms.Button cmdSubmit;
        private Gizmox.WebGUI.Forms.Button cmdViaPushSharp;
        private Gizmox.WebGUI.Forms.TextBox txtUserAuth;
        private Gizmox.WebGUI.Forms.Label label1;
        private Gizmox.WebGUI.Forms.TextBox txtUseKey;
        private Gizmox.WebGUI.Forms.Label label2;
        private Gizmox.WebGUI.Forms.Button cmdWebPushPayload;
    }
}