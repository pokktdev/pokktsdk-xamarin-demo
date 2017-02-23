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
using SampleApp.Droid.Source.Utility;
using Android.Text;

namespace SampleApp.Droid.Source.UI
{
    public class PokktInterstitialFragment : BaseFragment
    {
        // ui
        private TextView txtAdType, txtScreenName;
        private EditText edtScreenName;
        private ProgressBar progressCacheRewarded, progressShowRewarded, progressCacheNonRewarded, progressShowNonRewarded;
        private Button btnCacheRewarded, btnShowRewarded, btnCacheNonRewarded, btnShowNonRewarded;
        private TextView txtEarnedPoints;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View rootView = inflater.Inflate(Resource.Layout.fragment_pokkt_interstitial, container, false);

            // ad type heading
            txtAdType = (TextView)FindView(rootView, Resource.Id.txt_ad_type);

            // screen name
            txtScreenName = (TextView)FindView(rootView, Resource.Id.txt_screen_name);
            edtScreenName = (EditText)FindView(rootView, Resource.Id.edt_screen_name);

            // earned points
            txtEarnedPoints = (TextView)FindView(rootView, Resource.Id.txt_earned_points);

            // cache rewarded
            progressCacheRewarded = (ProgressBar)FindView(FindView(rootView, Resource.Id.btn_cache_rewarded), Resource.Id.progressBar);
            btnCacheRewarded = (Button)FindView(FindView(rootView, Resource.Id.btn_cache_rewarded), Resource.Id.button);

            // show rewarded
            progressShowRewarded = (ProgressBar)FindView(FindView(rootView, Resource.Id.btn_show_rewarded), Resource.Id.progressBar);
            btnShowRewarded = (Button)FindView(FindView(rootView, Resource.Id.btn_show_rewarded), Resource.Id.button);

            // cache non rewarded
            progressCacheNonRewarded = (ProgressBar)FindView(FindView(rootView, Resource.Id.btn_cache_non_rewarded), Resource.Id.progressBar);
            btnCacheNonRewarded = (Button)FindView(FindView(rootView, Resource.Id.btn_cache_non_rewarded), Resource.Id.button);

            // show non rewarded
            progressShowNonRewarded = (ProgressBar)FindView(FindView(rootView, Resource.Id.btn_show_non_rewarded), Resource.Id.progressBar);
            btnShowNonRewarded = (Button)FindView(FindView(rootView, Resource.Id.btn_show_non_rewarded), Resource.Id.button);

            return rootView;
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);

            // setup data

            // ad Type
            SetFont(txtAdType, TypefaceStyle.Bold);

            // screen name
            SetFont(edtScreenName, TypefaceStyle.Normal);
            SetFont(txtScreenName, TypefaceStyle.Normal);

            // earned points
            SetFont(txtEarnedPoints, TypefaceStyle.Normal);
            txtEarnedPoints.Text = GetString(Resource.String.txt_earned_points).Replace("%s", Convert.ToString(PokktStorage.GetVideoPoints(this.Activity)));

            // cache rewarded
            SetFont(btnCacheRewarded, TypefaceStyle.Normal);
            SetProgressbarColor(progressCacheRewarded);
            btnCacheRewarded.Text = GetString(Resource.String.txt_btn_cache_rewarded);
            btnCacheRewarded.Click += CacheRewarded;

            // show rewarded
            SetFont(btnShowRewarded, TypefaceStyle.Normal);
            SetProgressbarColor(progressShowRewarded);
            btnShowRewarded.Text = GetString(Resource.String.txt_btn_show_rewarded);
            btnShowRewarded.Click += ShowRewarded;

            // cache non rewarded
            SetFont(btnCacheNonRewarded, TypefaceStyle.Normal);
            SetProgressbarColor(progressCacheNonRewarded);
            btnCacheNonRewarded.Text = GetString(Resource.String.txt_btn_cache_non_rewarded);
            btnCacheNonRewarded.Click += CacheNonRewarded;

            // show non rewarded
            SetFont(btnShowNonRewarded, TypefaceStyle.Normal);
            SetProgressbarColor(progressShowNonRewarded);
            btnShowNonRewarded.Text = GetString(Resource.String.txt_btn_show_non_rewarded);
            btnShowNonRewarded.Click += ShowNonRewarded;

