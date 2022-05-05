using System.Numerics;
using CryptoProjectMethods;
using CryptoProject.CryptoSystems;

class Message
{
    string _message;
    CryptoSystem _cryptoSystem;

    public CryptoSystem cryptosystem
    {
        get { return _cryptoSystem; }
    }
    public Message(string message, CryptoSystem cryptoSystem)
    {
        _message = message;
        _cryptoSystem = cryptoSystem;
    }
}