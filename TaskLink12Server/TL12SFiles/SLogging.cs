namespace TaskLink12Server
{
    public partial class TLS
    {
        public static string LogI(string msg)
        {
            TLL.Log(msg);
            //Form.textBoxLog.Invoke(new Action(() => Form.textBoxLog.Text += TLL.Log(msg) + "\r\n"));
            return msg;
        }
    }
}
