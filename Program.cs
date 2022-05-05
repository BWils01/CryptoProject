// See https://aka.ms/new-console-template for more information
using CryptoProject.CryptoSystems;
using System.Numerics;

BigInteger big = 34253451345314;
big = BigInteger.ModPow(big, 69, 7331);
BigInteger inverse = BigInteger.ModPow(big, 7331 - 2, 7331);
Console.WriteLine(big*inverse%7331);

int options = 4;
while(options != 0)
{
    Console.WriteLine("What would you like to do?");
    Console.WriteLine("Note: messages are confined to the ASCII table");
    Console.WriteLine("0. Exit");
    Console.WriteLine("1. Encrypt");
    Console.WriteLine("2. Decrypt");
    Console.WriteLine("3. Intercept");
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
    Message(string message, CryptoSystem cryptoSystem)
    {
        _message = message;
        _cryptoSystem = cryptoSystem;
    }
}
class Methods
{
    public static BigInteger StringToAscii(string message)
    {
        BigInteger result = 1;

        for(int i = 0; i < message.Length; i++)
        {
            int character = message[i];
            result = result*1000 + character;
        }
        return result;
    }

    public static string AsciiToString(BigInteger message)
    {
        string result = "";

        while(message != 1)
        {
            result = (char) (message % 1000) + result;
            message = message / 1000;
        }

        return result;
    }
}