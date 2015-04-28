using System.Collections.Generic;
using System.IO;

namespace ATM
{
    class Reader<TOut,TParser>:IReader<Stream,List<TOut> > where TParser:IParser<TOut>
    {
        private readonly TParser _parser;

        public Reader(TParser parser)
        {
            _parser = parser;
        }

        public List<TOut> Read(Stream input)
        {
            StreamReader sr = new StreamReader(input);
            var result = new List<TOut>();
            while (!sr.EndOfStream)
            {
                var str = sr.ReadLine();
                result.Add(_parser.Parse(str));
            }
            return result;
        }
    }
}
