using System;
using System.Diagnostics;

public partial class TLL
{
    public static string Log(string msg)
    {
        Console.WriteLine(msg);
        Debug.WriteLine(msg);

        return msg;
    }
}
