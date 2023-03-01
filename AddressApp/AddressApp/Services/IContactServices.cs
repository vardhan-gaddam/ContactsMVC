using AddressApp.Models;

namespace AddressApp.Services
{
	public interface IContactServices
	{
		public void AddContact(Contact contact);
		public IEnumerable<Contact> GetContacts();
		public Contact GetContact(int id);
		public void EditContact(Contact contact);
		public void DeleteContact(int id);
	}
}
