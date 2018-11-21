using Fitness.DataModels.Models.Categories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fitness.DataModels.Models.Exercises
{
    public class ExerciseModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Added { get; set; }

        public IEnumerable<CategoryModel> Categories { get; set; }
    }
}
