using System.Configuration;

namespace SmartMallFramework
{

    public class AppSetting
    {
        Configuration config;

        /// <summary>
        /// get the app setting
        /// </summary>
        public AppSetting()
        {
            config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        }

        /// <summary>
        /// get the connection
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetConnectionString(string key)
        {
            return config.ConnectionStrings.ConnectionStrings[key].ConnectionString;
        }

        /// <summary>
        /// SQL connection
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void SaveConnectionString(string key, string value)
        {
            config.ConnectionStrings.ConnectionStrings[key].ConnectionString = value;
            config.ConnectionStrings.ConnectionStrings[key].ProviderName = "System.Data.SqlClient";
            config.Save(ConfigurationSaveMode.Modified);
        }

    }
}
