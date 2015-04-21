using System;
using System.Collections.Generic;
using System.IO;
using log4net;

namespace ATM
{
    class CassetteWriter
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(CassetteWriter));
        public static void Write(List<Cassette> cassettes, string path)
        {
            try
            {
                var sr = new StreamWriter(path);

                foreach (var variable in cassettes)
                {
                    sr.Write(variable.Banknote.Nominal + " " + variable.Number + " ");
                }
                sr.Close();
            }
            catch (ArgumentNullException ex)
            {
                Log.Error(ex);
            }
            catch (DirectoryNotFoundException ex)
            {
                Log.Error(ex);
            }
        }
    }
}
