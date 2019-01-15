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
using Fitness.AndroidApp.Services.Category;
using Fitness.DataModels.Models.Categories;
using Java.IO;

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
                    new CategoryModel() { Id = 4, Name = "name", Description = "description for first item", Image = "" },
                    new CategoryModel() { Id = 7, Name = "name2", Description = "description for second item", Image = "" },
                    new CategoryModel() { Id = 8, Name = "name3", Description = "description for 3 item", Image = "" },
                    new CategoryModel() { Id = 9, Name = "name4", Description = "description for 4 item", Image = "" },
                    new CategoryModel() { Id = 17, Name = "name5", Description = "description for 5 item", Image = "" },
                    new CategoryModel() { Id = 27, Name = "name6", Description = "description for 6 item", Image = "" },
                    new CategoryModel() { Id = 37, Name = "name7", Description = "description for 7 item", Image = "" }
                };
            ListView list = FindViewById<ListView>(Resource.Id.categoriesList);
            list.Adapter = new CategoryScreenAdapter(this, categories);
            list.ItemClick += List_ItemClick;
        }

        private void List_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            ListView list = FindViewById<ListView>(Resource.Id.categoriesList);
            CategoryModel category = (list.Adapter as CategoryScreenAdapter)[e.Position];
            Intent intent = new Intent(this, typeof(ExerciseListActivity));
            intent.PutExtra("categoryId", category.Id);
            StartActivity(intent);
        }
    }
}