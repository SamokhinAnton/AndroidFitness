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
using Fitness.DataModels.Models.Categories;

namespace Fitness.AndroidApp
{
    [Activity(Label = "CategoryListActivity")]
    public class CategoryListActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.category_list_activity);

            var categories = new List<CategoryModel>() {
                    new CategoryModel() { Id = 1, Name = "name", Description = "", Image = "" },
                    new CategoryModel() { Id = 2, Name = "name2", Description = "", Image = "" }
                };
            var strs = new List<string>() { "name", "name2" };
            ListView list = FindViewById<ListView>(Resource.Id.categoriesList);
            list.Adapter = new ArrayAdapter<CategoryModel>(this, Android.Resource.Layout.SimpleListItem1, categories);


        }


    }
}