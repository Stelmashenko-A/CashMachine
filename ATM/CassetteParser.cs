using System;
using log4net;

namespace ATM
{
    class CassetteParser:IParser<Cassette>
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(CassetteParser));
        public Cassette Parse(string data)
        {
            var strs = data.Split(' ');

            try
            {
                decimal nominal;
                if (!decimal.TryParse(strs[0], out nominal))
                {
                    throw new Exception("Can't parse " + strs[0] + " to decimal");
                }

                int num;
                if (!int.TryParse(strs[1], out num))
                {
                    throw new Exception("Can't parse " + strs[1] + " to int");
                }


                return new Cassette(new Banknote(nominal), num);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }
    }
}
