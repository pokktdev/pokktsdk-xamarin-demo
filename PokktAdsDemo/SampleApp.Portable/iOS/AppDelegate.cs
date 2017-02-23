using Foundation;
using UIKit;

namespace SampleApp.iOS
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
	[Register ("AppDelegate")]
	public class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		UIWindow window;
		public override UIWindow Window {
			get;
			set;
		}

		public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
		{
			// Override point for customization after application launch.
			// If not required for your application you can safely delete this method

			// Code to start the Xamarin Test Cloud Agent
			#if ENABLE_TEST_CLOUD
			Xamarin.Calabash.Start();
			#endif

			application.SetMinimumBackgroundFetchInterval(UIApplication.BackgroundFetchIntervalMinimum);

			UIUserNotificationSettings settings = UIUserNotificationSettings.GetSettingsForTypes( UIUserNotificationType.Alert 
				| UIUserNotificationType.Badge 
				| UIUserNotificationType.Sound, 
				new NSSet());

			application.RegisterUserNotificationSettings(settings);

			window = new UIWindow (UIScreen.MainScreen.Bounds);

			UINavigationController navCont = new UINavigationController ();
			//navCont.NavigationController.NavigationBar.Translucent = true;
			//PokktDemoOptionVC optionVC = new PokktDemoOptionVC("PokktDemoOptionVC", null);
			//navCont.PushViewController(optionVC, true);
			//window.RootViewController = navCont;



			DemoSelector demoSelector = new DemoSelector ("DemoSelector", null);
			navCont.PushViewController(demoSelector, true);
			window.RootViewController = navCont;
			window.MakeKeyAndVisible ();
			return true;
		}

//		public override void AwakeFromNib() 
//		{
//			base.AwakeFromNib();
//			NSBundle.MainBundle.LoadNib("MainScreen", this, null);
//		}

		public override void OnResignActivation (UIApplication application)
		{
			// Invoked when the application is about to move from active to inactive state.
			// This can occur for certain types of temporary interruptions (such as an incoming phone call or SMS message) 
			// or when the user quits the application and it begins the transition to the background state.
			// Games should use this method to pause the game.
		}

		public override void DidEnterBackground (UIApplication application)
		{
			// Use this method to release shared resources, save user data, invalidate timers and store the application state.
			// If your application supports background exection this method is called instead of WillTerminate when the user quits.
		}

		public override void WillEnterForeground (UIApplication application)
		{
			// Called as part of the transiton from background to active state.
			// Here you can undo many of the changes made on entering the background.
		}

		public override void OnActivated (UIApplication application)
		{
			// Restart any tasks that were paused (or not yet started) while the application was inactive. 
			// If the application was previously in the background, optionally refresh the user interface.
		}

		public override void WillTerminate (UIApplication application)
		{
			// Called when the application is about to terminate. Save data, if needed. See also DidEnterBackground.
		}
	}
}


