using System.Numerics;
namespace CryptoProject.CryptoSystems;

abstract class CryptoSystem
{
    #region fields
    protected BigInteger _prime;
    protected string _system;
    #endregion
    #region properties
    public BigInteger prime
    {
        get { return _prime; }
    }
    public string system
    {
        get { return _system; }
    }
    #endregion
    #region constructors

    #endregion
    #region methods
    public abstract void PrintInfo();
    public abstract string Encrypt(string message);
    public abstract string Decrypt(string message);
    public abstract string Intercept(string message);
    #endregion
}