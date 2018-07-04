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

namespace Fitness.AndroidApp
{
    [Activity(Label = "LoginActivity")]
    public class LoginActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.login_activity);

            Button login = FindViewById<Button>(Resource.Id.loginButton);

            login.Click += delegate
            {
                Intent intent = new Intent(this, typeof(Second));
                var loginInput = FindViewById<EditText>(Resource.Id.login).Text;
                var passwordInput = FindViewById<EditText>(Resource.Id.password).Text;
                intent.PutExtra("login", loginInput);
                intent.PutExtra("password", passwordInput);
                StartActivity(intent);
            };
            // Create your application here
        }
    }
}