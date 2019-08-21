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

            if(Session["userId"] != null)
            {
                DAL_ContactEntity objDAL = new DAL_ContactEntity();
                List<ContactViewModel> contactinfo = objDAL.RetriveRecords();
                return View(contactinfo);
            }
            return RedirectToAction("Login", "CrmAccounts");
          
           
        }

        //EDIT Contact
        [HttpPost]
        public ActionResult EditContact(Guid id, string propertyName, string value)
        {
            if(Session["userId"] != null)
            {
                var status = false;
                var message = "";

                //Update data to CRM
                DAL_ContactEntity objDAL = new DAL_ContactEntity();
                List<ContactViewModel> contacts = objDAL.RetriveRecords();

                var contact = contacts.Where(c => c.ContactId == id).FirstOrDefault();

                if (contact != null)
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
            return RedirectToAction("Login", "CrmAccounts");

        }

        //Add New Contact Form
        public ActionResult CreateContact()
        {
            if(Session["userId"] != null)
            {
                return View();
            }
            return RedirectToAction("Login", "CrmAccounts");
            
        }
        //Add New Contact
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateContact(CreateContactViewModel vm)
        {
            if(Session["userId"] != null)
            {
                if (!ModelState.IsValid)
                {
                    return View(vm);
                }
                DAL_ContactEntity objDAL = new DAL_ContactEntity();
                objDAL.PostRecord(vm);

                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("Login", "CrmAccounts");
          
        }

        //Delete Contact
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteContact(Guid contactId)
        {
            if(Session["userId"] != null)
            {
                DAL_ContactEntity objDAL = new DAL_ContactEntity();
                objDAL.DeleteRecord(contactId);

                return RedirectToAction("Index", "Contacts");
            }
            return RedirectToAction("Login", "CrmAccounts");
        }


    }

    
}