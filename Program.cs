using System;
using System.Threading;
using Com.Samples.V1;
using Grpc.Core;

namespace sample_dotnet_grpc
{
    public class Program
    {
        const int Port = 50051;
        public static void Main(string[] args)
        {
            Server server = new Server
            {
                Services = { 
                    InternalApplicationService.BindService(new StatusImpl()) 
                },
                Ports = { new ServerPort("0.0.0.0", Port, ServerCredentials.Insecure) }
            };
            server.Start();
            Console.WriteLine("Status server listening on port " + Port);
            testGRPC();
            Thread.Sleep(Timeout.Infinite);
            server.ShutdownAsync().Wait(); 
        }
        
        private static void testGRPC()
        {
            Channel channel = new Channel("127.0.0.1:50051", ChannelCredentials.Insecure);
            var client = new InternalApplicationService.InternalApplicationServiceClient(channel);
            var reply = client.GetApplicationStatus(new ApplicationStatusRequest {ApplicationId = 1 });
            Console.WriteLine("Greeting: " + reply.ApplicationStatus);
            
        }
    }
}