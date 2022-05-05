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
    BigInteger _gA;
    BigInteger _gB;
    #endregion
    #region constructors
    public DiffieHellman(BigInteger prime, BigInteger generator, BigInteger a, BigInteger b)
    {
        _prime = prime;
        _generator = generator;
        _recieverSecret = b;
        _senderSecret = a;
        _gA = BigInteger.ModPow(generator, a, prime);
        _gB = BigInteger.ModPow(generator, b, prime);
        _sharedKey = BigInteger.ModPow(_gA, b, prime);
        _system = "Diffie-Hellman";
    }
    public DiffieHellman(BigInteger prime, BigInteger generator, string gAgB)
    {
        _prime = prime;
        _generator = generator;
        _recieverSecret = 1;
        _senderSecret = 1;
        _sharedKey = 1;
        var split = gAgB.Split('.');
        _gA = BigInteger.Parse(split[0]);
        _gB = BigInteger.Parse(split[1]);
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
        BigInteger inv = Methods.ModInversion(_sharedKey, _prime);
        BigInteger messageI = Methods.StringToAscii(message);
        string resultMS = Methods.AsciiToString(BigInteger.ModPow(messageI, inv, _prime));
        return resultMS;
    }
    public override string Intercept(string message)
    {
        //brute force g^A
        for(int i = 1; i < _prime; i++)
        {
            if(BigInteger.ModPow(_generator, i, _prime) == _gA)
            {
                _senderSecret = i;
                break;
            }
        }
        for (int i = 1; i < _prime; i++)
        {
            if (BigInteger.ModPow(_generator, i, _prime) == _gB)
            {
                _recieverSecret = i;
                break;
            }
        }
        _sharedKey = BigInteger.ModPow(_gA, _recieverSecret, _prime);

        string resultM = Decrypt(message);
        return resultM;
    }
    #endregion
}