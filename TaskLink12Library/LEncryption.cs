using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public partial class TLL
{

    /// <summary>
    /// Calculates SHA-512 Hash Sum of given string
    /// </summary>
    /// <param name="text">text to calculate the Hash of</param>
    /// <returns>Calculated SHA-256 Hash</returns>
    public static string GetHash512(string text)
    {
        byte[] textBytes = Utf8.GetBytes(text);
        using (SHA512Managed hashstring = new SHA512Managed())
        {
            byte[] hash = hashstring.ComputeHash(textBytes);
            StringBuilder builder = new StringBuilder();
            foreach (byte x in hash)
            {
                builder.Append(string.Format(@"{0:x2}", x));
            }
            string encodedString = builder.ToString();
            Log("Encrypted text. SHA-256 Hash: " + encodedString);
            return encodedString;
        }
    }

    /*
    /// <summary>
    /// Encrypts given string with AES using passphrase and initVector
    /// </summary>
    /// <param name="plainText">string to Encrypt</param>
    /// <param name="passPhrase">Passphrase to use in Combination with initVector</param>
    /// <returns>Encrypted string</returns>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2202:Objekte nicht mehrmals verwerfen")]
    public static string EncryptString(string text, string SessionPassword, string initVector)
    {
        try
        {
            //Log("Encrypting: " + text);
            //Log("With Password: " + SessionPassword);
            //Log("Using initVector: " + initVector);

            byte[] initVectorBytes = Utf8.GetBytes(initVector);
            byte[] plainTextBytes = Utf8.GetBytes(text);
            PasswordDeriveBytes password = new PasswordDeriveBytes(SessionPassword, null);
            byte[] keyBytes = password.GetBytes(keysize / 8);
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
                password.Dispose();
                symmetricKey.Clear();
                return Utf8.GetString(cipherTextBytes);
                //return Convert.ToBase64String(cipherTextBytes);
            }
        }
        catch (Exception ex)
        {
            Log(ex, "Encrypting " + text);
            return text;
        }
    }

    /// <summary>
    /// Decrypts given string with AES using passphrase and initVector
    /// </summary>
    /// <param name="cipherText">string to Decrypt</param>
    /// <param name="passPhrase">Passphrase to use in Combination with initVector</param>
    /// <returns>Decrypted string</returns>
    public static string DecryptString(string text, string SessionPassword, string initVector)
    {
        try
        {
            //Log("Decrypting: " + text);
            //Log("With Password: " + SessionPassword);
            //Log("Using initVector: " + initVector);

            byte[] initVectorBytes = Utf8.GetBytes(initVector);

            byte[] cipherTextBytes = Utf8.GetBytes(text);//Convert.FromBase64String(text);

            PasswordDeriveBytes password = new PasswordDeriveBytes(SessionPassword, null);
            byte[] keyBytes = password.GetBytes(keysize / 8);
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
                password.Dispose();
                symmetricKey.Clear();
                return TLL.StringCheck(Utf8.GetString(plainTextBytes, 0, decryptedByteCount));
            }
        }
        catch (Exception ex)
        {
            Log(ex, "Decrypting " + text);
            return text;
        }
    }
    */
    /*public static string DecryptString(string text, string SessionPassword, string secret)
    {
        string textToDecrypt = text;
        string ToReturn = "";
        string publickey = SessionPassword.Substring(2, 16); ;
        string privatekey = secret;
        byte[] privatekeyByte = { };
        privatekeyByte = System.Text.Encoding.UTF8.GetBytes(privatekey);
        byte[] publickeybyte = { };
        publickeybyte = System.Text.Encoding.UTF8.GetBytes(publickey);
        MemoryStream ms = null;
        CryptoStream cs = null;
        byte[] inputbyteArray = new byte[textToDecrypt.Replace(" ", "+").Length];
        inputbyteArray = Convert.FromBase64String(textToDecrypt.Replace(" ", "+"));
        using (AesCryptoServiceProvider des = new AesCryptoServiceProvider())
        {
            ms = new MemoryStream();
            cs = new CryptoStream(ms, des.CreateDecryptor(publickeybyte, privatekeyByte), CryptoStreamMode.Write);
            cs.Write(inputbyteArray, 0, inputbyteArray.Length);
            cs.FlushFinalBlock();
            Encoding encoding = Encoding.UTF8;
            ToReturn = encoding.GetString(ms.ToArray());
        }
        return ToReturn;
    }
    public static string EncryptString(string text, string SessionPassword, string secret)
    {
        string textToEncrypt = text;
        string ToReturn = "";
        string publickey = SessionPassword.Substring(2, 16);
        string secretkey = secret;
        byte[] secretkeyByte = { };
        secretkeyByte = Encoding.UTF8.GetBytes(secretkey);
        byte[] publickeybyte = { };
        publickeybyte = Encoding.UTF8.GetBytes(publickey);
        MemoryStream ms = null;
        CryptoStream cs = null;
        byte[] inputbyteArray = System.Text.Encoding.UTF8.GetBytes(textToEncrypt);
        using (AesCryptoServiceProvider des = new AesCryptoServiceProvider())
        {
            ms = new MemoryStream();
            cs = new CryptoStream(ms, des.CreateEncryptor(publickeybyte, secretkeyByte), CryptoStreamMode.Write);
            cs.Write(inputbyteArray, 0, inputbyteArray.Length);
            cs.FlushFinalBlock();
            ToReturn = Convert.ToBase64String(ms.ToArray());
        }
        return ToReturn;
    }*/
    public static byte[] EncryptString(string text, string SessionPassword, string secret)
    {
        byte[] iv = Utf8.GetBytes(secret);
        byte[] array;

        using (Aes aes = Aes.Create())
        {
            aes.Key = Encoding.UTF8.GetBytes(SessionPassword.Substring(2,16));
            aes.IV = iv;

            ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                    {
                        streamWriter.Write(text);
                    }
                    array = memoryStream.ToArray();
                }
            }
        }
        return array;
    }

    /// <summary>
    /// Decrypts string
    /// </summary>
    /// <param name="text"></param>
    /// <param name="SessionPassword"></param>
    /// <param name="secret"></param>
    /// <returns></returns>
    public static string DecryptString(byte[] text, string SessionPassword, string secret)
    {
        byte[] iv = Utf8.GetBytes(secret);
        //byte[] buffer = Convert.FromBase64String(text);

        using (Aes aes = Aes.Create())
        {
            aes.Key = Encoding.UTF8.GetBytes(SessionPassword.Substring(2, 16));
            aes.IV = iv;
            ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

            using (MemoryStream memoryStream = new MemoryStream(text))
            {
                using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                    {
                        return streamReader.ReadToEnd();
                    }
                }
            }
        }
    }
}