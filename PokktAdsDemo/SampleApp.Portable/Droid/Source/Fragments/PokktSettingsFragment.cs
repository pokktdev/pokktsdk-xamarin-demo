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
using SampleApp.Droid.Source.Utility;
using Android.Text;
using PokktExtension;

namespace SampleApp.Droid.Source.UI
{
    public class PokktSettingsFragment : BaseFragment
    {
        // ui
        // edt_security_key
        //btn_export_log btn_export_log_to_cloud
        private TextView txtSettings,txtIPAddress;
        private EditText edtIPAddress, edtApplicationID, edtSecurityKey;
        private Button btnExportLog, btnExportLogToCloud;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View rootView = inflater.Inflate(Resource.Layout.fragment_settings, container, false);

            // setting
            txtSettings = (TextView)FindView(rootView, Resource.Id.txt_ad_settings);

            // ipAddress
            txtIPAddress = (TextView)FindView(rootView, Resource.Id.txt_ip_address);
            edtIPAddress = (EditText)FindView(rootView, Resource.Id.edt_ip_address);

            // application id
            edtApplicationID = (EditText)FindView(rootView, Resource.Id.edt_application_id);

            // security key
            edtSecurityKey = (EditText)FindView(rootView, Resource.Id.edt_security_key);

            // export log
            btnExportLog = (Button)FindView(FindView(rootView, Resource.Id.btn_export_log), Resource.Id.button);

            // export log to cloud
            btnExportLogToCloud = (Button)FindView(FindView(rootView, Resource.Id.btn_export_log_to_cloud), Resource.Id.button);

            return rootView;
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);

            // setup data
            SetFont(txtSettings, TypefaceStyle.Bold);

            // ipAddress
            if (Resources.GetBoolean(Resource.Boolean.is_test_release))
            {
                SetFont(edtIPAddress, TypefaceStyle.Normal);
                txtIPAddress.Visibility = ViewStates.Visible; // it is used for our testing purpose please igonre it
                edtIPAddress.Visibility = ViewStates.Visible;
            }

            // application id
            SetFont(edtApplicationID, TypefaceStyle.Normal);
            edtApplicationID.Text = PokktStorage.GetAppId(this.Activity);

            // security key
            SetFont(edtSecurityKey, TypefaceStyle.Normal);
            edtSecurityKey.Text = PokktStorage.GetSecurityKey(this.Activity);

            // export log
            SetFont(btnExportLog, TypefaceStyle.Normal);
            btnExportLog.Text = GetString(Resource.String.txt_export_log);
            btnExportLog.Click += ExportLog;

            // export log to cloud
            SetFont(btnExportLogToCloud, TypefaceStyle.Normal);
            btnExportLogToCloud.Text = GetString(Resource.String.txt_export_to_cloud);
            btnExportLogToCloud.Click += ExportLogToCloud;
        }

        private void ExportLog(object sender, EventArgs e) {
            PokktAds.Debugging.ExportLog(); // if you want to export log to some specific location
        }

        private void ExportLogToCloud(object sender, EventArgs e) {
            PokktAds.Debugging.ExportLogToCloud(); // if you want to export log to cloud
        }
        public override void OnDestroy()
        {
            base.OnDestroy();

            if (TextUtils.IsEmpty(edtApplicationID.Text))
            {
                Toast.MakeText(this.Activity, "Please Enter Application Id", ToastLength.Short).Show();
                return;
            }

            if (TextUtils.IsEmpty(edtSecurityKey.Text))
            {
                Toast.MakeText(this.Activity, "Please Enter Security Key", ToastLength.Short).Show();
                return;
            }

            // saving applicationID and SecurityKey for SDK locally
            String applicationId = edtApplicationID.Text.Trim();
            String securityKey = edtSecurityKey.Text.Trim();
            PokktStorage.SetAppId(this.Activity, applicationId);
            PokktStorage.SetSecurityKey(this.Activity, securityKey);

            // Updating PokktConfig in PokktSDk in case it is changed from this screen.
            PokktAds.SetPokktConfig(applicationId, securityKey);            
        }
    }
}