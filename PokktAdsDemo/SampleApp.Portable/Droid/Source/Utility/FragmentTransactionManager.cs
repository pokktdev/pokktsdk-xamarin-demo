using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace SampleApp.Droid.Source.Utility
{
    class FragmentTransactionManager
    {

        public static void AddFragmentWithTag(Activity act, int containerID, Fragment frag, String fragmentTag ) {
            FragmentManager fragmentManager = act.FragmentManager;
            fragmentManager.BeginTransaction()
                .Add(containerID, frag, fragmentTag)
                .AddToBackStack(null)
                .CommitAllowingStateLoss();
        }
    }
}