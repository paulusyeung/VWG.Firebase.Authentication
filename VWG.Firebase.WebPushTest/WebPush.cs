using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

using PushSharp.Core;
using PushSharp.Google;
using Newtonsoft.Json.Linq;

namespace VWG.Firebase.WebPushTest
{
    public class WebPush
    {
        public static WebPushStatus SendNotification(string serverApiKey, string senderId, string deviceId, string message)
        {
            WebPushStatus result = new WebPushStatus();

            try
            {
                result.Successful = false;
                result.Error = null;

                var value = message;
                WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                tRequest.Method = "post";
                //tRequest.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
                tRequest.ContentType = "application/json";
                tRequest.Headers.Add(string.Format("Authorization: key={0}", serverApiKey));
                tRequest.Headers.Add(string.Format("Sender: id={0}", senderId));

                //string postData = "collapse_key=score_update&time_to_live=108&delay_while_idle=1&data.message=" + value + "&data.time=" + System.DateTime.Now.ToString() + "&registration_id=" + deviceId + "";

                var data = new
                {
                    to = deviceId,
                    notification = new
                    {
                        body = message,
                        title = "This is the data",
                        icon = "myicon"
                    },
                    priority = "high"
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(data);

                //Byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                Byte[] byteArray = Encoding.UTF8.GetBytes(json);

                tRequest.ContentLength = byteArray.Length;

                using (Stream dataStream = tRequest.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);

                    using (WebResponse tResponse = tRequest.GetResponse())
                    {
                        using (Stream dataStreamResponse = tResponse.GetResponseStream())
                        {
                            using (StreamReader tReader = new StreamReader(dataStreamResponse))
                            {
                                String sResponseFromServer = tReader.ReadToEnd();
                                result.Response = sResponseFromServer;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Successful = false;
                result.Response = null;
                result.Error = ex;
            }

            return result;
        }

        public static WebPushStatus SendNotification_Firefox(string serverApiKey, string senderId, string deviceId, string message)
        {
            WebPushStatus result = new WebPushStatus();

            try
            {
                result.Successful = false;
                result.Error = null;

                var value = message;
                WebRequest tRequest = WebRequest.Create("https://updates.push.services.mozilla.com/wpush/v1");
                tRequest.Method = "post";
                //tRequest.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
                tRequest.ContentType = "application/json";
                tRequest.Headers.Add(string.Format("Authorization: key={0}", serverApiKey));
                tRequest.Headers.Add(string.Format("Sender: id={0}", senderId));

                //string postData = "collapse_key=score_update&time_to_live=108&delay_while_idle=1&data.message=" + value + "&data.time=" + System.DateTime.Now.ToString() + "&registration_id=" + deviceId + "";

                var data = new
                {
                    registration_ids = deviceId,
                    data = new
                    {
                        body = message,
                        title = "This is the data",
                        icon = "myicon"
                    },
                    priority = "high"
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(data);

                //Byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                Byte[] byteArray = Encoding.UTF8.GetBytes(json);

                tRequest.ContentLength = byteArray.Length;

                using (Stream dataStream = tRequest.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);

                    using (WebResponse tResponse = tRequest.GetResponse())
                    {
                        using (Stream dataStreamResponse = tResponse.GetResponseStream())
                        {
                            using (StreamReader tReader = new StreamReader(dataStreamResponse))
                            {
                                String sResponseFromServer = tReader.ReadToEnd();
                                result.Response = sResponseFromServer;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Successful = false;
                result.Response = null;
                result.Error = ex;
            }

            return result;
        }

        public static void ViaPushSharp(string serverApiKey, string senderId, string deviceId, string message)
        {
            String[] MY_REGISTRATION_IDS = { deviceId };

            // Configuration
            //var config = new GcmConfiguration("GCM-SENDER-ID", "AUTH-TOKEN", null);
            var config = new GcmConfiguration(senderId, serverApiKey, null);

            // Firebase hack
            config.GcmUrl = "https://fcm.googleapis.com/fcm/send";

            // Create a new broker
            var gcmBroker = new GcmServiceBroker(config);

            #region Wire up events: OnNotificationFailed, OnNotificationSucceeded
            gcmBroker.OnNotificationFailed += (notification, aggregateEx) => {

                aggregateEx.Handle(ex => {

                    // See what kind of exception it was to further diagnose
                    if (ex is GcmNotificationException)
                    {
                        var notificationException = (GcmNotificationException)ex;

                        // Deal with the failed notification
                        var gcmNotification = notificationException.Notification;
                        var description = notificationException.Description;

                        Console.WriteLine($"GCM Notification Failed: ID={gcmNotification.MessageId}, Desc={description}");
                    }
                    else if (ex is GcmMulticastResultException)
                    {
                        var multicastException = (GcmMulticastResultException)ex;

                        foreach (var succeededNotification in multicastException.Succeeded)
                        {
                            Console.WriteLine($"GCM Notification Failed: ID={succeededNotification.MessageId}");
                        }

                        foreach (var failedKvp in multicastException.Failed)
                        {
                            var n = failedKvp.Key;
                            var e = failedKvp.Value;

                            //Console.WriteLine($"GCM Notification Failed: ID={n.MessageId}, Desc={e.Description}");
                            Console.WriteLine($"GCM Notification Failed: ID={n.MessageId}, Desc={e.Message}");
                        }

                    }
                    else if (ex is DeviceSubscriptionExpiredException)
                    {
                        var expiredException = (DeviceSubscriptionExpiredException)ex;

                        var oldId = expiredException.OldSubscriptionId;
                        var newId = expiredException.NewSubscriptionId;

                        Console.WriteLine($"Device RegistrationId Expired: {oldId}");

                        if (!string.IsNullOrWhiteSpace(newId))
                        {
                            // If this value isn't null, our subscription changed and we should update our database
                            Console.WriteLine($"Device RegistrationId Changed To: {newId}");
                        }
                    }
                    else if (ex is RetryAfterException)
                    {
                        var retryException = (RetryAfterException)ex;
                        // If you get rate limited, you should stop sending messages until after the RetryAfterUtc date
                        Console.WriteLine($"GCM Rate Limited, don't send more until after {retryException.RetryAfterUtc}");
                    }
                    else
                    {
                        Console.WriteLine("GCM Notification Failed for some unknown reason");
                    }

                    // Mark it as handled
                    return true;
                });
            };

            gcmBroker.OnNotificationSucceeded += (notification) => {
                Console.WriteLine("GCM Notification Sent!");
            };
            #endregion

            // Start the broker
            gcmBroker.Start();

            foreach (var regId in MY_REGISTRATION_IDS)
            {
                // Queue a notification to send
                gcmBroker.QueueNotification(new GcmNotification
                {
                    RegistrationIds = new List<string> {
                        regId
                    },
                    Data = JObject.Parse("{ \"somekey\" : \"somevalue\" }")
                });
            }

            // Stop the broker, wait for it to finish   
            // This isn't done after every message, but after you're
            // done with the broker
            gcmBroker.Stop();
        }
    }

    public class WebPushStatus
    {
        public bool Successful
        {
            get;
            set;
        }

        public string Response
        {
            get;
            set;
        }

        public Exception Error
        {
            get;
            set;
        }
    }
}
