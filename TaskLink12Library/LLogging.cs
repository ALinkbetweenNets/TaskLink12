using System;
using System.Windows.Forms;

public partial class TLL
{
    public static string Log(string msg)
    {
        Console.WriteLine(msg);
        //Debug.WriteLine(msg);

        return msg;
    }

    public static string Log(Exception ex)
    {
        return Log(ex.Message);
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
            return Log("Error MSGBOX: " + ex);
        }
    }

}

