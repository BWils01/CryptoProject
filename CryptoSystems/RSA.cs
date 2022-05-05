using System.Numerics;
using CryptoProjectMethods;
namespace CryptoProject.CryptoSystems;

class RSA : CryptoSystem
{
    #region fields
    BigInteger _secondPrime;
    BigInteger _exponent;
    BigInteger _phiN;
    BigInteger _N;

    #endregion
    #region constructors
    public RSA(BigInteger prime, BigInteger secondPrime, BigInteger exponent)
    {
        _prime = prime;
        _secondPrime = secondPrime;
        _exponent = exponent;
        _phiN = (prime - 1) * (secondPrime - 1);
        _N = prime * secondPrime;
        _system = "RSA";
    }
    public RSA(BigInteger N, BigInteger exponent)
    {
        _prime = 0;
        _secondPrime = 0;
        _exponent = exponent;
        _phiN = (_prime - 1) * (_secondPrime - 1);
        _N = N;
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
        BigInteger messageI = Methods.StringToAscii(message);
        string resultM = Methods.AsciiToString(BigInteger.ModPow(messageI, _exponent, _prime * _secondPrime));
        return resultM;
    }
    public override string Decrypt(string message)
    {
        BigInteger messageI = Methods.StringToAscii(message);
        BigInteger inv = Methods.ModInversion(_exponent, _phiN);
        string resultM = Methods.AsciiToString(BigInteger.ModPow(messageI, inv, _prime * _secondPrime));
        return resultM;
    }
    public override string Intercept(string message)
    {
        //brute force N (this is horrible and slow)
        for(int i = 1; i < _N; i++)
        {
            for(int j = 1; j < _N; j++)
            {
                if(i * j == _N)
                {
                    _prime = i;
                    _secondPrime = j;
                }
            }
        }
        _phiN = (_prime - 1) * (_secondPrime - 1);

        string resultM = Decrypt(message);
        return resultM;
    }
    #endregion
}