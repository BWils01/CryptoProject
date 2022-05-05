// See https://aka.ms/new-console-template for more information
using CryptoProject.CryptoSystems;
using CryptoProjectMethods;
using CryptoProjectMemory;
using System.Numerics;

BigInteger big = 34253451345314;
BigInteger bigger = BigInteger.Parse("1000000000000066600000000000001");
big = BigInteger.ModPow(big, 69, 7331);
BigInteger inverse = BigInteger.ModPow(big, 7331 - 2, 7331);
Console.WriteLine(big*inverse%7331);
Console.WriteLine(Methods.Order(6, 11));
Console.WriteLine(Methods.isPrime(bigger));

int options = 4;
Memory memory = new Memory();
Console.WriteLine("This program can encrypt, decrypt, and intercept messages as well as create cryptosystems to be stored in memory");
Console.WriteLine("What this means:");
Console.WriteLine("Encrypt: encrypt a new message with an established cryptosystem (this creates a stored message)");
Console.WriteLine("Decrypt: decrypt a created message with an established cryptosystem");
Console.WriteLine("Intercept: decrypt an already encrypted message that does not have an established cryptosystem as if you intercepted someone else's communication");
Console.WriteLine("View Memory: view created cryptosytems or messages");
Console.WriteLine("Create/Delete: create or delete a cryptosystem");
Console.WriteLine("Press Enter to continue");
Console.ReadLine();
Console.WriteLine();
Console.WriteLine();
while(options != 0)
{
    Console.WriteLine("What would you like to do?");
    Console.WriteLine("Note: messages are confined to the ASCII table");
    Console.WriteLine("0. Exit");
    Console.WriteLine("1. Encrypt");
    Console.WriteLine("2. Decrypt");
    Console.WriteLine("3. Intercept");
    Console.WriteLine("4. View Memory");
    Console.WriteLine("5. Create/Delete");
    options = Convert.ToInt32(Console.ReadLine());
    int choice = 0;
    switch (options)
    {
        #region exit
        case 0:
            Console.WriteLine("Good Bye");
            break;
        #endregion
        #region encryption
        case 1:
            Console.WriteLine("Do you know the memory location of the cryptosystem?");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No");
            choice = Convert.ToInt32(Console.ReadLine());
            if(choice == 2)
            {
                memory.PrintSystems();
                Console.WriteLine("Press Enter to continue");
                Console.ReadLine();
            }

            //acquire data
            Console.WriteLine("Input memory location");
            int location = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please input message");
            string strMessage = Console.ReadLine();

            //encrypt data
            BigInteger numMessage = memory.systemMemory[location].Encrypt(strMessage);

            //store in memory
            Message message = new Message(numMessage, memory.systemMemory[location].system);
            memory.CreateMessage(message);

            //print info to user
            Console.WriteLine($"Your encrypted message is {numMessage}");
            Console.WriteLine($"at location {location}");
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
        #region create/delete
        case 5:
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

