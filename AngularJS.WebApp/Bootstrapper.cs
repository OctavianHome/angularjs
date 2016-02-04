using System.Web.Mvc;
using AngularJS.Repository.Generic;
using AngularJS.Repository.Repository;
using Microsoft.Practices.Unity;
using Unity.Mvc4;

namespace AngularJS.WebApp
{
  public static class Bootstrapper
  {
    public static IUnityContainer Initialise()
    {
      var container = BuildUnityContainer();

      DependencyResolver.SetResolver(new UnityDependencyResolver(container));

      return container;
    }

    private static IUnityContainer BuildUnityContainer()
    {
      var container = new UnityContainer();

      // register all your components with the container here
      // it is NOT necessary to register your controllers

      // e.g. container.RegisterType<ITestService, TestService>();    
      container.RegisterType<IPersonRepository, PersonRepository>();

      RegisterTypes(container);

      return container;
    }

    public static void RegisterTypes(IUnityContainer container)
    {
    
    }
  }
}