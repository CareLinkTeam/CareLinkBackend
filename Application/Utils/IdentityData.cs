namespace Application.Utils;

public class IdentityData
{
    //Role denefinitions
    public const string AdminRole = "Admin";
    public const string CareTakerRole = "CareTaker";
    public const string CustomerRole = "Customer";

    //Policy names 
    public const string AdminPolicy = "AdminOnly";
    public const string CareTakerPolicy = "CareTakerOnly";

    public const string RoleClaim = "Role";
    public const string NameClaim = "Name";

}

