using ContestNetworking.Protocol;
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
    public class MyConcurentServer : AbstractConcurentServer
    {
        IDictionary<String, IContestObserver> allClients = new Dictionary<string, IContestObserver>();
        public IContestService Service { get; set; }
        public MyConcurentServer(int port, String addr,IContestService serv):base(port,addr) {
            Service = serv;
        }


        public override Thread CreateWorker(TcpClient clientSocket)
        {
            ClientWorker worker = new ClientWorker(this.Service, clientSocket);
            return new Thread(new ThreadStart(worker.run));
        }
    }
}
