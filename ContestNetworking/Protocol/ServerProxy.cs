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
        IContestObserver Controller;
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
            this.Controller = observer;
            if (response is ErrorResponse)
            {
                this.CloseConnection();
                throw new Exception("LogIn denied");
            }
        }

        public void LogOut(User user)
        {
            IRequest request = new LogOutRequest(user);
            this.SendRequest(request);
            IResponse response = this.ReadResponse();
            //if (response is OkResponse)
            //this.Connected = false;
            CloseConnection();
            if (response is ErrorResponse)
            {
                throw new Exception(((ErrorResponse)response).Message);
            }
        }
        public IList<AgeCategory> GetAgeCategories()
        {
            IRequest request = new AgeCategoriesRequest();
            this.SendRequest(request);
            IResponse response = this.ReadResponse();
            if (response is ErrorResponse)
            {
                throw new Exception(((ErrorResponse)response).Message);
            }
            AgeCategoriesResponse resp = (AgeCategoriesResponse)response;
            return resp.AllCategs;
        }

        public IList<Competition> GetCompetitions(AgeCategory ageCategory)
        {
            IRequest request = new CompetitionsRequest(ageCategory);
            this.SendRequest(request);
            IResponse response = this.ReadResponse();
            if (response is ErrorResponse)
            {
                throw new Exception(((ErrorResponse)response).Message);
            }
            IList<Competition> allComps = ((CompetitionsResponse)response).allComps;
            return allComps;
        }
        public IList<ParticipantDTO> GetParticipantDTOs(Competition competition)
        {
            IRequest request = new ParticipantsRequest(competition);
            this.SendRequest(request);
            IResponse response = this.ReadResponse();
            if (response is ErrorResponse)
            {
                throw new Exception(((ErrorResponse)response).Message);
            }
            IList<ParticipantDTO> allParts = ((ParticipantsResponse)response).AllParts;
            return allParts;
        }
        public void DeleteParticipant(ParticipantDTO participantDTO, IContestObserver obs)
        {
            IRequest request = new DeleteRequest(participantDTO);
            this.SendRequest(request);
            IResponse response = this.ReadResponse();
            if (response is ErrorResponse)
            {
                throw new Exception(((ErrorResponse)response).Message);
            }
            OkResponse resp = (OkResponse)response;
            Controller.ParticipantRemoved(resp.participant);
        }
        public ParticipantDTO AddParticipant(ParticipantDTO participantDTO,IContestObserver obs)
        {
            IRequest request = new AddRequest(participantDTO);
            this.SendRequest(request);
            IResponse response = this.ReadResponse();
            if (response is ErrorResponse)
            {
                throw new Exception(((ErrorResponse)response).Message);
            }
            OkResponse resp = (OkResponse)response;
            Controller.ParticipantAdded(resp.participant);
            return null;
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
                Console.WriteLine("Response read from Queue "+ response.GetType());
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
                    Console.WriteLine("Response read from stream " + respObj.GetType());
                    IResponse response = (IResponse)respObj;
                    if (response is IUpdateResponse)
                    {
                        //Task.Run(() => this.HandleUpdate((IUpdateResponse)response));
                        this.HandleUpdate((IUpdateResponse)response);
                    }
                    else
                    {
                        lock (ResponseQueue)
                        {
                            Console.WriteLine("Response put in queue " + response.GetType());
                            ResponseQueue.Enqueue(response);
                        }
                        this.WaitHandle.Set();
                    }
                }catch (Exception ex)
                {
                    Console.WriteLine("Exeption in ServerProxy "+ ex.Message);
                }
            }
        }
        public void CloseConnection()
        {
            this.Connected = false;
            try
            {
                StreamToClientWorker.Close();
                this.SocketToClientWorker.Close();
                this.WaitHandle.Close();
                this.Controller = null;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
        public void HandleUpdate(IUpdateResponse response)
        {
            if (response is UpdateRemovedParticipantResponse)
            {
                try
                {
                    UpdateRemovedParticipantResponse resp = (UpdateRemovedParticipantResponse)response;
                    this.Controller.ParticipantRemoved(resp.participant);
                }catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                }
            }
            if (response is UpdateAddParticipatResponse)
            {
                try
                {
                    UpdateAddParticipatResponse resp = (UpdateAddParticipatResponse)response;
                    this.Controller.ParticipantAdded(resp.participantDTO);
                }catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                }
            }
        }

       
    }
}
