using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Management;

namespace TaskLink12Client
{
    public static partial class TLC
    {
        /// <summary>
        /// Gets all running processes on the computer + Their Ownership. System Processes get marked with a "!"
        /// </summary>
        /// <returns>returns sorted list of names of running processes</returns>
        public static string[] GetRunningProcesses()
        {
            List<string> processList = new List<string>();
            string query = "Select * From Win32_Process";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
            ManagementObjectCollection procList = searcher.Get();
            foreach (ManagementObject obj in procList)
            {
                try
                {
                    string[] argList = new string[] { string.Empty, string.Empty };
                    //int returnVal = Convert.ToInt32(obj.InvokeMethod("GetOwner", argList));
                    //Console.Write(obj.InvokeMethod("GetOwner", argList));
                    if (obj.InvokeMethod("GetOwner", argList).ToString() != "0")
                        processList.Add("!" + obj["Name"].ToString() + ";");
                    else
                        processList.Add(obj["Name"].ToString() + ";");
                    //Console.WriteLine(obj.InvokeMethod("GetOwner", argList));
                    //Console.Write(obj["Name"]);
                    //Console.WriteLine(obj);
                }
                catch { }
            }
            procList.Dispose();
            searcher.Dispose();
            /*foreach (Process p in Process.GetProcesses())
            {
                try
                {
                    if (p.ProcessName.Length > 0 && p.ProcessName != " ")
                    {
                        if (p.MainModule.FileName.StartsWith(@"C:\Windows\"))
                            ProcessList.Add("!" + TLL.StringCheck(p.ProcessName.ToLower().Replace('!', ' ')) + ";");

                        else
                            ProcessList.Add(TLL.StringCheck(p.ProcessName.ToLower().Replace('!', ' ')) + ";");
                    }
                }
                catch(Exception ex) {
                    //TLL.Log(ex); 
                    try { ProcessList.Add(TLL.StringCheck(p.ProcessName.ToLower().Replace('!', ' ')) + ";"); }
                    catch { }
                }
            }*/
            processList = processList.Distinct().ToList();
            processList.Sort();
            return processList.ToArray();
        }

        /// <summary>
        /// Tries to kill all Processes with a given Name
        /// </summary>
        /// <param name="name">Name of the targeted Process</param>
        /// <returns>Whether Ending the Process was successful</returns>
        public static bool KillProc(string name)
        {
            bool success = false;
            if (name.Length > 0)
            {
                name = name.ToLower().Replace("!","");
                name = name.ToLower().Replace(".exe", "");
                LogI("Killing Process "+name);
                try
                {
                    foreach (var process in Process.GetProcessesByName(name))
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
                }
                catch (Exception ex) { TLL.Log(ex); }
                try
                {
                    foreach (var process in Process.GetProcessesByName(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(name)))
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
                }
                catch (Exception ex) { TLL.Log(ex); }
            }
            return success;
        }
    }
}
