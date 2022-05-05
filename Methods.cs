using System.Numerics;
namespace CryptoProjectMethods;

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

        while (message != 1 && message > 0)
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
    #region Miller Rabin test
    private static ThreadLocal<Random> s_Gen = new ThreadLocal<Random>(
      () => 
      {
          return new Random();
      }
    );
    private static Random Gen
    {
        get
        {
            return s_Gen.Value;
        }
    }
    public static Boolean isPrime(this BigInteger value, int witnesses = 10)
    {
        if (value <= 1)
            return false;

        if (witnesses <= 0)
            witnesses = 10;

        BigInteger d = value - 1;
        int s = 0;

        while (d % 2 == 0)
        {
            d /= 2;
            s += 1;
        }

        Byte[] bytes = new Byte[value.ToByteArray().LongLength];
        BigInteger a;

        for (int i = 0; i < witnesses; i++)
        {
            do
            {
                Gen.NextBytes(bytes);

                a = new BigInteger(bytes);
            }
            while (a < 2 || a >= value - 2);

            BigInteger x = BigInteger.ModPow(a, d, value);
            if (x == 1 || x == value - 1)
                continue;

            for (int r = 1; r < s; r++)
            {
                x = BigInteger.ModPow(x, 2, value);

                if (x == 1)
                    return false;
                if (x == value - 1)
                    break;
            }

            if (x != value - 1)
                return false;
        }

        return true;
    }
    #endregion
}