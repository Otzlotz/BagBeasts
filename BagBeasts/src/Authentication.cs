using BagBeasts.src.Database;
namespace BagBeasts.src.Authentication;

public static class Authentication
{
    public static bool CheckForAuth(string AuthToken)
    {
        UserAccessor UA = new UserAccessor();

        if (AuthToken != null)
        {
            UA.validateAuthToken(AuthToken);
            return true;
        }
        return false;
    }
}