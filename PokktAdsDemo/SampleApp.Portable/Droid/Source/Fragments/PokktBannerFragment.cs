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
using PokktExtension;
using Android.Text;
using Com.Pokkt.Plugin.Common;

namespace SampleApp.Droid.Source.UI
{
    public class PokktBannerFragment : BaseFragment
    {
        // ui
        private TextView txtAdType, txtScreenName;
        private EditText edtScreenName;
        private Button btnLoadTopBanner, btnLoadBottomBanner, btnDestroyBanner;
        private ProgressBar progressLoadTopBanner, progressLoadBottomBanner;
       
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View rootView = inflater.Inflate(Resource.Layout.fragment_pokkt_banner, container, false);

            // ad type heading
            txtAdType = (TextView)FindView(rootView, Resource.Id.txt_ad_type);

            // screen name
            txtScreenName = (TextView)FindView(rootView, Resource.Id.txt_screen_name);
            edtScreenName = (EditText)FindView(rootView, Resource.Id.edt_screen_name);

            // load top banner
            progressLoadTopBanner = (ProgressBar)FindView(FindView(rootView, Resource.Id.btn_load_banner), Resource.Id.progressBar);
            btnLoadTopBanner = (Button)FindView(FindView(rootView, Resource.Id.btn_load_banner), Resource.Id.button);

           // load bottom banner
            progressLoadBottomBanner = (ProgressBar)FindView(FindView(rootView, Resource.Id.btn_load_second_banner), Resource.Id.progressBar);
            btnLoadBottomBanner = (Button)FindView(FindView(rootView, Resource.Id.btn_load_second_banner), Resource.Id.button);

            // destroy second banner
            btnDestroyBanner = (Button)FindView(FindView(rootView, Resource.Id.btn_destroy_banner), Resource.Id.button);

            // pokkt banner containers = space needs to be provided to show banner on your screen using placeholder provided by PokktSDK
           // pokktBannerViewTop = (PokktBannerView)FindView(rootView, Resource.Id.pokkt_banner_view_top);
            //pokktBannerViewBottom = (PokktBannerView)FindView(rootView, Resource.Id.pokkt_banner_view_bottom);

            return rootView;

        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);

            // setup data

            /// ad Type
            SetFont(txtAdType, TypefaceStyle.Bold);

            // screen name
            SetFont(edtScreenName, TypefaceStyle.Normal);
            SetFont(txtScreenName, TypefaceStyle.Normal);

            // load top banner
            SetFont(btnLoadTopBanner, TypefaceStyle.Normal);
            SetProgressbarColor(progressLoadTopBanner);
            btnLoadTopBanner.Text = (GetString(Resource.String.txt_btn_load_top_banner));
            btnLoadTopBanner.Click += LoadBannerTop;

           
            // load bottom banner
            SetFont(btnLoadBottomBanner, TypefaceStyle.Normal);
            SetProgressbarColor(progressLoadBottomBanner);
            btnLoadBottomBanner.Text = GetString(Resource.String.txt_btn_load_bottom_banner);
            btnLoadBottomBanner.Click += LoadBannerBottom;

            // destroy bottom banner
            SetFont(btnDestroyBanner, TypefaceStyle.Normal);
            btnDestroyBanner.Text = GetString(Resource.String.txt_btn_destroy_bottom_banner);
            btnDestroyBanner.Click += DestroyBanner;

            // OPTIONAL but we SUGGEST you to implement actions as it will help you to determine the status of your request
            PokktAds.Banner.BannerLoadedEvent += bannerLoaded;
            PokktAds.Banner.BannerLoadFailedEvent += bannerLoadFailed;
        }

        private void LoadBannerTop(object sender, EventArgs e)
        {
            String screenName = edtScreenName.Text;
            if (TextUtils.IsEmpty(screenName))
            {
                Toast.MakeText(this.Activity, "Please Enter Screen Name", ToastLength.Short).Show();
                return;
            }
            progressLoadTopBanner.Visibility = ViewStates.Visible;
            //other way to load banner by providing exact location where you want it to load
            PokktAds.Banner.LoadBannerWithRect(screenName, ConvertDpToPx(60), ConvertDpToPx(468), 0,0 ); // standard full banner size 
        }

        private void LoadBannerBottom(object sender, EventArgs e)
        {
            String screenName = edtScreenName.Text;
            if (TextUtils.IsEmpty(screenName))
            {
                Toast.MakeText(this.Activity, "Please Enter Screen Name", ToastLength.Short).Show();
                return;
            }
            progressLoadBottomBanner.Visibility = ViewStates.Visible;
            // one way to load banner
            PokktAds.Banner.LoadBanner(screenName,BannerPosition.BottomCenter);
        }

        private int ConvertDpToPx(float dpValue)
        {
            var pxValue = (int)TypedValue.ApplyDimension(ComplexUnitType.Dip, dpValue, Resources.DisplayMetrics);
            return pxValue;
        }


        /**
         * To destroy PokktBannerView is mandatory we recommend you to destroy all you PokktBannerView instances
         * on onDestroy of activity or fragment or any place of your choice.
         */
        private void DestroyBanner(object sender, EventArgs e)
        {
            PokktAds.Banner.RemoveBanner();
        }
        

        // Implementaions of Actions subscribed for BannerAds


        public void bannerLoaded(String screenName)
        {
            if (this.Activity == null)
            {
                return;
            }
            progressLoadTopBanner.Visibility = ViewStates.Gone;
            progressLoadBottomBanner.Visibility = ViewStates.Gone;

            Toast.MakeText(this.Activity, "Banner Ad is available", ToastLength.Short).Show();
        }

        public void bannerLoadFailed(String screenName, String errorMessage)
        {
            if (this.Activity == null)
            {
                return;
            }
            progressLoadTopBanner.Visibility = ViewStates.Gone;
            progressLoadBottomBanner.Visibility = ViewStates.Gone;

            Toast.MakeText(this.Activity, "Banner Ad is not available", ToastLength.Short).Show();
        }
        // Don't forget to destroy banner on 
        public override void OnDestroy()
        {
            base.OnDestroy();
            PokktAds.Banner.RemoveBanner();
        }

    }
}