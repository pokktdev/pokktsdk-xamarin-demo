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
using Android.Text;

namespace SampleApp.Droid.Source.Utility
{
    public class PokktStorage
    {

        private static String SharedPrefsName = "PokktSharedPrefName";

        public static void StoreVideoPoints(Context context, float points)
        {
            float oldPoints = GetVideoPoints(context);
            context.GetSharedPreferences(SharedPrefsName, FileCreationMode.Private).Edit()
                    .PutFloat("points", oldPoints + points).Apply();
        }

        public static float GetVideoPoints(Context context)
        {
            return context.GetSharedPreferences(SharedPrefsName, FileCreationMode.Private).GetFloat("points", 0);
        }

        public static String GetAppId(Context context)
        {
            //return context.getSharedPreferences(SharedPrefsName, Context.MODE_PRIVATE).getString("appId", "a2717a45b835b5e9f50284a38d62a74e");// video demo
            return context.GetSharedPreferences(SharedPrefsName, FileCreationMode.Private).GetString("appId", "d572bd855ed1c299ca5491b5df54d42b");// Dev_Abhinav
            //return context.getSharedPreferences("MyVideoPrefs", Context.MODE_PRIVATE).getString("appId", "954b975f9c753bcb8fca42624d78139a");// Suraj Test app
        }

        public static void SetAppId(Context context, String appId)
        {
            if (!TextUtils.IsEmpty(appId))
            {
                context.GetSharedPreferences(SharedPrefsName, FileCreationMode.Private).Edit().PutString("appId", appId).Apply();
            }
        }

        public static String GetSecurityKey(Context context)
        {
            //return context.getSharedPreferences(SharedPrefsName, Context.MODE_PRIVATE).getString("securityKey", "iJ02lJss0M"); // video demo
            return context.GetSharedPreferences(SharedPrefsName, FileCreationMode.Private).GetString("securityKey", "6414dc853a151b4dfe7d04a171e38bd8");// Dev_Abhinav
            //return context.getSharedPreferences("MyVideoPrefs", Context.MODE_PRIVATE).getString("securityKey", "ae501f1003b0dc927dea807498ceaf3c");// Suraj Test app
        }

        public static void SetSecurityKey(Context context, String appId)
        {
            if (!TextUtils.IsEmpty(appId))
            {
                context.GetSharedPreferences(SharedPrefsName, FileCreationMode.Private).Edit().PutString("securityKey", appId).Apply();
            }
        }
    }
}