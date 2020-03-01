using System.Collections.Generic;
using System.IO;
using System.Net;

namespace TaskLink12Server
{
    public static partial class TLS
    {
        public static void FileClientSave(string[] ClientList)
        {
            File.WriteAllLines(TLS.PathC, ClientList);
        }

        public static IPAddress[] FileClientLoad()
        {
            List<IPAddress> ipList = new List<IPAddress>();
            foreach (string s in File.ReadAllLines(TLS.PathC))
            {
                try
                {
                    if (TLL.IPFilter(TLL.StringCheck(s)))
                        ipList.Add(IPAddress.Parse(TLL.StringCheck(s)));
                }
                catch { }
            }
            return ipList.ToArray();
        }
    }
}
