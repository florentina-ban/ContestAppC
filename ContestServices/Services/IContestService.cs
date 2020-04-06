﻿
using ContestModel.Domain;
using System.Collections.Generic;

namespace ContestServices.Services
{
    public interface IContestService
    {
        void LogIn(User user, IContestObserver observer);
        void LogOut(User user, IContestObserver observer);
        IList<AgeCategory> GetAgeCategories();
        IList<Competition> GetCompetitions(AgeCategory ageCategory);
        IList<ParticipantDTO> GetParticipantDTOs(Competition competition);
        void DeleteParticipant(ParticipantDTO participantDTO,IContestObserver obs);
        void AddParticipant(ParticipantDTO participantDTO, IContestObserver obs);
    }
}
