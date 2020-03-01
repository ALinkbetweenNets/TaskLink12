using System.Collections.Generic;
using System.Net;
using System.Text;

public partial class TLL
{
    /// <summary>
    /// Used to Convert strings and bytes to and from UTF8 chars
    /// </summary>
    public static UTF8Encoding Utf8 = new UTF8Encoding();

    /// <summary>
    /// Filter for local IP Addresses used in IPFilter
    /// </summary>
    private static readonly string[] LocalIPFilter = new string[] {
        "MTkyLjE2OC4 =","MTAu","MTcyLg==" };

    /// <summary>
    /// used to determine the keysize of the encryption algorithm
    /// AES standard keysize is 256
    /// </summary>
    public const ushort keysize = 256;

    /// <summary>
    /// Session password used for Communication. Should never be clear text (-> use SHA-512).
    /// Must be equal on all devices
    /// </summary>
    public string SessionPassword = string.Empty;

    /// <summary>
    /// Checks wether the Session Password is set
    /// </summary>
    public bool SPSet
    {
        get
        {
            return SessionPassword.Length > 0;
        }
    }

    /// <summary>
    /// Checks wether án IP Adress is set
    /// </summary>
    public bool IPSet
    {
        get
        {
            return LocalIP.Length > 0;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public const ushort ReadLengthLength = 4;

    /// <summary>
    /// size of the IV in bytes = keysize / 8
    /// Default 256 -> IV = 32 bytes
    /// Using 16 character string -> 32 bytes when converted to a byte array
    /// </summary>
    public string initVector = "pemgail9uzpgzl88";

    /// <summary>
    /// Local IP Address used for connections. Replaced at init
    /// </summary>
    public string LocalIP = "";

    /// <summary>
    /// Used in the IPFilter to check wether given IPs can be parsed
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Codequalität", "IDE0052:Ungelesene private Member entfernen", Justification = "<Ausstehend>")]
    public static IPAddress testIPOut;

    /// <summary>
    /// List of IP Adresses from Network Adapters
    /// </summary>
    public List<IPAddress> IpList = new List<IPAddress>();



}
