using System;
using System.Diagnostics;
using System.Globalization;

namespace TaskLink12Client
{
    public partial class TLC
    {
        /// <summary>
        /// Tries to kill all Processes with a given Name
        /// </summary>
        /// <param name="name">Name of the targeted Process</param>
        /// <returns>Whether Ending the Process was successful</returns>
        public static bool KillProc(string name)
        {
            bool success = false;
            foreach (var process in Process.GetProcessesByName(name.ToLower()))
            {
                string procName = process.ProcessName;
                try
                {
                    TLL.Log("Killing Process " + procName);
                    process.Kill();
                    TLL.Log("Successfully ended " + process.ProcessName);
                    success = true;
                }
                catch (Exception)
                {
                    TLL.Log("Could not End Process " + process.ProcessName);
                }
            }
            foreach (var process in Process.GetProcessesByName(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(name.ToLower())))
            {
                string procName = process.ProcessName;
                try
                {
                    TLL.Log("Killing Process " + procName);
                    process.Kill();
                    TLL.Log("Successfully ended " + process.ProcessName);
                    success = true;
                }
                catch (Exception)
                {
                    TLL.Log("Could not End Process " + process.ProcessName);
                }
            }
            return success;
        }
    }
}
