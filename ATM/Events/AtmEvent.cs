using System;
using System.Collections.Generic;
using System.Linq;

namespace ATM.Events
{
    public class AtmEvent
    {
        public delegate void InsertCassettesEventHandler(object sender, InsertCassettesArgs e);
        public static event InsertCassettesEventHandler InsertCassettesEvent;

        public delegate void RemoveCassettesEventHandler(object sender, RemoveCassettesArgs e);
        public static event RemoveCassettesEventHandler RemoveCassettesEvent;

        public delegate void WithdrawMoneyEventHandler(object sender, WithdrawArgs e);
        public static event WithdrawMoneyEventHandler WithdrawMoneyEvent;

        internal static void OnInsertCassettesEvent(IEnumerable<Cassette> cassettes)
        {
            var handler = InsertCassettesEvent;
            var list = cassettes.Select(item => (Cassette) item.Clone()).ToList();
            var insertCassettesArgs = new InsertCassettesArgs(DateTime.Now, list);
            if (handler != null) handler(null, insertCassettesArgs);
        }

        internal static void OnRemoveCassettesEvent()
        {
            var handler = RemoveCassettesEvent;
            if (handler != null) handler(null, new RemoveCassettesArgs(DateTime.Now));
        }

        internal static void OnWithdrawMoneyEvent(decimal requestedSum, AtmState resultOfOperation, Money money )
        {
            var handler = WithdrawMoneyEvent;
            var withdrawArgs = new WithdrawArgs(DateTime.Now,requestedSum, resultOfOperation,(Money)money.Clone());
            if (handler != null) handler(null, withdrawArgs);
        }
    }
}
