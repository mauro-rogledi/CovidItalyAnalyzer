using CovidItalyAnalyzer.ModelData;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

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
        private static CultureInfo myCI = CultureInfo.CurrentCulture;
        private static Calendar myCal = myCI.Calendar;
        private static CalendarWeekRule myCWR = myCI.DateTimeFormat.CalendarWeekRule;
        private static DayOfWeek myFirstDOW = myCI.DateTimeFormat.FirstDayOfWeek;

        public static List<ReturnData> FillDailySwabs(int region)
        {
            return FillRegionDifferentsWithFunction(region, f => f.tamponi);
        }

        public static List<ReturnData> FillDailyCases(int region)
        {
            return FillRegionWithFunction(region, p => p.nuovi_positivi);
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

        internal static List<ReturnData> FillRangeData(DateTime dateFrom, DateTime dateTo, int top, Func<RegionData, float> func)
        {
            return dateFrom.Date == dateTo.Date
                ? DataReaderRegion
                    .ReadRegionsAtDate(dateFrom)
                    .Select((curr) => new ReturnData()
                    {
                        data = curr.data,
                        value = func.Invoke(curr),
                        lbl = curr.denominazione_regione
                    })
                    .OrderByDescending(v => v.value)
                    .Take(top)
                    .ToList()
                : DataReaderRegion
                    .ReadRegionsAtRangeDate(dateFrom, dateTo)
                    .Select((curr) => new ReturnData()
                    {
                        data = curr.Max(r => r.data),
                        value = curr.Sum(r => func.Invoke(r)),
                        lbl = curr.Max(r => r.denominazione_regione)
                    })
                    .OrderByDescending(v => v.value)
                    .Take(top)
                    .ToList();
        }

        internal static List<ReturnData> FillRangeDataInhabitants(DateTime dateFrom, DateTime dateTo, int top, Func<ModelData.RegionData, float> func)
        {
            return dateFrom.Date == dateTo.Date
                ? DataReaderRegion
                    .ReadRegionsAtDate(dateFrom)
                    .Select((curr) => new ReturnData()
                    {
                        data = curr.data,
                        value = func.Invoke(curr) * 100000 / DataReaderPeople.ReadPeopleByRegion(curr.codice_regione),
                        lbl = curr.denominazione_regione
                    })
                    .OrderByDescending(v => v.value)
                    .Take(top)
                    .ToList()
                : DataReaderRegion
                    .ReadRegionsAtRangeDate(dateFrom, dateTo)
                    .Select((curr) => new ReturnData()
                    {
                        data = curr.Max(r => r.data),
                        value = curr.Sum(r => func.Invoke(r) * 100000 / DataReaderPeople.ReadPeopleByRegion(curr.First().codice_regione)),
                        lbl = curr.Max(r => r.denominazione_regione)
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
            return FillDailySwabs(region)
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

        public static List<ReturnData> FillDailySwabCases(int region)
        {
            var cases = FillDailyCases(region);
            var swab = FillDailySwabs(region);

            return cases.Zip(swab, (c, s) => new ReturnData()
            {
                lbl = c.lbl,
                data = c.data,
                value = s.value != 0 ? c.value / s.value : 0F
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

        private static List<ReturnData> FillRegionDifferentsWithFunction(int region, Func<RegionData, float> func)
        {
            List<RegionData> list = DataReaderRegion.ReadRegionData(region)
                .ToList();

            return list
                .Select((curr, i) => new ReturnData()
                {
                    data = curr.data,
                    value = i > 1 ? (func?.Invoke(curr) ?? 0F) - (func?.Invoke(list[i - 1]) ?? 0F) : func?.Invoke(curr) ?? 0F,
                    lbl = curr.data.ToString("dd/MM/yy")
                }
                )
                .ToList();
        }

        private static List<ReturnData> FillRegionWithFunction(int region, Func<RegionData, float> func)
        {
            return DataReaderRegion.ReadRegionData(region)
                .Select((curr, i) => new ReturnData()
                {
                    data = curr.data,
                    value = func?.Invoke(curr) ?? 0F,
                    lbl = curr.data.ToString("dd/MM/yy")
                }
                )
                .ToList();
        }
    }
}