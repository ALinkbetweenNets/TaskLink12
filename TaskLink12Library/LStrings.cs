﻿using System;
using System.Text;
using System.Text.RegularExpressions;

public partial class TLL
{
    /// <summary>
    /// Removes any Bad Chars from given String
    /// </summary>
    /// <param name="testString">String to remove Bad Chars from</param>
    /// <returns></returns>
    public static string StringCheck(string testString)
    {
        ASCIIEncoding ascii = new ASCIIEncoding();
        /*foreach (char bad in BAD_CHARS)
        {
            if (testString.Contains(bad.ToString()))
                testString = testString.Replace(bad.ToString(), string.Empty);
        }*/
        testString = Encoding.ASCII.GetString(
    Encoding.Convert(
        Encoding.UTF8,
        Encoding.GetEncoding(
            Encoding.ASCII.EncodingName,
            new EncoderReplacementFallback(string.Empty),
            new DecoderExceptionFallback()
            ),
        Encoding.UTF8.GetBytes(testString)
    )
);//! for process markings ; for process differntiating
        return Regex.Replace(Regex.Replace(testString, @"[^\u0000-\u007F]+", string.Empty), @"[/\'{},#$%?]", string.Empty);
    }

    /// <summary>
    /// Converts bytes to string
    /// </summary>
    /// <param name="bytesToConvert"></param>
    /// <param name="byteLength">Length of message</param>
    /// <param name="cleartext">Wether to not decrypt message</param>
    /// <returns>Built string</returns>
    public static string GetString(byte[] bytesToConvert, int byteLength, string SessionPassword, string initVector, bool encrypted = false)
    {
        StringBuilder stringBuilder = new StringBuilder();
        for (int i = 0; i < byteLength; i++)
            stringBuilder.Append(Convert.ToChar(bytesToConvert[i]).ToString());
        string finishedString = StringCheck(stringBuilder.ToString());
        Console.WriteLine("Received: " + finishedString);
        return encrypted ? DecryptString(finishedString, SessionPassword, initVector) : finishedString;
    }

    /// <summary>
    /// Converts string to bytes
    /// </summary>
    /// <param name="stringToConvert"></param>
    /// <param name="cleartext">Wether to not encrypt message</param>
    /// <returns>Converted Bytes</returns>
    public static byte[] GetBytes(string stringToConvert, string SessionPassword, string initVector, bool encrypt = false)
    {
        stringToConvert = StringCheck(stringToConvert);
        return encrypt ? Utf8.GetBytes(EncryptString(stringToConvert, SessionPassword, initVector)) : Utf8.GetBytes(stringToConvert);
    }
}
