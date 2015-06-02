using System;
using System.Collections.Generic;

namespace ATM.Events
{
    public class InsertCassettesArgs:EventArgs
    {
        public InsertCassettesArgs(DateTime time, List<Cassette> cassettes)
        {
            Time = time;
            Cassettes = cassettes;
        }

        public DateTime Time { get; private set; }

        public List<Cassette> Cassettes { get; private set; } 
        
    }
}
