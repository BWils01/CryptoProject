using System.Numerics;
namespace CryptoProject.CryptoSystems;

abstract class CryptoSystem
{
    BigInteger _prime;
    string _system;

    public BigInteger prime
    {
        get { return _prime; }
        set { _prime = value; }
    }
    public abstract void PrintInfo();
    public abstract BigInteger Encrypt(string message);
    public abstract string Decrypt(BigInteger message);
}