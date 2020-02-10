

namespace TaskLink12Client
{
    public static partial class TLC
    {
        /// <summary>
        /// Variable to reference Main Window Form
        /// </summary>
        public static FormTLClient Form;

        /// <summary>
        /// Determines wether Silent Mode is on / off
        /// Silent Mode disables MSG Boxes etc
        /// </summary>
        public static bool Silent = false;

        /// <summary>
        /// File to control Silent mode
        /// </summary>
        public const string PathSilent = @"C:\ProgramData\TaskLink\12\Client\S.tl";

        /// <summary>
        /// The File under which the Session Password get stored
        /// </summary>
        public const string PathSP = @"C:\ProgramData\TaskLink\12\Client\SP.tl";

        /// <summary>
        /// Bool to know if the Receiver is running
        /// </summary>
        public static bool ReceiverOn = false;
    }
}
