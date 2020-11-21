using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VamTech.Ecommerce.Api.Policies
{
    public class ProfileHandler : AuthorizationHandler<ProfileRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ProfileRequirement requirement)
        {
            if(context.User.Claims.Any(x=> x.Type == "Perfil"))
            {
                context.Succeed(requirement);
            }

            return Task.FromResult(0);
        }
    }
}
