#region Using

using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;


using Gizmox.WebGUI;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Resources;
using System.Web.Configuration;


#endregion

namespace VWG.Firebase
{
    /// <summary>
    /// Summary description for Notification
    /// </summary>
    [ToolboxItem(true)]
    //[ToolboxBitmapAttribute(typeof(Notification), "VWG.Firebase.Notification.bmp")]
    //[DesignTimeController("Gizmox.WebGUI.Forms.Design.PlaceHolderController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0 , Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    //[ClientController("Gizmox.WebGUI.Client.Controllers.PlaceHolderController, Gizmox.WebGUI.Client, Version=4.5.25701.0 , Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [Serializable()]
    //[MetadataTag("VWG.Firebase.Notification")]
    [Skin(typeof(NotificationSkin))]
    public partial class Notification : HtmlBox
    {
        public Notification()
        {

            InitializeComponent();
        }


        protected override void RenderAttributes(IContext context, IAttributeWriter writer)
        {
            base.RenderAttributes(context, writer);

            writer.WriteAttributeString(WGAttributes.Text, Text);
        }

        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                if (base.Text != value)
                {
                    base.Text = value;
                    this.Update();
                }
            }
        }

        #region Hiding HtmlBox properties

        // Prevent design time serialization and setting of certain HtmlBox properties that could interfere 
        // with XonomyBox's rendering.
        // 照抄 CKEditor

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override string Html { get { return ""; } }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsWindowless { get { return false; } }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override string Url { get { return ""; } }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override string Path { get { return ""; } }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Gizmox.WebGUI.Common.Resources.ResourceHandle Resource { get { return null; } }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public HtmlBoxType Type { get { return HtmlBoxType.HTML; } }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ContentType { get { return "text/html"; } }

        /// <summary>
        /// 直接 inject 啲 html page + Query Strings，原本唔想用 Query Strings，不過掂搞都用唔倒 client side javascript Data_GetAttribute
        /// </summary>
        protected override string Source
        {
            get
            {
                NotificationSkin fbNotiSkin = this.Skin as NotificationSkin;
                if (fbNotiSkin != null)
                {
                    // 將 NotificationSkin 入面嘅 index.html 轉換為 VWG 式 http url link
                    String src = (new SkinResourceHandle(typeof(VWG.Firebase.NotificationSkin), "index.html")).ToString();

                    // 讀取 web.config 入面嘅 Google / Firebase parameters
                    String fcmSenderId = WebConfigurationManager.AppSettings["FCM_SenderId"];
                    String fcmServerKey = WebConfigurationManager.AppSettings["FCM_ServerKey"];

                    // 組成 Url + QueryString
                    return String.Format("{0}?senderId={1}&serverKey={2}", src, fcmSenderId, fcmServerKey);
                }

                return base.Source;
            }
        }

        #endregion
    }
}