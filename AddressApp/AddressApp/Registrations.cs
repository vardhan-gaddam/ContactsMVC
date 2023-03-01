using AddressApp.Interfaces;
using AddressApp.Services;
using AddressBookApp.Context;
using SimpleInjector;
using SimpleInjector.Packaging;

namespace AddressApp
{
	public class Registrations : IPackage
	{
		public void RegisterServices(Container container)
		{
			container.Register<IDapperContext, DapperContext>(Lifestyle.Scoped);
			container.Register<IContactRepository, DapperRepository.ContactRepository>(Lifestyle.Scoped);
		//	container.Register<IContactRepository, EFRepository.ContactRepository>(Lifestyle.Scoped);
			container.Register<IContactServices, ContactServices>(Lifestyle.Scoped);
		}
	}
}
