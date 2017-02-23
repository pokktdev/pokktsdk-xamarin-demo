// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace SampleApp.iOS
{
    [Register ("DemoScreen")]
    partial class DemoScreen
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton cacheNonRewardedBtn { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton CacheRewardedBtn { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel earnedTxt { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton showNonRewardedAdBtn { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton ShowRewardedBtn { get; set; }

        [Action ("CacheInterstitialAdBtn_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void CacheInterstitialAdBtn_TouchUpInside (UIKit.UIButton sender);

        [Action ("cacheNonRewarded_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void cacheNonRewarded_TouchUpInside (UIKit.UIButton sender);

        [Action ("CacheRewarded_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void CacheRewarded_TouchUpInside (UIKit.UIButton sender);

        [Action ("CacheVideoBtn_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void CacheVideoBtn_TouchUpInside (UIKit.UIButton sender);

        [Action ("ShowInterstitialAdBtn_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void ShowInterstitialAdBtn_TouchUpInside (UIKit.UIButton sender);

        [Action ("showNonRewarded_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void showNonRewarded_TouchUpInside (UIKit.UIButton sender);

        [Action ("showRewarded_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void showRewarded_TouchUpInside (UIKit.UIButton sender);

        [Action ("ShowVideoBtn_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void ShowVideoBtn_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (cacheNonRewardedBtn != null) {
                cacheNonRewardedBtn.Dispose ();
                cacheNonRewardedBtn = null;
            }

            if (CacheRewardedBtn != null) {
                CacheRewardedBtn.Dispose ();
                CacheRewardedBtn = null;
            }

            if (earnedTxt != null) {
                earnedTxt.Dispose ();
                earnedTxt = null;
            }

            if (showNonRewardedAdBtn != null) {
                showNonRewardedAdBtn.Dispose ();
                showNonRewardedAdBtn = null;
            }

            if (ShowRewardedBtn != null) {
                ShowRewardedBtn.Dispose ();
                ShowRewardedBtn = null;
            }
        }
    }
}