﻿using System;

namespace TaskLink12Client
{
    public partial class TLC
    {
        public static string LogI(string msg)
        {
            Form.textBoxLog.Invoke(new Action(() => Form.textBoxLog.Text += TLL.Log(msg) + "\r\n"));
            return msg;
        }
    }
}
