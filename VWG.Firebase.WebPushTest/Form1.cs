#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

using System.Web.Script.Serialization;
using Microsoft.AspNetCore.WebUtilities;
#endregion

namespace VWG.Firebase.WebPushTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void cmdSubmit_Click(object sender, EventArgs e)
        {
            if ((txtDeviceId.Text.Trim() != String.Empty) && (txtMessage.Text.Trim() != String.Empty))
            {
                String fcmSenderId = ConfigurationManager.AppSettings["FCM_SenderId"];
                String fcmServerKey = ConfigurationManager.AppSettings["FCM_ServerKey"];

                String endpoint = txtDeviceId.Text.Trim();
                String [] endpointParts = endpoint.Split('/');
                String deviceId = (endpointParts.Length > 1) ? endpointParts[endpointParts.Length - 1] : endpoint;

                var result = WebPush.SendNotification(fcmServerKey, fcmSenderId, deviceId, txtMessage.Text);
            }
        }

        private void cmdViaPushSharp_Click(object sender, EventArgs e)
        {
            if ((txtDeviceId.Text.Trim() != String.Empty) && (txtMessage.Text.Trim() != String.Empty))
            {
                String fcmSenderId = ConfigurationManager.AppSettings["FCM_SenderId"];
                String fcmServerKey = ConfigurationManager.AppSettings["FCM_ServerKey"];

                String endpoint = txtDeviceId.Text.Trim();
                String [] endpointParts = endpoint.Split('/');
                String deviceId = (endpointParts.Length > 1) ? endpointParts[endpointParts.Length - 1] : endpoint;

                WebPush.ViaPushSharp(fcmServerKey, fcmSenderId, deviceId, txtMessage.Text);
            }
        }

        private void cmdSubmit_FF_Click(object sender, EventArgs e)
        {
            if ((txtDeviceId.Text.Trim() != String.Empty) && (txtMessage.Text.Trim() != String.Empty))
            {
                String fcmSenderId = ConfigurationManager.AppSettings["FCM_SenderId"];
                String fcmServerKey = ConfigurationManager.AppSettings["FCM_ServerKey"];

                var result = WebPush.SendNotification_Firefox(fcmServerKey, fcmSenderId, txtDeviceId.Text.Trim(), txtMessage.Text);
            }
        }

        private void cmdWebPushPayload_Click(object sender, EventArgs e)
        {
            if ((txtDeviceId.Text.Trim() != String.Empty) && (txtMessage.Text.Trim() != String.Empty))
            {
                String fb_ApiKey = ConfigurationManager.AppSettings["Firebase_ApiKey"];

                String endpoint = txtDeviceId.Text.Trim();
                String message = txtMessage.Text.Trim();

                byte[] payload = Encoding.ASCII.GetBytes(message);

                String[] endpointParts = endpoint.Split('/');
                String deviceId = (endpointParts.Length > 1) ? endpointParts[endpointParts.Length - 1] : endpoint;

                var data = new
                {
                    to = deviceId,
                    notification = new
                    {
                        body = message,
                        title = "Send via WebPushHelper",
                        icon = "myIconUrl"
                    },
                    priority = "high"
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(data);

                //byte[] byteArray = Encoding.UTF8.GetBytes(json);

                //byte[] userAuth = WebEncoders.Base64UrlDecode(txtUserAuth.Text.Trim());

                //byte[] userKey = WebEncoders.Base64UrlDecode(txtUseKey.Text.Trim());

                //WebPushHelper.SendNotification(endpoint, userKey, userAuth, byteArray, 0, 0, false);

                WebPushHelper.SendNotification(endpoint, json, txtUseKey.Text.Trim(), txtUserAuth.Text.Trim(), 0, 0, false);
            }
        }
    }
}