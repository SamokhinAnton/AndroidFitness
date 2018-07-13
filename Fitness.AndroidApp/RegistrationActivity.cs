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
    [Activity(Label = "RegistrationActivity")]
    public class RegistrationActivity : Activity
    {
        private Button LoginButton { get; set; }
  
        private Button ForgotPasswordButton { get; set; }

        private Button RegisterButton { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.registration_activity);

            LoginButton = FindViewById<Button>(Resource.Id.registrationSignInButton);
            ForgotPasswordButton = FindViewById<Button>(Resource.Id.registrationForgotPasswordButton);
            RegisterButton = FindViewById<Button>(Resource.Id.registrationButton);

            LoginButton.Click += LoginOnCLick;
            ForgotPasswordButton.Click += ForgotPasswordOnClick;
            RegisterButton.Click += RegisterOnClick;
        }

        private void RegisterOnClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ForgotPasswordOnClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void LoginOnCLick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}