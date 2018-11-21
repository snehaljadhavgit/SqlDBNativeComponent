using System;
using System.Threading.Tasks;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using GalaSoft.MvvmLight.Threading;
using Plugin.CurrentActivity;
using SqlDBNativeComponent.Helper;
using SqlDBNativeComponent.ViewModel;

namespace SqlDBNativeComponent.Droid
{
    //You can specify additional application information in this attribute
    [Application]
    public class MainApplication : Application , Application.IActivityLifecycleCallbacks
    {


        static SqlHelper database;
        // declarations
        protected readonly string logTag = "App";



        public MainApplication(IntPtr handle, JniHandleOwnership transer)
          : base(handle, transer)
        {
        }
        // properties

        public static MainApplication Current { get; }

        public override void OnTerminate()
        {
            base.OnTerminate();
            UnregisterActivityLifecycleCallbacks(this);
        }

        public void OnActivityCreated(Activity activity, Bundle savedInstanceState)
        {
            CrossCurrentActivity.Current.Activity = activity;
        }

        public void OnActivityDestroyed(Activity activity)
        {
        }

        public void OnActivityPaused(Activity activity)
        {

        }

        public void OnActivityResumed(Activity activity)
        {
            CrossCurrentActivity.Current.Activity = activity;
        }

        public void OnActivitySaveInstanceState(Activity activity, Bundle outState)
        {
        }

        public void OnActivityStarted(Activity activity)
        {
            CrossCurrentActivity.Current.Activity = activity;
        }

        public void OnActivityStopped(Activity activity)
        {

        }


        // events




        static ViewModelLocator locator;
        public static ViewModelLocator Locator
        {
            get
            {
                if (locator == null)
                {
                    DispatcherHelper.Initialize();

                    locator = new ViewModelLocator();
                }

                return locator;
            }

        }

        public static SqlHelper Database
        {
            get
            {
                if (database == null)
                {
                    database = new SqlHelper();
                }
                return database;
            }
        }

    }
}
