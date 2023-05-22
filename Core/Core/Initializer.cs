using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Core
{
    public static class Initializer
    {
        public static void Initialize(string variableKey, string variableValue)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings[variableKey].Value = variableValue;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        public static void ProcessCommandLineArgs(string variableKey)
        {
            string[] args = Environment.GetCommandLineArgs();

            // Проверяем наличие аргументов командной строки
            if (args.Length > 1)
            {
                // Получаем значение из аргумента командной строки
                string variableValue = args[1];

                Initialize(variableKey, variableValue);
            }
        }
    }
}
