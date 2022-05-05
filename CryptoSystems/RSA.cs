using System.Numerics;
using CryptoProjectMethods;
namespace CryptoProject.CryptoSystems;

class RSA : CryptoSystem
{
    #region fields
    BigInteger _secondPrime;
    BigInteger _exponent;
    BigInteger _phiN;

    #endregion
    #region constructors
    public RSA(BigInteger prime, BigInteger secondPrime, BigInteger exponent)
    {
        _prime = prime;
        _secondPrime = secondPrime;
        _exponent = exponent;
        _phiN = (prime - 1) * (secondPrime - 1);
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
        Console.WriteLine("Public");
        Console.WriteLine($"Exponent: {_exponent}");
        Console.WriteLine($"N = Prime1 * Prime2: {_prime * _secondPrime}");
        Console.WriteLine("Private:");
        Console.WriteLine($"Prime1: {_prime}");
        Console.WriteLine($"Prime2: {_secondPrime}");
        Console.WriteLine($"Exponent^-1: {Methods.ModInversion(_exponent, _phiN)}");
    }
    public override string Encrypt(string message)
    {
        throw new NotImplementedException();
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