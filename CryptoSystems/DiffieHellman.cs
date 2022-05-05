using System.Numerics;
using CryptoProjectMethods;
namespace CryptoProject.CryptoSystems;

class DiffieHellman : CryptoSystem
{
    #region fields
    BigInteger _recieverSecret; //the b exponent
    BigInteger _senderSecret; //the a exponent
    BigInteger _generator;
    BigInteger _sharedKey;
    #endregion
    #region constructors
    public DiffieHellman(BigInteger prime, BigInteger generator, BigInteger a, BigInteger b)
    {
        _prime = prime;
        _generator = generator;
        _recieverSecret = b;
        _senderSecret = a;
        _sharedKey = b*a % prime;
        _system = "Diffie-Hellman";
    }
    #endregion
    #region properties

    #endregion
    #region methods
    public override void PrintInfo()
    {
        Console.WriteLine("Diffie-Hellman Encryption System Info");
        Console.WriteLine();
        Console.WriteLine("Public:");
        Console.WriteLine($"g^a: {BigInteger.ModPow(_generator, _senderSecret, _prime)}");
        Console.WriteLine($"g^b: {BigInteger.ModPow(_generator, _recieverSecret, _prime)}");
        Console.WriteLine($"Prime: {_prime}");
        Console.WriteLine("Private:");
        Console.WriteLine($"Shared Key: {_sharedKey}");
    }
    public override string Encrypt(string message)
    {
        BigInteger messageI = Methods.StringToAscii(message);
        string resultMS = Methods.AsciiToString(BigInteger.ModPow(messageI, _sharedKey, _prime));
        return resultMS;
    }
    public override string Decrypt(string message)
    {

    }
    public override string Intercept(string message)
    {
        throw new NotImplementedException();
    }
    #endregion
}