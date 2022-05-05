﻿using System.Numerics;
namespace CryptoProject.CryptoSystems;

class ElGamal : CryptoSystem
{
    #region fields
    BigInteger _generator;
    BigInteger _privateKey;
    #endregion
    #region constructors
    public ElGamal(BigInteger prime, BigInteger generator, BigInteger privateKey)
    {
        _generator = generator;
        _privateKey = privateKey;
        _prime = prime;
        _system = "El Gamal";
    }
    #endregion
    #region properties

    #endregion
    #region methods
    public override void PrintInfo()
    {
        Console.WriteLine("El Gamal Encryption System Info");
        Console.WriteLine();
        Console.WriteLine($"Generator: {_generator}");
        Console.WriteLine($"Prime: {_prime}");
        Console.WriteLine($"Private Key: {_privateKey}");
    }
    public override BigInteger Encrypt(string message)
    {
        throw new NotImplementedException();
    }
    public override string Decrypt(BigInteger message)
    {
        throw new NotImplementedException();
    }
    public override string Intercept(BigInteger message)
    {
        throw new NotImplementedException();
    }
    #endregion
}