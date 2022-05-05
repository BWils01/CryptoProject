using System.Numerics;
using CryptoProjectMethods;
using CryptoProject.CryptoSystems;

class Message
{
    #region fields
    BigInteger _message;
    string _type;
    #endregion
    #region properties
    public BigInteger message
    {
        get { return _message; }
    }
    public string type
    {
        get { return _type; }
    }
    #endregion
    #region constructors
    public Message(BigInteger message, string type)
    {
        _message = message;
        _type = type;
    }
    #endregion
    #region methods

    #endregion
}