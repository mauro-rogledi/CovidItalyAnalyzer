using System;
using System.Configuration;

namespace CovidItalyAnalyzer.Library
{
    public static class SettingManager
    {
        private const string folderdata = "Folderdata";
        private const string username = "username";
        private const string password = "password";
        private const string email = "email";
        private const string usegithub = "usegihub";

        public static string FolderData { get; set; }

        public static bool UseGitHub { get; set; }

        public static string UserName { get; set; }

        public static string Password { get; set; }
        public static string Email { get; internal set; }

        public static void ReadData()
        {
            FolderData = ReadSetting<string>(folderdata);
            bool useGitHub = false;
            if (Boolean.TryParse(ReadSetting<bool>(usegithub), out useGitHub))
                UseGitHub = useGitHub;
            UserName = ReadSetting<string>(username);
            Password = Crypting.Decrypt(ReadSetting<string>(password));
            Email = ReadSetting<string>(email);
        }

        public static void SaveData()
        {
            AddUpdateAppSettings(folderdata, FolderData);
            AddUpdateAppSettings(usegithub, UseGitHub.ToString());
            AddUpdateAppSettings(username, UserName);
            AddUpdateAppSettings(password, Crypting.Encrypt(Password));
            AddUpdateAppSettings(email, Email);
        }

        private static string ReadSetting<T>(string key)
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                return appSettings[key] ?? "";
            }
            catch (ConfigurationErrorsException)
            {
                return "";
            }
        }

        private static void AddUpdateAppSettings(string key, string value)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error writing app settings");
            }
        }
    }
}