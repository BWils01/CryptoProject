using System.Numerics;
using CryptoProject;
namespace CryptoProject.CryptoSystems;

class RSA : CryptoSystem
{
    #region fields
    BigInteger _secondPrime;
    BigInteger _exponent;

    #endregion
    #region constructors
    public RSA(BigInteger prime, BigInteger secondPrime, BigInteger exponent)
    {
        _prime = prime;
        _secondPrime = secondPrime;
        _exponent = exponent;
        _system = "RSA";
    }
    #endregion
    #region properties

    #endregion
    #region methods
    public override void PrintInfo()
    {
        Console.WriteLine("RSA Encryption System Info");
        Console.WriteLine();
        Console.WriteLine($"Prime 1: {_prime}");
        Console.WriteLine($"Prime 2: {_secondPrime}");
        Console.WriteLine($"N = Prime1 * Prime2: {_prime * _secondPrime}");
        Console.WriteLine($"Exponent: {_exponent}");
    }
    public override BigInteger Encrypt(string message)
    {
        throw new NotImplementedException();
    }
    public override string Decrypt(BigInteger message)
    {
        throw new NotImplementedException();
    }
    #endregion
}