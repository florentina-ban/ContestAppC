using ContestModel.Domain;
using ContestServices.Services;
using System;

namespace ContestFormApp.Services
{
    public class ContestController : IContestObserver
    {
        public IContestService ServiceProxy { get; set; }
        public User currentUser { get; set; }

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
            mainForm.Show();
        }
        public void SetAgeActegories(int age)
        {
           // ServiceProxy.
        }
    }
}
