using System;

namespace ATM.Events
{
    public class WithdrawArgs:EventArgs
    {
        public WithdrawArgs(DateTime time, decimal requestedSum, AtmState resultOfOperation, Money money)
        {
            Time = time;
            RequestedSum = requestedSum;
            ResultOfOperation = resultOfOperation;
            Money = money;
        }

        public DateTime Time { get; private set; }

        public decimal RequestedSum { get; private set; }

        public AtmState ResultOfOperation { get; private set; }

        public Money Money { get; private set; }
    }
}
