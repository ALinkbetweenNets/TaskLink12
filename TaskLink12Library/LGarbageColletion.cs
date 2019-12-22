using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;

public partial class TLL
{
    public static async Task<long> Collector()
    {
        long start = GC.GetTotalMemory(true);

        GC.Collect();
        GC.WaitForPendingFinalizers();
        Log(GC.WaitForFullGCComplete().ToString());
        GC.Collect();
        long finish = GC.GetTotalMemory(true);

        Log($"Garbage Collection. Used Memory before: {start}. After Collection: {finish}. Cleared {start - finish}.");
        return (start - finish);
    }
}
