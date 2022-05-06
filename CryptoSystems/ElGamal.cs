using System.Numerics;
using CryptoProjectMethods;
namespace CryptoProject.CryptoSystems;

class ElGamal : CryptoSystem
{
    #region fields
    BigInteger _generator;
    BigInteger _privateKey;
    BigInteger _gX;
    #endregion
    #region properties

    #endregion
    #region constructors
    public ElGamal(BigInteger prime, BigInteger generator, BigInteger privateKey, BigInteger gX)
    {
        _generator = generator;
        _privateKey = privateKey;
        _prime = prime;
        _gX = gX;
        _system = "El Gamal";
    }
    #endregion
    #region methods
    public override void PrintInfo()
    {
        Console.WriteLine("El Gamal Encryption System Info");
        Console.WriteLine();
        Console.WriteLine("Public:");
        Console.WriteLine($"Generator: {_generator}");
        Console.WriteLine($"Prime: {_prime}");
        Console.WriteLine($"g^x (mod p): {_gX}");
        Console.WriteLine("Private:");
        Console.WriteLine($"Private Key: {_privateKey}");
    }
    public override string Encrypt(string message)
    {
        BigInteger result = Methods.StringToAscii(message);

        Random random = new Random();
        BigInteger tempKey = random.NextInt64()%_prime;

        BigInteger c1 = BigInteger.ModPow(_generator, tempKey, _prime);
        BigInteger c2 = result * BigInteger.ModPow(_generator, tempKey * _privateKey, _prime);

        return c1.ToString() + "C" + c2.ToString();
    }
    public override string Decrypt(string message)
    {
        var split = message.Split('C');
        BigInteger c1 = BigInteger.Parse(split[0]);
        BigInteger c2 = BigInteger.Parse(split[1]);

        BigInteger inv = Methods.ModInversion(_privateKey, _prime);

        BigInteger resultI = c2 * (Methods.ModInversion(BigInteger.ModPow(c1, _privateKey, _prime), _prime)) % _prime;
        string resultS = Methods.AsciiToString(resultI);

        return resultS;
    }
    public override string Intercept(string message)
    {
        //brute force privateKey
        BigInteger privateKey = -1;
        for(BigInteger i = 0; i < _prime; i++)
        {
            if (BigInteger.ModPow(_generator, i, _prime) == BigInteger.ModPow(_generator, _gX, _prime))
            {
                privateKey = i;
                break;
            }
        }
        Console.WriteLine($"private key is {privateKey}");
        _privateKey = privateKey;

        string result = Decrypt(message);

        return result;
    }
    #endregion
}