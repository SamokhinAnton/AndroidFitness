using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fitness.Core.Repositories.Exercises;
using Fitness.DataModels.Models.Exercises;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fitness.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : Controller
    {
        private IExerciseRepository<ExerciseModel> _exercise { get; set; }

        public ExerciseController(IExerciseRepository<ExerciseModel> exercise)
        {
            _exercise = exercise;
        }

        [HttpGet("{categoryId}")]
        public async Task<IActionResult> GetExercises(int categoryId)
        {
            var exercises = await _exercise.GetByCategory(categoryId);
            return Ok(exercises);
        }
    }
}