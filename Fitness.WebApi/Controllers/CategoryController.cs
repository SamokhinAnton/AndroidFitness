﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fitness.Core.Repositories.Categories;
using Fitness.Core.Repositories.Categories.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fitness.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private ICategoryRepository<CategoryModel> _category { get; set; }
        public CategoryController(ICategoryRepository<CategoryModel> category)
        {
            _category = category;
        }

    }
}