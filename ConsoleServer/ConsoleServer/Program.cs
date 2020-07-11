using Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            //testGetDetails();
            testServer();
            Console.WriteLine("press any key");
            Console.ReadKey();

        }
        public static void testGetDetails()
        {
            string query = @"SELECT *  FROM [datatormim].[dbo].[ChatDetail] 
                            where FromUserAd = @userA_ADName or FromUserAd = @userB_ADName 
                            or ToUserAd = @userA_ADName or ToUserAd = @userB_ADName ";

            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@userA_ADName", "user1"));
            sqlParams.Add(new SqlParameter("@userB_ADName", "DESKTOP-V21CEJ9\\admin"));

            ChatDetails[] details =  DAL.select<ChatDetails>(query, sqlParams.ToArray());

            details.ToList().ForEach(d => Console.WriteLine(d.odaa));
        }


        public static void testServer()
        {
            Server server = new Server();
            ConsoleTestManager mng = new ConsoleTestManager(server);

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
