using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using BookstoreMH.Data;

namespace BookstoreMH.Authorization
{
    public class IsBookstoreAdminRequirement : IAuthorizationRequirement { }
    public class IsBookstoreAdmin :
        AuthorizationHandler<IsBookstoreAdminRequirement, Book>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public IsBookstoreAdmin(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        protected override async Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            IsBookstoreAdminRequirement requirement,
            Book resource)
        {
            var appUser = await _userManager.GetUserAsync(context.User);
            if (appUser == null)
            {
                return;
            }
             context.Succeed(requirement);
        }
    }
}