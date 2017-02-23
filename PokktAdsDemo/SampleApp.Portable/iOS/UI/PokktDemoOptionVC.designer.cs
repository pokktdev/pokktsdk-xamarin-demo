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
    [Register ("PokktDemoOptionVC")]
    partial class PokktDemoOptionVC
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton bannerAdsBtn { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton interstitialAdsBtn { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView logoImgV { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIScrollView scrollView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton settingBtn { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton videoAdsBtn { get; set; }

        [Action ("bannerAdsDemo:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void bannerAdsDemo (UIKit.UIButton sender);

        [Action ("interstitialAdsDemo:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void interstitialAdsDemo (UIKit.UIButton sender);

        [Action ("settingVC:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void settingVC (UIKit.UIButton sender);

        [Action ("videoAdsDemo:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void videoAdsDemo (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (bannerAdsBtn != null) {
                bannerAdsBtn.Dispose ();
                bannerAdsBtn = null;
            }

            if (interstitialAdsBtn != null) {
                interstitialAdsBtn.Dispose ();
                interstitialAdsBtn = null;
            }

            if (logoImgV != null) {
                logoImgV.Dispose ();
                logoImgV = null;
            }

            if (scrollView != null) {
                scrollView.Dispose ();
                scrollView = null;
            }

            if (settingBtn != null) {
                settingBtn.Dispose ();
                settingBtn = null;
            }

            if (videoAdsBtn != null) {
                videoAdsBtn.Dispose ();
                videoAdsBtn = null;
            }
        }
    }
}