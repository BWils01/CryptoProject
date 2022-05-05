// See https://aka.ms/new-console-template for more information
using CryptoProject.CryptoSystems;
using CryptoProject;
using System.Numerics;

BigInteger big = 34253451345314;
big = BigInteger.ModPow(big, 69, 7331);
BigInteger inverse = BigInteger.ModPow(big, 7331 - 2, 7331);
Console.WriteLine(big*inverse%7331);
Console.WriteLine(Methods.Order(6, 11));

int options = 4;
while(options != 0)
{
    Console.WriteLine("What would you like to do?");
    Console.WriteLine("Note: messages are confined to the ASCII table");
    Console.WriteLine("0. Exit");
    Console.WriteLine("1. Encrypt");
    Console.WriteLine("2. Decrypt");
    Console.WriteLine("3. Intercept");
    Console.WriteLine("4. View Memory");
    options = Convert.ToInt32(Console.ReadLine());
    int choice = 0;
    switch (options)
    {
        #region exit
        case 0:
            //nothing
            break;
        #endregion
        #region encryption
        case 1:
            //encrypting
            Console.WriteLine("What Cryptosystem are you using?");
            Console.WriteLine("1. El Gamal");
            Console.WriteLine("2. RSA");
            Console.WriteLine("3. DiffieHellman");
            switch (choice)
            {
                case 1:
                    //stuff
                    break;
                case 2:
                    //stuff
                    break;
                case 3:
                    //stuff
                    break;
                default:
                    Console.WriteLine($"{choice} is not an option");
                    break;
            }
            break;
        #endregion
        #region decryption
        case 2:
            //decrypting
            Console.WriteLine("What Cryptosystem are you using?");
            Console.WriteLine("1. El Gamal");
            Console.WriteLine("2. RSA");
            Console.WriteLine("3. DiffieHellman");
            switch (choice)
            {
                case 1:
                    //stuff
                    break;
                case 2:
                    //stuff
                    break;
                case 3:
                    //stuff
                    break;
                default:
                    Console.WriteLine($"{choice} is not an option");
                    break;
            }
            break;
        #endregion
        #region interception
        case 3:
            //decyphering a message as if you don't know what it is
            Console.WriteLine("What Cryptosystem are you using?");
            Console.WriteLine("1. El Gamal");
            Console.WriteLine("2. RSA");
            Console.WriteLine("3. DiffieHellman");
            switch (choice)
            {
                case 1:
                    //stuff
                    break;
                case 2:
                    //stuff
                    break;
                case 3:
                    //stuff
                    break;
                default:
                    Console.WriteLine($"{choice} is not an option");
                    break;
            }
            break;
        #endregion
        #region memory
        case 4:
                //stuff
                break;
        #endregion
        #region default
        default:
            Console.WriteLine("Invalid Input");
            break;
        #endregion
    }
}
class Message
{
    string _message;
    CryptoSystem _cryptoSystem;

    public CryptoSystem cryptosystem
    {
        get { return _cryptoSystem; }
        set { _cryptoSystem = value; }
    }
    public Message(string message, CryptoSystem cryptoSystem)
    {
        _message = message;
        _cryptoSystem = cryptoSystem;
    }
}
