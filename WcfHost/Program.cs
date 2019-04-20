using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using WcfDataContracts;

namespace WcfHost
{
    class Program
    {
        public static string BASE_NAME = "ComplexCalculator";
        public static int PORT = 9005;

        static void Main(string[] args)
        {
            Uri baseAddress = new Uri($"http://localhost:{PORT}/{BASE_NAME}");

            ServiceHost host = new ServiceHost(typeof(ComplexCalculator), baseAddress);

            try
            {
                ServiceEndpoint endpoint = host.AddServiceEndpoint(typeof(IComplexCalculator), new BasicHttpBinding(), "ENDPOINT_1");

                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                host.Description.Behaviors.Add(smb);

                host.Open();
                Console.WriteLine("---> ComplexCalculator Service started running...");
                Console.WriteLine("---> Press <ENTER> to finish");
                Console.ReadLine();
                host.Close();
                Console.WriteLine("---> Service finished working.");
            } catch (CommunicationException ce)
            {
                Console.WriteLine($"Exception encountered: {ce}");
                host.Abort();
            }
        }
    }
}
