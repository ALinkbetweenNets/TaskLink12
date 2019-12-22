using System;
using System.Net;
using System.Text;

public static partial class TLL
{
    /// <summary>
    /// Network port to use for TCP connection. Must be unused by other services.
    /// Must be equal on communicating Systems.
    /// </summary>
    public static ushort Port = 2502;

    /// <summary>
    /// Used to Convert strings and bytes to and from UTF8 chars
    /// </summary>
    public static UTF8Encoding Utf8 = new UTF8Encoding();

    /// <summary>
    /// Filter for local IP Addresses used in IPFilter
    /// </summary>
    public const string LocalIPFilter = "MTkyLjE2OC4 =";

    /// <summary>
    /// The File under which the Session Password get stored
    /// </summary>
    private const string PathSP = ".SP.tl";

    /// <summary>
    /// Array of chars that should be removed from the TCP traffic -> enhancing safety
    /// </summary>
    private static readonly char[] BAD_CHARS = { '/', '\\', '\"', '\'', '{', '}' };

}
