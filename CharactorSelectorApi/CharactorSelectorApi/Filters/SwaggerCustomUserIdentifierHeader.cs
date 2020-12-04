using System.Collections.Generic;
using System.Linq;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CharactorSelectorApi.Filters
{
    public class SwaggerCustomUserIdentifierHeader : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var authorizeAttributes = context.MethodInfo.DeclaringType?.GetCustomAttributes(true)
                .Union(context.MethodInfo.GetCustomAttributes(true));

            if (!authorizeAttributes.Any()) return;

            operation.Parameters ??= new List<OpenApiParameter>();

            operation.Parameters.Add(new OpenApiParameter
            {
                Required = true,
                Description =
                    "User identifier for auditing purpose. Pass in either AD username or Global Membership id",
                Name = Constants.CustomHeader.UserIdentifier,
                In = ParameterLocation.Header
            });

            operation.Parameters.Add(new OpenApiParameter
            {
                Required = true,
                Description =
                    @"Source of the user identifier. : 1 = 'GlobalMembership', 2 = 'ActiveDirectory' or 3 = 'Others'",
                Name = Constants.CustomHeader.MemberOfSystemId,
                In = ParameterLocation.Header
            });
        }
    }
}