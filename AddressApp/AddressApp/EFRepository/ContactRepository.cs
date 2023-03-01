using AddressApp.Interfaces;
using AddressApp.Models;

namespace AddressApp.EFRepository
{
    public class ContactRepository  : IContactRepository
	{
		private  ApplicationDbContext _db;
		public ContactRepository(ApplicationDbContext db)
		{
			_db = db;
		}
		public IEnumerable<Contact> GetContacts()
		{
			return _db.ASPContactInformation.ToList();
		}
		public Contact GetContact(int id)
		{
			return _db.ASPContactInformation.Find(id);
		}
		public void AddContact(Contact contact)
		{
			_db.ASPContactInformation.Add(contact);
			_db.SaveChanges();
		}
		public void EditContact(Contact contact)
		{
			_db.ASPContactInformation.Update(contact);
			_db.SaveChanges();
		}
		public void DeleteContact(int id)
		{
			var contact = _db.ASPContactInformation.FirstOrDefault(u=>u.Id== id);
			_db.ASPContactInformation.Remove(contact); 
			_db.SaveChanges();
		}
	}
}
