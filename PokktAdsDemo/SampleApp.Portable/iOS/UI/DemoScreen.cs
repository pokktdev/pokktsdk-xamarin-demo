using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using PokktExtension;
using PokktExtension.Enums;

namespace SampleApp.iOS
{
	partial class DemoScreen : UIViewController
	{
		string screenTitle;

		public DemoScreen (string screenName) : base ()
		{
			this.screenTitle = screenName;
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			//Adding event
			PokktExtension.PokktAds.VideoAd.AdCachingCompletedEvent += AdCachingCompletedEvent;
			PokktExtension.PokktAds.VideoAd.AdCachingFailedEvent += AdCachingFailedEvent;
			PokktExtension.PokktAds.VideoAd.AdAvailabilityEvent += AdAvailabilityEvent;
			PokktExtension.PokktAds.VideoAd.AdDisplayedEvent += AdDisplayedEvent;
			PokktExtension.PokktAds.VideoAd.AdCompletedEvent += AdCompletedEvent;
			PokktExtension.PokktAds.VideoAd.AdClosedEvent += AdClosedEvent;
			PokktExtension.PokktAds.VideoAd.AdSkippedEvent += AdSkippedEvent;
			PokktExtension.PokktAds.VideoAd.AdGratifiedEvent += AdGratifiedEvent;
			PokktExtension.PokktAds.VideoAd.AdFailedToShowEvent += AdFailedToShowEvent;
		}

		partial void showNonRewarded_TouchUpInside(UIButton sender)
		{
			PokktAds.VideoAd.ShowNonRewarded(screenTitle);
		}

		partial void showRewarded_TouchUpInside(UIButton sender)
		{
			PokktAds.VideoAd.ShowRewarded(screenTitle);
		}

		partial void CacheRewarded_TouchUpInside(UIButton sender)
		{
			PokktAds.VideoAd.CacheRewarded(screenTitle);

			ChangeButtonText(CacheRewardedBtn, "Caching Rewarded");

			DisbaleButton(CacheRewardedBtn);
			DisbaleButton(ShowRewardedBtn);
		}

		partial void cacheNonRewarded_TouchUpInside(UIButton sender)
		{
			PokktAds.VideoAd.CacheNonRewarded(screenTitle);

			ChangeButtonText(cacheNonRewardedBtn, "Caching NonRewarded");

			DisbaleButton(cacheNonRewardedBtn);
			DisbaleButton(showNonRewardedAdBtn);
		}

		//Extra utility methods

		void ChangeButtonText(UIButton button, string text)
		{
			button.SetTitle (text, UIControlState.Normal);
			button.SetTitle (text, UIControlState.Highlighted);
			button.SetTitle (text, UIControlState.Disabled);
			button.SetTitle (text, UIControlState.Selected);
		}

		void EnableButton(UIButton button)
		{
			button.Enabled = true;
			button.Alpha = 1.0f;
		}

		void DisbaleButton(UIButton button)
		{
			button.Enabled = false;
			button.Alpha = 0.5f;
		}

		void ResetAllButton(bool isRewarded)
		{
			if (isRewarded)
			{
				ChangeButtonText(CacheRewardedBtn, "Cache Rewarded");
				ChangeButtonText(ShowRewardedBtn, "Show Rewarded");

				EnableButton(CacheRewardedBtn);
				EnableButton(ShowRewardedBtn);
			}
			else
			{
				ChangeButtonText(cacheNonRewardedBtn, "Cache NonRewarded");
				ChangeButtonText(showNonRewardedAdBtn, "Show NonRewarded");

				EnableButton(cacheNonRewardedBtn);
				EnableButton(showNonRewardedAdBtn);
			}
		}

		//Delegate handler

		void AdCachingCompletedEvent(string screenName, bool isRewarded, float reward)
		{
			Console.WriteLine(screenName);

			if (isRewarded)
			{
				EnableButton(ShowRewardedBtn);
				ChangeButtonText(ShowRewardedBtn, "Show Rewarded Ad (Cached)");
			}
			else
			{
				EnableButton(showNonRewardedAdBtn);
				ChangeButtonText(showNonRewardedAdBtn, "Show NonRewarded Ad (Cached)");
			}
		}

		void AdCachingFailedEvent(string screenName, bool isRewarded, string errorMessage)
		{
			Console.WriteLine("AdCachingFailedEvent called: " + errorMessage);
			ResetAllButton(isRewarded);
		}

		void AdAvailabilityEvent(string screenName, bool isRewarded, bool isAvailable)
		{
			Console.WriteLine("AdAvailabilityEvent called: " + isAvailable);
		}

		void AdGratifiedEvent(string screenName, bool isRewarded, float reward)
		{
			Console.WriteLine("AdGratifiedEvent called and reward point is: " + reward);
			earnedTxt.Text = "Earned point: " + reward.ToString();
		}

		void AdFailedToShowEvent(string screenName, bool isRewarded, string errorMessage)
		{
			Console.WriteLine("AdFailedToShowEvent called: " + errorMessage);
			ResetAllButton(isRewarded);
		}

		void AdSkippedEvent(string screenName, bool isRewarded)
		{
			Console.WriteLine("AdSkippedEvent called");
		}

		void AdClosedEvent(string screenName, bool isRewarded)
		{
			Console.WriteLine("AdClosedEvent called");
			ResetAllButton(isRewarded);
		}

		void AdDisplayedEvent(string screenName, bool isRewarded)
		{
			Console.WriteLine("AdDisplayedEvent called");
		}

		void AdCompletedEvent(string screenName, bool isRewarded)
		{
			Console.WriteLine("AdCompletedEvent called");
		}
	}
}