            // OPTIONAL but we SUGGEST you to implement actions as it will help you to determine the status of your request
            PokktAds.Interstitial.AdAvailabilityEvent += AdAvailabilityStatus;
            PokktAds.Interstitial.AdCachingCompletedEvent += AdCachingCompleted;
            PokktAds.Interstitial.AdCachingFailedEvent += AdCachingFailed;
            PokktAds.Interstitial.AdDisplayedEvent += AdDisplayed;
            PokktAds.Interstitial.AdFailedToShowEvent += AdFailedToShow;
            PokktAds.Interstitial.AdSkippedEvent += AdSkipped;
            PokktAds.Interstitial.AdCompletedEvent += AdCompleted;
            PokktAds.Interstitial.AdClosedEvent += AdClosed;
            PokktAds.Interstitial.AdGratifiedEvent += AdGratified;
        }

        private void CacheRewarded(object sender, EventArgs e)
        {
            progressCacheRewarded.Visibility = ViewStates.Visible;
            if (isScreenNameSpecified())
            {
                PokktAds.Interstitial.CacheRewarded(edtScreenName.Text.Trim());
            }
        }

        private void ShowRewarded(object sender, EventArgs e)
        {
            progressShowRewarded.Visibility = ViewStates.Visible;
            if (isScreenNameSpecified())
            {
                PokktAds.Interstitial.ShowRewarded(edtScreenName.Text.Trim());
            }
        }

        private void CacheNonRewarded(object sender, EventArgs e)
        {
            progressCacheNonRewarded.Visibility = ViewStates.Visible;
            if (isScreenNameSpecified())
            {
                PokktAds.Interstitial.CacheNonRewarded(edtScreenName.Text.Trim());
            }
        }

        private void ShowNonRewarded(object sender, EventArgs e)
        {
            progressShowNonRewarded.Visibility = ViewStates.Visible;
            if (isScreenNameSpecified())
            {
                PokktAds.Interstitial.ShowNonRewarded(edtScreenName.Text.Trim());
            }
        }


        private bool isScreenNameSpecified()
        {
            if (TextUtils.IsEmpty(edtScreenName.Text))
            {
                Toast.MakeText(this.Activity, "Please Enter Screen Name or Zone ID", ToastLength.Short).Show();
                return false;
            }
            return true;
        }

        private void HideProgress()
        {
            progressCacheRewarded.Visibility = ViewStates.Gone;
            progressShowRewarded.Visibility = ViewStates.Gone;
            progressCacheNonRewarded.Visibility = ViewStates.Gone;
            progressShowNonRewarded.Visibility = ViewStates.Gone;
        }

        // Implementaions of Actions subscribed for InterstitialAds
        public void AdCachingCompleted(String screenName, bool isRewarded, float reward)
        {
            if (this.Activity == null)
            {
                return;
            }
            Toast.MakeText(this.Activity, "Interstitial Ad Caching Completed ! Ad vc is: " + reward, ToastLength.Short).Show();
            if (edtScreenName.Text.Trim().Equals(screenName))
            { // screen name check as our SDK supports multiple ad-requests,
              // it will help in identifying response to which request has arrived
                HideProgress();
            }
        }

        public void AdCachingFailed(String screenName, bool isRewarded, String errorMessage)
        {
            if (this.Activity == null)
            {
                return;
            }
            Toast.MakeText(this.Activity, "Interstitial Ad Download Error " + errorMessage, ToastLength.Short).Show();
            if (edtScreenName.Text.Trim().Equals(screenName))
            {
                HideProgress();
            }
        }

        public void AdDisplayed(String screenName, bool isRewarded)
        {
            if (this.Activity == null)
            {
                return;
            }
            Toast.MakeText(this.Activity, "Interstitial Ad Displayed", ToastLength.Short).Show();

        }


        public void AdFailedToShow(String screenName, bool isRewarded, String errorMessage)
        {
            if (this.Activity == null)
            {
                return;
            }
            Toast.MakeText(this.Activity, "Interstitial Ad Show Error " + errorMessage, ToastLength.Short).Show();
            if (edtScreenName.Text.Trim().Equals(screenName))
            {
                HideProgress();
            }
        }


        public void AdClosed(String screenName, bool isRewarded)
        {
            if (this.Activity == null)
            {
                return;
            }
            HideProgress();
            txtEarnedPoints.Text = GetString(Resource.String.txt_earned_points).Replace("%s", Convert.ToString(PokktStorage.GetVideoPoints(this.Activity)));
            Toast.MakeText(this.Activity, "Interstitial Ad Closed", ToastLength.Short).Show();
        }


        public void AdSkipped(String screenName, bool isRewarded)
        {
            if (this.Activity == null)
            {
                return;
            }
            HideProgress();
            Toast.MakeText(this.Activity, "Interstitial Ad Skipped", ToastLength.Short).Show();
        }


        public void AdCompleted(String screenName, bool isRewarded)
        {
            if (this.Activity == null)
            {
                return;
            }
            HideProgress();
            txtEarnedPoints.Text = GetString(Resource.String.txt_earned_points).Replace("%s", Convert.ToString(PokktStorage.GetVideoPoints(this.Activity)));
            Toast.MakeText(this.Activity, "Interstitial Ad Completed", ToastLength.Short).Show();
        }


        public void AdGratified(String screenName, bool isRewarded, float reward)
        {
            if (this.Activity == null)
            {
                return;
            }
            Toast.MakeText(this.Activity, "Points Earned " + reward, ToastLength.Short).Show();
            PokktStorage.StoreVideoPoints(this.Activity, (float)reward);
        }

        public void AdAvailabilityStatus(String screenName, bool isRewarded, bool availability)
        {
            if (this.Activity == null)
            {
                return;
            }
            if (availability)
            {
                Toast.MakeText(this.Activity, "Interstitial Ad is Available", ToastLength.Short).Show();
            }
            else
            {
                Toast.MakeText(this.Activity, "Interstitial Ad is not Available", ToastLength.Short).Show();
            }
        }

    }
}