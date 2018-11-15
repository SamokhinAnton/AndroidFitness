using System;
using System.Collections.Generic;
using System.Text;

namespace Fitness.EntityBase.Entities.dbo
{
    public class ExerciseCategoryEntity
    {
        public int Id { get; set; }

        public ExerciseEntity Exercise { get; set; }

        public CategoryEntity Category { get; set; }

        public DateTime Created { get; set; }

    }
}
