﻿using System.Numerics;
namespace CryptoProject;

static class Methods
{
    public static BigInteger StringToAscii(string message)
    {
        BigInteger result = 1;

        for (int i = 0; i < message.Length; i++)
        {
            int character = message[i];
            result = result * 1000 + character;
        }
        return result;
    }

    public static string AsciiToString(BigInteger message)
    {
        string result = "";

        while (message != 1)
        {
            result = (char)(message % 1000) + result;
            message = message / 1000;
        }

        return result;
    }

    public static bool Order(BigInteger num, BigInteger prime)
    {
        List<BigInteger> generated = new List<BigInteger>();

        for(int i = 1; i < prime - 1; i++)
        {
            BigInteger newNum = BigInteger.ModPow(num, i, prime);
            if (generated.Contains(newNum))
            {
                return false;
            }
            else
            {
                generated.Add(newNum);
            }
        }

        return true;
    }
}