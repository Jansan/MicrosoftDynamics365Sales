
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using MicrosoftDynamics365Sales.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel.Description;
using System.Web;
using System.Web.Mvc;

namespace MicrosoftDynamics365Sales.Controllers
{
    public class CrmAccountsController : Controller
    {
        // GET: CrmAccounts
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Login(CrmAccountViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            IOrganizationService organizationService = null;

            try
            {
                ClientCredentials clientCredentials = new ClientCredentials();
                clientCredentials.UserName.UserName = vm.UserIdEmail;
                clientCredentials.UserName.Password = vm.Password;

                // For Dynamics 365 Customer Engagement V9.X, set Security Protocol as TLS12
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                // Get the URL from CRM, Navigate to Settings -> Customizations -> Developer Resources
                // Copy and Paste Organization Service Endpoint Address URL
                organizationService = (IOrganizationService)new OrganizationServiceProxy(new Uri(vm.CrmWebServiceUrl), //"https://"+ vm.CrmWebService + ".api.crm4.dynamics.com/XRMServices/2011/Organization.svc"),
                null, clientCredentials, null);

                if (organizationService != null)
                {
                    Guid userid = ((WhoAmIResponse)organizationService.Execute(new WhoAmIRequest())).UserId;

                    if (userid != Guid.Empty)
                    {
                        Session["userId"] = userid;
                        Session["username"] = clientCredentials.UserName.UserName;
                        ViewBag.ConnectionSuccess = "Connection Established Successfully...";
                        return RedirectToAction(nameof(Index));
                    }
                }
                else
                {
                    ViewBag.FailedConnection = "Failed to Established Connection!!!";
                    return View(vm);
                }
            }
            catch (Exception ex)
            {
                //throw new Exception("Exception caught - " + ex.Message);
                ViewBag.Wrong = "Error in login.";
                return View(vm);
            }

            // return RedirectToAction(nameof(Index));
            return View(vm);
        }

    }
}