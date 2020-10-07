﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidItalyAnalyzer.ModelData
{
    public class CountyData
    {
        public string data { get; set; }
        public string stato { get; set; }
        public int codice_regione { get; set; }
        public string denominazione_regione { get; set; }
        public int codice_provincia { get; set; }
        public string denominazione_provincia { get; set; }
        public string sigla_provincia { get; set; }
        public string totale_casi  { get; set; }
    }
}