

using System;

namespace TaskLink12Client
{
    public partial class TLC
    {
        public static string LogI(string msg)
        {
            TLC.Form.textBoxLog.Invoke(new Action(() => TLC.Form.textBoxLog.Text += TLL.Log(msg) + "\r\n"));
            return msg;
        }
    }
}
