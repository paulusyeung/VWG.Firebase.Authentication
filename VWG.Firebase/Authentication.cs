﻿#region Using

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
using Newtonsoft.Json;
using System.Web.Configuration;


#endregion

namespace VWG.Firebase
{
    /// <summary>
    /// Summary description for Authentication
    /// </summary>
    [ToolboxItem(true)]
    //[ToolboxBitmapAttribute(typeof(Authentication), "VWG.Firebase.Authentication.bmp")]
    //[DesignTimeController("Gizmox.WebGUI.Forms.Design.PlaceHolderController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0 , Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    //[ClientController("Gizmox.WebGUI.Client.Controllers.PlaceHolderController, Gizmox.WebGUI.Client, Version=4.5.25701.0 , Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [Serializable()]
    //[MetadataTag("VWG.Firebase.Authentication")]
    [Skin(typeof(AuthenticationSkin))]
    public partial class Authentication : HtmlBox
    {
        #region private properties
        private FirebaseUser _User = new FirebaseUser();
        private FirebaseProviderData _UserInfo = new FirebaseProviderData();
        private List<FirebaseProviderData> _ProviderData = new List<FirebaseProviderData>();
        private FirebaseCredential _Credential = new FirebaseCredential();
        private FirebaseSignInMode _SignInMode;
        private bool _SignInOk = false;
        #endregion

        public Authentication()
        {
            InitializeComponent();
        }

        protected override void RenderAttributes(IContext context, IAttributeWriter writer)
        {
            base.RenderAttributes(context, writer);

            writer.WriteAttributeString(WGAttributes.Text, Text);
        }

        // Auto-generated by VWG
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

        /// <summary>
        /// Callback from web client
        /// </summary>
        /// <param name="objEvent"></param>
        protected override void FireEvent(IEvent objEvent)
        {
            _SignInOk = false;
            var arg = objEvent["Value"];
            dynamic json = JsonConvert.DeserializeObject(arg);

            switch (objEvent.Type)
            {
                case "initApp":
                    break;
                case "IsSignedIn":
                    _SignInOk = true;
                    this.IsSignedIn(EventArgs.Empty);
                    break;
                case "signOut":
                    break;
                case "signInWithEmail":
                    _SignInOk = true;
                    DeserializeAuthResultWithEmail(json);
                    this.SignInResult(EventArgs.Empty);
                    break;
                case "signInWithGoogle":
                    _SignInOk = true;
                    DeserializeAuthResultWithGoogle(json);
                    this.SignInResult(EventArgs.Empty);
                    break;
                case "signInWithFacebook":
                    _SignInOk = true;
                    DeserializeAuthResultWithGoogle(json);
                    this.SignInResult(EventArgs.Empty);
                    break;
                case "signInFailed":
                    this.SignInResult(EventArgs.Empty);
                    break;
                default:
                    base.FireEvent(objEvent);
                    break;
            }
        }

        #region private functions
        private void DeserializeAuthResultWithEmail(dynamic user)
        {
            _User.uid = user.uid;
            _User.displayName = user.displayName;
            _User.email = user.email;
            _User.emailVerified = user.emailVerified;
            _User.isAnonymous = user.isAnonymous;
            _User.refreshToken = user.stsTokenManager.refreshToken;

            if (_User.providerData != null) _User.providerData.Clear();
            foreach (dynamic pdata in user.providerData)
            {
                FirebaseProviderData item = new FirebaseProviderData();
                item.uid = pdata.uid;
                item.displayName = pdata.displayName;
                item.photoURL = pdata.photoURL;
                item.email = pdata.email;
                item.providerId = pdata.providerId;

                _ProviderData.Add(item);
            }
            _User.providerData = _ProviderData;
            _User.providerId = (_User.providerData.Count > 0) ? _User.providerData[0].providerId : String.Empty;

            _UserInfo.displayName = (_User.providerData.Count > 0) ? _User.providerData[0].displayName : String.Empty;
            _UserInfo.email = (_User.providerData.Count > 0) ? _User.providerData[0].email : String.Empty;
            _UserInfo.photoURL = (_User.providerData.Count > 0) ? _User.providerData[0].photoURL : String.Empty;
            _UserInfo.providerId = (_User.providerData.Count > 0) ? _User.providerData[0].providerId : String.Empty;
            _UserInfo.uid = (_User.providerData.Count > 0) ? _User.providerData[0].uid : String.Empty;

            _Credential.idToken = String.Empty;
            _Credential.accessToken = String.Empty;
            _Credential.provider = String.Empty;
        }

