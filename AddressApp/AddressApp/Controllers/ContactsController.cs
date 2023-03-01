using AddressApp.Models;
using Microsoft.AspNetCore.Mvc;
using AddressApp.Services;
namespace AddressApp.Controllers
{
	public class ContactsController : Controller
	{
		IContactServices ContactServices { get; set; }
		public ContactsController(IContactServices contactServices)
		{
			ContactServices = contactServices;
		}
		public IActionResult Index()
		{
			var contacts = ContactServices.GetContacts();
			return View(contacts);
		}
		public IActionResult Form()
		{
			return View();
		}
		public IActionResult AddContact(Contact contact)
		{
			if (ModelState.IsValid)
			{
				ContactServices.AddContact(contact);
				TempData["success"] = "Contact Added Successfully";
				return RedirectToAction("Index");
			}
			return RedirectToAction("Form");
		}
		public IActionResult ShowContactCard(int id)
		{
			var contact = ContactServices.GetContact(id);
			return View(contact);
		}
		[HttpGet]
		public IActionResult Edit(int id)
		{
			var contact = ContactServices.GetContact(id);
			return View(contact);
		}

		[HttpPost]
		public IActionResult Edit(Contact contact)
		{
			ContactServices.EditContact(contact);
			TempData["success"] = "Contact Edited Successfully";
			return RedirectToAction("Index");
		}
		public IActionResult Delete(int id)
		{
			ContactServices.DeleteContact(id);
			TempData["success"] = "Contact Deleted Successfully";
			return RedirectToAction("index");
		}
	}
}
