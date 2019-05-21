using MicrosoftDynamics365Sales.ViewModels;
using Microsoft.Xrm.Client.Services;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;


namespace Dynamics365SalesTest.DAL
{
    public class DAL_AccountEntity
    {
        public List<AccountViewModel> RetriveRecords()
        {
            using (OrganizationService service = new OrganizationService("MyConnectionString"))
            {
                QueryExpression query = new QueryExpression
                {
                    EntityName = "account",
                    ColumnSet = new ColumnSet("accountid", "name", "accountnumber"/*, "vatnumber"*/)
                };
                List<AccountViewModel> info = new List<AccountViewModel>();
                EntityCollection accountRecord = service.RetrieveMultiple(query);
                if (accountRecord != null && accountRecord.Entities.Count > 0)
                {
                    AccountViewModel accountModel;
                    for (int i = 0; i < accountRecord.Entities.Count; i++)
                    {
                        accountModel = new AccountViewModel();

                        if (accountRecord[i].Contains("accountid") && accountRecord[i]["accountid"] != null)
                            accountModel.AccountId = (Guid)accountRecord[i]["accountid"];

                        if (accountRecord[i].Contains("name") && accountRecord[i]["name"] != null)
                            accountModel.AccountName = accountRecord[i]["name"].ToString();

                        if (accountRecord[i].Contains("accountnumber") && accountRecord[i]["accountnumber"] != null)
                            accountModel.AccountNumber = accountRecord[i]["accountnumber"].ToString();

                        //if (accountRecord[i].Contains("businesstypecode") && accountRecord[i]["businesstypecode"] != null)
                        //    accountModel.VatNumber = accountRecord[i]["businesstypecode"].ToString();



                        info.Add(accountModel);
                    }
                }
                return info;
            }
        }
    }
}