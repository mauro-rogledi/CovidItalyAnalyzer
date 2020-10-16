using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidItalyAnalyzer.Library
{
    public class ReturnData
    {
        public DateTime data { get; set; }
        public string lbl { get; set; }
        public float value { get; set; }
    }

    public class DataExtractorRegion
    {
        static CultureInfo myCI = CultureInfo.CurrentCulture;
        static Calendar myCal = myCI.Calendar;
        static CalendarWeekRule myCWR = myCI.DateTimeFormat.CalendarWeekRule;
        static DayOfWeek myFirstDOW = myCI.DateTimeFormat.FirstDayOfWeek;

        public static List<ReturnData> FillDailyCases(int region)
        {
            var list = DataReaderRegion.ReadRegionData(region)
                .ToList();

            return list
                .Select((curr, i) => new ReturnData()
                {
                    data = curr.data,
                    value = i > 0 ? curr.totale_casi - list[i - 1].totale_casi : curr.totale_casi
                }
                )
                .ToList();
        }

        public static List<ReturnData> FillDailySwab(int region)
        {
            var list = DataReaderRegion.ReadRegionData(region)
                .ToList();

            return list
                .Select((curr, i) => new ReturnData()
                {
                    data = curr.data,
                    value = i > 0 ? curr.tamponi - list[i - 1].tamponi : curr.tamponi
                }
                )
                .ToList();
        }

        internal static List<ReturnData> FillTotalRegionCasesAtDate(DateTime date, int top)
        {
            return DataReaderRegion
                .ReadRegionsAtDate(date)
                .Select((curr) => new ReturnData()
                {
                    data = curr.data,
                    value = curr.totale_positivi,
                    lbl = curr.denominazione_regione
                })
                .OrderByDescending(v => v.value)
                .Take(top)
                .ToList();
        }

        internal static List<ReturnData> FillNewRegionCasesAtDate(DateTime dateFrom, DateTime dateTo, int top)
        {
            return dateFrom == dateTo
                ? DataReaderRegion
                    .ReadRegionsAtDate(dateFrom)
                    .Select((curr) => new ReturnData()
                    {
                        data = curr.data,
                        value = curr.nuovi_positivi,
                        lbl = curr.denominazione_regione
                    })
                    .OrderByDescending(v => v.value)
                    .Take(top)
                    .ToList()
                : DataReaderRegion
                    .ReadRegionsAtRangeDate(dateFrom, dateTo)
                    .GroupBy(g => g.codice_regione)
                    .Select((curr) => new ReturnData()
                    {
                        data = curr.Max(r => r.data),
                        value = curr.Sum(r => r.nuovi_positivi),
                        lbl = curr.Max(r => r.denominazione_regione)
                    })
                    .OrderByDescending(v => v.value)
                    .Take(top)
                    .ToList();
        }

        internal static List<ReturnData> FillNewRegionCasesPercAtDate(DateTime date, int top)
        {
            return DataReaderRegion
                .ReadRegionsAtDate(date)
                .Select((curr) => new ReturnData()
                {
                    data = curr.data,
                    value = (float)curr.nuovi_positivi * 1000000 / (float)DataReaderPeopleRegions.ReadPeopleByRegion(curr.codice_regione),
                    lbl = curr.denominazione_regione
                })
                .OrderByDescending(v => v.value)
                .Take(top)
                .ToList();
        }

        public static List<ReturnData> FillWeeklyCases(int region)
        {
            return FillDailyCases(region)
                .GroupBy(g => myCal.GetWeekOfYear(g.data, myCWR, myFirstDOW))
                .Select((s) => new ReturnData
                {
                    data = s.Max(f => f.data),
                    lbl = s.Max(f => f.data).ToString("dd/MM/yy"),
                    value = s.Sum(c => c.value)
                }
                )
                .ToList();
        }



        public static List<ReturnData> FillWeeklySwab(int region)
        {
            return FillDailySwab(region)
                .GroupBy(g => myCal.GetWeekOfYear(g.data, myCWR, myFirstDOW))
                .Select((s) => new ReturnData
                {
                    data = s.Max(f => f.data),
                    lbl = s.Max(f => f.data).ToString("dd/MM/yy"),
                    value = s.Sum(c => c.value)
                }
                )
                .ToList();
        }

        public static List<ReturnData> FillWeeklySwabCases(int region)
        {
            var cases = FillWeeklyCases(region);
            var swab = FillWeeklySwab(region);

            return cases.Zip(swab, (c, s) => new ReturnData()
            {
                lbl = c.lbl,
                data = c.data,
                value = c.value / s.value
            })
            .ToList();
        }
        internal static List<ReturnData> FillTotalyCases(int region)
        {
            return DataReaderRegion.ReadRegionData(region)
                .OrderBy(d => d.data)
                .Select((s) => new ReturnData
                {
                    data = s.data,
                    lbl = s.data.ToString("dd/MM/yy"),
                    value = s.totale_casi
                }
                )
                .ToList();
        }

    }
}
