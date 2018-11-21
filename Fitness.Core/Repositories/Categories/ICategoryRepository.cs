using System;
using System.Collections.Generic;
using System.Text;

namespace Fitness.Core.Repositories.Categories
{
    public interface ICategoryRepository<T> : IBaseRepository<T>, ISearch<T>
        where T: new()
    {

    }
}
