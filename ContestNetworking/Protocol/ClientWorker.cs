using ContestServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace ContestNetworking.Protocol
{
    public class ClientWorker : IContestObserver
    {
        public IContestService Service { get; set; }
        public TcpClient SocketToClient { get; set; }
        public NetworkStream StreamToClient { get; set; }
        public IFormatter MyFormatter;
        volatile bool connected;

        public ClientWorker(IContestService service, TcpClient socketToClient)
        {
            
            Service = service;
            SocketToClient = socketToClient;
            try
            {
                StreamToClient = SocketToClient.GetStream();
                MyFormatter = new BinaryFormatter();
                connected = true;
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("ClientWorker created");
        }

        public Object HandleRequest(IRequest request)
        {
            IResponse response=null;
            if (request is LogInRequest)
                try
                 { 
                    Service.LogIn(((LogInRequest)request).NewUser, this);
                    response = new OkResponse();
                    return (Object)response;
                }catch (Exception ex)
                {
                    return new ErrorResponse(ex.Message);
                }
            return (Object)response;
        }
        public void SendResponse(IResponse response)
        {
            Console.WriteLine("Sending response" + response.GetType());
            MyFormatter.Serialize(StreamToClient,response);
            StreamToClient.Flush();

        }
        public void run()
        {
            while (connected)
            {
                try
                {
                    Console.WriteLine("in ClientWorker - waiting for reqests");
                    Object request = MyFormatter.Deserialize(StreamToClient);
                    Console.WriteLine("in ClientWorker - request received"+request.GetType());
                    Object response = this.HandleRequest((IRequest)request);
                    if (response != null)
                    {
                        this.SendResponse((IResponse)response);
                    }
                }catch(Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
            try
            {
                StreamToClient.Close();
            }catch (Exception ec)
            {
                Console.WriteLine(ec.Message);
            }
        }
    }
}
