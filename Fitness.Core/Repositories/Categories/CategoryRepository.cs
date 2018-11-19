using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fitness.Core.Repositories.Categories.Models;
using Fitness.Core.Utilities.Extensions;
using Fitness.EntityBase;
using Fitness.EntityBase.Entities.dbo;
using Microsoft.EntityFrameworkCore;

namespace Fitness.Core.Repositories.Categories
{
    public class CategoryRepository : ICategoryRepository<CategoryModel>
    {
        private FitnessContext _ctx { get; set; }

        public CategoryRepository(FitnessContext context)
        {
            _ctx = context;
        }

        public async Task Create(CategoryModel entity)
        {
            var category = entity.ToCategoryEntity();
            await _ctx.Categories.AddAsync(category);
            await _ctx.SaveChangesAsync();
        }

        public async Task Delete(int Id)
        {
            var category = await _ctx.Categories.FindAsync(Id);
            _ctx.Remove(category);
            await _ctx.SaveChangesAsync();
        }

        public async Task<IEnumerable<CategoryModel>> GetAllAsync()
        {
            var categories = await _ctx.Categories.Select(c => c.ToCategoryModel()).ToListAsync();
            return categories;
        }

        public async Task<CategoryModel> GetByIdAsync(int Id)
        {
            var categoryEntity = await _ctx.Categories.FindAsync(Id);
            var category = categoryEntity.ToCategoryModel();
            return category;
        }

        public async Task<IEnumerable<CategoryModel>> SearchAsync(string pattern)
        {
            var categories = await _ctx.Categories
                .Where(c => c.Name.Contains(pattern) || c.Description.Contains(pattern))
                .Select(c => c.ToCategoryModel())
                .ToListAsync();
            return categories;
        }

        public async Task Update(CategoryModel entity)
        {
            _ctx.Categories.Update(entity.ToCategoryEntity());
            await _ctx.SaveChangesAsync();
        }
    }
}
