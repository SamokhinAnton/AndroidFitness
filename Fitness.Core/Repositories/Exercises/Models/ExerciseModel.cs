using Fitness.Core.Repositories.Categories.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fitness.Core.Repositories.Exercises.Models
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
