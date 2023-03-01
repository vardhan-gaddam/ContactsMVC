using AddressApp.Interfaces;
using AddressApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace AddressApp.ViewComponents
{
    public class ContactsViewComponent : ViewComponent
	{
		private readonly IContactRepository _contactServices;
		public ContactsViewComponent(IContactRepository contactServices)
		{
			_contactServices = contactServices;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			IEnumerable<Contact> contacts = _contactServices.GetContacts();

			return await Task.FromResult((IViewComponentResult)View("contacts", contacts));
		}
	}
}
