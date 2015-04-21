using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Threading;

namespace ATM
{
    public static class Configurator
    {
        public static Dictionary<AtmState, string> Config()
        {
            var atmStates = new Dictionary<AtmState, string>();
            var specifiedCulture = ConfigurationManager.AppSettings["Lang"];
            SetCulture(specifiedCulture);
            var states = Enum.GetValues(typeof (AtmState));
            var resourceManager = new ResourceManager("Atm.Lang.Language", Assembly.GetExecutingAssembly());
            foreach (AtmState state in states)
            {
                var type = Enum.GetName(typeof (AtmState), state);
                if (type != null)
                {
                    atmStates.Add(state, resourceManager.GetString(type));
                }
            }
            return atmStates;
        }

        private static void SetCulture(string specifiedCulture)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(specifiedCulture);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(specifiedCulture);
        }
    }
}
