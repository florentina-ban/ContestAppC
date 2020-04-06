using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContestFormApp.Services
{
    public enum ContestEvent
    {
        ParticipantRemoved, ParticipantAdded
    };
    public class ContestEventArgs : EventArgs
    {
        public ContestEvent eventType { get; set; }
        public Object Data { get; set; }

        public ContestEventArgs(ContestEvent myEvent, object data)
        {
            this.eventType = myEvent;
            Data = data;
        }
    }
}
