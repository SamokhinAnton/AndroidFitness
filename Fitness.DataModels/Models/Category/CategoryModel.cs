using Fitness.DataModels.Models.Exercises;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fitness.DataModels.Models.Categories
{
    public class CategoryModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public IEnumerable<ExerciseModel> Exercises { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
