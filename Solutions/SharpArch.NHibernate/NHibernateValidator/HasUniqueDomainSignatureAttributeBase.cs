namespace SharpArch.NHibernate.NHibernateValidator
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using Domain.DomainModel;
    using Domain.PersistenceSupport;
    using JetBrains.Annotations;

    public class HasUniqueDomainSignatureAttributeBase : ValidationAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HasUniqueDomainSignatureAttributeBase"/> class.
        /// </summary>
        protected HasUniqueDomainSignatureAttributeBase()
            : base("Provided values matched an existing, duplicate entity")
        {
        }

        /// <summary>
        /// Gets a value that indicates whether the attribute requires validation context.
        /// </summary>
        public override bool RequiresValidationContext
        {
            get { return true; }
        }

        /// <summary>
        /// Performs database lookup to ensure domain signature uniqueness.
        /// </summary>
        /// <typeparam name="TId">The type of the identifier.</typeparam>
        /// <param name="value">The entity.</param>
        /// <param name="validationContext">The validation context.</param>
        /// <returns></returns>
        /// <exception cref="System.InvalidOperationException"></exception>
        protected ValidationResult DoValidate<TId>([NotNull] object value, [NotNull] ValidationContext validationContext)
        {
            var entityToValidate = value as IEntityWithTypedId<TId>;
            if (entityToValidate == null)
                throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture,
                    "This validator must be used at the class level of an IDomainWithTypedId<{0}>. The type you provided was {1}",
                    typeof(TId), value.GetType()));

            var duplicateChecker = (IEntityDuplicateChecker) validationContext.GetService(typeof (IEntityDuplicateChecker));
            return duplicateChecker.DoesDuplicateExistWithTypedIdOf(entityToValidate)
                ? new ValidationResult(ErrorMessage)
                : ValidationResult.Success;
        }
    }
}