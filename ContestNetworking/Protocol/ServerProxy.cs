using ContestModel.Domain;
using ContestServices.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ContestNetworking.Protocol
{
    public class ServerProxy : IContestService
    {
        public int MyPort;
        public string MyAddress;
        public TcpClient SocketToClientWorker;
        IFormatter MyFormatter;
        bool Connected;
        Queue<IResponse> ResponseQueue;
        NetworkStream StreamToClientWorker;
        private EventWaitHandle WaitHandle;
        public ServerProxy(int myPort, String myAddress)
        {
            MyAddress = myAddress;
            MyPort = myPort;
            ResponseQueue = new Queue<IResponse>();
        }

        
        public void InitializeConnection()
        {
            try
            {
                SocketToClientWorker = new TcpClient(MyAddress, MyPort);
                this.Connected = true;
                StreamToClientWorker = SocketToClientWorker.GetStream();
                MyFormatter = new BinaryFormatter();
                this.WaitHandle = new AutoResetEvent(false);
                this.StartReader();
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void LogIn(User user, IContestObserver observer)
        {
            InitializeConnection();
            IRequest request = new LogInRequest(user);
            this.SendRequest(request);
            IResponse response = this.ReadResponse();
            if (response is ErrorResponse)
            {
                throw new Exception("LogIn denied");
            }
        }

        public void LogOut(User user, IContestObserver observer)
        {
            throw new NotImplementedException();
        }
        public void StartReader()
        {
            Thread thread = new Thread(this.run);
            thread.Start();
        }
        public void SendRequest(IRequest request)
        {
            try
            {
                Console.WriteLine("before sending the request "+request.ToString());
                MyFormatter.Serialize(StreamToClientWorker, request);
                StreamToClientWorker.Flush();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public IResponse ReadResponse()
        {
            IResponse response = null;
            try
            {
                this.WaitHandle.WaitOne();
                response = ResponseQueue.Dequeue();

            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return response;
        }
        public void run()
        {
            while (this.Connected)
            {
                try
                {
                    Object respObj = MyFormatter.Deserialize(StreamToClientWorker);
                    IResponse response = (IResponse)respObj;
                    if (response is IUpdateResponse)
                    {
                        this.HandleUpdate((IUpdateResponse)response);
                    }
                    else
                    {
                        lock (ResponseQueue)
                        {
                            ResponseQueue.Enqueue(response);
                        }
                        this.WaitHandle.Set();
                    }
                }catch (Exception ex)
                {
                    Console.WriteLine("Exeption in ServerProxy");
                }
            }
        }
        public void HandleUpdate(IUpdateResponse response)
        {

        }
    }
}
