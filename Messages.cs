using System.Numerics;
using CryptoProjectMethods;
using CryptoProject.CryptoSystems;

class Message
{
    #region fields
    string _message;
    string _type;
    #endregion
    #region properties
    public string message
    {
        get { return _message; }
    }
    public string type
    {
        get { return _type; }
    }
    #endregion
    #region constructors
    public Message(string message, string type)
    {
        _message = message;
        _type = type;
    }
    #endregion
    #region methods

    #endregion
}