using Microsoft.AspNetCore.Authorization;

namespace MinhaApi.Api.Policies
{
    public class SameUserOrAdminRequirement : IAuthorizationRequirement
    {

    }
}