        private void DeserializeAuthResultWithGoogle(dynamic json)
        {
            dynamic user = json.user;

            _User.uid = user.uid;
            _User.displayName = user.displayName;
            _User.email = user.email;
            _User.emailVerified = user.emailVerified;
            _User.isAnonymous = user.isAnonymous;
            _User.refreshToken = user.stsTokenManager.refreshToken;

            if (_User.providerData != null) _User.providerData.Clear();
            foreach (dynamic pdata in user.providerData)
            {
                FirebaseProviderData item = new FirebaseProviderData();
                item.uid = pdata.uid;
                item.displayName = pdata.displayName;
                item.photoURL = pdata.photoURL;
                item.email = pdata.email;
                item.providerId = pdata.providerId;

                _ProviderData.Add(item);
            }
            _User.providerData = _ProviderData;
            _User.providerId = (_User.providerData.Count > 0) ? _User.providerData[0].providerId : String.Empty;

            _UserInfo.displayName = (_User.providerData.Count > 0) ? _User.providerData[0].displayName : String.Empty;
            _UserInfo.email = (_User.providerData.Count > 0) ? _User.providerData[0].email : String.Empty;
            _UserInfo.photoURL = (_User.providerData.Count > 0) ? _User.providerData[0].photoURL : String.Empty;
            _UserInfo.providerId = (_User.providerData.Count > 0) ? _User.providerData[0].providerId : String.Empty;
            _UserInfo.uid = (_User.providerData.Count > 0) ? _User.providerData[0].uid : String.Empty;

            _Credential.idToken = json.credential.idToken;
            _Credential.accessToken = json.credential.accessToken;
            _Credential.provider = json.credential.provider;
        }
        #endregion

        #region Custom Properties
        public FirebaseUser FbUser
        {
            get { return _User; }
            set { _User = value; }
        }

        public FirebaseProviderData FbUserInfo
        {
            get { return _UserInfo; }
            set { _UserInfo = value; }
        }

        public FirebaseCredential FbCredential
        {
            get { return _Credential; }
            set { _Credential = value; }
        }

        public FirebaseSignInMode FbSignInMode
        {
            get { return _SignInMode; }
            set { _SignInMode = value; }
        }

        public bool FbSignInOk
        {
            get { return _SignInOk; }
            set { _SignInOk = value; }
        }
        #endregion

        #region Custom Methods

        /// <summary>
        /// Ask Firebase is the user signed in?
        /// Override OnIsSignedIn() Event to review the result
        /// </summary>
        public void IsSignedIn()
        {
            String script = String.Format("document.getElementById(\"TRG_{0}\").contentWindow.isSignedIn(\"VWG_{1}\");", this.ID.ToString(), this.ID.ToString());
            VWGClientContext.Current.Invoke(this, "eval", script);
        }

        public void SigneOut()
        {
            String script = String.Format("document.getElementById(\"TRG_{0}\").contentWindow.signOut(\"VWG_{1}\");", this.ID.ToString(), this.ID.ToString());
            VWGClientContext.Current.Invoke(this, "eval", script);
        }

        public void SignInWithEmail(String email, String password)
        {
            String script = String.Format("document.getElementById(\"TRG_{0}\").contentWindow.signInWithEmail(\"VWG_{1}\", \"{2}\", \"{3}\");", this.ID.ToString(), this.ID.ToString(), email, password);
            VWGClientContext.Current.Invoke(this, "eval", script);
        }

        public void SignInWithGoogle()
        {
            String script = String.Format("document.getElementById(\"TRG_{0}\").contentWindow.signInWithGoogle(\"VWG_{1}\");", this.ID.ToString(), this.ID.ToString());
            VWGClientContext.Current.Invoke(this, "eval", script);
        }

        public void SignInWithFacebook()
        {
            String script = String.Format("document.getElementById(\"TRG_{0}\").contentWindow.signInWithFacebook(\"VWG_{1}\");", this.ID.ToString(), this.ID.ToString());
            VWGClientContext.Current.Invoke(this, "eval", script);
        }
        #endregion

        #region Custom Events

        #region OnIsSignedIn Event: IsSignedIn 嘅 callback
        private static readonly SerializableEvent IsSignedInEvent = SerializableEvent.Register("OnIsSignedIn", typeof(EventHandler), typeof(Authentication));

