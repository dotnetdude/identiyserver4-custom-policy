using Microsoft.AspNetCore.Authorization;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class MinimumAgeHandler : AuthorizationHandler<MinimumAgeRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumAgeRequirement requirement)
        {
            if (!context.User.HasClaim(c => c.Type == "client_Age"))
            {
                // .NET 4.x -> return Task.FromResult(0);
                return Task.CompletedTask;
            }

            var clientage = Convert.ToInt16(context.User.FindFirst(
                c => c.Type == "client_Age").Value);

            if (clientage >= requirement.MinimumAge)
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }

    public class MinimumAgeRequirement : IAuthorizationRequirement
    {
        public int MinimumAge { get; private set; }

        public MinimumAgeRequirement(int minimumAge)
        {
            MinimumAge = minimumAge;
        }
    }
}
