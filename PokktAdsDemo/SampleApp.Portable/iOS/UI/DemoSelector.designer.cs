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
    [Register ("DemoSelector")]
    partial class DemoSelector
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton DemoScreen1Btn { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton DemoScreen2Btn { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton ExportLogBtn { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIScrollView Scroll { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton testBannerBtn { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtFldScreen { get; set; }

        [Action ("DemoScreen1Btn_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void DemoScreen1Btn_TouchUpInside (UIKit.UIButton sender);

        [Action ("DemoScreen2Btn_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void DemoScreen2Btn_TouchUpInside (UIKit.UIButton sender);

        [Action ("ExportLogBtn_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void ExportLogBtn_TouchUpInside (UIKit.UIButton sender);

        [Action ("TestBannerBtn_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void TestBannerBtn_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (DemoScreen1Btn != null) {
                DemoScreen1Btn.Dispose ();
                DemoScreen1Btn = null;
            }

            if (DemoScreen2Btn != null) {
                DemoScreen2Btn.Dispose ();
                DemoScreen2Btn = null;
            }

            if (ExportLogBtn != null) {
                ExportLogBtn.Dispose ();
                ExportLogBtn = null;
            }

            if (Scroll != null) {
                Scroll.Dispose ();
                Scroll = null;
            }

            if (testBannerBtn != null) {
                testBannerBtn.Dispose ();
                testBannerBtn = null;
            }

            if (txtFldScreen != null) {
                txtFldScreen.Dispose ();
                txtFldScreen = null;
            }
        }
    }
}