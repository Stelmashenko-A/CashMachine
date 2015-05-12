using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class Record
    {
        public Record( DateTime timeOfOperation,decimal requestedSum, Money money, AtmState resultOfOperation)
        {
            Money = money;
            TimeOfOperation = timeOfOperation;
            ResultOfOperation = resultOfOperation;
            RequestedSum = requestedSum;
        }

        public Money Money { get; private set; }
        public DateTime TimeOfOperation { get; private set; }
        public AtmState ResultOfOperation { get; private set; }
        public decimal RequestedSum { get; private set; }

    }
}
