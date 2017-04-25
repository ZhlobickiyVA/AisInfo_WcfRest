using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;
using Moq;
using Ninject;
using LibraryService;
using LibraryService.Abstract;
using LibraryService.Concrete;
using AisInformMVC.Infrastructure.Concrete;
using AisInformMVC.Infrastructure.Abstract;

namespace AisInformMVC.Infrastructure
{
  public class NinjectDependencyResolver : IDependencyResolver
  {
    private IKernel kernel;

    public NinjectDependencyResolver(IKernel kernelParam)
    {
      kernel = kernelParam;
      AddBindings();
    }

    public object GetService(Type serviceType)
    {
      return kernel.TryGet(serviceType);
    }

    public IEnumerable<object> GetServices(Type serviceType)
    {
      return kernel.GetAll(serviceType);
    }

    private void AddBindings()
    {
      // Здесь размещаются привязки

      kernel.Bind<IAdRepository>().To<EfAdRepository>();
      kernel.Bind<IEmployeesRepository>().To<EfEmployeesRepository>();
      kernel.Bind<IHoliDayRepository>().To<EfHolidayrepository>();

      // Secure
      kernel.Bind<IAuthProvider>().To<FormAuthProvider>();

      // ListSoc 


      kernel.Bind<IListEdv>().To<EfListEdvRepository>();
      kernel.Bind<IListMdou>().To<EfListMdouRepository>();
      kernel.Bind<IListOldPeople>().To<EFListOldPeopleRepository>();
      kernel.Bind<IListPayKinder>().To<EFListPayKinderRepository>();

      // PriceDoc

      kernel.Bind<IPriceDocument>().To<EfPriceDocRepository>();


    }
  }
}