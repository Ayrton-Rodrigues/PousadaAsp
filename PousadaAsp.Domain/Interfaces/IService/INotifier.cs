using System;
using System.Collections.Generic;
using System.Text;

namespace PousadaAsp.Domain.Interfaces.IService
{
    public interface INotifier
    {
        bool HasNotification();

        List<string> GetNotification();

        void Handle(string message);
        
    }
}
