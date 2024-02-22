using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.Server.ObserverPattern
{
    public interface IObserver
    {
        void UpdatePackagesView();
        void UpdateUserView();
        void updateSubscribersView();
        void updateTotalPrice();
    }
}
