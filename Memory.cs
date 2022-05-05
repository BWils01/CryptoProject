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
        for(int i = 0; i < _messageMemory.Count; i++)
        {
            Console.WriteLine($"Memory Location {i}");
            Console.WriteLine($"{_messageMemory[i].type} CryptoSystem");
            Console.WriteLine($"message: {_messageMemory[i].message}");
        }
    }
    public void CreateSystem(CryptoSystem system)
    {
        _systemMemory.Add(system);
    }
    public void CreateMessage(Message message)
    {
        _messageMemory.Add(message);
    }
    public void DeleteSystem(int location)
    {
        _systemMemory.RemoveAt(location);
    }
    public void DeleteMessage(int location)
    {
        _messageMemory.RemoveAt(location);
    }
    #endregion
}