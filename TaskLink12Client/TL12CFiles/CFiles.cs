using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskLink12Client
{
    public partial class TLC
    {
        public static void FileSilent(ref TextBox textBoxLog)
        {
            try
            {
                if (File.Exists(TLC.PathSilent))
                {
                    var SFile = File.ReadAllLines(TLC.PathSilent);
                    TLL.LogF("Loaded File:", ref textBoxLog);
                    foreach (string i in SFile)
                    {
                        TLL.LogF(i, ref textBoxLog);
                        if (i == "Silent")
                        {
                            Silent = true;
                            TLL.LogF("Started in Silent Mode. No Message Boxes will appear", ref textBoxLog);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                TLL.Log(ex);
            }
        }

        public static void FileSP(ref TextBox textBoxLog, TLL tll)
        {
            try
            {
                if (File.Exists(TLL.PathSP))
                {
                    var SPFile = File.ReadAllLines(TLL.PathSP);
                    TLL.LogF("Loaded File:", ref textBoxLog);
                    foreach (string i in SPFile)
                    {
                        TLL.LogF(i, ref textBoxLog);
                        if (i.Length > 0)
                        {
                            tll.SessionPassword = i;
                            if (!TLC.Silent)
                                TLL.LogBox($"Loaded Session Password (Hash: {tll.SessionPassword}) from {TLL.PathSP}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                TLL.Log(ex);
                TLL.LogBox("Error initially loading Session Password");
            }
        }

    }
}
