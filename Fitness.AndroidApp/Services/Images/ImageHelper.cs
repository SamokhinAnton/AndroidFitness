using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Fitness.AndroidApp.Services.Images
{
    public class ImageHelper
    {
        public static async Task<Bitmap> GetImageFromUrl(string url)
        {
            using (var client = new HttpClient())
            {
                var msg = await client.GetAsync(url);
                if (msg.IsSuccessStatusCode)
                {
                    using (var stream = await msg.Content.ReadAsStreamAsync())
                    {
                        var bitmap = await BitmapFactory.DecodeStreamAsync(stream);
                        return bitmap;
                    }
                }
            }
            return null;
        }
    }
}