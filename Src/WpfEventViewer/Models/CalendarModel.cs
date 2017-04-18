using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Livet;
using System.Windows;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace WpfEventViewer.Models
{
    public class CalendarModel : NotificationObject
    {
        // MainModel と通信用
        public MainModel ViewData { get; set; } = null;

        // 日表示モードで使用するプロパティ

        #region DayVisible変更通知プロパティ
        private bool _DayVisible;

        public bool DayVisible
        {
            get
            { return _DayVisible; }
            set
            {
                if (_DayVisible == value)
                    return;
                _DayVisible = value;
                RaisePropertyChanged();
            }
        }
        #endregion
        #region DayItems変更通知プロパティ
        private ObservableCollection<DateObject> _DayItems;

        public ObservableCollection<DateObject> DayItems
        {
            get
            { return _DayItems; }
            set
            {
                if (_DayItems == value)
                    return;
                _DayItems = value;
                RaisePropertyChanged();
            }
        }
        #endregion
        #region DaySelectedIndex変更通知プロパティ
        private int _DaySelectedIndex;

        public int DaySelectedIndex
        {
            get
            { return _DaySelectedIndex; }
            set
            { 
                if (_DaySelectedIndex == value)
                    return;
                _DaySelectedIndex = value;
                RaisePropertyChanged();
            }
        }
        #endregion
        #region DaySelectedValue変更通知プロパティ
        private DateObject _DaySelectedValue;

        public DateObject DaySelectedValue
        {
            get
            { return _DaySelectedValue; }
            set
            {
                if (_DaySelectedValue == value)
                    return;
                _DaySelectedValue = value;
                RaisePropertyChanged();
            }
        }
        #endregion
        #region DayTitle変更通知プロパティ
        private string _DayTitle;

        public string DayTitle
        {
            get
            { return _DayTitle; }
            set
            {
                if (_DayTitle == value)
                    return;
                _DayTitle = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        // 月表示モードで使用するプロパティ

        #region MonthVisible変更通知プロパティ
        private bool _MonthVisible;

        public bool MonthVisible
        {
            get
            { return _MonthVisible; }
            set
            { 
                if (_MonthVisible == value)
                    return;
                _MonthVisible = value;
                RaisePropertyChanged();
            }
        }
        #endregion
        #region MonthItems変更通知プロパティ
        private ObservableCollection<int> _MonthItems;

        public ObservableCollection<int> MonthItems
        {
            get
            { return _MonthItems; }
            set
            { 
                if (_MonthItems == value)
                    return;
                _MonthItems = value;
                RaisePropertyChanged();
            }
        }
        #endregion
        #region MonthSelectedValue変更通知プロパティ
        private int _MonthSelectedValue;

        public int MonthSelectedValue
        {
            get
            { return _MonthSelectedValue; }
            set
            { 
                if (_MonthSelectedValue == value)
                    return;
                _MonthSelectedValue = value;
                RaisePropertyChanged();
            }
        }
        #endregion
        #region MonthTitle変更通知プロパティ
        private string _MonthTitle;

        public string MonthTitle
        {
            get
            { return _MonthTitle; }
            set
            { 
                if (_MonthTitle == value)
                    return;
                _MonthTitle = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        // 年表示モードで使用するプロパティ

        #region YearVisible変更通知プロパティ
        private bool _YearVisible;

        public bool YearVisible
        {
            get
            { return _YearVisible; }
            set
            { 
                if (_YearVisible == value)
                    return;
                _YearVisible = value;
                RaisePropertyChanged();
            }
        }
        #endregion
        #region YearItems変更通知プロパティ
        private ObservableCollection<int> _YearItems;

        public ObservableCollection<int> YearItems
        {
            get
            { return _YearItems; }
            set
            { 
                if (_YearItems == value)
                    return;
                _YearItems = value;
                RaisePropertyChanged();
            }
        }
        #endregion
        #region YearSelectedValue変更通知プロパティ
        private int _YearSelectedValue;

        public int YearSelectedValue
        {
            get
            { return _YearSelectedValue; }
            set
            { 
                if (_YearSelectedValue == value)
                    return;
                _YearSelectedValue = value;
                RaisePropertyChanged();
            }
        }
        #endregion
        #region YearTitle変更通知プロパティ
        private string _YearTitle;

        public string YearTitle
        {
            get
            { return _YearTitle; }
            set
            { 
                if (_YearTitle == value)
                    return;
                _YearTitle = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        // 日表示モード、月表示モード、年表示モード、それぞれで使用する処理

        #region メソッド

        // 日表示モード関連
        
        // 日表示モードでのタイトルクリック
        // 日→月に、表示モードを切り替える
        public void DayTitleClick()
        {
            this.DayVisible = false;
            this.MonthVisible = true;
            this.YearVisible = false;

            if (this.MonthItems.Count == 0)
                this.MonthItems = new ObservableCollection<int>(Enumerable.Range(1, 12));

            this.MonthSelectedValue = this.DaySelectedValue.Date.Month;
            this.MonthTitle = $"{this.DaySelectedValue.Date.Year}年";

        }

        // 日付のクリックでは、コントロールの状態変化処理は無いため、
        // DayItemClick() という機能は無し
        //public void DayItemClick()
        //{

        //}

        // 指定の日付データを元に、その月の1か月間＋先月の余り分＋翌月の出だし分のリストを返却
        // →日表示モード時に、準備処理として呼び出される
        private List<DateObject> GetDayItems(DateTime dt)
        {
            // 今月分
            var days = Enumerable
                .Range(1, DateTime.DaysInMonth(dt.Year, dt.Month))
                .Select(day => new DateObject { Date = new DateTime(dt.Year, dt.Month, day) })
                .ToList();

            // 先月分
            var first = days.FirstOrDefault();
            for (var i = 0; i < (int)first.Date.DayOfWeek; i++)
            {
                days.Insert(0, new DateObject
                {
                    ThisMonthMember = false,
                    Date = days.FirstOrDefault().Date.AddDays(-1)
                });
            }

            // 翌月分
            var last = days.LastOrDefault();
            for (var i = 0; i < 6 - (int)last.Date.DayOfWeek; i++)
            {
                days.Add(new DateObject
                {
                    ThisMonthMember = false,
                    Date = days.LastOrDefault().Date.AddDays(1)
                });
            }

            return days;
            
        }

        // 月表示モード関連

        // 月表示モード時のタイトルクリック
        // 月→年に、表示モードを切り替える
        public void MonthTitleClick()
        {
            this.DayVisible = false;
            this.MonthVisible = false;
            this.YearVisible = true;

            // 現在の年
            var baseYear = this.DaySelectedValue.Date.Year;
            this.YearItems.Clear();
            this.YearItems.Add(baseYear);

            // 過去４年分
            for (var i = 0; i < 4; i++)
                this.YearItems.Insert(0, this.YearItems.FirstOrDefault() - 1);

            // 未来４年分
            for (var i = 0; i < 4; i++)
                this.YearItems.Add(this.YearItems.LastOrDefault() + 1);

            this.YearSelectedValue = baseYear;
            this.YearTitle = "年選択";

        }

        // 月表示モード時の日付クリック処理
        // 月→日に、表示モードを切り替える
        public void MonthItemClick(int month)
        {
            this.DayVisible = true;
            this.MonthVisible = false;
            this.YearVisible = false;

            // 選択中の年＋指定月＋１日目
            var date = new DateTime(this.DaySelectedValue.Date.Year, month, 1);
            var days = this.GetDayItems(date);

            this.DayItems.Clear();
            days.ForEach(x => this.DayItems.Add(x));

            this.DayTitle = date.ToString("yyyy年M月");
            this.DaySelectedValue = days.FirstOrDefault(x => x.Date == date);

            // MainModel 側で、検索処理を実行してもらう
            // →最終的に、本クラスの UpdateDayItems メソッドに戻ってくる
            this.ViewData?.SearchData();

        }

        // 年表示モード関連

        // 年選択タイトルのクリックでは、コントロールの状態変化処理は無いため、
        // YearTitleClick() という機能は無し
        //public void YearTitleClick()
        //{

        //}

        // 年表示モード時の月クリック処理
        // 年→月に、表示モードを切り替える
        public void YearItemClick(int year)
        {
            this.DayVisible = false;
            this.MonthVisible = true;
            this.YearVisible = false;

            this.DaySelectedValue.Date = new DateTime(year, this.DaySelectedValue.Date.Month, 1);
            this.MonthTitle = $"{this.DaySelectedValue.Date.Year}年";
            this.MonthSelectedValue = this.DaySelectedValue.Date.Month;

        }

        #endregion

        // コンストラクタ、MainModel からのイベントログデータ受け取り

        #region メソッド２

        // コンストラクタ
        public CalendarModel()
        {
            // 初期化
            this.DayVisible = true;
            this.MonthVisible = false;
            this.YearVisible = false;

            this.DayItems = new ObservableCollection<DateObject>();
            this.MonthItems = new ObservableCollection<int>();
            this.YearItems = new ObservableCollection<int>();

            // 今月分の表示
            var date = DateTime.Today;
            var days = this.GetDayItems(date);

            days.ForEach(x => this.DayItems.Add(x));
            this.DayTitle = date.ToString("yyyy年M月");
            this.DaySelectedValue = days.FirstOrDefault(x => x.Date == date);
            
        }

        // MainModel から情報、警告、エラーをセットするデータを受け取る
        // このリストを元に、DayItems の該当日付に対応している、InformationCount, WarningCount, ErrorCount
        // にセットする
        public void UpdateDayItems(string logName, string appliName, bool infoVisible, bool warnVisible, bool errorVisible)
        {
            // appliName が「全体」の場合、（検索条件的に）空欄に変更
            if (appliName == "全体")
                appliName = string.Empty;

            // 全データのうち、表示中の一か月分を取得
            var items = MemoryDB.Instance.EventLogDB[logName]
                .Where(x =>
                {
                    var b1 = x.TimeGenerated.Year == this.DaySelectedValue.Date.Year;
                    var b2 = x.TimeGenerated.Month == this.DaySelectedValue.Date.Month;
                    return b1 && b2;
                })
                .Where(x =>
                {
                    // 1:Error, 2:Warning, 3:Information, 4:Security Audit Success, 5:Security Audit Failure
                    var b1 = infoVisible ? x.EventType == 3 : false;
                    var b2 = warnVisible ? x.EventType == 2 : false;
                    var b3 = errorVisible ? x.EventType == 1 : false;
                    return b1 || b2 || b3;
                })
                .Where(x => string.IsNullOrWhiteSpace(appliName) ? true : x.SourceName == appliName)
                .ToList();

            // 日付リストのうち、任意の１日に該当するイベントログリストを取得
            var days = new List<DateObject>();
            foreach(var dayItem in this.DayItems)
            {
                // １日毎の DateObject クラスの未登録メンバーを補完しつつ、登録用リストを準備していく
                var item = dayItem;
                days.Add(item);

                var targets = items.Where(x => x.TimeGenerated.Day == item.Date.Day);
                if(targets == null || targets.Count() == 0)
                {
                    item.InformationCount = 0;
                    item.WarningCount = 0;
                    item.ErrorCount = 0;
                    continue;
                }
                
                if (infoVisible)
                    item.InformationCount = targets.Count(x => x.EventType == 3);
                else
                    item.InformationCount = 0;

                if (warnVisible)
                    item.WarningCount = targets.Count(x => x.EventType == 2);
                else
                    item.WarningCount = 0;

                if (errorVisible)
                    item.ErrorCount = targets.Count(x => x.EventType == 1);
                else
                    item.ErrorCount = 0;

                item.EventLogItems = targets.ToList();

            }

            this.DayItems = new ObservableCollection<DateObject>(days);

        }


        #endregion

    }
}
