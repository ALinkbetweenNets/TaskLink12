﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskLink12Client
{
    public class CVariables
    {
        /// <summary>
        /// Local IP Address used for connections. Replaced at init
        /// </summary>
        public static string LocalIP = "192.168.1.10";

        /// <summary>
        /// Session password used for Communication. Should never be clear text (-> use SHA-256).
        /// Must be equal on all devices
        /// </summary>
        public static string SessionPassword = string.Empty;

        /// <summary>
        /// Determines wether Silent Mode is on / off
        /// Silent Mode disables MSG Boxes etc
        /// </summary>
        private bool Silent = false;

        /// <summary>
        /// File to control Silent mode
        /// </summary>
        private const string PathSilent = ".S.tl";
    }
}