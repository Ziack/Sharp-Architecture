namespace SharpArch.Domain.Specifications
{
    using System;
    using System.Linq.Expressions;
    using JetBrains.Annotations;

    /// <summary>
    ///     An ad hoc query specification.
    /// </summary>
    /// <typeparam name="T">The entity type.</typeparam>
    [PublicAPI]
    public class AdHoc<T> : QuerySpecification<T>
    {
        private readonly Expression<Func<T, bool>> expression;

        /// <summary>
        /// Initializes a new instance of the <see cref="AdHoc{T}" /> class.
        /// </summary>
        /// <param name="expression">The expression.</param>
        public AdHoc([CanBeNull] Expression<Func<T, bool>> expression)
        {
            this.expression = expression;
        }

        /// <summary>
        ///     Gets the matching criteria.
        /// </summary>
        [CanBeNull]
        public override Expression<Func<T, bool>> MatchingCriteria => this.expression;
    }
}