using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Fitness.DataModels.Models.Categories;

namespace Fitness.AndroidApp.Services.Category
{
    public class CategoryScreenAdapter : BaseAdapter<CategoryModel>
    {
        public List<CategoryModel> categories;
        public Activity context;

        public CategoryScreenAdapter(Activity context, List<CategoryModel> categories)
            : base()
        {
            this.categories = categories;
            this.context = context;
        }

        public override CategoryModel this[int position]
        {
            get
            {
                return categories[position];
            }
        }

        public override int Count
        {
            get
            {
                return categories.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return categories[position]?.Id ?? 0;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var category = categories[position];
            View view = convertView;

            if(view == null)
            {
                view = context.LayoutInflater.Inflate(Resource.Layout.CategoryListItemView, null);
            }

            var textInput1 = view.FindViewById<TextView>(Resource.Id.categoryItemView1);

            textInput1.Text = string.Format($"{category.Id} - {category.Name}");
            textInput1.SetTextColor(Color.Blue);
            textInput1.TextAlignment = TextAlignment.Center;

            var textInput2 = view.FindViewById<TextView>(Resource.Id.categoryItemView2);

            textInput2.Text = string.Format($"{category.Description}");
            textInput2.SetTextColor(Color.Gray);
            textInput2.TextAlignment = TextAlignment.TextEnd;

            return view;
        }
    }
}