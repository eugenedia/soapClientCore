using NumberConversion;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace TestSoapClient
{
    public class NumberConversionClient
    {
        public readonly string serviceUrl = "https://www.dataaccess.com/webservicesserver/numberconversion.wso";
        public readonly EndpointAddress endpointAddress;
        public readonly BasicHttpBinding basicHttpBinding;


        public NumberConversionClient()
        {
            endpointAddress = new EndpointAddress(serviceUrl);
            basicHttpBinding = new BasicHttpBinding(endpointAddress.Uri.Scheme.ToLower() == "http" ?
                    BasicHttpSecurityMode.None : BasicHttpSecurityMode.Transport);

            basicHttpBinding.OpenTimeout = TimeSpan.FromMinutes(3);
            basicHttpBinding.CloseTimeout = TimeSpan.FromMinutes(3);
            basicHttpBinding.ReceiveTimeout = TimeSpan.FromMinutes(3);
            basicHttpBinding.SendTimeout = TimeSpan.FromMinutes(3);
        }

        public async Task<NumberConversionSoapTypeClient> GetInstanceAsync()
        {
            return await Task.Run(() => new NumberConversionSoapTypeClient(basicHttpBinding, endpointAddress));
        }

       public async Task<NumberToWordsResponse> NumberToWordsAsync()
        {
            var client = await GetInstanceAsync();

            var response = await client.NumberToWordsAsync(132);

            return response;
        }
    }
}
