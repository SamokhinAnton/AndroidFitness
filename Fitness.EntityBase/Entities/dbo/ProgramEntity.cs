using System;
using System.Collections.Generic;
using System.Text;

namespace Fitness.EntityBase.Entities.dbo
{
    public class ProgramEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Created { get; set; }

        public string Comment { get; set; }

        public UserEntity User { get; set; }

        public UserEntity Owner { get; set; }

        public virtual List<ProgramExercisesEntity> ProgramExercises { get; set; }
    }
}
