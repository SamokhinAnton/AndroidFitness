using Microsoft.AspNetCore.Authorization;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fitness.WebApi.Utilities.Swagger
{
    public class AuthorizationHeaderParameterOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            if(context.ApiDescription.TryGetMethodInfo(out var methoInfo))
            {
                var isAuthorized = methoInfo.CustomAttributes.Any(c => c.AttributeType == typeof(AuthorizeAttribute));
                var isAllowAnonymous = methoInfo.CustomAttributes.Any(c => c.AttributeType == typeof(AllowAnonymousAttribute));
                if (isAuthorized && !isAllowAnonymous)
                {
                    if (operation.Parameters == null)
                        operation.Parameters = new List<IParameter>();
                    operation.Parameters.Add(new NonBodyParameter
                    {
                        Name = "Authorization",
                        In = "header",
                        Description = "JWT Token",
                        Required = true,
                        Type = "string",
                        Default = "Bearer "
                    });
                }
            }
        }
    }
}
