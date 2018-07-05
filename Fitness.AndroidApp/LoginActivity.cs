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

                var loginInput = FindViewById<EditText>(Resource.Id.login);
                var passwordInput = FindViewById<EditText>(Resource.Id.password);
                if (!string.IsNullOrEmpty(loginInput.Text))
                {
                    var popUp = new PopupWindow((View)Resource.Layout.popUpWindow);
                    popUp.ShowAtLocation(this.CurrentFocus, GravityFlags.Top, 0, 0);
                    loginInput.Error = "enter login";
                    return;
                }
                if (string.IsNullOrEmpty(passwordInput.Text))
                {
                    passwordInput.Error = "enter password";
                    return;
                }
                intent.PutExtra("login", loginInput.Text);
                intent.PutExtra("password", passwordInput.Text);
                StartActivity(intent);
                OverridePendingTransition(Android.Resource.Animation.FadeOut, Android.Resource.Animation.SlideOutRight);

            };
            // Create your application here
        }
    }
}