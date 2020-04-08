using ContestModel.Domain;
using ContestServices.Services;
using System;
using System.Collections.Generic;

namespace ContestFormApp.Services
{
    public class ContestController : IContestObserver
    {
        public IContestService ServiceProxy { get; set; }
        public User currentUser { get; set; }

        public event EventHandler<ContestEventArgs> udateEvent;

        public ContestController(IContestService serviceProxy)
        {
            ServiceProxy = serviceProxy;
        }
        public void LogIn(string user, string pass)
        {
            User newUser = new User(user, pass);
            ServiceProxy.LogIn(newUser, this);
            this.currentUser = newUser;
            Form1 mainForm = new Form1(this);
            mainForm.Text += user;
            mainForm.Show();
        }
        public void LogOut()
        {
            ServiceProxy.LogOut(this.currentUser);
        }
        public IList<AgeCategory> GetAgeCategories()
        {
            return this.ServiceProxy.GetAgeCategories();
        }
        public IList<Competition> GetCompetitions(AgeCategory ageCategory)
        {
            return this.ServiceProxy.GetCompetitions(ageCategory);
        }
        public IList<ParticipantDTO> GetParticipantDTOs(Competition competition)
        {
            return this.ServiceProxy.GetParticipantDTOs(competition);
        }

        public void ParticipantRemoved(ParticipantDTO participantDTO)
        {
            ContestEventArgs eventArgs = new ContestEventArgs(ContestEvent.ParticipantRemoved, (object)participantDTO);
            this.UpdateParticipanti(eventArgs);
        }
        public void ParticipantAdded(ParticipantDTO participantDTO)
        {
            ContestEventArgs eventArgs = new ContestEventArgs(ContestEvent.ParticipantAdded, (object)participantDTO);
            this.UpdateParticipanti(eventArgs);
        }
        public void UpdateParticipanti(ContestEventArgs eventArgs)
        {
            if (this.udateEvent == null)
                return;
            this.udateEvent(this, eventArgs);
            Console.WriteLine("update event called");
        }
        public void DeleteParticipant(ParticipantDTO participantDTO)
        {            
            ServiceProxy.DeleteParticipant(participantDTO,this);
           // this.UpdateParticipanti(new ContestEventArgs(ContestEvent.ParticipantRemoved, (object)participantDTO));
        }
        public void AddParticipant(String name, int age, IList<Competition> competitions)
        {
            ParticipantDTO participantDTO = new ParticipantDTO(new Participant(-1, name, age), competitions);
            ServiceProxy.AddParticipant(participantDTO, this);
           // this.UpdateParticipanti(new ContestEventArgs(ContestEvent.ParticipantAdded, (object)participantDTO));
        }
    }
}
