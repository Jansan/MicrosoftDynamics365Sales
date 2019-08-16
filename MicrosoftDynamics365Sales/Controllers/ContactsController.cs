using MicrosoftDynamics365Sales.DAL;
using MicrosoftDynamics365Sales.ViewModels;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MicrosoftDynamics365Sales.Controllers
{
    public class ContactsController : Controller
    {
        // GET: Contacts
        public ActionResult Index()
        {
            DAL_ContactEntity objDAL = new DAL_ContactEntity();
            List<ContactViewModel> contactinfo = objDAL.RetriveRecords(); 
          
            return View(contactinfo);
        }

        //EDIT Contact
        [HttpPost]
        public ActionResult EditContact(Guid id, string propertyName, string value)
        {
            var status = false;
            var message = "";

            //Update data to CRM
            DAL_ContactEntity objDAL = new DAL_ContactEntity();
            List<ContactViewModel> contacts = objDAL.RetriveRecords();

            var contact = contacts.Where(c => c.ContactId == id).FirstOrDefault();
            
            if(contact != null)
            {
                if (propertyName == "FirstName")
                {
                    contact.FirstName = value;
                }
                if (propertyName == "Mobile")
                {
                    contact.Mobile = value;
                }
                objDAL.UpdateRecord(contact);
                status = true;
            }
            else
            {
                message = "Error!";
            }
            
            

            var response = new { value = value, status = status, message = message };
            JObject o = JObject.FromObject(response);

            return Content(o.ToString());
        }

        //Add New Contact
        public ActionResult CreateContact()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateContact(CreateContactViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            DAL_ContactEntity objDAL = new DAL_ContactEntity();
            objDAL.PostRecord(vm);

            return RedirectToAction(nameof(Index));

            

        }

        //Delete Contact
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteContact(Guid? contactId)
        {
            
                DAL_ContactEntity objDAL = new DAL_ContactEntity();
                objDAL.DeleteRecord(contactId);

                return View(Index());
                    
        }


    }

    
}