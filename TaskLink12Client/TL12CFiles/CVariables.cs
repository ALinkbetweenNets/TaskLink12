

namespace TaskLink12Client
{
    public partial class TLC
    {



        /// <summary>
        /// Determines wether Silent Mode is on / off
        /// Silent Mode disables MSG Boxes etc
        /// </summary>
        public static bool Silent = false;

        /// <summary>
        /// File to control Silent mode
        /// </summary>
        public const string PathSilent = ".S.tl";

        /// <summary>
        /// The File under which the Session Password get stored
        /// </summary>
        public const string PathSP = @"C:\ProgramData\TaskLink\12\Client\SP.tl";

        public static bool ReceiverOn = false;
    }
}
