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
using Fitness.AndroidApp.Services.Images;
using Fitness.DataModels.Models.Exercises;

namespace Fitness.AndroidApp.Services.Exercises
{
    public class ExerciseScreenAdapter : BaseAdapter<ExerciseModel>
    {

        public List<ExerciseModel> exercises;
        public Activity context;

        public ExerciseScreenAdapter(Activity context, List<ExerciseModel> exercises)
            : base()
        {
            this.exercises = exercises;
            this.context = context;
        }

        public override ExerciseModel this[int position]
        {
            get
            {
                return exercises[position];
            }
        }

        public override int Count
        {
            get
            {
                return exercises.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return exercises[position]?.Id ?? 0;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var exercise = this[position];
            View view = convertView;

            if (view == null)
            {
                view = context.LayoutInflater.Inflate(Resource.Layout.CategoryListItemView, null);
            }
            
            //var imageRes = (int)typeof(Resource.Drawable).GetField("bike").GetValue(null);
            //imageInput.SetImageResource(imageRes);

            var textInput1 = view.FindViewById<TextView>(Resource.Id.categoryItemView1);

            textInput1.Text = string.Format($"{exercise.Id} - {exercise.Name}");
            textInput1.SetTextColor(Color.Blue);
            textInput1.TextAlignment = TextAlignment.Center;

            var textInput2 = view.FindViewById<TextView>(Resource.Id.categoryItemView2);

            textInput2.Text = string.Format($"{exercise.Description}");
            textInput2.SetTextColor(Color.Gray);
            textInput2.TextAlignment = TextAlignment.TextEnd;

            return view;
        }
    }
}