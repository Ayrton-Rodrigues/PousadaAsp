using PousadaAsp.Domain.Interfaces.IService;
using System;
using System.Collections.Generic;
using System.Text;

namespace PousadaAsp.Domain.Services
{
    public class NotifierService : INotifier
    {
        private List<string> _notifications;

        public NotifierService()
        {
            _notifications = new List<string>();
        }

        public List<string> GetNotification()
        {
            return _notifications;
        }

        public void Handle(string message)
        {
            _notifications.Add(message);
        }

        public bool HasNotification()
        {
            return _notifications.Count > 0;
        }
    }
}
