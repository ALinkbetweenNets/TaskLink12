

namespace TaskLink12Client
{
    public partial class TLC
    {

        /// <summary>
        /// Session password used for Communication. Should never be clear text (-> use SHA-256).
        /// Must be equal on all devices
        /// </summary>
        public static string SessionPassword = string.Empty;

        /// <summary>
        /// Determines wether Silent Mode is on / off
        /// Silent Mode disables MSG Boxes etc
        /// </summary>
        public bool Silent = false;

        /// <summary>
        /// File to control Silent mode
        /// </summary>
        public const string PathSilent = ".S.tl";

        public static bool ReceiverOn = false;
    }
}
