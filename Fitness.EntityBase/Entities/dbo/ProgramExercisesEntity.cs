using System;
using System.Collections.Generic;
using System.Text;

namespace Fitness.EntityBase.Entities.dbo
{
    public class ProgramExercisesEntity
    {
        public int Id { get; set; }

        public int ProgramId { get; set; }

        public ProgramEntity Program { get; set; }

        public int ExerciseId { get; set; }

        public ExerciseEntity Exercise { get; set; }

        public int Sequence { get; set; }

        public DateTime Created { get; set; }

        public DateTime Scheduled { get; set; }

        public string Comment { get; set; }

        public virtual List<SetEntity> Sets { get; set; }

    }
}
