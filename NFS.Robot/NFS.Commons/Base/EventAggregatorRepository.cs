using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFS.Commons.Base
{
  public class EventAggregatorRepository
    {
        public EventAggregatorRepository()
        {
            eventAggregator = new EventAggregator();
        }
        public IEventAggregator eventAggregator;
        public static EventAggregatorRepository eventRepository = null;

        //单例，保持内存唯一实例
        public static EventAggregatorRepository GetInstance() 
        {
            if (eventRepository == null)
            {
                eventRepository = new EventAggregatorRepository();
            }
            return eventRepository;
        }
    }
}
