using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Threading;
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
                    var specifiedCulture = ConfigurationManager.AppSettings["Lang"];
                    SetCulture(specifiedCulture);
                    var states = Enum.GetValues(typeof (AtmState));
                    var resourceManager = new ResourceManager(Properties.Resources.PathToLanguage, Assembly.GetExecutingAssembly());
                    foreach (AtmState state in states)
                    {
                        var type = Enum.GetName(typeof (AtmState), state);

                        if (type != null)
                        {
                            atmStates.Add(state, resourceManager.GetString(type));
                        }
                    }
                }
                catch (MissingManifestResourceException ex)
                {
                    Log.Error(ex);
                }}
                return atmStates;
        }

        private static void SetCulture(string specifiedCulture)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(specifiedCulture);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(specifiedCulture);
        }
    }
}
