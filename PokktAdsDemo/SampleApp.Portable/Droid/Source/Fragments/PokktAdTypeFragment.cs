using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Graphics;
using SampleApp.Droid.Source.Utility;
using PokktExtension;

namespace SampleApp.Droid.Source.UI
{
    public class PokktAdTypeFragment : BaseFragment
    {
        // ui
        private TextView txtTestRelease, txtFrameworkName, txtSDKVersion;
        private Button btnAdTypeVideo, btnAdTypeInterstitial, btnAdTypeBanner, btnAdTypeMore;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {

            View rootView = inflater.Inflate(Resource.Layout.fragment_pokkt_ad_type, container, false);

            //version info
            txtTestRelease = (TextView)FindView(rootView, Resource.Id.txt_test_release_version);
            txtSDKVersion = (TextView)FindView(rootView, Resource.Id.txt_sdk_version);
            txtFrameworkName = (TextView)FindView(rootView, Resource.Id.txt_framework_name);

            //video
            btnAdTypeVideo = (Button)FindView(FindView(rootView, Resource.Id.btn_ad_type_video), Resource.Id.button);

            //interstitial
            btnAdTypeInterstitial = (Button)FindView(FindView(rootView, Resource.Id.btn_ad_type_interstitial), Resource.Id.button);

            //banner
            btnAdTypeBanner = (Button)FindView(FindView(rootView, Resource.Id.btn_ad_type_banner), Resource.Id.button);

            //more == settings
            btnAdTypeMore = (Button)FindView(FindView(rootView, Resource.Id.btn_ad_type_more), Resource.Id.button);

            return rootView;
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);

            // setup data

            // txtTestRelease
            if (Resources.GetBoolean(Resource.Boolean.is_test_release))
            {
                txtTestRelease.Visibility = ViewStates.Visible;
                txtTestRelease.Text = Resources.GetString(Resource.String.txt_test_release_version).Replace("%s", Resources.GetString(Resource.String.test_release_version));
                SetFont(txtTestRelease, TypefaceStyle.Normal);

                txtFrameworkName.Visibility = ViewStates.Visible;
                txtFrameworkName.Text = Resources.GetString(Resource.String.framework_name);
                SetFont(txtFrameworkName, TypefaceStyle.Normal);
            }

            // txtSDKVersion
            txtSDKVersion.Text = Resources.GetString(Resource.String.txt_sdk_version).Replace("%s", PokktAds.GetPokktSDKVersion());
            SetFont(txtSDKVersion,TypefaceStyle.Bold);

            // btnAdTypeVideo
            btnAdTypeVideo.Text = Resources.GetString(Resource.String.txt_btn_ad_type_video);
            SetFont(btnAdTypeVideo, TypefaceStyle.Normal);     
            btnAdTypeVideo.Click += OpenVideosAdsShowcase;

            // btnAdTypeInterstitial
            btnAdTypeInterstitial.Text = GetString(Resource.String.txt_btn_ad_type_interstitial);
            SetFont(btnAdTypeInterstitial, TypefaceStyle.Normal);
            btnAdTypeInterstitial.Click += OpenInterstitialAdsShowcase;

            // btnAdTypeBanner
            btnAdTypeBanner.Text = GetString(Resource.String.txt_btn_ad_type_banner);
            SetFont(btnAdTypeBanner, TypefaceStyle.Normal);
            btnAdTypeBanner.Click += OpenBannerAdsShowcase;

            // btnAdTypeMore
            btnAdTypeMore.Text = GetString(Resource.String.txt_btn_more);
            SetFont(btnAdTypeMore, TypefaceStyle.Normal);
            btnAdTypeMore.Click += OpenMoreSettings;
        }
              
        private void OpenVideosAdsShowcase(object sender, EventArgs e)
        {
            PokktVideoFragment fragment = new PokktVideoFragment();
            FragmentTransactionManager.AddFragmentWithTag(this.Activity, Resource.Id.container, fragment, typeof(PokktVideoFragment).Name);
        }

        private void OpenInterstitialAdsShowcase(object sender, EventArgs e)
        {
            PokktInterstitialFragment fragment = new PokktInterstitialFragment();
            FragmentTransactionManager.AddFragmentWithTag(this.Activity, Resource.Id.container, fragment, typeof(PokktInterstitialFragment).Name);
        }

        private void OpenBannerAdsShowcase(object sender, EventArgs e)
        {
            PokktBannerFragment fragment = new PokktBannerFragment();
            FragmentTransactionManager.AddFragmentWithTag(this.Activity, Resource.Id.container, fragment, typeof(PokktBannerFragment).Name);
        }

        private void OpenMoreSettings(object sender, EventArgs e)
        {
            PokktSettingsFragment fragment = new PokktSettingsFragment();
            FragmentTransactionManager.AddFragmentWithTag(this.Activity, Resource.Id.container, fragment, typeof(PokktSettingsFragment).Name);
        }
        
        public override void OnDestroy()
        {
            base.OnDestroy();
            // although C# handles it own its own but still its safe to remove evanthandlers when not required
            btnAdTypeVideo.Click -= OpenVideosAdsShowcase;
            btnAdTypeInterstitial.Click -= OpenInterstitialAdsShowcase;
            btnAdTypeBanner.Click -= OpenBannerAdsShowcase;
            btnAdTypeMore.Click -= OpenMoreSettings;
            this.Activity.Finish();
        }
    }
    
}