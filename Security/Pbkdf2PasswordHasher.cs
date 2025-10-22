using System.Security.Cryptography;
using System.Text;

namespace STRANDVENTURE.Security;

public sealed class Pbkdf2PasswordHasher : IPasswordHasher
{
    private const int Iterations = 210_000;
    private const int SaltSize = 16;     // 128-bit salt
    private const int KeySize = 32;      // 256-bit subkey
    private const string FormatMarker = "PBKDF2-HMACSHA256";

    public string Hash(string password)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(password);

        Span<byte> salt = stackalloc byte[SaltSize];
        RandomNumberGenerator.Fill(salt);

        byte[] subkey = Rfc2898DeriveBytes.Pbkdf2(
            password,
            salt.ToArray(),
            Iterations,
            HashAlgorithmName.SHA256,
            KeySize);

        return string.Join('.', new[]
        {
            FormatMarker,
            Iterations.ToString(),
            Convert.ToBase64String(salt),
            Convert.ToBase64String(subkey)
        });
    }

    public bool Verify(string password, string hash)
    {
        if (string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(hash)) return false;

        var parts = hash.Split('.', 4);
        if (parts.Length != 4 || parts[0] != FormatMarker) return false;

        if (!int.TryParse(parts[1], out var iterations) || iterations < 10_000) return false;

        byte[] salt = Convert.FromBase64String(parts[2]);
        byte[] expected = Convert.FromBase64String(parts[3]);

        byte[] actual = Rfc2898DeriveBytes.Pbkdf2(password, salt, iterations, HashAlgorithmName.SHA256, expected.Length);

        return CryptographicOperations.FixedTimeEquals(actual, expected);
    }
}