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
            if(memory.systemMemory.Count == 0)
            {
                Console.WriteLine("There are no stored cyptosystems");
                break;
            }
            Console.WriteLine("Do you know the memory location of the cryptosystem? y/n");
            string ynE = Console.ReadLine();

            choice = Convert.ToInt32(Console.ReadLine());
            if(ynE == "n")
            {
                memory.PrintSystems();
                Console.WriteLine();
                Console.WriteLine("Press Enter to continue");
                Console.ReadLine();
            }

            //acquire data
            Console.WriteLine("Input memory location");
            int locationE = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please input message");
            string strMessage = Console.ReadLine();

            //encrypt data
            BigInteger numMessage = memory.systemMemory[locationE].Encrypt(strMessage);

            //store in memory
            Message message = new Message(numMessage, memory.systemMemory[locationE].system);
            memory.CreateMessage(message);

            //print info to user
            Console.WriteLine($"Your encrypted message is {numMessage}");
            Console.WriteLine($"at location {locationE}");
            break;
        #endregion
        #region decryption
        case 2:
            if (memory.systemMemory.Count == 0)
            {
                Console.WriteLine("There are no stored cyptosystems");
                break;
            }

            Console.WriteLine("Do you know the memory location of the cryptosystem? y/n");
            string ynD = Console.ReadLine();

            if (ynD == "n")
            {
                memory.PrintSystems();
                Console.WriteLine();
                Console.WriteLine("Press Enter to continue");
                Console.ReadLine();
            }
            Console.WriteLine("Input the memory location");
            int locationDS = Convert.ToInt32((Console.ReadLine()));

            Console.WriteLine("Is the message stored? y/n");
            ynD = Console.ReadLine();

            //Decrypt a stored message
            if(ynD == "y")
            {
                Console.WriteLine("Do you know the memory location of the message? y/n");
                ynD = Console.ReadLine();
                if (ynD == "n")
                {
                    memory.PrintMessages();
                    Console.WriteLine();
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                }
                Console.WriteLine("Input the memory location");
                int locationDM = Convert.ToInt32((Console.ReadLine()));

                string decrypted = memory.systemMemory[locationDS].Decrypt(memory.messageMemory[locationDM].message);
                Console.WriteLine($"Decrypted message is {decrypted}");
            }
            else
            {
                Console.WriteLine("Input the encrypted message");
                BigInteger messageD = BigInteger.Parse(Console.ReadLine());

                string decrypted = memory.systemMemory[locationDS].Decrypt(messageD);
                Console.WriteLine($"Decrypted message is {decrypted}");
            }
            break;
        #endregion
        #region interception
        case 3:
            //decyphering a message as if you don't know what it is
            Console.WriteLine("A cryptosystem is necessary to have been created");
            Console.WriteLine("You can put in only the known information and choose random info for the rest");
            if (memory.systemMemory.Count == 0)
            {
                Console.WriteLine("There are no stored cyptosystems");
                break;
            }
            Console.WriteLine("Do you wish to exit? y/n");
            string ynI = Console.ReadLine();
            if (ynI == "y") break;

            Console.WriteLine("Do you know the memory location of the system? y/n");

            if (ynI == "n")
            {
                memory.PrintSystems();
                Console.WriteLine();
                Console.WriteLine("Press Enter to continue");
                Console.ReadLine();
            }

            Console.WriteLine("Input the memory location of the system");
            int locationIS = Convert.ToInt32((Console.ReadLine()));

            Console.WriteLine("Is the message in the memory? y/n");
            ynI = Console.ReadLine();
            BigInteger intercept;
            
            if(ynI == "n")
            {
                intercept = BigInteger.Parse(Console.ReadLine());
            }
            else
            {
                Console.WriteLine("Do you know the memory location of the message? y/n");
                ynI = Console.ReadLine();

                if(ynI == "n")
                {
                    memory.PrintMessages();
                    Console.WriteLine();
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                }

                Console.WriteLine("What is the location of the message");
                int locationIM = Convert.ToInt32((Console.ReadLine()));
                intercept = memory.messageMemory[locationIM].message;
            }

            string translation = memory.systemMemory[locationIS].Intercept(intercept);
            Console.WriteLine($"The message is {translation}");

            break;
        #endregion
        #region memory
        case 4:
            Console.WriteLine("Which memory would you like to view?");
            Console.WriteLine("0. exit");
            Console.WriteLine("1. Stored cryptosystems");
            Console.WriteLine("2. Stored encrypted messages");
            Console.WriteLine("3. Both");

            switch (choice)
            {
                case 0:
                    //nothing
                    break;
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
                    Console.WriteLine("Invalid input");
                    break;
            }

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

