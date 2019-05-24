using MicrosoftDynamics365Sales.DAL;
using MicrosoftDynamics365Sales.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}