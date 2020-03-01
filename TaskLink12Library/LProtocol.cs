public partial class TLL
{

    /// <summary>
    /// Version of the TaskLink Project. Used in Protocol
    /// </summary>
    public const string Version = "12.3";

    /// <summary>
    /// Network port to use for TCP connection. Must be unused by other services.
    /// Must be equal on communicating Systems.
    /// </summary>
    public static ushort Port = 2502;

    public const ushort R1Min = 10;
    public const ushort R1Max = 30;
    public const ushort R2Min = 100;
    public const ushort R2Max = 120;
}
