using System.Collections.Generic;
using System.IO;

namespace ATM
{
    class CassetteWriter
    {
        public static void Write(List<Cassette> cassettes, string path)
        {
            using (var sr = new StreamWriter(path))
            {
                foreach (var variable in cassettes)
                {
                    sr.Write(variable.Banknote.Nominal+" "+variable.Number+" ");
                }
                sr.Close();
            }
        }
    }
}
