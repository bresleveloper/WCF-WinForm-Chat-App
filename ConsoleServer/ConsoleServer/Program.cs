using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleServer
{


    class Program
    {
        static void Main(string[] args)
        {
            Server server = new Server();
            Manager mng = new Manager(server);

            using (ServiceHost host = new ServiceHost(server, new Uri[] {
                //Uri must be "net.pipe://***"
                new Uri(Names.Address)
            }))
            {
                host.AddServiceEndpoint(typeof(IServer), new NetTcpBinding(), Names.Endpoint);
                host.Open();

                string msg = string.Empty;
                Console.WriteLine("Service is available. Press <exit> to exit.");
                Console.WriteLine();

                while (msg != "exit")
                {
                    Console.WriteLine("msg to broadcast:");
                    msg = Console.ReadLine();
                    mng.Broadcast(msg);
                    Console.WriteLine();
                }
                host.Close();
            }

        }
    }
}
