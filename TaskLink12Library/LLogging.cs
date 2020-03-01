using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

public partial class TLL
{
    /// <summary>
    /// Writes Message to Debug/ Console
    /// </summary>
    /// <param name="msg">Message to Log</param>
    /// <param name="file">Wether to Append message to Logfile</param>
    /// <returns>Logged message is returned</returns>
    public static string Log(string msg, bool file = true)
    {
        //Console.WriteLine(msg);
        if (file)
            try
            {
                File.AppendAllText("TLLog.txt"
                    , DateTime.Now.ToString()
                    + ": " + msg + "\n");
            }
            catch { }
        Debug.WriteLine(msg);
        return msg;
    }

    /// <summary>
    /// Log Overload for Exceptions
    /// </summary>
    /// <param name="ex">Exception to Log</param>
    /// <param name="ExceptionSender">Additional Info about Exception Location</param>
    /// <returns>Returns Log Message</returns>
    public static string Log(Exception ex, string ExceptionSender = "")
    {
        if (ExceptionSender.Length > 0)
            return Log(ex.StackTrace + ex.Message + "\n" + ExceptionSender);
        else
            return Log(ex.StackTrace + ex.Message);
    }

    public static string LogF(string msg, ref TextBox textBox)
    {
        textBox.Text += msg + "\r\n";
        return Log("* " + msg + " /*");
    }

    /// <summary>
    /// Shows Message Box and Logs Message
    /// </summary>
    /// <param name="msg">Message to display and Log</param>
    public static string LogBox(string msg = "Please set a Session Password first")
    {
        try
        {
            Microsoft.VisualBasic.Interaction.MsgBox(msg,
                    Microsoft.VisualBasic.MsgBoxStyle.OkOnly);
            return Log($"MsgBox ({msg})");
        }
        catch (Exception ex)
        {
            Log(ex);
            return Log("ERROR in MsgBox");
        }
    }

}

