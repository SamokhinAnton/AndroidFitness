using System;
using System.Collections.Generic;
using System.Text;

namespace Fitness.EntityBase.Entities.dbo
{
    public class ExerciseEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual List<ProgramExercisesEntity> ProgramExercises { get; set; }

        public virtual List<ExerciseCategoryEntity> Categories { get; set; }
    }
}
