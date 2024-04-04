using System.Diagnostics;
using Android.Hardware.Usb;
using Shiny;
using Shiny.Push;

namespace Shiny_Implementation;

public partial class App : Application
{
    private readonly IPushManager _pushManager;

    public App(IPushManager pushManager)
    {
        _pushManager = pushManager;

        InitializeComponent();

		MainPage = new AppShell();
	}

    protected override async void OnStart()
    {
        base.OnStart();

        //Push Notifications
        if (_pushManager.RegistrationToken == null)
        {
            //Push Registration
            var result = await _pushManager.RequestAccess();
            if (result.Status == AccessState.Available)
            {
                // you should send this to your server with a userId attached if you want to do custom work
                var value = result.RegistrationToken;
            }
        }

        Debug.WriteLine("Token: " + _pushManager.RegistrationToken);
    }
}

