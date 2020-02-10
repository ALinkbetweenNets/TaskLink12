using System;
using System.IO;
using System.Windows.Forms;

namespace TaskLink12Client
{
    public static partial class TLC
    {
        /// <summary>
        /// Checks File for SIlent Flag and sets Silent Mode
        /// </summary>
        /// <param name="textBoxLog"></param>
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

        /// <summary>
        /// Creates File for Silent Mode Flag
        /// </summary>
        /// <param name="Sil">Silent Mode Setting to write</param>
        public static void FileSSave(bool Sil)
        {
            try
            {
                TLL.Log("Writing...");
                File.Delete(TLC.PathSilent);

                if (Sil)
                {
                    File.Create(TLC.PathSilent);
                    File.WriteAllText(TLC.PathSilent, "Silent");
                }
                TLL.Log("Writing Done");
                TLL.LogBox($"Saved Silent Mode Setting ({Sil}) to {TLC.PathSilent}");
                
            }
            catch (Exception ex)
            {
                TLL.Log(ex);
                TLL.LogBox($"Error while trying to save Silent Mode Setting to {TLC.PathSilent}");
            }
        }


    }
}
