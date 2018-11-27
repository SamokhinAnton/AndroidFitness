using Fitness.EntityBase;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fitness.Core.Repositories
{

    /// <summary>
    /// runtime repository. Mb will be removed.
    /// </summary>
    public class BaseRepository
    {
        protected FitnessContext FitnessCtx { get; set; }

        protected IConfiguration Configuration { get; }

        public BaseRepository(FitnessContext context, IConfiguration configuration)
        {
            FitnessCtx = context;
            Configuration = configuration;
        }
    }
}
