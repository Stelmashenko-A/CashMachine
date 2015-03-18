using System.IO;

namespace ATM
{
    static class AtmReader
    {
        public static Cassete ReadCassete(string fileName)
        {
            var cassete = new Cassete();
            string data;
            using (var sr = new StreamReader(fileName))
            {
                data = sr.ReadLine();
            }
            if (data == null) return cassete;
            var strArray = data.Split(' ');
            var numberOfPars = strArray.Length / 2;
            for (var i = 0; i < numberOfPars; i++)
            {
                var nominal = int.Parse(strArray[i * 2]);
                var num = int.Parse(strArray[i * 2 + 1]);
                cassete.Money.Banknotes.Add(new MutablePair<Banknote, int>(new Banknote(nominal), num));
            }
            return cassete;
        }
    }
}
