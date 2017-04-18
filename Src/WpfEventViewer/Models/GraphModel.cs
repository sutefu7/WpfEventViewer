using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Livet;

using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;
using System.Collections.ObjectModel;

namespace WpfEventViewer.Models
{
    public class GraphModel : NotificationObject
    {

        #region PlotData変更通知プロパティ
        private PlotModel _PlotData;

        public PlotModel PlotData
        {
            get
            { return _PlotData; }
            set
            { 
                if (_PlotData == value)
                    return;
                _PlotData = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        public GraphModel()
        {
            this.PlotData = new PlotModel();
        }

        public void UpdatePlotData(ReadOnlyObservableCollection<DateObject> calendarItems)
        {
            //// 折れ線グラフ

            //var item = new PlotModel { Title = "通知の推移" };
            //var infoSeries = new LineSeries { Title = "情報", MarkerType = MarkerType.Circle };
            //var warnSeries = new LineSeries { Title = "警告", MarkerType = MarkerType.Square };
            //var errorSeries = new LineSeries { Title = "エラー", MarkerType = MarkerType.Triangle };

            //// 縦軸、ログ件数
            //// 横軸、日付（１日～３１日、または３０、２８日など）
            //foreach(var calendarItem in calendarItems)
            //{
            //    infoSeries.Points.Add(new DataPoint(calendarItem.Date.Day, calendarItem.InformationCount));
            //    warnSeries.Points.Add(new DataPoint(calendarItem.Date.Day, calendarItem.WarningCount));
            //    errorSeries.Points.Add(new DataPoint(calendarItem.Date.Day, calendarItem.ErrorCount));

            //}

            //item.Series.Add(infoSeries);
            //item.Series.Add(warnSeries);
            //item.Series.Add(errorSeries);
            //this.PlotData = item;




            // グループ化した棒グラフ
            var items = new Collection<DayItem>();
            foreach(var calendarItem in calendarItems)
            {
                // 先月、来月分は除く
                if (!calendarItem.ThisMonthMember)
                    continue;

                items.Add(new DayItem
                {
                    Label = $"{calendarItem.Date.Day.ToString()}({calendarItem.Date.ToString("ddd")})",
                    InfoCount = calendarItem.InformationCount,
                    WarnCount = calendarItem.WarningCount,
                    ErrorCount = calendarItem.ErrorCount,
                });
                
            }

            var item = new PlotModel
            {
                Title = "通知の推移",
                LegendPlacement = LegendPlacement.Outside,
                LegendPosition = LegendPosition.RightTop,
                LegendOrientation = LegendOrientation.Vertical,
            };

            item.Axes.Add(new CategoryAxis { ItemsSource = items, LabelField = "Label" });
            item.Axes.Add(new LinearAxis { Position = AxisPosition.Left, MinimumPadding = 0, AbsoluteMinimum = 0 });

            item.Series.Add(new ColumnSeries { Title = "情報", ItemsSource = items, ValueField = "InfoCount" });
            item.Series.Add(new ColumnSeries { Title = "警告", ItemsSource = items, ValueField = "WarnCount" });
            item.Series.Add(new ColumnSeries { Title = "エラー", ItemsSource = items, ValueField = "ErrorCount" });

            this.PlotData = item;
            
        }

        private class DayItem
        {
            public string Label { get; set; }
            public int InfoCount { get; set; }
            public int WarnCount { get; set; }
            public int ErrorCount { get; set; }
        }

    }
}
