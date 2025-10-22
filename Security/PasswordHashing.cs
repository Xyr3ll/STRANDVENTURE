namespace STRANDVENTURE.Security;

public static class PasswordHashing
{
    // Helper for places without DI (e.g., EF seeding)
    public static string HashForSeed(string password) =>
        new Pbkdf2PasswordHasher().Hash(password);
}