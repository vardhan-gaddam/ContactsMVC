using AddressApp.ContactsException;
using AddressApp.Interfaces;
using AddressApp.Models;

namespace AddressApp.Services
{
	public class ContactServices : IContactServices
	{
		private IContactRepository _contactServicesRepo;
		public ContactServices(IContactRepository contactServicesRepo)
		{
			_contactServicesRepo = contactServicesRepo;
		}

		public IEnumerable<Contact> GetContacts()
		{
			return _contactServicesRepo.GetContacts();
		}
		public Contact GetContact(int id)
		{
			try
			{
				var getContact = _contactServicesRepo.GetContact(id);
			}
			catch (ContactNotFoundException ex)
			{
				Console.WriteLine(ex.Message);
			}
			return _contactServicesRepo.GetContact(id);
		}
		public void AddContact(Contact contact)
		{
			_contactServicesRepo.AddContact(contact);
		}
		public void EditContact(Contact contact)
		{
			_contactServicesRepo.EditContact(contact);
		}
		public void DeleteContact(int id)
		{
			_contactServicesRepo.DeleteContact(id);
		}
	}

}
