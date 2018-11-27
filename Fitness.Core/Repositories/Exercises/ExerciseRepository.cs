using Fitness.Core.Utilities.Extensions;
using Fitness.DataModels.Models.Categories;
using Fitness.DataModels.Models.Exercises;
using Fitness.EntityBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.Core.Repositories.Exercises
{
    public class ExerciseRepository : IExerciseRepository<ExerciseModel>, ISearch<ExerciseModel>
    {
        private FitnessContext _ctx { get; set; }

        public ExerciseRepository(FitnessContext context)
        {
            _ctx = context;
        }

        public Task Create(ExerciseModel entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ExerciseModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ExerciseModel>> GetByCategory(int categoryId)
        {
            var exercises = await _ctx.Exercises.Where(e => e.Categories.Any(ec => ec.CategoryId == categoryId))
                .Select(e => new ExerciseModel() { Id = e.Id, Name = e.Name, Description = e.Description, Added = e.Categories.FirstOrDefault(ec => ec.ExerciseId == e.Id).Created.ToShortDateString()})
                .ToListAsync();
            return exercises;
        }

        public async Task<ExerciseModel> GetByIdAsync(int id)
        {
            var exerciseEntity = await _ctx.Exercises.Include(e => e.Categories).ThenInclude(ec => ec.Category).FirstOrDefaultAsync(e => e.Id == id);
            var exercise = new ExerciseModel()
            {
                Id = exerciseEntity.Id,
                Name = exerciseEntity.Name,
                Description = exerciseEntity.Description,
                Added = exerciseEntity.Categories.FirstOrDefault(ec => ec.ExerciseId == exerciseEntity.Id).Created.ToShortDateString(),
                Categories = exerciseEntity.Categories.Select(c => c.Category.ToCategoryModel())
            };
            return exercise;
        }

        public Task<IEnumerable<ExerciseModel>> SearchAsync(string pattern)
        {
            throw new NotImplementedException();
        }

        public Task Update(ExerciseModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
