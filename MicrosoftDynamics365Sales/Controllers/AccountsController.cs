using Dynamics365SalesTest.DAL;
using MicrosoftDynamics365Sales.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MicrosoftDynamics365Sales.Controllers
{
    public class AccountsController : Controller
    {
        /// <summary>
        /// GET Accounts
        /// </summary>
        /// <returns></returns>
        // GET: Accounts
        public ActionResult Index()
        {
            DAL_AccountEntity objDAL = new DAL_AccountEntity();
            List<AccountViewModel> accountinfo = objDAL.RetriveRecords();

            return View(accountinfo);
        }

        /// <summary>
        /// Get account details
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Account details</returns>
        // GET: Account/Details
        public ActionResult Details(Guid id)
        {
            DAL_AccountEntity objDAL = new DAL_AccountEntity();
            List<AccountViewModel> accountinfo = objDAL.RetriveRecords();
            var account = accountinfo.Where(a => a.AccountId == id).FirstOrDefault();

            return View(account);
        }
    }
}