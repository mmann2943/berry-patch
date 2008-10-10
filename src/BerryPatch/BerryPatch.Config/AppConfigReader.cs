using System.Collections.Generic;
using System.Configuration;

namespace BerryPatch.Config
{
    public class AppConfigReader:IConfig
    {
        public string ReadAppSetting(string appSettingKey)
        {
            return ConfigurationManager.AppSettings[appSettingKey];
        }

        public bool AppSettingExists(string appSettingName)
        {
            throw new System.NotImplementedException();
        }

        public string ReadValue(string nodeName, string sectionToRead)
        {
            throw new System.NotImplementedException();
        }

        public List<string> GetSections()
        {
            throw new System.NotImplementedException();
        }
    }
}