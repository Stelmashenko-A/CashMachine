using System.Collections.Generic;
using System.IO;

namespace ATM.Input
{
    public class CsvReader : IReader<List<Cassette>>
    {
        public List<Cassette> Read(string fileName)
        {
            List<Cassette> list = new List<Cassette>();
            var stream = new StreamReader(new FileStream(fileName, FileMode.Open));

            stream.ReadLine();
            while (!stream.EndOfStream)
            {
                var str = stream.ReadLine();
                if (str != null)
                {
                    var strs = str.Split(',');
                    var number = int.Parse(strs[0]);
                    var nominal = int.Parse(strs[1]);
                    list.Add(new Cassette(new Banknote(nominal), number));
                }
            }
            return list;
        }
    }
}
