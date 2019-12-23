using System;
using System.Net;
using System.Net.Sockets;

public partial class TLL
{
    ///<summary>
    ///Gets IP Address of Internal Network and Writes to label
    ///</summary>
    public void RefreshLocalIP(System.Windows.Forms.Label labelIP)
    {
        try
        {
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            Log("Local IP Addresses:");
            foreach (IPAddress address in host.AddressList)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork
                    && IPFilter(address))
                {
                    LocalIP = address.ToString();
                    Log(LocalIP);
                }
            }
            if (LocalIP?.Length > 0)
            {
                labelIP.Text = "Local IP: " + LocalIP;
            }
            else
            {
                Log("Could not get local IP Address");
            }
        }
        catch (Exception ex)
        {
            Log(ex);
            Log("Error while getting local IP");
        }
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
