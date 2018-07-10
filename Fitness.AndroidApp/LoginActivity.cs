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
using Fitness.AndroidApp.Services;

namespace Fitness.AndroidApp
{
    [Activity(Label = "LoginActivity")]
    public class LoginActivity : Activity
    {
        private AlertService Alert = new AlertService();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.login_activity);

            Button login = FindViewById<Button>(Resource.Id.loginButton);
            login.Click += LoginOnClick;

            Button forgotButtonShow = FindViewById<Button>(Resource.Id.showForgotPasswordButton);
            forgotButtonShow.Click += ForgotPasswordBlockOnClick;

            Button registration = FindViewById<Button>(Resource.Id.goToRegistrationPage);
            registration.Click += ForgotPasswordBlockOnClick;
        }

        private void RegistrationClick(object sender, EventArgs eventArgs)
        {
            Intent intent = new Intent(this, typeof(RegistrationActivity));
            StartActivity(intent);
        }

        private void LoginOnClick(object sender, EventArgs eventArgs)
        {
            Intent intent = new Intent(this, typeof(Second));

            var loginInput = FindViewById<EditText>(Resource.Id.login);
            var passwordInput = FindViewById<EditText>(Resource.Id.password);
            if (string.IsNullOrEmpty(loginInput.Text))
            {
                Alert.LoginAlert(this).Show();

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
            OverridePendingTransition(Android.Resource.Animation.FadeOut, Android.Resource.Animation.FadeIn);
        }

        private void ForgotPasswordBlockOnClick(object sender, EventArgs eventArgs)
        {
            LinearLayout forgotPasswordLayout = FindViewById<LinearLayout>(Resource.Id.forgotPasswordBlock);
            forgotPasswordLayout.Visibility = ViewStates.Visible;
        }


    }
}