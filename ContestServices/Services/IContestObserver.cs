using ContestModel.Domain;
using System;

namespace ContestServices.Services
{
    public interface IContestObserver
    {
        void ParticipantRemoved(ParticipantDTO participantDTO);
        void ParticipantAdded(ParticipantDTO participantDTO);

    }
}
