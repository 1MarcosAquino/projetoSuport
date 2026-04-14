using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace MinhaApi.Api.Policies
{
    public class SameUserOrAdminHandler : AuthorizationHandler<SameUserOrAdminRequirement>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            SameUserOrAdminRequirement requirement)
        {
            var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var role = context.User.FindFirst(ClaimTypes.Role)?.Value;

            var httpContext = context.Resource as HttpContext;

            var routeId = httpContext?.Request.RouteValues["id"]?.ToString();

            if (role == "Admin" || userId == routeId)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}