using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Fitness.AndroidApp.Services.Category;
using Fitness.DataModels.Models.Categories;
using Fitness.DataModels.Models.Exercises;

namespace Fitness.AndroidApp
{
    [Activity(Label = "CategoryGridView")]
    public class CategoryGridView : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.category_grid_activity);

            var categories = new List<CategoryModel>() {
                    new CategoryModel() { Id = 4, Name = "name", Description = "description for first item", Image = "https://image.shutterstock.com/image-vector/bike-bicycle-cycle-icon-vector-450w-1174864702.jpg" },
                    new CategoryModel() { Id = 7, Name = "name2", Description = "description for second item", Image = "https://image.shutterstock.com/image-vector/green-bike-transportation-logo-icon-450w-1212806968.jpg" },
                    new CategoryModel() { Id = 8, Name = "name3", Description = "description for 3 item", Image = "https://image.shutterstock.com/image-vector/bike-bicycle-cycle-icon-vector-450w-1174864702.jpg" },
                    new CategoryModel() { Id = 9, Name = "name4", Description = "description for 4 item", Image = "https://image.shutterstock.com/image-vector/green-bike-transportation-logo-icon-450w-1212806968.jpg" },
                    new CategoryModel() { Id = 17, Name = "name5", Description = "description for 5 item", Image = "https://image.shutterstock.com/image-vector/bike-bicycle-cycle-icon-vector-450w-1174864702.jpg" },
                    new CategoryModel() { Id = 27, Name = "name6", Description = "description for 6 item", Image = "https://image.shutterstock.com/image-vector/green-bike-transportation-logo-icon-450w-1212806968.jpg" },
                    new CategoryModel() { Id = 37, Name = "name7", Description = "description for 7 item", Image = "https://image.shutterstock.com/image-vector/bike-bicycle-cycle-icon-vector-450w-1174864702.jpg" }
                };
            var strs = new List<string>() { "name", "name2" };
            GridView grid = FindViewById<GridView>(Resource.Id.categoryGridView);
            
            grid.Adapter = new CategoryScreenAdapter(this, categories);
            grid.ItemClick += List_ItemClick;
        }

        private void List_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var exercises = new List<ExerciseModel>() {
                    new ExerciseModel() { Id = 4, Name = "name", Description = "description for first item",
                        Categories = new List<CategoryModel>() {
                            new CategoryModel() { Id = 4, Name = "name1", Description = "description for first item", Image = "" },
                            new CategoryModel() { Id = 7, Name = "name2", Description = "description for second item", Image = "" },
                        }
                    },
                    new ExerciseModel() { Id = 7, Name = "name2", Description = "description for second item", Categories = new List<CategoryModel>() {
                            new CategoryModel() { Id = 4, Name = "name3", Description = "description for first item", Image = "" },
                            new CategoryModel() { Id = 7, Name = "name4", Description = "description for second item", Image = "" },
                        }
                    },
                    new ExerciseModel() { Id = 8, Name = "name3", Description = "description for 3 item", Categories = new List<CategoryModel>() {
                            new CategoryModel() { Id = 4, Name = "name5", Description = "description for first item", Image = "" },
                            new CategoryModel() { Id = 7, Name = "name6", Description = "description for second item", Image = "" },
                        }
                    },
                    new ExerciseModel() { Id = 9, Name = "name4", Description = "description for 4 item", Categories = new List<CategoryModel>() {
                            new CategoryModel() { Id = 8, Name = "name7", Description = "description for first item", Image = "" },
                            new CategoryModel() { Id = 9, Name = "name8", Description = "description for second item", Image = "" },
                        }
                    },
                    new ExerciseModel() { Id = 17, Name = "name5", Description = "description for 5 item", Categories = new List<CategoryModel>() {
                            new CategoryModel() { Id = 8, Name = "name9", Description = "description for first item", Image = "" },
                            new CategoryModel() { Id = 9, Name = "name10", Description = "description for second item", Image = "" },
                        }
                    },
                    new ExerciseModel() { Id = 27, Name = "name6", Description = "description for 6 item", Categories = new List<CategoryModel>() {
                            new CategoryModel() { Id = 17, Name = "name11", Description = "description for first item", Image = "" },
                            new CategoryModel() { Id = 27, Name = "name12", Description = "description for second item", Image = "" },
                            new CategoryModel() { Id = 37, Name = "name13", Description = "description for second item", Image = "" },
                        }
                    },
                    new ExerciseModel() { Id = 37, Name = "name7", Description = "description for 7 item", Categories = new List<CategoryModel>() {
                            new CategoryModel() { Id = 4, Name = "name14", Description = "description for first item", Image = "" }
                        }
                    },
                };
            GridView list = FindViewById<GridView>(Resource.Id.categoryGridView);
            CategoryModel category = (list.Adapter as CategoryScreenAdapter)[e.Position];
            var filteredExercises = exercises.Where(ex => ex.Categories.Any(c => c.Id == category.Id)).ToList();
            Intent intent = new Intent(this, typeof(ExerciseListActivity));
            intent.PutExtra("exercises", JsonConvert.SerializeObject(filteredExercises));
            StartActivity(intent);
        }
    }
}