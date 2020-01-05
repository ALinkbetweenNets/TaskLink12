using System;

public partial class TLL
{
    /// <summary>
    /// Uses GC to clean up unused Memory and free RAM
    /// </summary>
    /// <returns></returns>
    public static void GCollector()
    {
        GC.Collect();
        GC.WaitForPendingFinalizers();
        Log(GC.WaitForFullGCComplete().ToString());
        GC.Collect();
        //Log($"GC: Memory before: {start}. After: {finish}. Cleared {start - finish}.");
    }
}
