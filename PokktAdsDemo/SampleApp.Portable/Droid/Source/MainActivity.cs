using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Widget;
using Android.OS;
using Android.Util;
using PokktExtension;
using PokktExtension.Enums;
using PokktExtension.Droid;

namespace SampleApp.Droid
{
    [Activity(Label = "PokktSample", MainLauncher = true, Icon = "@drawable/icon", Theme = "@android:style/Theme.Black.NoTitleBar.Fullscreen")]
    public class MainActivity : Activity
    {
        static int i = 0;
        string TAG = "PokktXamarinSample";
        private TextView txtVersionName;
        private EditText editTextScreenName;
        private Button buttonPokktInit, buttonNoRewarded, buttonRewardedAd, buttonBanner, buttonOfferwall, buttonExportLog;
        //button_pokkt_init, button_no_rewarded, button_rewarded_ad, button_banner, button_offerwall, button_export_log;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            PokktManager.SetNativeExtentions(new AndroidExtension(this));
            PokktManager.SetDebug(true);
            //global::Xamarin.Forms.Forms.Init (this, bundle);

            //LoadApplication (new App ());

            SetContentView(Resource.Layout.main_screen_layout);

            // TODO: find a proper place for the following
            //PokktExtension.PokktManager.SetNativeExtentions(new AndroidExtension());

            String versionName = "v";
            try
            {

                versionName += PokktManager.GetPokktSDKVersion();
                Log.Debug(TAG, "Version No: " + versionName);
            }
            catch (Exception e)
            {
                Log.Debug(TAG, e.Message);
            }
            initUI();
            txtVersionName.Text = versionName;

            // Pokkt init
            PokktManager.Dispatcher.PokktInitialisedEvent += onPokktInitialised;
            PokktManager.Dispatcher.BannerLoadedEvent += onBannerLoaded;
            PokktManager.Dispatcher.BannerLoadFailedEvent += onBannerLoadFailed;
            buttonPokktInit.Click += delegate
            {
                buttonPokktInit.Text = "Initializing";
                PokktConfig config = new PokktConfig();
                config.SecurityKey = "ae501f1003b0dc927dea807498ceaf3c";
                // Chikkey 81f2f0b8e67752ddd552f9b9e2c678f3
                // Suraj Test App ae501f1003b0dc927dea807498ceaf3c
                config.ApplicationId = "954b975f9c753bcb8fca42624d78139a";
                // Chikkey 0f666bc5d176ce734443a4fe00183d63
                // Suraj Test App 954b975f9c753bcb8fca42624d78139a
                PokktManager.InitPokkt(config);
            };

            //Non-Rewarded Ad
            buttonNoRewarded.Click += delegate
            {
                if (editTextScreenName.Text.Length > 0)
                {
                    Intent intent = new Intent(this, typeof(VideoActivity));
                    intent.PutExtra("isRewarded", false);
                    intent.PutExtra("screenName", editTextScreenName.Text.ToString().Trim());
                    StartActivity(intent);
                }
                else
                {
                    Toast.MakeText(this, "screen name cannot be empty", ToastLength.Long).Show();
                }
            };
            //Rewarded Ad
            buttonRewardedAd.Click += delegate
            {
                if (editTextScreenName.Text.Length > 0)
                {
                    Intent intent = new Intent(this, typeof(VideoActivity));
                    intent.PutExtra("isRewarded", true);
                    intent.PutExtra("screenName", editTextScreenName.Text.ToString().Trim());
                    StartActivity(intent);
                }
                else
                {
                    Toast.MakeText(this, "screen name cannot be empty", ToastLength.Long).Show();
                }
            };

            // Pokkt banner
            buttonBanner.Click += delegate
            {
                PokktManager.LoadBanner(editTextScreenName.Text.ToString().Trim(), (int)BannerPosition.TopCenter);
                // PokktManager.BannerAutoRefresh(false);

            };
            //Offerwall
            buttonOfferwall.Click += delegate
            {
                StartActivity(new Intent(this, typeof(OfferwallActivity)));
            };

            // Export Log

            buttonExportLog.Click += delegate
           {
               PokktManager.ExportLog();
           };


            //			FindViewById<Button> (Resource.Id.button_export_log).Click += delegate 
            //			{
            //				PokktManager.ExportLog();
            //			};


        }


        private void initUI()
        {
            txtVersionName = FindViewById<TextView>(Resource.Id.tvVersion);
            editTextScreenName = (EditText)FindViewById(Resource.Id.editScreenName);
            buttonPokktInit = FindViewById<Button>(Resource.Id.button_pokkt_init);
            buttonNoRewarded = FindViewById<Button>(Resource.Id.button_no_rewarded);
            buttonRewardedAd = FindViewById<Button>(Resource.Id.button_rewarded_ad);
            buttonBanner = FindViewById<Button>(Resource.Id.button_banner);
            buttonOfferwall = FindViewById<Button>(Resource.Id.button_offerwall);
            buttonExportLog = FindViewById<Button>(Resource.Id.button_export_log);

            buttonNoRewarded.Enabled = false;
            buttonRewardedAd.Enabled = false;
            buttonBanner.Enabled = false;
            buttonOfferwall.Enabled = false;
        }

        public void onPokktInitialised(bool isReady, String message)
        {
            if (isReady)
            {
                buttonPokktInit.Text = "Initialized";
                buttonNoRewarded.Enabled = true;
                buttonRewardedAd.Enabled = true;
                buttonBanner.Enabled = true;
                buttonOfferwall.Enabled = true;
            }
            else
            {
                Toast.MakeText(this, "Failed to initialize Pokkt SDK", ToastLength.Long).Show();
            }
        }

        public void onBannerLoaded(String screenName)
        {

            Console.WriteLine("Banner loaded" + i++);
        }

        public void onBannerLoadFailed(String screenName, String errorMessage)
        {
            Console.WriteLine("Banner load failed");
        }

        protected override void OnResume()
        {
            base.OnResume();
            PokktManager.resumeBanner(editTextScreenName.Text);
           
        }



    }
}
