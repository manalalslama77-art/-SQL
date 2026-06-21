using BCrypt.Net;

namespace FinancialStatus.Common.Helpers;

public static class PasswordHelper
{
    public static string HashPassword(string password)
    {
        return BCrypt.EnhancedBCrypt.HashPassword(password, enhancedEntropy: true);
    }

    public static bool VerifyPassword(string password, string hash)
    {
        try
        {
            return BCrypt.EnhancedBCrypt.VerifyPassword(password, hash);
        }
        catch
        {
            return false;
        }
    }
}
