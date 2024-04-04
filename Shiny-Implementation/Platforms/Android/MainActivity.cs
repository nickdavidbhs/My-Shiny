using Android.App;
using Android.Content.PM;
using Android.OS;
using Firebase;

namespace Shiny_Implementation;

[Activity(
    Theme = "@style/MainTheme",
    MainLauncher = true,
    ConfigurationChanges =
    ConfigChanges.ScreenSize |
    ConfigChanges.Orientation |
    ConfigChanges.UiMode |
    ConfigChanges.ScreenLayout |
    ConfigChanges.SmallestScreenSize |
    ConfigChanges.Density)]
[IntentFilter(
      new[] {
Shiny.ShinyPushIntents.NotificationClickAction
      },
      Categories = new[] {
          "android.intent.category.DEFAULT"
      }
  )]
public class MainActivity : MauiAppCompatActivity
{
    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        FirebaseApp.InitializeApp(this);
    }
}

