using LiveCharts;
using LiveCharts.Wpf;

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

    public class ChartManager
    {
        private CultureInfo myCI;
        private Calendar myCal;
        private CalendarWeekRule myCWR;
        private DayOfWeek myFirstDOW;
        private CartesianChart chart;

        public ChartManager(CartesianChart chart)
        {
            this.chart = chart;
            myCI = CultureInfo.CurrentCulture;
            myCal = myCI.Calendar;
            myCWR = myCI.DateTimeFormat.CalendarWeekRule;
            myFirstDOW = myCI.DateTimeFormat.FirstDayOfWeek;
        }

        public void FillChartWithWeeklyCasesByRegion(int region, string regionName)
        {
            var data = FillWeeklyCasesByRegion(region);

            chart.Series.Clear();
            chart.AxisX.Clear();
            chart.AxisY.Clear();

            chart.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = $"Consuntivo settimanale {regionName}",
                    Values = new ChartValues<int>(data.Select(s => (int)s.value)),
                    PointGeometry = DefaultGeometries.None,
                    DataLabels = true,
                    LabelPoint = point => point.Y.ToString("N0")
                }
            };

            chart.AxisX.Add(new Axis
            {
                Labels = data.Select(s => s.lbl).ToList(),
                LabelsRotation = 15,
                Separator = new Separator
                {
                    Step = 1,
                    IsEnabled = false //disable it to make it invisible.
                }
            });

            chart.AxisY.Add(new Axis
            {
                Title = "Infetti",
                LabelFormatter = value => value.ToString("N0")
            });

            chart.LegendLocation = LegendLocation.Top;
        }

        public void FillChartWithWeeklySwabByRegion(int region, string regionName)
        {
            var data = FillWeeklySwabByRegion(region);

            chart.Series.Clear();
            chart.AxisX.Clear();
            chart.AxisY.Clear();

            chart.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = $"Consuntivo settimanale {regionName}",
                    Values = new ChartValues<int>(data.Select(s => (int)s.value)),
                    PointGeometry = DefaultGeometries.None,
                    DataLabels = true,
                    LabelPoint = point => point.Y.ToString("N0")
                }
            };

            chart.AxisX.Add(new Axis
            {
                Labels = data.Select(s => s.lbl).ToList(),
                LabelsRotation = 15,
                Separator = new Separator
                {
                    Step = 1,
                    IsEnabled = false //disable it to make it invisible.
                }
            });

            chart.AxisY.Add(new Axis
            {
                Title = "Tamponi",
                LabelFormatter = value => value.ToString("N0")
            });

            chart.LegendLocation = LegendLocation.Top;
        }

        public void FillChartWithWeeklySwabCasesByRegion(int region, string regionName)
        {
            var swab = FillWeeklySwabCasesByRegion(region);
            var cases = FillWeeklyCasesByRegion(region);

            chart.Series.Clear();
            chart.AxisX.Clear();
            chart.AxisY.Clear();

            chart.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = $"Nuovi infetti {regionName}",
                    Values = new ChartValues<int>(cases.Select(s => (int)s.value)),
                    PointGeometry = DefaultGeometries.None,
                    DataLabels = true,
                    LabelPoint = point => point.Y.ToString("N0"),
                    ScalesYAt = 0
                },
                new LineSeries
                {
                    Title = "Rapporto Infetti/Tamponi",
                    Values = new ChartValues<float>(swab.Select(s => s.value)),
                    PointGeometry = DefaultGeometries.None,
                    DataLabels = true,
                    ScalesYAt = 1
                }
            };

            chart.AxisX.Add(new Axis
            {
                Labels = swab.Select(s => s.lbl).ToList(),
                LabelsRotation = 15,
                Separator = new Separator
                {
                    Step = 1,
                    IsEnabled = false //disable it to make it invisible.
                }
            });

            chart.AxisY.Add(new Axis
            {
                Title = "Nuovi Infetti",
                LabelFormatter = value => value.ToString("N0")
            });

            chart.AxisY.Add(new Axis
            {
                Title = "Rapporto Infetti/Tamponi",
                LabelFormatter = value => value.ToString("0.00"),
                Position = AxisPosition.RightTop
            });

            chart.LegendLocation = LegendLocation.Top;
        }

        private List<ReturnData> FillWeeklyCasesByRegion(int region)
        {
            var list = DataReader.ReadRegionData(region)
                .ToList();

            return list
                .Select((curr, i) => new ReturnData()
                {
                    data = curr.data,
                    value = i > 0 ? curr.totale_casi - list[i - 1].totale_casi : curr.totale_casi
                }
                )
                .GroupBy(g => myCal.GetWeekOfYear(g.data, myCWR, myFirstDOW))
                .Select((s) => new ReturnData
                {
                    lbl = s.Max(f => f.data).ToString("dd/MM/yy"),
                    value = s.Sum(c => c.value)
                }
                )
                .ToList();
        }

        private List<ReturnData> FillWeeklySwabByRegion(int region)
        {
            var list = DataReader.ReadRegionData(region)
                .ToList();

            return list
                .Select((curr, i) => new ReturnData()
                {
                    data = curr.data,
                    value = i > 0 ? curr.tamponi - list[i - 1].tamponi : curr.tamponi
                }
                )
                .GroupBy(g => myCal.GetWeekOfYear(g.data, myCWR, myFirstDOW))
                .Select((s) => new ReturnData
                {
                    lbl = s.Max(f => f.data).ToString("dd/MM/yy"),
                    value = s.Sum(c => c.value)
                }
                )
                .ToList();
        }

        private List<ReturnData> FillWeeklySwabCasesByRegion(int region)
        {
            var cases = FillWeeklyCasesByRegion(region);
            var swab = FillWeeklySwabByRegion(region);

            return cases.Zip(swab, (c, s) => new ReturnData()
            {
                data = c.data,
                value = c.value * 100 / s.value
            })
            .ToList();
        }
    }
}