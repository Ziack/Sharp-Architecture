namespace SharpArch.NHibernate.NHibernateValidator
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using JetBrains.Annotations;
    using SharpArch.Domain.DomainModel;

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    [PublicAPI]
    [BaseTypeRequired(typeof(IEntityWithTypedId<string>))]
    public sealed class HasUniqueDomainSignatureWithStringIdAttribute : HasUniqueDomainSignatureAttributeBase
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return DoValidate<string>(value, validationContext);
        }
    }
}