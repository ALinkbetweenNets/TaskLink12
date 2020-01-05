using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

public partial class TLL
{
    ///<summary>
    ///Gets IP Address of Internal Network and Writes to label
    ///</summary>
    public static List<IPAddress> RefreshLocalIP()
    {
        List<IPAddress> IpList = new List<IPAddress>();
        try
        {
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            Log("Local IP Addresses:");
            foreach (IPAddress address in host.AddressList)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork
                    && IPFilter(address))
                {
                    IpList.Add(address);
                    Log(address.ToString());
                }
            }
        }
        catch (Exception ex)
        {
            Log(ex);
            Log("Error while getting local IP");
        }
        return IpList;
    }

    /// <summary>
    /// Tests IPv4 Address with IP localIPFilter
    /// </summary>
    /// <param name="IPToCheck">The IPv4 Address to test</param>
    /// <returns>Wether The given IPv4 is local (IP Filter applies)</returns>
    public static bool IPFilter(string IPToCheck) => IPAddress.TryParse(IPToCheck, out testIPOut)
        && IPToCheck.StartsWith(Utf8.GetString(
            Convert.FromBase64String(LocalIPFilter)));

    /// <summary>
    /// Overload for IPAddress Objects. Tests IPv4 Address with IP localIPFilter
    /// </summary>
    /// <param name="IPToCheck">The IPv4 Address to test</param>
    /// <returns>Wether The given IPv4 is local (IP Filter applies)</returns>
    public static bool IPFilter(IPAddress IPToCheck) => IPToCheck.ToString().StartsWith(
        Utf8.GetString(Convert.FromBase64String(LocalIPFilter)));
}
