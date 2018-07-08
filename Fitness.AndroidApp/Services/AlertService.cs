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

namespace Fitness.AndroidApp.Services
{
    public class AlertService
    {
        public Dialog LoginAlert(Context context)
        {
            AlertDialog.Builder alert = new AlertDialog.Builder(context);
            alert.SetTitle("Confirm delete");
            alert.SetMessage("Lorem ipsum dolor sit amet, consectetuer adipiscing elit.");
            alert.SetPositiveButton("Delete", (senderAlert, args) => {
                Toast.MakeText(context, "Deleted!", ToastLength.Short).Show();
            });

            alert.SetNegativeButton("Cancel", (senderAlert, args) => {
                Toast.MakeText(context, "Cancelled!", ToastLength.Short).Show();
            });

            alert.SetNeutralButton("Neutral", (senderAlert, args) => {
                Toast.MakeText(context, "Neutral!", ToastLength.Short).Show();
            });

            Dialog dialog = alert.Create();

            return dialog;
        }
    }
}