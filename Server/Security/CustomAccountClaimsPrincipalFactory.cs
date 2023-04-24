using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication.Internal;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Woolworths.FoodISO.Services;

namespace Woolworths.FoodISO.WebClient.Security
{
    // https://stackoverflow.com/questions/64706336/create-claims-for-a-blazor-webassembly-project
    public class CustomAccountClaimsPrincipalFactory : AccountClaimsPrincipalFactory<RemoteUserAccount>
    {
        private readonly IUserService _userService;

        private const string ID_CLAIM_TYPE = "oid";

        public CustomAccountClaimsPrincipalFactory(IAccessTokenProviderAccessor accessor, IUserService userService)
            : base(accessor) 
        {
            _userService = userService;
        }

        public async override ValueTask<ClaimsPrincipal> CreateUserAsync(RemoteUserAccount account, RemoteAuthenticationUserOptions options)
        {
            var user = await base.CreateUserAsync(account, options);

            if (user.Identity.IsAuthenticated)
            {
                var identity = (ClaimsIdentity)user.Identity;
                var id = identity.Claims.Where(c => c.Type == ID_CLAIM_TYPE).FirstOrDefault();

                if (id != null)
                {
                    var appUser = await _userService.GetUser(id.Value);

                    if (appUser != null)
                    {
                        identity.AddClaim(new Claim(Constants.CustomClaimNames.DefaultStore, appUser.defaultStoreId.ToString()));
                        identity.AddClaim(new Claim(Constants.CustomClaimNames.AlternateStores, string.Join(",", appUser.stores)));
                        identity.AddClaim(new Claim(Constants.CustomClaimNames.ViewAll, appUser.viewAll.ToString()));
                        identity.AddClaim(new Claim(Constants.CustomClaimNames.UseSmallView, appUser.useSmallView.ToString()));

                        foreach (var role in appUser.roles)
                            identity.AddClaim(new Claim(ClaimTypes.Role, role.name));
                    }
                }
            }

            return user;
        }
    }
}
