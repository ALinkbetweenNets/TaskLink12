public partial class TLL
{
    /// <summary>
    /// Enum for types of Results a Thread can return after finishing
    /// </summary>
    public enum ThreadReturn
    {
        /// <summary>
        /// Session Password not set
        /// </summary>
        SP,
        /// <summary>
        /// Exception occured
        /// </summary>
        Exception,
        /// <summary>
        /// Thread successfull, execution without error
        /// </summary>
        Success,
    } 

}
