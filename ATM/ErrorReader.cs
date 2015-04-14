using System.Collections.Generic;
using System.IO;

namespace ATM
{
    static class ErrorReader
    {
        public static Dictionary<AtmState, string> Read(string path)
        {
            var streamReader = new StreamReader(path);
            var result = new Dictionary<AtmState, string>
            {
                {AtmState.CombinationFailed, streamReader.ReadLine()},
                {AtmState.MoneyDeficiency, streamReader.ReadLine()}
            };
            return result;
        }

        public static Dictionary<AtmState, string> GetDefault()
        {
            return new Dictionary<AtmState, string>
            {
                {AtmState.CombinationFailed, "CombinationFailed"},
                {AtmState.MoneyDeficiency, "MoneyDeficiency"},
                {AtmState.NoError,"NoError" }
            };

        }


    }
}
