using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidItalyAnalyzer.Library
{
    public static class DataReader
    {
        public static bool HasReadData { get => HasData(); }

        private static bool HasData()
        {
            if (SettingManager.FolderData == "")
                return false;

            return Directory.Exists(Path.Combine(SettingManager.FolderData, "dati-json"));
        }

        public static async Task<(bool fromClone, string message)> RefreshData()
        {
            (bool ok, string message) gitResult;
            bool fromClone = false;

            if (HasReadData)
                gitResult = await GitManager.GitPull();
            else
            {
                gitResult = await GitManager.GitClone();
                fromClone = true;
            }

            if (gitResult.ok)
            {
                DataReaderRegion.ReadData(SettingManager.FolderData);
                DataReaderCounty.ReadData(SettingManager.FolderData);
            }

            return (fromClone, gitResult.message);
        }

        public static bool ReadData()
        {
            if (!HasReadData)
                return false;

            DataReaderRegion.ReadData(SettingManager.FolderData);
            DataReaderCounty.ReadData(SettingManager.FolderData);

            return true;
        }
    }
}
