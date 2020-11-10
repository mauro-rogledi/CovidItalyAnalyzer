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

        public static bool HasReadData { get => folder != string.Empty && Directory.Exists(Path.Combine(folder, "dati-json")); }

        internal static void ReadData(string folderName)
        {
            folder = folderName;
            ReadRegionData(folderName);
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

        internal static IEnumerable<RegionData> ReadRegionsAtRangeDate(DateTime dateFrom, DateTime dateTo)
        {
            return DataReaderRegion.RegionDatas
                 .Where(r => r.data.Date >= dateFrom.Date && r.data.Date <= dateTo.Date);
        }

        internal static IOrderedEnumerable<ItalyRegion> ReadRegions()
        {
            return italyRegions
                .OrderBy(o => o.denominazione_regione);
        }

        internal static void RefreshDatas()
        {
            ReadRegionData(folder);
        }

        private static void ReadRegionData(string folderName)
        {
            string fileName = Path.Combine(folderName, "dati-json\\dpc-covid19-ita-regioni.json");
            if (!File.Exists(fileName)) 
                return;
            var allData = Newtonsoft.Json.JsonConvert.DeserializeObject<List<RegionData>>(File.ReadAllText(fileName));
            ReadItalyRegions(allData);

            RegionDatas = new List<RegionData>();

            foreach (var region in italyRegions)
            {
                var data = allData
                    .Distinct(new RegionDateCompare())
                    .Where(r => r.codice_regione == region.codice_regione)
                    .OrderBy(o => o.data)
                    .ToList();

                RegionDatas.AddRange(
                    data.Select((curr, i) =>
                        {
                            curr.nuovi_tamponi = i > 0 ? curr.tamponi - data[i - 1].tamponi : curr.tamponi;
                            curr.nuovi_deceduti = i > 0 ? curr.deceduti - data[i - 1].deceduti : curr.deceduti;
                            return curr;
                        })
                );
            }
        }

        private static void ReadItalyRegions(List<RegionData> allData)
        {
            italyRegions = allData
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

    public class RegionDateCompare : IEqualityComparer<RegionData>
    {
        public bool Equals(RegionData x, RegionData y)
        {
            //Check whether the compared objects reference the same data.
            if (Object.ReferenceEquals(x, y)) return true;

            //Check whether any of the compared objects is null.
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;

            //Check whether the products' properties are equal.
            return x.denominazione_regione == y.denominazione_regione && x.codice_regione == y.codice_regione && x.data == y.data;
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