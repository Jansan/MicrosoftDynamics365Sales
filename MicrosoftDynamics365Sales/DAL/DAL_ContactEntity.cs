﻿using Microsoft.Xrm.Client.Services;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using MicrosoftDynamics365Sales.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicrosoftDynamics365Sales.DAL
{
    public class DAL_ContactEntity
    {
        public List<ContactViewModel> RetriveRecords()
        {
            using (OrganizationService service = new OrganizationService("MyConnectionString"))
            {
                QueryExpression query = new QueryExpression
                {
                    EntityName = "contact",
                    ColumnSet = new ColumnSet("contactid", "firstname", "lastname", "emailaddress1", "mobilephone")
                };
                List<ContactViewModel> info = new List<ContactViewModel>();
                EntityCollection contactRecord = service.RetrieveMultiple(query);
                if (contactRecord != null && contactRecord.Entities.Count > 0)
                {
                    ContactViewModel contactModel;
                    for (int i = 0; i < contactRecord.Entities.Count; i++)
                    {
                        contactModel = new ContactViewModel();

                        if (contactRecord[i].Contains("contactid") && contactRecord[i]["contactid"] != null)
                            contactModel.ContactId = (Guid)contactRecord[i]["contactid"];

                        if (contactRecord[i].Contains("firstname") && contactRecord[i]["firstname"] != null)
                            contactModel.FirstName = contactRecord[i]["firstname"].ToString();

                        if (contactRecord[i].Contains("lastname") && contactRecord[i]["lastname"] != null)
                            contactModel.LastName = contactRecord[i]["lastname"].ToString();

                        if (contactRecord[i].Contains("emailaddress1") && contactRecord[i]["emailaddress1"] != null)
                            contactModel.Email = contactRecord[i]["emailaddress1"].ToString();

                        if (contactRecord[i].Contains("mobilephone") && contactRecord[i]["mobilephone"] != null)
                            contactModel.Mobile = contactRecord[i]["mobilephone"].ToString();

                        info.Add(contactModel);
                    }
                }
                return info;
            }
        }
    }
}