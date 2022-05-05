using System.Numerics;
using CryptoProjectMethods;
namespace CryptoProject.CryptoSystems;

class ElGamal : CryptoSystem
{
    #region fields
    BigInteger _generator;
    BigInteger _privateKey;
    #endregion
    #region constructors
    public ElGamal(BigInteger prime, BigInteger generator, BigInteger privateKey)
    {
        _generator = generator;
        _privateKey = privateKey;
        _prime = prime;
        _system = "El Gamal";
    }
    #endregion
    #region properties

    #endregion
    #region methods
    public override void PrintInfo()
    {
        Console.WriteLine("El Gamal Encryption System Info");
        Console.WriteLine();
        Console.WriteLine("Public:");
        Console.WriteLine($"Generator: {_generator}");
        Console.WriteLine($"Prime: {_prime}");
        Console.WriteLine($"g^x (mod p): {BigInteger.ModPow(_generator, _privateKey, _prime)}");
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
        throw new NotImplementedException();
    }
    public override string Intercept(string message)
    {
        throw new NotImplementedException();
    }
    #endregion
}