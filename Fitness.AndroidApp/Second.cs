﻿using System;
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
    [Activity(Label = "Second")]
    public class Second : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Second);
            Button button = FindViewById<Button>(Resource.Id.goToFirstPageButton);
            button.Click += delegate {
                StartActivity(typeof(MainActivity));
            };
            // Create your application here
        }
    }
}