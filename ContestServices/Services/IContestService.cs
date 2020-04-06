
using ContestModel.Domain;

namespace ContestServices.Services
{
    public interface IContestService
    {
        void LogIn(User user, IContestObserver observer);
        void LogOut(User user, IContestObserver observer);
    }
}
