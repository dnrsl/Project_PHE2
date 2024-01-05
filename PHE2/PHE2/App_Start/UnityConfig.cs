using PHE2.Contratcs;
using PHE2.Data;
using PHE2.Repositoreis;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace PHE2
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<IAccountRepository, AccountRepository>();
            container.RegisterType<IAccountRoleRepository, AccountRoleRepository>();
            container.RegisterType<ICharacteristicRepository, CharacteristicRepository>();
            container.RegisterType<IProjectRepository, ProjectRepository>();
            container.RegisterType<IUserProjectRepository, UserProjectRepository>();

            container.RegisterType<Phe2DbContext>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}