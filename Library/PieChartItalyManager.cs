using CovidItalyAnalyzer.ModelData;

using LiveCharts;
using LiveCharts.Wpf;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidItalyAnalyzer.Library
{
    public class PieChartItalyManager
    {
        private CultureInfo myCI;
        private Calendar myCal;
        private CalendarWeekRule myCWR;
        private DayOfWeek myFirstDOW;
        private PieChart chart;

        public Func<DateTime> FromDate { get; set; }
        public Func<DateTime> ToDate { get; set; }
        public Func<ComboData> Top { get; set; }

        private readonly Dictionary<string, Action> ChartAvailable = new Dictionary<string, Action>();

        public string Title { get; private set; }

        public PieChartItalyManager(PieChart chart)
        {
            this.chart = chart;
            myCI = CultureInfo.CurrentCulture;
            myCal = myCI.Calendar;
            myCWR = myCI.DateTimeFormat.CalendarWeekRule;
            myFirstDOW = myCI.DateTimeFormat.FirstDayOfWeek;

            ChartAvailable.Add(Properties.Resources.NewCasesInRange, () => FillChart(Properties.Resources.NewCasesInRange, p => p.nuovi_positivi));
            ChartAvailable.Add(Properties.Resources.CasePerinhabitants, () => FillChartInhabitants(Properties.Resources.CasePerinhabitants, p => p.nuovi_positivi));
            ChartAvailable.Add(Properties.Resources.DeadsInRange, () => FillChart(Properties.Resources.DeadsInRange, p => p.nuovi_deceduti));
            ChartAvailable.Add(Properties.Resources.DeadsPerinhabitants, () => FillChartInhabitants(Properties.Resources.DeadsPerinhabitants, p => p.nuovi_deceduti));
            ChartAvailable.Add(Properties.Resources.SwabsInRange, () => FillChart(Properties.Resources.SwabsInRange, p => p.nuovi_tamponi));
            ChartAvailable.Add(Properties.Resources.SwabsPerinhabitants, () => FillChartInhabitants(Properties.Resources.SwabsPerinhabitants, p => p.nuovi_tamponi));
        }

        public string[] GetChartAvailable()
        {
            return ChartAvailable.Aggregate(new List<string>(), (acc, x) => { acc.Add(x.Key); return acc; })
                .ToArray();
        }

        internal void SetChart(string chart)
        {
            if (ChartAvailable.ContainsKey(chart))
                ChartAvailable[chart]?.Invoke();
        }

        void FillChart(string title, Func<ModelData.RegionData, float> dataToExtract)
        {
            var dateFrom = FromDate?.Invoke() ?? DateTime.Today;
            var dateTo = ToDate?.Invoke() ?? DateTime.Today;
            var top = Top?.Invoke()?.value ?? 5;
            var data = DataExtractorRegion.FillRangeData(dateFrom, dateTo, top, dataToExtract);

            Title = dateFrom.Date == dateTo.Date
                    ? $"{title} {dateFrom.Date.ToShortDateString()}"
                    : $"{title} {Properties.Resources.BetweenDate} {dateFrom.Date.ToString("dd/MM/yy")} {{Properties.Resources.And}} {dateTo.Date.ToString("dd/MM/yy")}";

            Func<ChartPoint, string> labelPoint = chartPoint =>
                string.Format("{0}", chartPoint.Y.ToString("N0"));

            var series = new SeriesCollection();

            foreach (var region in data)
                series.Add(
                    new PieSeries()
                    {
                        Title = region.lbl,
                        Values = new ChartValues<float> { region.value },
                        DataLabels = true,
                        LabelPoint = labelPoint
                    });

            this.chart.Series = series;
            this.chart.LegendLocation = LegendLocation.Right;
        }

        private void FillChartInhabitants(string title, Func<ModelData.RegionData, float> dataToExtract)
        {
            var dateFrom = FromDate?.Invoke() ?? DateTime.Today;
            var dateTo = ToDate?.Invoke() ?? DateTime.Today;
            var top = Top?.Invoke()?.value ?? 5;
            var data = DataExtractorRegion.FillRangeDataInhabitants(dateFrom, dateTo, top, dataToExtract);

            Title = dateFrom.Date == dateTo.Date
                    ? $"{title} {dateFrom.Date.ToShortDateString()}"
                    : $"{title} {Properties.Resources.BetweenDate} {dateFrom.Date.ToString("dd/MM/yy")} {Properties.Resources.And} {dateTo.Date.ToString("dd/MM/yy")}";

            Func<ChartPoint, string> labelPoint = chartPoint =>
                string.Format("{0}", chartPoint.Y.ToString("#,##0.##"));

            var series = new SeriesCollection();

            foreach (var region in data)
                series.Add(
                    new PieSeries()
                    {
                        Title = region.lbl,
                        Values = new ChartValues<float> { region.value },
                        DataLabels = true,
                        LabelPoint = labelPoint
                    });

            this.chart.Series = series;
            this.chart.LegendLocation = LegendLocation.Right;
        }
    }
}
