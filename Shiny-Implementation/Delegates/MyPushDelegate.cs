using System;
using System.Diagnostics;
using Shiny.Push;

#if IOS
using UIKit;
using UserNotifications;
#endif

namespace Shiny_Implementation.Delegates
{
    public partial class MyPushDelegate : IPushDelegate
    {
        #region Constructor

        public MyPushDelegate()
        {
        }

        #endregion

        #region Methods

        public async Task OnEntry(PushNotification notification)
        {
            //todo
            // fires when the user taps on a push notification
            // please read specific android documentation below on how to make this work
            //Android - not working
            //iOS - Works Good
            System.Diagnostics.Debug.WriteLine("OnEntry Method Activated");
            System.Diagnostics.Debug.WriteLine(notification.Data.ToString());
        }

        public async Task OnReceived(PushNotification notification)
        {
            //todo
            // fires when a push notification is received
            // iOS: set content-available: 1  or this won't fire - Works Good
            // Android: Works good
            System.Diagnostics.Debug.WriteLine("OnEntry Received Activated");
            System.Diagnostics.Debug.WriteLine(notification.Data.ToString());
        }

        public async Task OnNewToken(string token)
        {
            // fires when a push registration token change is set by the operating system or provider
            // also fires with RequestAccess value changes (or initial request)
        }

        public async Task OnUnRegistered(string token)
        {
            // fires when IPushManager.UnRegister is called
            // or on startup when permissions are denied to push
        }

        #endregion

    }

#if IOS
    public partial class MyPushDelegate : Shiny.Push.IApplePushDelegate
    {
        // this is only used in a foreground call
        public UNNotificationPresentationOptions? GetPresentationOptions(PushNotification notification)
        {
            return UNNotificationPresentationOptions.Alert;
        }

        // this is executed on any content-available push notification
        public UIBackgroundFetchResult? GetFetchResult(PushNotification notification)
        {
            return UIBackgroundFetchResult.NewData;
        }
    }
#endif
}

