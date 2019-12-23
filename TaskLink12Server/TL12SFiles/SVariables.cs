using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskLink12Server
{
    public partial class TLS
    {
        /// <summary>
        /// Session password used for Communication. Should never be clear text (-> use SHA-256).
        /// Must be equal on all devices
        /// </summary>
        public static string SessionPassword = string.Empty;
    }
}
