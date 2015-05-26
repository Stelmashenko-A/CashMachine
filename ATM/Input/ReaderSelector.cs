using System.Collections.Generic;
using System.Linq;

namespace ATM.Input
{
    public static class ReaderSelector
    {
        static public IReader<List<Cassette>> Select(string fileName)
        {
            var format = fileName.Split('.').Last();
            format = format.ToLower();

            var isFormatDetected = false;
            IReader<List<Cassette>> reader = null;

            if (format == "json")
            {
                isFormatDetected = true;
                reader = new JsonReader<List<Cassette>>();
            }
            if (format == "xml")
            {
                isFormatDetected = true;
                reader = new XmlReader<List<Cassette>>();
            }
            if (format != "csv") return !isFormatDetected ? null : reader;
            reader = new CsvReader();

            return reader;
        }
    }
}
