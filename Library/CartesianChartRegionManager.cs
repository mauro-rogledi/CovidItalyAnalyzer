using LiveCharts;
using LiveCharts.Wpf;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace CovidItalyAnalyzer.Library
{
    public class CartesianChartRegionManager
    {
        private CultureInfo myCI;
        private Calendar myCal;
        private CalendarWeekRule myCWR;
        private DayOfWeek myFirstDOW;
        private CartesianChart chart;

        private readonly Dictionary<string, Action<int, string>> ChartAvailable = new Dictionary<string, Action<int, string>>();

        public CartesianChartRegionManager(CartesianChart chart)
        {
            this.chart = chart;
            myCI = CultureInfo.CurrentCulture;
            myCal = myCI.Calendar;
            myCWR = myCI.DateTimeFormat.CalendarWeekRule;
            myFirstDOW = myCI.DateTimeFormat.FirstDayOfWeek;

            ChartAvailable.Add(Properties.Resources.DailyCases, (int r, string s) => FillChartWithDailyCases(r, s));
            ChartAvailable.Add(Properties.Resources.WeeklyCases, (int r, string s) => FillChartWithWeeklyCases(r, s));
            ChartAvailable.Add(Properties.Resources.WeeklySwabs, (int r, string s) => FillChartWithWeeklySwab(r, s));
            ChartAvailable.Add(Properties.Resources.WeeklyCasesSwabs, (int r, string s) => FillChartWithWeeklySwabCases(r, s));
            ChartAvailable.Add(Properties.Resources.TotalCases, (int r, string s) => FillChartWitTotalCases(r, s));
        }

        public string[] GetChartAvailable()
        {
            return ChartAvailable
                .Aggregate(new List<string>(), (acc, x) => { acc.Add(x.Key); return acc; })
                .ToArray();
        }

        internal void SetChart(string chart, int value, string display)
        {
            ChartAvailable[chart].Invoke(value, display);
        }

        public void FillChartWitTotalCases(int region, string regionName)
        {
            var data = DataExtractorRegion.FillTotalyCases(region);

            this.chart.Series.Clear();
            this.chart.AxisX.Clear();
            this.chart.AxisY.Clear();

            this.chart.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = $"Totale infetti giornaliero {regionName}",
                    Values = new ChartValues<int>(data.Select(s => (int)s.value)),
                    PointGeometry = DefaultGeometries.None,
                    DataLabels = false,
                    LabelPoint = point => point.Y.ToString("N0")
                }
            };

            this.chart.AxisX.Add(new Axis
            {
                Labels = data.Select(s => s.lbl).ToList(),
                LabelsRotation = 15,
                Separator = new Separator
                {
                    Step = 7,
                    IsEnabled = false //disable it to make it invisible.
                }
            });

            this.chart.AxisY.Add(new Axis
            {
                Title = "Infetti",
                LabelFormatter = value => value.ToString("N0")
            });

            this.chart.LegendLocation = LegendLocation.Top;
        }

        public void FillChartWithDailyCases(int region, string regionName)
        {
            var data = DataExtractorRegion.FillDailyCases(region);

            this.chart.Series.Clear();
            this.chart.AxisX.Clear();
            this.chart.AxisY.Clear();

            this.chart.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = $"{Properties.Resources.DailyCases} {regionName}",
                    Values = new ChartValues<int>(data.Select(s => (int)s.value)),
                    PointGeometry = DefaultGeometries.None,
                    DataLabels = true,
                    LabelPoint = point => point.Y.ToString("N0")
                }
            };

            this.chart.AxisX.Add(new Axis
            {
                Labels = data.Select(s => s.lbl).ToList(),
                LabelsRotation = 15,
                Separator = new Separator
                {
                    Step = 1,
                    IsEnabled = false //disable it to make it invisible.
                }
            });

            this.chart.AxisY.Add(new Axis
            {
                Title = "Infetti",
                LabelFormatter = value => value.ToString("N0")
            });

            this.chart.LegendLocation = LegendLocation.Top;
        }

        public void FillChartWithWeeklyCases(int region, string regionName)
        {
            var data = DataExtractorRegion.FillWeeklyCases(region);

            this.chart.Series.Clear();
            this.chart.AxisX.Clear();
            this.chart.AxisY.Clear();

            this.chart.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = $"{Properties.Resources.WeeklyCases} {regionName}",
                    Values = new ChartValues<int>(data.Select(s => (int)s.value)),
                    PointGeometry = DefaultGeometries.None,
                    DataLabels = true,
                    LabelPoint = point => point.Y.ToString("N0")
                }
            };

            this.chart.AxisX.Add(new Axis
            {
                Labels = data.Select(s => s.lbl).ToList(),
                LabelsRotation = 15,
                Separator = new Separator
                {
                    Step = 1,
                    IsEnabled = false //disable it to make it invisible.
                }
            });

            this.chart.AxisY.Add(new Axis
            {
                Title = "Infetti",
                LabelFormatter = value => value.ToString("N0")
            });

            this.chart.LegendLocation = LegendLocation.Top;
        }

        public void FillChartWithWeeklySwab(int region, string regionName)
        {
            var data = DataExtractorRegion.FillWeeklySwab(region);

            this.chart.Series.Clear();
            this.chart.AxisX.Clear();
            this.chart.AxisY.Clear();

            this.chart.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = $"{Properties.Resources.WeeklySwabs} {regionName}",
                    Values = new ChartValues<int>(data.Select(s => (int)s.value)),
                    PointGeometry = DefaultGeometries.None,
                    DataLabels = true,
                    LabelPoint = point => point.Y.ToString("N0")
                }
            };

            this.chart.AxisX.Add(new Axis
            {
                Labels = data.Select(s => s.lbl).ToList(),
                LabelsRotation = 15,
                Separator = new Separator
                {
                    Step = 1,
                    IsEnabled = false //disable it to make it invisible.
                }
            });

            this.chart.AxisY.Add(new Axis
            {
                Title = "Tamponi",
                LabelFormatter = value => value.ToString("N0")
            });

            this.chart.LegendLocation = LegendLocation.Top;
        }

        public void FillChartWithWeeklySwabCases(int region, string regionName)
        {
            var swab = DataExtractorRegion.FillWeeklySwabCases(region);
            var cases = DataExtractorRegion.FillWeeklyCases(region);

            this.chart.Series.Clear();
            this.chart.AxisX.Clear();
            this.chart.AxisY.Clear();

            this.chart.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = $"{Properties.Resources.WeeklyCases} {regionName}",
                    Values = new ChartValues<int>(cases.Select(s => (int)s.value)),
                    PointGeometry = DefaultGeometries.None,
                    DataLabels = true,
                    LabelPoint = point => point.Y.ToString("N0"),
                    ScalesYAt = 0
                },
                new LineSeries
                {
                    Title = Properties.Resources.RelationshipCasesSwabs,
                    Values = new ChartValues<float>(swab.Select(s => s.value)),
                    PointGeometry = DefaultGeometries.None,
                    DataLabels = true,
                    ScalesYAt = 1
                }
            };

            this.chart.AxisX.Add(new Axis
            {
                Labels = swab.Select(s => s.lbl).ToList(),
                LabelsRotation = 15,
                Separator = new Separator
                {
                    Step = 1,
                    IsEnabled = false //disable it to make it invisible.
                }
            });

            this.chart.AxisY.Add(new Axis
            {
                Title = "Nuovi Infetti",
                LabelFormatter = value => value.ToString("N0")
            });

            this.chart.AxisY.Add(new Axis
            {
                Title = "Rapporto Infetti/Tamponi",
                LabelFormatter = value => value.ToString("P"),
                Position = AxisPosition.RightTop
            });

            this.chart.LegendLocation = LegendLocation.Top;
        }
    }
}