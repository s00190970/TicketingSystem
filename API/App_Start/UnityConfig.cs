using Core.IRepositories;
using Infrastructure.Repositories;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace API
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<IPriorityRepository, PriorityRepository>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}