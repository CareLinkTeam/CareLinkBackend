namespace API.Identity;

public static class AuthorizationPolicyRegistration
{
    public static IServiceCollection AddAuthorizationPolicies(this IServiceCollection services)
    {
        services.AddAuthorization(options =>
        {
            // Admin-only policy
            options.AddPolicy(IdentityData.AdminPolicy, policy =>
                policy.RequireClaim(IdentityData.RoleClaim, IdentityData.AdminRole));

            // caretaker-only policy
            options.AddPolicy(IdentityData.CareTakerPolicy, policy =>
                policy.RequireClaim(IdentityData.RoleClaim, IdentityData.CareTakerRole));
        });

        return services;
    }
}

