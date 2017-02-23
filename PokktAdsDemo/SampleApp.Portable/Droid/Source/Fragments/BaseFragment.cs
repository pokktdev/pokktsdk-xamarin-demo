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

namespace SampleApp.Droid.Source.UI
{
    public class BaseFragment : Fragment
    {
        /// <summary>
        /// Utility method used by child fragments to set custom font to UI elements
        /// </summary>
        /// <param name="view"></param> view on which you want to set font
        /// <param name="typeFaceStyle"></param> stest style you wan tto set for that view likewise "bold/normal/italic"
        protected void SetFont(View view, TypefaceStyle typeFaceStyle)
        {
            
            Typeface typeFace = Typeface.CreateFromAsset(this.Activity.Assets, "BankGothicBold.ttf");

            if (view is Button)
            {
                ((Button)view).SetTypeface(typeFace, typeFaceStyle);
            }
            else if (view is TextView)
            {
                ((TextView)view).SetTypeface(typeFace, typeFaceStyle);
            }
            else if (view is EditText)
            {
                ((EditText)view).SetTypeface(typeFace, typeFaceStyle);
            }

        }

        /// <summary>
        /// used by child fragments to find view from  view group
        /// </summary>
        /// <param name="rootView"></param> container inside which we have to find view with requested viewID
        /// <param name="viewID"></param> view ID we are lookign for
        /// <returns></returns>
        protected View FindView(View rootView, int viewID)
        {
            return rootView.FindViewById(viewID);
        }

        protected void SetProgressbarColor(ProgressBar progressbar)
        {
            progressbar.IndeterminateDrawable.SetColorFilter(Resources.GetColor(Resource.Color.clr_blue), PorterDuff.Mode.SrcIn);
        }
    }
}