using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using System.Web.Mvc;

namespace CompositionRoot
{
    /// <summary>
    /// Resolves dependencies in mvc application.
    /// </summary>
    public class NinjectMvcDependencyResolver : IDependencyResolver
    {
        #region Fields
        private IKernel kernel;
        #endregion

        #region Constructors
        /// <summary>
        /// Instanciates NinjectDependencyResolver with specified parameters.
        /// </summary>
        /// <param name="kernel"> IKernel instance.</param>
        /// <exception> System.ArgumentNullException if kernel is null.</exception>
        public NinjectMvcDependencyResolver(IKernel kernel)
        {
            if (kernel == null) throw new ArgumentNullException(nameof(kernel));
            this.kernel = kernel;
            kernel.Load<MvcResolver>();
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Resolves singly registered services that support arbitrary object creation.
        /// </summary>
        /// <param name="serviceType"> The type of the requested service or object.</param>
        /// <returns> The requested service or object.</returns>
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        /// <summary>
        ///  Resolves multiply registered services.
        /// </summary>
        /// <param name="serviceType"> The type of the requested services.</param>
        /// <returns> The requested services.</returns>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        #endregion
    }
}
