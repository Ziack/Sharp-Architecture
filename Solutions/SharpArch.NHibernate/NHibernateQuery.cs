namespace SharpArch.NHibernate
{
    using System;
    using global::NHibernate;
    using JetBrains.Annotations;

    public abstract class NHibernateQuery
    {
        protected NHibernateQuery([NotNull] ISession session)
        {
            if (session == null) throw new ArgumentNullException(nameof(session));

            this.Session = session;
        }

        [NotNull]
        protected virtual ISession Session { get; }
    }
}
