using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using System.Resources;
using log4net;

namespace ATM
{
    public static class Configurator
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Configurator));
        public static Dictionary<AtmState, string> Config()
        {
            
            var atmStates = new Dictionary<AtmState, string>();
            {
                try
                {
                    var states = Enum.GetValues(typeof (AtmState));
                    var resourceManager = new ResourceManager(ConfigurationManager.AppSettings["PathToLanguage"], Assembly.GetExecutingAssembly());
                    foreach (AtmState state in states)
                    {
                        var type = Enum.GetName(typeof (AtmState), state);
                        Log.Debug(type);

                        if (type != null)
                        {
                            atmStates.Add(state, resourceManager.GetString(type));
                        }
                    }
                }
                catch (MissingManifestResourceException ex)
                {
                    Log.Error(ex);
                    throw;
                }}
                return atmStates;
        }
    }
}
