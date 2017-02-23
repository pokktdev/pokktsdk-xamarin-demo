using Foundation;
using UIKit;
//using PokktExtension;
using PokktExtension.Enums;
using PokktExtension.iOS;
using System;
//using System.CodeDom.Compiler;

namespace SampleApp.iOS
{
	partial class DemoSelector : UIViewController
	{
		//private PokktConfig pokktConfig;

		public DemoSelector (string nibName, NSBundle bundle) : base (nibName, bundle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			//DisableButton ();

			//Setting extension and adding event
			PokktExtension.PokktAds.SetNativeExtentions(new IosExtension());

			PokktExtension.PokktAds.Banner.BannerLoadedEvent += BannerLoaded;
			PokktExtension.PokktAds.Banner.BannerLoadFailedEvent += BannerLoadFailed;

			PokktExtension.PokktAds.SetPokktConfig("954b975f9c753bcb8fca42624d78139a", "ae501f1003b0dc927dea807498ceaf3c");

			PokktExtension.PokktAds.SetThirdPartyUserId("123456");

			PokktExtension.PokktAds.Debugging.ShouldDebug(true);
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning();
			// Dispose of any resources that can be recreated.
		}

		partial void DemoScreen1Btn_TouchUpInside (UIButton sender)
		{
			DemoScreen demoScreen = new DemoScreen(txtFldScreen.Text);
			this.NavigationController.PushViewController(demoScreen, true);
		}

		partial void DemoScreen2Btn_TouchUpInside (UIButton sender)
		{
			InterstitialScreenVC interstitialScreen = new InterstitialScreenVC(txtFldScreen.Text);
			this.NavigationController.PushViewController(interstitialScreen, true);
		}

		partial void TestBannerBtn_TouchUpInside(UIButton sender)
		{
			PokktExtension.PokktAds.Banner.LoadBanner(txtFldScreen.Text, (int)BannerPosition.TopCenter);
		}


		partial void ExportLogBtn_TouchUpInside (UIButton sender)
		{
		//	PokktManager.ExportLog();
		}

		private void ShowDemoScreen(string adType)
		{ 
			DemoScreen demoScreen = new DemoScreen (txtFldScreen.Text);
			this.NavigationController.PushViewController(demoScreen, true);
		}

		void BannerLoaded (string screenName)
		{
			Console.WriteLine("BannerLoaded called:" + screenName);
		}

		void BannerLoadFailed(string screenName, string message)
		{
			Console.WriteLine("BannerLoadFailed called");

		}
	}
}
