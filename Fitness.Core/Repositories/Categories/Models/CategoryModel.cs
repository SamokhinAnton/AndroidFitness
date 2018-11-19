using Fitness.Core.Repositories.Exercises.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fitness.Core.Repositories.Categories.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public IEnumerable<ExerciseModel> Exercises { get; set; }
    }
}
