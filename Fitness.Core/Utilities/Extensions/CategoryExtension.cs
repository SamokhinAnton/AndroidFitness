using Fitness.Core.Repositories.Categories.Models;
using Fitness.EntityBase.Entities.dbo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fitness.Core.Utilities.Extensions
{
    public static class CategoryExtension
    {
        public static CategoryModel ToCategoryModel(this CategoryEntity entity)
        {
            var category = new CategoryModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                Image = entity.Image,
                Description = entity.Description
            };
            return category;
        }

        public static CategoryEntity ToCategoryEntity(this CategoryModel model)
        {
            var category = new CategoryEntity()
            {
                Id = model.Id,
                Name = model.Name,
                Image = model.Image,
                Description = model.Description
            };
            return category;
        }
    }
}
