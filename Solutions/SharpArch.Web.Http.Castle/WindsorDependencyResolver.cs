namespace SharpArch.Web.Http.Castle
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Web.Http.Dependencies;
    using global::Castle.Windsor;

    /// <summary>
    ///     Resolves HTTP dependencies using Castle Windsor.
    /// </summary>
    public class WindsorDependencyResolver : IDependencyResolver
    {
        readonly IWindsorContainer container;

        /// <summary>
        ///     Initializes a new instance of the <see cref="WindsorDependencyResolver" /> class.
        /// </summary>
        /// <param name="container">The container.</param>
        public WindsorDependencyResolver(IWindsorContainer container)
        {
            Contract.Requires(container != null);

            this.container = container;
        }

        /// <summary>
        ///     Begins the scope.
        /// </summary>
        /// <returns>A scope.</returns>
        public IDependencyScope BeginScope()
        {
            return new WindsorDependencyScope(container);
        }

        /// <summary>
        ///     Gets the service for the specified type.
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        /// <returns>A service.</returns>
        public object GetService(Type serviceType)
        {
            return WindsorDependencyScope.TryResolveService(this.container, serviceType);
        }

        /// <summary>
        ///     Gets all services for the specified type.
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        /// <returns>A collection of services.</returns>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return WindsorDependencyScope.TryResolveServices(this.container, serviceType);
        }

        /// <summary>
        ///     Disposes the container.
        /// </summary>
        public void Dispose()
        {
            this.container.Dispose();
        }
    }
}