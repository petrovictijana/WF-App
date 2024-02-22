using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.Server.Strategy_Pattern
{
    public class Context
    {
        private IStrategy strategy;

        // Postavljanje strategije kroz konstruktor ili metodu
        public Context(IStrategy strategy)
        {
            this.strategy = strategy;
        }

        // Postavljanje strategije kroz property
        public void SetStrategy(IStrategy strategy)
        {
            this.strategy = strategy;
        }

        // Izvršavanje strategije
        public void ExecuteStrategy()
        {
            strategy.execute();
        }
    }
}
