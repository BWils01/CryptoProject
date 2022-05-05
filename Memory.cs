using System.Numerics;
using CryptoProject.CryptoSystems;
namespace CryptoProjectMemory;

class Memory
{
    #region fields
    List<CryptoSystem> _systemMemory = new List<CryptoSystem>();
    List<Message> _messageMemory = new List<Message>();
    #endregion
    #region properties
    public List<CryptoSystem> systemMemory
    {
        get { return _systemMemory; }
        set { _systemMemory = value; }
    }
    public List<Message> messageMemory
    {
        get { return _messageMemory; }
        set { _messageMemory = value; }
    }
    #endregion
    #region constructors

    #endregion
    #region methods
    public void PrintSystems()
    {
        for(int i = 0; i < _systemMemory.Count; i++)
        {
            Console.WriteLine($"Memory Location {i}");
            _systemMemory[i].PrintInfo();
        }
    }
    public void PrintMessages()
    {
        //stuff
    }
    #endregion
}