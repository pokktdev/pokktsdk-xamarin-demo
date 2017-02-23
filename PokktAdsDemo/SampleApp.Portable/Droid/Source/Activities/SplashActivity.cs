using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace SampleApp.Droid.Source.UI
{
    [Activity(MainLauncher =true, Icon = "@drawable/ic_launcher", 
        Theme = "@android:style/Theme.Black.NoTitleBar.Fullscreen")]
    public class SplashActivity : Activity
    {

        private bool isClosed = false;
        private Handler handler = new Handler();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_splash);
            this.Window.AddFlags(WindowManagerFlags.Fullscreen);

            handler.PostDelayed(new Action(OpenMainActivity), 500);
        }

        private void OpenMainActivity()
        {
            StartActivity(typeof(MainActivity));
            handler.RemoveCallbacks(OpenMainActivity);
            Finish();
        }
    }
}