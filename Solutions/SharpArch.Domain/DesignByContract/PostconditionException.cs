#if LEGACY_DESIGN_BY_CONTRACT
namespace SharpArch.Domain
{
    using System;

    /// <summary>
    ///     An exception that is raised when an postcondition check fails.
    /// </summary>
    [Obsolete("Will be removed in next version. Please use Microsoft Code Contracts.")]
    public class PostconditionException : DesignByContractException
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PostconditionException" /> class.
        /// </summary>
        public PostconditionException()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="PostconditionException" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public PostconditionException(string message)
            : base(message)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="PostconditionException" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="inner">The inner exception.</param>
        public PostconditionException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
#endif