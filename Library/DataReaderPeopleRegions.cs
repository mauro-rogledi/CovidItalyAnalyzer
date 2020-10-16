using CovidItalyAnalyzer.ModelData;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidItalyAnalyzer.Library
{
    public static class DataReaderPeopleRegions
    {
        private static List<PeopleRegionData> PeopleData;

        public static int ReadPeopleByRegion(int region)
        {
            if (PeopleData == null)
                PeopleData = ReadDataFromJson();

            return PeopleData
                .Find(p => p.codice_regione == region)
                .popolazione;
        }

        private static List<PeopleRegionData> ReadDataFromJson()
        {
            var asciiString = Encoding.ASCII.GetString(Properties.Resources.PopolazioneRegioni, 0, Properties.Resources.PopolazioneRegioni.Length);
            return JsonConvert.DeserializeObject<List<PeopleRegionData>>(asciiString);
        }
    }
}
