using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.Core.Repositories
{
    public interface ISearch<T>
        where T: new()
    {
        Task<IEnumerable<T>> SearchAsync(string pattern);
    }
}
