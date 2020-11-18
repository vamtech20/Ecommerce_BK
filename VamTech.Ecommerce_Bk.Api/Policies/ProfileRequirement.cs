using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VamTech.Ecommerce.Api.Policies
{
    public class ProfileRequirement : IAuthorizationRequirement
    {
        public ProfileRequirement()
            {
            }

    }
}
