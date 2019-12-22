﻿using System;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;

public static partial class TLL
{
    /// <summary>
    /// Encrypts given string with AES using passphrase and initVector
    /// </summary>
    /// <param name="plainText">string to Encrypt</param>
    /// <param name="passPhrase">Passphrase to use in Combination with initVector</param>
    /// <returns>Encrypted string</returns>
    public static string EncryptString(string text, string password, string initVector)
    {
        Log("Encrypting: " + text);
        Log("With Password: " + password);
        Log("Using initVector: " + initVector);

        byte[] initVectorBytes = Utf8.GetBytes(initVector);
        byte[] plainTextBytes = Utf8.GetBytes(text);
        PasswordDeriveBytes pass = new PasswordDeriveBytes(password, null);
        byte[] keyBytes = pass.GetBytes(keysize / 8);
        using (AesCryptoServiceProvider symmetricKey = new AesCryptoServiceProvider
        {
            Mode = CipherMode.CBC
        })
        {
            ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
            cryptoStream.FlushFinalBlock();
            byte[] cipherTextBytes = memoryStream.ToArray();
            cryptoStream.Close();
            memoryStream.Close();
            pass.Dispose();
            symmetricKey.Clear();
            return Convert.ToBase64String(cipherTextBytes);
        }
    }

    /// <summary>
    /// Decrypts given string with AES using passphrase and initVector
    /// </summary>
    /// <param name="cipherText">string to Decrypt</param>
    /// <param name="passPhrase">Passphrase to use in Combination with initVector</param>
    /// <returns>Decrypted string</returns>
    public static string DecryptString(string text, string password, string initVector)
    {
        Log("Decrypting: " + text);
        Log("With Password: " + password);
        Log("Using initVector: " + initVector);

        byte[] initVectorBytes = Utf8.GetBytes(initVector);
        byte[] cipherTextBytes = Convert.FromBase64String(text);
        PasswordDeriveBytes pass = new PasswordDeriveBytes(password, null);
        byte[] keyBytes = pass.GetBytes(keysize / 8);
        using (AesCryptoServiceProvider symmetricKey = new AesCryptoServiceProvider
        {
            Mode = CipherMode.CBC
        })
        {
            ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
            MemoryStream memoryStream = new MemoryStream(cipherTextBytes);
            CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];
            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            cryptoStream.Close();
            memoryStream.Close();
            pass.Dispose();
            symmetricKey.Clear();
            return Utf8.GetString(plainTextBytes, 0, decryptedByteCount);
        }
    }
}