        private EventHandler IsSignedInHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(Authentication.IsSignedInEvent);
            }
        }

        // 對內我採用跟 IsSignedIn public method 同名, 對外就用 OnIsSignedIn public event
        protected virtual void IsSignedIn(EventArgs e)
        {
            EventHandler objEventHandler = this.IsSignedInHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, new EventArgs());
            }
        }

        /// <summary>
        /// 當 calling IsSignedIn 時, callback 就係 OnIsSignedIn
        /// </summary>
        public event EventHandler OnIsSignedIn
        {
            add
            {
                this.AddCriticalHandler(Authentication.IsSignedInEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(Authentication.IsSignedInEvent, value);
            }
        }
        #endregion

        #region OnSignInWithEmail Event: SignInWithEmail 嘅 callback
        private static readonly SerializableEvent SignInWithEmailEvent = SerializableEvent.Register("OnSignInWithEmail", typeof(EventHandler), typeof(Authentication));

        private EventHandler SignInWithEmailHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(Authentication.SignInWithEmailEvent);
            }
        }

        // 對內我採用跟 SignInWithEmail public method 同名, 對外就用 OnSignInWithEmail public event
        protected virtual void SignInWithEmail(EventArgs e)
        {
            EventHandler objEventHandler = this.SignInWithEmailHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, new EventArgs());
            }
        }

        /// <summary>
        /// deprecated: 當 calling SignInWithEmail 時, callback 就係 OnSignInWithEmail
        /// </summary>
        public event EventHandler OnSignInWithEmail
        {
            add
            {
                this.AddCriticalHandler(Authentication.SignInWithEmailEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(Authentication.SignInWithEmailEvent, value);
            }
        }
        #endregion

        #region OnSignInResult Event: SignInWithEmail, SignInWithGoogle, SignInWithFacebook 嘅 callback
        private static readonly SerializableEvent SignInResultEvent = SerializableEvent.Register("OnSignInResult", typeof(EventHandler), typeof(Authentication));

        private EventHandler SignInResultHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(Authentication.SignInResultEvent);
            }
        }

        protected virtual void SignInResult(EventArgs e)
        {
            EventHandler objEventHandler = this.SignInResultHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, new EventArgs());
            }
        }

        /// <summary>
        /// 當 calling SignInWithEmail, SignInWithGoogle, SignInWithFacebook 時, callback 就係 OnSignInResult
        /// </summary>
        public event EventHandler OnSignInResult
        {
            add
            {
                this.AddCriticalHandler(Authentication.SignInResultEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(Authentication.SignInResultEvent, value);
            }
        }
        #endregion

        #region FbAuthOk Event: callback to parent
        private static readonly SerializableEvent FbAuthOkEvent = SerializableEvent.Register("FbAuthOk", typeof(EventHandler), typeof(Authentication));

        private EventHandler FbAuthOkHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(Authentication.FbAuthOkEvent);
            }
        }

        protected virtual void OnFbAuthOk(EventArgs e)
        {
            EventHandler objEventHandler = this.FbAuthOkHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, new EventArgs());
            }
        }

        /// <summary>
        /// deprecated: 用嘅時候記得要 create 這個 event
        /// </summary>
        public event EventHandler FbAuthOk
        {
            add
            {
                this.AddCriticalHandler(Authentication.FbAuthOkEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(Authentication.FbAuthOkEvent, value);
            }
        }
        #endregion


        #endregion

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
                AuthenticationSkin fbauthSkin = this.Skin as AuthenticationSkin;
                if (fbauthSkin != null)
                {
                    // 將 AuthenticationSkin 入面嘅 WebAuth.html 轉換為 VWG 式 http url link
                    String src = (new SkinResourceHandle(typeof(VWG.Firebase.AuthenticationSkin), "WebAuth.html")).ToString();

                    // 讀取 web.config 入面嘅 Firebase parameters
                    String apiKey = WebConfigurationManager.AppSettings["Firebase_ApiKey"];
                    String authDomain = WebConfigurationManager.AppSettings["Firebase_AuthDomain"];
                    String dbURL = WebConfigurationManager.AppSettings["Firebase_DatabaseURL"];
                    String storage  = WebConfigurationManager.AppSettings["Firebase_StorageBucket"];

                    // 組成 Url + QueryString
                    return String.Format("{0}?apiKey={1}&authDomain={2}&dbURL={3}&storage={4}", src, apiKey, authDomain, dbURL, storage);
                }

                return base.Source;
            }
        }

        #endregion
    }

    #region Custom Firebase Classes
    public class FirebaseProviderData
    {
        public String uid { get; set; }
        public String displayName { get; set; }
        public String photoURL { get; set; }
        public String email { get; set; }
        public String providerId { get; set; }
    }

    public class FirebaseUser
    {
        public String uid { get; set; }
        public String displayName { get; set; }
        public String photoURL { get; set; }
        public String email { get; set; }
        public bool emailVerified { get; set; }
        public bool isAnonymous { get; set; }
        public String refreshToken { get; set; }
        public IList<FirebaseProviderData> providerData { get; set; }
        public String providerId { get; set; }
    }

    public class FirebaseCredential
    {
        public String idToken { get; set; }
        public String accessToken { get; set; }
        public String provider { get; set; }
    }
    #endregion

    public enum FirebaseSignInMode
    {
        FirebaseUI,
        Email,
        Google,
        Facebook
    }
}