using Fitness.DataModels.Models.Exercises;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.Core.Repositories.Exercises
{
    public interface IExerciseRepository<T> : IBaseRepository<T>, ISearch<T>
        where T: new()
    {
        Task<IEnumerable<ExerciseModel>> GetByCategory(int categoryId);
    }
}
