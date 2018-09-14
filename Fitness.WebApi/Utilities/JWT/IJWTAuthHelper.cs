using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Security.Claims;

namespace Fitness.WebApi.Utilities.JWT
{
    public interface IJWTAuthHelper<Tuser>
    {
        string Create(HttpRequest request, Tuser user);

        string Extend(List<Claim> claims);
    }
}
