using LiveCharts;
using LiveCharts.Wpf;

using System;
using System.Collections.Generic;
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

            ChartAvailable.Add(Properties.Resources.TotalCaseAtDate, () => FillChartWithTotalRegionCasesAtDate());
            ChartAvailable.Add(Properties.Resources.NewCasesAtRangeDate, () => FillChartWithRegionNewCasesAtDate());
            ChartAvailable.Add("Cases per inhabitants", () => FillChartWithRegionNewPercCasesAtDate());
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

        internal string GetTitle(string text)
        {
            throw new NotImplementedException();
        }

        void FillChartWithTotalRegionCasesAtDate()
        {
            var date = FromDate?.Invoke() ?? DateTime.Today;
            var top = Top?.Invoke()?.value ?? 5;
            var data = DataExtractorRegion.FillTotalRegionCasesAtDate(date, top);

            var series = new SeriesCollection();

            var rand = new Random();

            foreach (var region in data)
                series.Add(
                    new PieSeries()
                    {
                        Title = region.lbl,
                        Values = new ChartValues<float> { region.value }
                    });

            this.chart.Series = series;
            this.chart.LegendLocation = LegendLocation.Right;
        }

        void FillChartWithRegionNewCasesAtDate()
        {
            var dateFrom = FromDate?.Invoke() ?? DateTime.Today;
            var dateTo = ToDate?.Invoke() ?? DateTime.Today;
            var top = Top?.Invoke()?.value ?? 5;
            var data = DataExtractorRegion.FillNewRegionCasesAtDate(dateFrom, dateTo, top);
            Title = dateFrom.Date == dateTo.Date
                ? $"New Cases at date {dateFrom.Date.ToShortDateString()}"
                : $"New Cases between date {dateFrom.Date.ToString("dd/MM/yy")} and {dateTo.Date.ToString("dd/MM/yy")}";

            Func<ChartPoint, string> labelPoint = chartPoint =>
                string.Format("{0}", chartPoint.Y.ToString("0"));

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

        void FillChartWithRegionNewPercCasesAtDate()
        {
            Title = "Cases per million inhabitants";

            var date = FromDate?.Invoke() ?? DateTime.Today;
            var top = Top?.Invoke()?.value ?? 5;
            var data = DataExtractorRegion.FillNewRegionCasesPercAtDate(date, top);


            Func<ChartPoint, string> labelPoint = chartPoint =>
                string.Format("{0}", chartPoint.Y.ToString("0.00"));

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
