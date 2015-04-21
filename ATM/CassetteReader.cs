using System;
using System.Collections.Generic;
using System.IO;
using log4net;

namespace ATM
{
    static class CassetteReader
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(CassetteReader));
        public static List<Cassette> ReadCassette(string fileName)
        {
            var moneyCassettes = new List<Cassette>();
            try
            {
                string data;
                using (var sr = new StreamReader(fileName))
                {
                    data = sr.ReadLine();
                }
                if (data == null)
                {
                    throw new NullReferenceException("data");
                }
                var strArray = data.Split(' ');
                var numberOfPars = strArray.Length/2;
                for (var i = 0; i < numberOfPars; i++)
                {
                    decimal nominal;
                    if (!decimal.TryParse(strArray[i*2], out nominal))
                    {
                        throw new Exception("Can't parse " + strArray[i * 2] + " to decimal");
                    }

                    int num;
                    if (!int.TryParse(strArray[i*2 + 1],out num))
                    {
                        throw new Exception("Can't parse " + strArray[i * 2 + 1] + " to int");
                    }

                    var cassette = new Cassette(new Banknote(nominal), num);
                    moneyCassettes.Add(cassette);
                }
            }
            catch (ArgumentNullException ex)
            {
                Log.Error(ex);
            }
            catch (FormatException ex)
            {
                Log.Error( ex);
            }
            return moneyCassettes;
        }
    }
}
