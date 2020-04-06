using ContestServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ContestNetworking.ServerTypes
{
    public abstract class AbstractConcurentServer : AbstractServer
    {
        public AbstractConcurentServer(int port, String ipAddr):base(port,ipAddr)
        {
        }

        public abstract Thread CreateWorker(TcpClient clientSocket);
        public override void ProcessRequest(TcpClient newClient)
        {
            Thread clientWorker = this.CreateWorker(newClient);
            clientWorker.Start();
        }
    }
}
