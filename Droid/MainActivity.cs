using Android.App;
using Android.Widget;
using Android.OS;
using SqlDBNativeComponent.Models;
using SqlDBNativeComponent.ViewModel;

namespace SqlDBNativeComponent.Droid
{
    [Activity(Label = "SqlDBNativeComponent", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        int count = 1;
        MainViewModel MainVm
        {
            get
            {
                return MainApplication.Locator.MainVm;
            }
        }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            RegEntity regEntity = new RegEntity();
          
            regEntity.Name = "xyz";
            regEntity.Password = "abbc";
            regEntity.Username = "snehjadhav";

            //save obj in local db 
            MainVm.SaveEmployeeInDB(regEntity, MainApplication.Database);

            Button button = FindViewById<Button>(Resource.Id.myButton);

            //
            RegEntity objw = MainVm.GetEmp("snehjadhav", MainApplication.Database);

            button.Click += delegate { button.Text = $"{count++} clicks!"; };
        }
    }
}

