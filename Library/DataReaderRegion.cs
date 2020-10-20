using CovidItalyAnalyzer.ModelData;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CovidItalyAnalyzer.Library
{
    public class ComboData
    {
        public int value { get; set; }
        public string display { get; set; }
    }

    public static class DataReaderRegion
    {
        private static List<RegionData> RegionDatas;
        private static List<ItalyRegion> italyRegions;

        private static string folder = string.Empty;

        public static bool HasReadData { get => folder != string.Empty; }

        internal static void ReadData(string folderName)
        {
            folder = folderName;
            ReadRegionData(folderName);
            ReadItalyRegions();
        }

        internal static IOrderedEnumerable<RegionData> ReadRegionData(int region)
        {
            return DataReaderRegion.RegionDatas
                 .Where(r => r.codice_regione == region)
                 .OrderBy(d => d.data);
        }

        internal static IEnumerable<RegionData> ReadRegionsAtDate(DateTime date)
        {
            return DataReaderRegion.RegionDatas
                 .Where(r => r.data.Date == date.Date);
        }
        internal static IEnumerable<IGrouping<int, RegionData>> ReadRegionsAtRangeDate(DateTime dateFrom, DateTime dateTo)
        {
            return DataReaderRegion.RegionDatas
                 .Where(r => r.data.Date >= dateFrom.Date && r.data.Date <= dateTo.Date)
                 .GroupBy(g => g.codice_regione);
        }

        internal static IOrderedEnumerable<ItalyRegion> ReadRegions()
        {
            return italyRegions
                .OrderBy(o => o.denominazione_regione);

            //.Select(r => new  ComboData() { value = r.codice_regione, display =r.denominazione_regione }).ToArray();
        }

        internal static void RefreshDatas()
        {
            ReadRegionData(folder);
        }

        private static void ReadRegionData(string folderName)
        {
            string fileName = Path.Combine(folderName, "dati-json\\dpc-covid19-ita-regioni.json");
            RegionDatas = Newtonsoft.Json.JsonConvert.DeserializeObject<List<RegionData>>(File.ReadAllText(fileName));
        }

        private static void ReadItalyRegions()
        {
            italyRegions = RegionDatas
                .OrderBy(d => d.codice_regione)
                .Distinct(new RegionCompare())
                .Aggregate<RegionData, List<ItalyRegion>>(
                    new List<ItalyRegion>(), (reg, d) =>
                    {
                        reg.Add(new ItalyRegion() { codice_regione = d.codice_regione, denominazione_regione = d.denominazione_regione });
                        return reg;
                    });
        }
    }

    public class RegionCompare : IEqualityComparer<RegionData>
    {
        public bool Equals(RegionData x, RegionData y)
        {
            //Check whether the compared objects reference the same data.
            if (Object.ReferenceEquals(x, y)) return true;

            //Check whether any of the compared objects is null.
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;

            //Check whether the products' properties are equal.
            return x.denominazione_regione == y.denominazione_regione && x.codice_regione == y.codice_regione;
        }

        public int GetHashCode(RegionData obj)
        {
            //Check whether the object is null
            if (Object.ReferenceEquals(obj, null)) return 0;

            //Get hash code for the Name field if it is not null.
            return obj.denominazione_regione.GetHashCode() ^ obj.codice_regione.GetHashCode();
        }
    }

}