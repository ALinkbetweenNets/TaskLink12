﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;

namespace TaskLink12Client
{
    public partial class TLC
    {

        /// <summary>
        /// Gets all running processes on the computer
        /// </summary>
        /// <returns>returns sorted list of names of running processes</returns>
        private string[] GetRunningProcesses()
        {
            List<string> processListRaw = new List<string>();
            foreach (Process p in Process.GetProcesses())
            {
                if (p.ProcessName != string.Empty && p.ProcessName != " ")
                {
                    if (p.MainModule.FileName.StartsWith(@"C:\Windows\"))
                        processListRaw.Add("!" + p.ProcessName.ToLower().Replace('!', ' ') + ";");

                    else
                        processListRaw.Add(p.ProcessName.ToLower().Replace('!', ' ') + ";");
                }
            }
            List<string> processList = processListRaw.Distinct().ToList();

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
