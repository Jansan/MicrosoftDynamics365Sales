using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicrosoftDynamics365Sales.Models
{
    public class CrmAccount
    {
        public string UserIdEmail { get; set; }

        public string Password { get; set; }

        public string CrmWebServiceUrl { get; set; }

    }
}