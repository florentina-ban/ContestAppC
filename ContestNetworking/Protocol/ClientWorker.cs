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
using ContestModel.Domain;

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

        public void ParticipantRemoved(ParticipantDTO participantDTO)
        {
            IUpdateResponse response = new UpdateRemovedParticipantResponse(participantDTO);
            // Console.WriteLine("ClientWorker - inainte de send UpdateResponse");
            try
            {
                this.SendResponse(response);
            }catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
        public void ParticipantAdded(ParticipantDTO participantDTO)
        {
            IUpdateResponse response = new UpdateAddParticipatResponse(participantDTO);
            // Console.WriteLine("ClientWorker - inainte de send UpdateResponse");
            try
            {
                this.SendResponse(response);
            }catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
        public Object HandleRequest(IRequest request)
        {
            IResponse response=null;
            try
            {
                if (request is LogInRequest)
                {
                    response = new OkResponse(null);

                    lock (this.Service)
                    {
                        Service.LogIn(((LogInRequest)request).NewUser, this);
                    }

                    return (Object)response;
                }
                if (request is LogOutRequest)
                {
                    lock (this.Service)
                    {
                        Service.LogOut(((LogOutRequest)request).user);
                    }
                    response = new OkResponse(null);
                    return (object)response;
                    
                }
                if (request is AgeCategoriesRequest)
                {
                    IList<AgeCategory> allCategs;

                    lock (this.Service)
                    {
                        allCategs = this.Service.GetAgeCategories();
                    }
                    response = new AgeCategoriesResponse(allCategs);
                    return (Object)response; 
                }
                if (request is CompetitionsRequest)
                {
                    CompetitionsRequest req = (CompetitionsRequest)request;
                    IList<Competition> allComps;
                    lock (this.Service)
                    {
                        allComps = this.Service.GetCompetitions(req.ageCategory);
                    }
                    response = new CompetitionsResponse(allComps);
                    return (Object)response;
                }
                if (request is ParticipantsRequest)
                {
                    ParticipantsRequest req = (ParticipantsRequest)request;
                    IList<ParticipantDTO> allPart;
                    lock (this.Service)
                    {
                        allPart = this.Service.GetParticipantDTOs(req.MyCompetition);
                    }
                    response = new ParticipantsResponse(allPart);
                    return (object)response;
                }
                if (request is DeleteRequest)
                {
                    DeleteRequest req = (DeleteRequest)request;
                    lock (this.Service)
                    {
                        Service.DeleteParticipant(req.Particip,this);
                    }
                    response = new OkResponse(req.Particip);
                    return (object)response;
                }
                if (request is AddRequest)
                {
                    ParticipantDTO part=null;
                    AddRequest req = (AddRequest)request;
                    lock (this.Service)
                    {
                        part=Service.AddParticipant(req.participantDTO, this);
                    }
                    response = new OkResponse(part);
                    return (object)response;
                }

            }catch (Exception ex){
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
                    Console.WriteLine("in ClientWorker - request received" + request.GetType());
                    Object response = this.HandleRequest((IRequest)request);
                    if (response != null)
                    {
                        this.SendResponse((IResponse)response);
                        if (request is LogOutRequest && response is OkResponse)
                            connected = false;
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
                try
                {
                    Thread.Sleep(1000);
                }
                catch( Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                }
            }
            try
            {
                StreamToClient.Close();
                SocketToClient.Close();
            }
            catch (Exception ec)
            {
                Console.WriteLine(ec.Message);
            }
        }
    }
}
