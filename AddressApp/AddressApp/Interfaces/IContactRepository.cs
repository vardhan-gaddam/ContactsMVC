using AddressApp.Models;

namespace AddressApp.Interfaces
{
    public interface IContactRepository
    {
        public void AddContact(Contact contact);
        public IEnumerable<Contact> GetContacts();
        public Contact GetContact(int id);
        public void EditContact(Contact contact);
        public void DeleteContact(int id);
    }
}
