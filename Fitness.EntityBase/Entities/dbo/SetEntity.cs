using System;
using System.Collections.Generic;
using System.Text;

namespace Fitness.EntityBase.Entities.dbo
{
    public class SetEntity
    {
        public int Id { get; set; }

        public int ExerciseId { get; set; }

        public ProgramExercisesEntity Exercise { get; set; }

        public double PlannedWeight { get; set; }

        public int PlannedReps { get; set; }

        public double ActualWeight { get; set; }

        public int ActualReps { get; set; }

        public bool isMissed { get; set; }

        public string Video { get; set; }

        public DateTime Done { get; set; }

        public string Comment { get; set; }

    }
}
