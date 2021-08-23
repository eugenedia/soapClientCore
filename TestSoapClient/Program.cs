using System;
using TestSoapClient.Services;
using TestSoapClient.Services.Interfaces;

namespace TestSoapClient
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            ISoapDemoApi soapDemoApi = new SoapDemoApi();
            var output = await soapDemoApi.GetCityDetails("10001");
            Console.WriteLine(output.City);
            Console.WriteLine(output.State);
            Console.WriteLine(output.Zip);

            long resultOfAdding = await soapDemoApi.AddIntegerAsync(100, 200);
            Console.WriteLine(resultOfAdding);

            var numberConversionClient = new NumberConversionClient();
            var numberAsString = await numberConversionClient.NumberToWordsAsync();
            Console.WriteLine(numberAsString.Body.NumberToWordsResult);
        }
    }
}
