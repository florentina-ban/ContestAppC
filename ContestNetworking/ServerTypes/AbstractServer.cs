using System;
using ContestServices.Services;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace ContestNetworking.ServerTypes
{
    public abstract class AbstractServer
    {
        public int Port { get; set; }
        public string IpAddress { get; set; }
        public TcpListener MySocketServer { get; set; } 
        public AbstractServer(int port, String ipAddress)
        {
            IpAddress = ipAddress;
            Port = port;
        }

        public void Start()
        {
            IPAddress ipAddr = IPAddress.Parse(this.IpAddress);
            IPEndPoint endp = new IPEndPoint(ipAddr, this.Port);
            this.MySocketServer = new TcpListener(endp);

            MySocketServer.Start();
            while (true)
            {
                Console.WriteLine("Waiting for clients ... ");
                TcpClient client = MySocketServer.AcceptTcpClient();
                Console.WriteLine("New Client Connected");
                this.ProcessRequest(client);
            }
        }
        public void Stop()
        {
            try
            {
                MySocketServer.Stop();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public abstract void ProcessRequest(TcpClient newClient);
    }
}
