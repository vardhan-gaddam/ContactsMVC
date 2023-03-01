using AddressApp.ContactsException;
using AddressApp.Interfaces;
using AddressApp.Models;
using AddressBookApp.Context;
using Dapper.Contrib.Extensions;

namespace AddressApp.DapperRepository
{
    public class ContactRepository : IContactRepository
    {
        private IDapperContext _dapperContext;
        public ContactRepository(IDapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public IEnumerable<Contact> GetContacts()
        {
            return _dapperContext.Connection.GetAll<Contact>().ToList();
        }
        public Contact GetContact(int id)
        {
            var existingContact = _dapperContext.Connection.Get<Contact>(id);

            if (existingContact == null) throw new ContactNotFoundException("No contact found");
            return existingContact;
        }
        public void AddContact(Contact contact)
        {
            _dapperContext.Connection.Insert(contact);
        }
        public void EditContact(Contact contact)
        {
            var existingContact = GetContact(contact.Id);
            if (existingContact == null)
            {
                throw new ApplicationException("No contact found");
            }
            _dapperContext.Connection.Update(contact);
        }
        public void DeleteContact(int id)
        {
            _dapperContext.Connection.Delete(new Contact { Id = id });
        }
    }
}
