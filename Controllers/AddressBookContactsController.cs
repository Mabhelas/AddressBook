using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AddressBook.Models;

namespace AddressBook.Controllers
{
    public class AddressBookContactsController : Controller
    {
        private readonly AddressBookDbContext _context;
        private int selectedContactId;

        public AddressBookContactsController(AddressBookDbContext context)
        {
            _context = context;
        }

        // GET: AddressBookContacts
        public async Task<IActionResult> Index(string SearchString)
        {
            ViewData["CurrentFilter"] = SearchString;
            var contacts = from c in _context.AddressBook
                           select c;
            if (!String.IsNullOrEmpty(SearchString))
            {
                contacts = contacts.Where(c => c.FirstName.Contains(SearchString)
                                            || c.Surname.Contains(SearchString)
                                            || c.Age.ToString().Contains(SearchString)
                                            || c.Birthday.ToString().Contains(SearchString)
                                            || c.TelephoneNumber.Contains(SearchString)
                                            || c.Country.Contains(SearchString)
                                            || c.State.Contains(SearchString)
                                            || c.City.Contains(SearchString));
            }
            return View(contacts);
        }

        // GET: AddressBookContacts/AddorEdit
        public IActionResult AddorEdit(int id=0)
        {
            var country = from c in _context.AddressBook
                           select c;
            if (id == 0)
                return View(new AddressBookContacts());
            else
                selectedContactId = id;
                ViewBag.CountryId = country.FirstOrDefault(x => x.ContactId == id).Country;
                ViewBag.SelectedCountryId = ViewBag.CountryId;
                return View(_context.AddressBook.Find(id));
        }

        // POST: AddressBookContacts/AddorEdit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddorEdit([Bind("ContactId,FirstName,Surname,Age,Birthday,TelephoneNumber,Country,State,City")] AddressBookContacts addressBook)
        {
            if (ModelState.IsValid)
            {
                addressBook.Age = DateTime.Now.Year - addressBook.Birthday.Year;

                //Check if it's an insert or update operation
                if (addressBook.ContactId == 0)
                {
                    await _context.AddAsync(addressBook);
                }
                else
                {
                    _context.Update(addressBook);
                }
                //Save changes to DB
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(addressBook);
        }

        // POST: AddressBookContacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AddressBook == null)
            {
                return Problem("Entity set 'AddressBookDbContext.AddressBook'  is null.");
            }
            var addressBook = await _context.AddressBook.FindAsync(id);
            if (addressBook != null)
            {
                _context.AddressBook.Remove(addressBook);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //Get saved country for a user
        public ActionResult getCountry(int id)
        {
            var country = from c in _context.AddressBook
                          select c;
            var contactCountry = country.FirstOrDefault(x => x.ContactId == id).Country;
            return Json(contactCountry);
        }
    }
}
