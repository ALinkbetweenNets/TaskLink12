using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

public partial class TLL
{
    public void FileSP(string path, ref TLL tll, ref TextBox textBoxLog, bool silent = false)
    {
        try
        {
            if (File.Exists(path))
            {
                var SPFile = File.ReadAllLines(path);
                TLL.LogF("Loaded File:", ref textBoxLog);
                foreach (string i in SPFile)
                {
                    TLL.LogF(i, ref textBoxLog);
                    if (i.Length > 0)
                    {
                        tll.SessionPassword = i;
                        if (!silent)
                            TLL.LogBox($"Loaded Session Password (Hash: {tll.SessionPassword}) from {path}");
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

    /// <summary>
    /// Writes Session Password to File
    /// </summary>
    public void FileSPSave(string path)
    {
        try
        {
            if (SPSet)
            {
                TLL.Log("Writing...");

                string[] SPList = new string[1];
                SPList[0] = SessionPassword;
                Log("Writing...");
                File.WriteAllLines(path, SPList);

                TLL.Log("Writing Done");
                TLL.LogBox($"Saved Session Password ({SessionPassword}) to {path}");
            }
        }
        catch (Exception ex)
        {
            TLL.Log(ex);
            TLL.LogBox($"Error while trying to save Session Password to {path}");
        }
    }

    public void FileSPRemove(string path)
    {
        try
        {
            TLL.Log("Deleting...");
            File.Delete(path);

            TLL.Log("Writing Done");
            TLL.LogBox($"Deleted Session Password under {path}");
        }
        catch (Exception ex)
        {
            TLL.Log(ex);
            TLL.LogBox($"Error while trying to delete Session Password in {path}. Probably already deleted.");
        }
    }
}
