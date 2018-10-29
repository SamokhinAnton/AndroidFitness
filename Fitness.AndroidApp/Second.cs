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
    [Activity(Label = "Second")]
    public class Second : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Second);
            var id = Intent.GetIntExtra("Id", 0);
            var login = Intent.GetStringExtra("login") ?? "login empty";
            var password = Intent.GetStringExtra("password") ?? "password empty";
            var resultFromFirst = Intent.GetStringExtra("result") ?? "result empty";
            ListView list = FindViewById<ListView>(Resource.Id.listView1);
            list.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, new List<string>() { "First", "Second", id.ToString(), login, password, resultFromFirst });

            Button button = FindViewById<Button>(Resource.Id.goToFirstPageButton);
            button.Click += delegate
            {
                StartActivity(typeof(MainActivity));
            };
        }
    }
}