using CovidItalyAnalyzer.ModelData;

using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Packaging;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CovidItalyAnalyzer.Library
{

    public class ComboData
    {
        public int value { get; set; }
        public string display { get; set; }
    }

    public static class DataReader
    {
        private static List<CountyData> CountyDatas;
        private static List<RegionData> RegionDatas;
        private static List<ItalyRegion> italyRegions;
        private static List<ItalyCounty> italyCounties;

        private static string folder;

        internal static void ReadData(string folderName)
        {
            folder = folderName;
            ReadCountyData(folderName);
            ReadRegionData(folderName);
            ReadItalyRegions();
            ReadItalyCounties();
        }

        internal static IOrderedEnumerable<RegionData> ReadRegionData(int region)
        {
            return DataReader.RegionDatas
                 .Where(r => r.codice_regione == region)
                 .OrderBy(d => d.data);
        }

        internal static IOrderedEnumerable<ItalyRegion> ReadRegions()
        {
            return italyRegions
                .OrderBy(o => o.denominazione_regione);

                //.Select(r => new  ComboData() { value = r.codice_regione, display =r.denominazione_regione }).ToArray();
        }

        internal static void RefreshDatas()
        {
            ReadCountyData(folder);
            ReadRegionData(folder);
        }

        private static void ReadCountyData(string folderName)

        {
            string fileName = Path.Combine(folderName, "dati-json\\dpc-covid19-ita-province.json");
            CountyDatas = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CountyData>>(File.ReadAllText(fileName));
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

        private static void ReadItalyCounties()
        {
            italyCounties = CountyDatas
                .OrderBy(d => d.codice_provincia)
                .Distinct(new CountyCompare())
                .Aggregate<CountyData, List<ItalyCounty>>(
                    new List<ItalyCounty>(), (reg, d) =>
                    {
                        reg.Add(new ItalyCounty() 
                        { 
                            codice_regione = d.codice_regione, 
                            denominazione_regione = d.denominazione_regione,
                            codice_provincia = d.codice_provincia,
                            denominazione_provincia = d.denominazione_provincia,
                            sigla_provincia =d.sigla_provincia
                        });
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

    public class CountyCompare : IEqualityComparer<CountyData>
    {
        public bool Equals(CountyData x, CountyData y)
        {
            //Check whether the compared objects reference the same data.
            if (Object.ReferenceEquals(x, y)) return true;

            //Check whether any of the compared objects is null.
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;

            //Check whether the products' properties are equal.
            return x.denominazione_provincia == y.denominazione_provincia && x.codice_provincia == y.codice_provincia;
        }

        public int GetHashCode(CountyData obj)
        {
            //Check whether the object is null
            if (Object.ReferenceEquals(obj, null)) return 0;

            //Get hash code for the Name field if it is not null.
            return obj.denominazione_provincia.GetHashCode() ^ obj.codice_provincia.GetHashCode();
        }
    }
}