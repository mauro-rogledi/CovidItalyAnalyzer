using CovidItalyAnalyzer.ModelData;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidItalyAnalyzer.Library
{

    public static class DataReaderCounty
    {
        private static List<CountyData> CountyDatas;
        private static List<ItalyCounty> italyCounties;
        private static string folder;

        internal static void ReadData(string folderName)
        {
            folder = folderName;
            ReadCountyData(folderName);
        }

        private static void ReadCountyData(string folderName)

        {
            string fileName = Path.Combine(folderName, "dati-json\\dpc-covid19-ita-province.json");
            if (!File.Exists(fileName))
                return;
            var allData = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CountyData>>(File.ReadAllText(fileName));
            ReadItalyCounties(allData);

            CountyDatas = new List<CountyData>();

            foreach (var county in italyCounties)
            {
                var data = allData
                    .Where(r => r.codice_regione == county.codice_regione && r.codice_provincia == county.codice_provincia)
                    .OrderBy(o => o.data)
                    .ToList();

                CountyDatas.AddRange(
                    data.Select((curr, i) =>
                    {
                        curr.nuovi_positivi = i > 0 ? curr.totale_casi - data[i - 1].totale_casi : curr.totale_casi;
                        return curr;
                    })
                );
            }
        }

        internal static IOrderedEnumerable<CountyData> ReadCountyData(int region, int county)
        {
            return DataReaderCounty.CountyDatas
             .Where(r => r.codice_regione == region && r.codice_provincia == county)
             .OrderBy(d => d.data);
        }


        internal static IOrderedEnumerable<ItalyCounty> ReadCounties(int region)
        {
            return italyCounties
                .Where(r => r.codice_regione == region && r.sigla_provincia != null)
                .OrderBy(o => o.denominazione_provincia);

            //.Select(r => new  ComboData() { value = r.codice_regione, display =r.denominazione_regione }).ToArray();
        }

        internal static IOrderedEnumerable<ItalyCounty> ReadAllCounties()
        {
            return italyCounties
                .Where(r => r.sigla_provincia != null)
                .OrderBy(o => o.denominazione_provincia);

            //.Select(r => new  ComboData() { value = r.codice_regione, display =r.denominazione_regione }).ToArray();
        }

        private static void ReadItalyCounties(List<CountyData> allData)
        {
            italyCounties = allData?
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
                            sigla_provincia = d.sigla_provincia
                        });
                        return reg;
                    });
        }
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