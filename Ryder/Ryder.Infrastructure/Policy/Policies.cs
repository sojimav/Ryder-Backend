using Microsoft.AspNetCore.Authorization;

namespace Ryder.Infrastructure.Policy
{
    public class Policies
    {
        public static string Rider = "Rider";
        public static string Customer = "Customer";

        public static AuthorizationPolicy RiderPolicy()
        {
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser().RequireRole(Rider).Build();
        }

        public static AuthorizationPolicy CustomerPolicy()
        {
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser().RequireRole(Customer).Build();
        }
    }
}