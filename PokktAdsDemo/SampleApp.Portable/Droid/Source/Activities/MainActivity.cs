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
using SampleApp.Droid.Source.Utility;
using SampleApp.Droid.Source.UI;
using PokktExtension;
using PokktExtension.Droid;

namespace SampleApp.Droid.Source.UI
{
    [Activity(MainLauncher = false,
        Theme = "@android:style/Theme.Black.NoTitleBar.Fullscreen",
        ConfigurationChanges = Android.Content.PM.ConfigChanges.Orientation | 
        Android.Content.PM.ConfigChanges.ScreenSize)]

    //keyboard|keyboardHidden|navigation||screenLayout|uiMode||smallestScreenSize
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            this.Window.AddFlags(WindowManagerFlags.Fullscreen);

            InItPokktSDK();

            PokktAdTypeFragment pokktAdTypeFragment = new PokktAdTypeFragment();
            FragmentTransactionManager.AddFragmentWithTag(this, Resource.Id.container, pokktAdTypeFragment, typeof(PokktAdTypeFragment).Name);
        }

        private void InItPokktSDK() {
            PokktAds.SetNativeExtentions(new AndroidExtension(this)); // Required for communication with PokktSDK. Should be the first line
            PokktAds.SetThirdPartyUserId("123456"); // optional
            PokktAds.Debugging.ShouldDebug(true); // optional, set it to true if you want to enable logs for PokktSDK
            PokktAds.SetPokktConfig(PokktStorage.GetAppId(this), PokktStorage.GetSecurityKey(this)); // required
           
        }
    }
}