using System;

namespace ATM.Events
{
    public class RemoveCassettesArgs:EventArgs
    {
        public RemoveCassettesArgs(DateTime time)
        {
            Time = time;
        }

        public DateTime Time { get; private set; }
    }
}
