using System.Numerics;
namespace CryptoProject.CryptoSystems;

abstract class CryptoSystem
{
    BigInteger _prime;
    string _system;

    public BigInteger prime
    {
        get { return _prime; }
    }
    public string system
    {
        get { return _system; }
    }
    public abstract void PrintInfo();
    public abstract BigInteger Encrypt(string message);
    public abstract string Decrypt(BigInteger message);
}