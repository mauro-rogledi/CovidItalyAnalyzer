using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidItalyAnalyzer.ModelData
{
    public class RegionData
    {
        public DateTime data { get; set; }
        public string stato { get; set; }
        public int codice_regione { get; set; }
        public string denominazione_regione { get; set; }
        public int ricoverati_con_sintomi { get; set; }
        public int terapia_intensiva { get; set; }
        public int totale_ospedalizzati { get; set; }
        public int isolamento_domiciliare { get; set; }
        public int totale_positivi { get; set; }
        public int variazione_totale_positivi { get; set; }
        public int nuovi_positivi { get; set; }
        public int dimessi_guariti { get; set; }
        public int deceduti { get; set; }
        public int? casi_da_sospetto_diagnostico { get; set; }
        public int? casi_da_screening { get; set; }
        public int totale_casi { get; set; }
        public int tamponi { get; set; }
        public int? casi_testati { get; set; }
        public int casi_giornalieri { get; set; }
    }
}
