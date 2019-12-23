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

    public static string Log(Exception ex)
    {
        return Log(ex.Message);
    }

    public static string LogF(string msg, ref System.Windows.Forms.TextBox textBox)
    {
        textBox.Text += msg;
        Log("* " + msg + " /*\r\n");
        return msg;
    }
}
