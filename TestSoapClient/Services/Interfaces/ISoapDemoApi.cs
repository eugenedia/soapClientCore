using SoapDemoService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TestSoapClient.Services.Interfaces
{
    public interface ISoapDemoApi
    {
        Task<SOAPDemoSoapClient> GetInstanceAsync();
        Task<Address> GetCityDetails(string zipCode);
        Task<long> AddIntegerAsync(int firstParam, int secondParam);
    }
}
