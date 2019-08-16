using System;

namespace MicrosoftDynamics365Sales.BusinessLayer
{
    public interface IAccountsBL
    {
        void Add(string accountName);
        void Update(int AcountId);
        
    }
}
