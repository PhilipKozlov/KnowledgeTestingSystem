using Ninject.Modules;
using Ninject.Web.Common;
using DAL.Interfaces;
using ORM;
using System.Data.Entity;
using DAL.Concrete;
using BLL.Interfaces;
using BLL.Concrete;

namespace CompositionRoot
{
    /// <summary>
    /// Provides bindings for application.
    /// </summary>
    public class MvcResolver : NinjectModule
    {
        #region Constructors
        /// <summary>
        /// Loads NInject module.
        /// </summary>
        public override void Load()
        {
            LoadOrm();
            LoadDal();
            LoadBll();
        }
        #endregion

        #region Private Methods
        private void LoadOrm()
        {
            Bind<DbContext>().To<TestingSystemContext>().InRequestScope();
        }

        private void LoadDal()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
            Bind<IUserRepository>().To<UserRepository>().InRequestScope();
            Bind<IRoleRepository>().To<RoleRepository>().InRequestScope();
            Bind<ISubjectRepository>().To<SubjectRepository>().InRequestScope();
            Bind<ITestRepository>().To<TestRepository>().InRequestScope();
            Bind<ITestResultRepository>().To<TestResultRepository>().InRequestScope();
        }

        private void LoadBll()
        {
            Bind<IUserService>().To<UserService>().InRequestScope();
            Bind<IRoleService>().To<RoleService>().InRequestScope();
            Bind<ISubjectService>().To<SubjectService>().InRequestScope();
            Bind<ITestService>().To<TestService>().InRequestScope();
            Bind<ITestResultService>().To<TestResultService>().InRequestScope();
            Bind<IUserTestingStatisticService>().To<UserTestingStatisticService>().InRequestScope();
            Bind<ITestingStatisticsService>().To<TestingStatisticsService>().InRequestScope();
            Bind<ITestEvaluationService>().To<TestEvaluationService>().InRequestScope();
        }
        #endregion
    }
}
