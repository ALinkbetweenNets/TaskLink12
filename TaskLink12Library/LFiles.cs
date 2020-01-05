using System;
using System.IO;
using System.Windows.Forms;

public partial class TLL
{
    /// <summary>
    /// Loads Session Password from Path and sets tll.SessionPassword adter check
    /// </summary>
    /// <param name="path">Path to SP File</param>
    /// <param name="tll">tll Object to insert SP into</param>
    /// <param name="textBoxLog">textBoxLog to use for LogF</param>
    /// <param name="silent">Wether to show MsgBoxes (TLC only)</param>
    public void FileSPLoad(string path, ref TLL tll, ref TextBox textBoxLog, bool silent = false)
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
    /// <param name="path">Path to file</param>
    /// <returns>Wether the writing Task was sucessful</returns>
    public bool FileSPSave(string path)
    {
        try
        {
            if (SPSet)
            {
                string[] SPList = new string[1];
                SPList[0] = SessionPassword;
                Log("Writing...");
                File.WriteAllLines(path, SPList);

                Log("Writing Done");
                LogBox($"Saved Session Password ({SessionPassword}) to {path}");
                return true;
            }
            else return false;
        }
        catch (Exception ex)
        {
            Log(ex);
            LogBox($"Error while trying to save Session Password to {path}");
            return false;
        }
    }

    /// <summary>
    /// Deletes the File in which the SP is stored
    /// </summary>
    /// <param name="path">Path to SP File</param>
    /// <returns>Wether the deletion was sucessful</returns>
    public bool FileSPRemove(string path)
    {
        try
        {
            Log("Deleting...");
            File.Delete(path);
            LogBox($"Deleted Session Password under {path}");
            return true;
        }
        catch (Exception ex)
        {
            Log(ex);
            LogBox($"Error while trying to delete Session Password in {path}. Probably already deleted.");
            return false;
        }
    }
}
