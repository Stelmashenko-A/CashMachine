using System;
using System.Collections.Generic;
using System.IO;

namespace ATM.Input
{
    internal class TxtReader : IReader<List<Cassette>>
    {
        public List<Cassette> Read(string fileName)
        {
            var stream = new StreamReader(new FileStream(fileName, FileMode.Open));
            var moneyCassettes = new List<Cassette>();
            var str = stream.ReadLine();
            if (str == null) return moneyCassettes;
            var strArray = str.Split(' ');
            var numberOfPars = strArray.Length/2;
            for (var i = 0; i < numberOfPars; i++)
            {
                decimal nominal;
                if (!decimal.TryParse(strArray[i*2], out nominal))
                {
                    throw new Exception("Can't parse " + strArray[i*2] + " to decimal");
                }

                int num;
                if (!int.TryParse(strArray[i*2 + 1], out num))
                {
                    throw new Exception("Can't parse " + strArray[i*2 + 1] + " to int");
                }

                var cassette = new Cassette(new Banknote(nominal), num);


                moneyCassettes.Add(cassette);
            }
            return moneyCassettes;
        }
    }
}
