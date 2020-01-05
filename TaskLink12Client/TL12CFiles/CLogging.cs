using System;

namespace TaskLink12Client
{
    public static partial class TLC
    {
        /// <summary>
        /// Static Invoke to Write to textBoxLog and Log
        /// </summary>
        /// <param name="msg">Message to display and Log</param>
        /// <returns>Returns Log Message</returns>
        public static string LogI(string msg)
        {
            Form.textBoxLog.Invoke(new Action(() => Form.textBoxLog.Text += TLL.Log(msg) + "\r\n"));
            return msg;
        }
    }
}
