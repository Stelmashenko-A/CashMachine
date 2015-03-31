using System.Collections.Generic;
using System.IO;

namespace ATM
{
    static class CassetteReader
    {
        public static List<Cassette> ReadCassette(string fileName)
        {
            var moneyCassettes = new List<Cassette>();
            
            string data;
            using (var sr = new StreamReader(fileName))
            {
                data = sr.ReadLine();
            }
            if (data == null) return moneyCassettes;
            var strArray = data.Split(' ');
            var numberOfPars = strArray.Length / 2;
            for (var i = 0; i < numberOfPars; i++)
            {
                var nominal = decimal.Parse(strArray[i * 2]);
                var num = int.Parse(strArray[i * 2 + 1]);
                var cassette = new Cassette(new Banknote(nominal), num);
                moneyCassettes.Add(cassette);
            }
            return moneyCassettes;
        }
    }
}
