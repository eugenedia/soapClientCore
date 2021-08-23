using SoapDemoService;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using TestSoapClient.Services.Interfaces;

namespace TestSoapClient.Services
{
    public class SoapDemoApi : ISoapDemoApi
    {
        public readonly string serviceUrl = "https://www.crcind.com:443/csp/samples/SOAP.Demo.cls";
        public readonly EndpointAddress endpointAddress;
        public readonly BasicHttpBinding basicHttpBinding;

        public SoapDemoApi()
        {
            endpointAddress = new EndpointAddress(serviceUrl);

            basicHttpBinding =
                new BasicHttpBinding(endpointAddress.Uri.Scheme.ToLower() == "http" ?
                            BasicHttpSecurityMode.None : BasicHttpSecurityMode.Transport);

            //Please set the time accordingly, this is only for demo
            basicHttpBinding.OpenTimeout = TimeSpan.MaxValue;
            basicHttpBinding.CloseTimeout = TimeSpan.MaxValue;
            basicHttpBinding.ReceiveTimeout = TimeSpan.MaxValue;
            basicHttpBinding.SendTimeout = TimeSpan.MaxValue;
        }

        public async Task<SOAPDemoSoapClient> GetInstanceAsync()
        {
            return await Task.Run(() => new SOAPDemoSoapClient(basicHttpBinding, endpointAddress));
        }

        public async Task<Address> GetCityDetails(string zipCode)
        {
            var client = await GetInstanceAsync();
            var response = await client.LookupCityAsync(zipCode);
            return response;
        }

        public async Task<long> AddIntegerAsync(int firstParam, int secondParam)
        {
            var client = await GetInstanceAsync();
            var response = await client.AddIntegerAsync(firstParam, secondParam);
            return response;
        }
    }
}
