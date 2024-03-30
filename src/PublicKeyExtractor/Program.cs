using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.OpenSsl;

namespace PublicKeyExtractor;

public static class Program
{
    public static void Main(string[] args)
    {
        if (args.Length != 1)
        {
            Console.WriteLine("Usage: PublicKeyExtractor <private_key_file.pem>");
            return;
        }

        var privateKeyPath = args[0];

        try
        {
            var (modulus, publicExponent) = ExtractModulusAndPublicExponentFromPrivateKey(privateKeyPath);

            Console.WriteLine($"Modulus (base64):\n{Convert.ToBase64String(modulus)}\n");
            Console.WriteLine($"Public Exponent (base64):\n{Convert.ToBase64String(publicExponent)}\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    private static (byte[] modulus, byte[] publicExponent) ExtractModulusAndPublicExponentFromPrivateKey(string privateKeyPath)
    {
        using StreamReader reader = File.OpenText(privateKeyPath);
        var keyPair = (RsaPrivateCrtKeyParameters)new PemReader(reader).ReadObject();

        return (keyPair.Modulus.ToByteArrayUnsigned(), keyPair.PublicExponent.ToByteArrayUnsigned());
    }
}