using System.Collections.Generic;

namespace BerryPatch.Config
{
    public interface IConfig
    {
        /// <summary>
        /// Reads the value of the app setting in the config file.
        /// </summary>
        /// <param name="appSettingName">Name of the app setting.</param>
        /// <returns></returns>
        string ReadAppSetting(string appSettingName);

        /// <summary>
        /// Determines if the app setting exists or not.
        /// </summary>
        /// <param name="appSettingName">Name of the app setting.</param>
        /// <returns></returns>
        bool AppSettingExists(string appSettingName);

        /// <summary>
        /// Reads the value attribute of a named node defined in a named section of the configuration.
        /// </summary>
        /// <param name="nodeName">Name of the node.</param>
        /// <param name="sectionToRead">The section to read.</param>
        /// <returns></returns>
        string ReadValue(string nodeName, string sectionToRead);

        /// <summary>
        /// Gets the named sections in the config file.
        /// </summary>
        /// <returns></returns>
        List<string> GetSections();
    }
}