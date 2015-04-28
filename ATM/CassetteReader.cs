using System;
using System.Collections.Generic;
using System.IO;
using log4net;

namespace ATM
{
    class CassetteReader//:IReader
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(CassetteReader));

        public List<Cassette> ReadCassette(object obj)
        {
            var fileName = (string) obj;
            Log.Info(fileName);
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
                Log.Debug(strArray);

                var numberOfPars = strArray.Length/2;
                Log.Debug(numberOfPars);

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
                    Log.Debug(cassette);

                    moneyCassettes.Add(cassette);
                }
            }
            catch (ArgumentNullException ex)
            {
                Log.Error(ex);
                throw;
            }
            catch (FormatException ex)
            {
                Log.Error(ex);
                throw;
            }

            return moneyCassettes;
        }
    }
}
