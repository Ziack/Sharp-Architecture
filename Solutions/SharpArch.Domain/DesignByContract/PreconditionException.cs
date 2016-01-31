#if LEGACY_DESIGN_BY_CONTRACT
namespace SharpArch.Domain
{
    using System;

    /// <summary>
    ///     An exception that is raised when an precondition check fails.
    /// </summary>
    [Obsolete("Will be removed in next version. Please use Microsoft Code Contracts.")]
    public class PreconditionException : DesignByContractException
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PreconditionException" /> class.
        /// </summary>
        public PreconditionException()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="PreconditionException" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public PreconditionException(string message)
            : base(message)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="PreconditionException" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="inner">The inner exception.</param>
        public PreconditionException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
#endif
