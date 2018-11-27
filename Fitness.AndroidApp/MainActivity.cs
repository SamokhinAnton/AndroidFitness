using System;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Content;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
//using Fitness.AndroidApp.Models;
using Fitness.DataModels.Entities.Users;
using Xamarin.Android.Net;

namespace Fitness.AndroidApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        //public UserModel User = new UserModel() { Email = "wefwef", FirstName = "qwfqf", LastName = "ewfwefwe", Id = 2 };

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_main);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;
            //EditText testText = FindViewById<EditText>(Resource.Id.testText);
            //testText.FocusChange += TestTextOnChange;

            Button button = FindViewById<Button>(Resource.Id.goToSecondPageButton);
            button.Click += SecondOnClick;

            Button loginButton = FindViewById<Button>(Resource.Id.goToLoginPage);
            loginButton.Click += LoginOnClick;

            Button userData = FindViewById<Button>(Resource.Id.goToUserData);
            userData.Click += UserDAtaOnClick;

        }

        private async void UserDAtaOnClick(object sender, EventArgs eventArgs)
        {
            Intent intent = new Intent(this, typeof(Second));
            try
            {
                using (HttpClient client = new HttpClient(new AndroidClientHandler()))
                {
                    client.DefaultRequestHeaders.Add("accept", "application/json");
                    UserModel user = null;
                    var response = await client.GetAsync("http://172.28.150.58:51687/api/Authorization/create");
                    
                    if (response.IsSuccessStatusCode)
                    {
                        //user = JsonConvert.DeserializeObject<UserModel>(await response.Content.ReadAsStringAsync());
                        var result = await response.Content.ReadAsStringAsync();
                        
                        intent.PutExtra("result", result);
                        StartActivity(intent);
                    }
                }
            }
            catch(Exception e)
            {
                intent.PutExtra("result", e.Message + " Inner: " + e.InnerException.Message);
                StartActivity(intent);
            }
        }


        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        private void SecondOnClick(object sender, EventArgs eventArgs)
        {
            Intent intent = new Intent(this, typeof(CategoryListActivity));
            StartActivity(intent);
        }

        private void LoginOnClick(object sender, EventArgs eventArgs)
        {
            Intent intent = new Intent(this, typeof(LoginActivity));
            StartActivity(intent);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }


        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View)sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }

        //private void FabOnClick2(object sender, EventArgs eventArgs)
        //{
        //    View view = (View)sender;
        //    Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
        //        .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        //}

        //private void TestTextOnChange(object sender, EventArgs eventArgs)
        //{
        //    View view = (View)sender;
        //    Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
        //        .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        //}
    }
}

