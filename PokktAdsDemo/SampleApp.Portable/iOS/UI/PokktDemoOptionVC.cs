using System;
using Foundation;

using UIKit;
using System.CodeDom.Compiler;
using CoreGraphics;

namespace SampleApp.iOS
{
	public partial class PokktDemoOptionVC : UIViewController
	{
		//public PokktDemoOptionVC() : base("PokktDemoOptionVC", null)
		//{
		//}

		public PokktDemoOptionVC(string nibName, NSBundle bundle) : base (nibName, bundle)
		{
			
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
			logoImgV.Transform = CGAffineTransform.MakeRotation(-7 / 22); //CGAffineTransformMakeRotation(-M_1_PI);

		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

