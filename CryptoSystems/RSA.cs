using System.Numerics;
using CryptoProject;
namespace CryptoProject.CryptoSystems;

class RSA : CryptoSystem
{
    #region fields
    BigInteger _secondPrime;

    #endregion
    #region constructors

    #endregion
    #region properties

    #endregion
    #region methods
    public override void PrintInfo()
    {
        throw new NotImplementedException();
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