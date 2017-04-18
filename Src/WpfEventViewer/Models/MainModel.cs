using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Livet;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace WpfEventViewer.Models
{
    public class MainModel : NotificationObject
    {
        // 連携用の Model

        #region 連携用のModel

        // CalendarModel と通信用
        public CalendarModel CalendarData { get; set; } = null;

        // ListModel と通信用
        public ListModel ListData { get; set; } = null;

        // DetailModel と通信用
        public DetailModel DetailData { get; set; } = null;

        // GraphModel と通信用
        public GraphModel GraphData { get; set; } = null;

        #endregion

        // 検索関連

        #region EventLogNames変更通知プロパティ
        private ObservableCollection<string> _EventLogNames;

        public ObservableCollection<string> EventLogNames
        {
            get
            { return _EventLogNames; }
            set
            {
                if (_EventLogNames == value)
                    return;
                _EventLogNames = value;
                RaisePropertyChanged();
            }
        }
        #endregion
        #region EventLogNamesSelectedValue変更通知プロパティ
        private string _EventLogNamesSelectedValue;

        public string EventLogNamesSelectedValue
        {
            get
            { return _EventLogNamesSelectedValue; }
            set
            {
                if (_EventLogNamesSelectedValue == value)
                    return;
                _EventLogNamesSelectedValue = value;
                RaisePropertyChanged();
            }
        }
        #endregion
        #region EventLogNamesSelectionChangedメソッド

        // 検索処理の実行
        public void EventLogNamesSelectionChanged()
        {
            // 「未選択」なら何もしない
            var logName = this.EventLogNamesSelectedValue;
            if (logName == "未選択")
                return;

            // 指定ログを未取得の場合、取得する
            if (!MemoryDB.Instance.EventLogDB.ContainsKey(logName) || MemoryDB.Instance.EventLogDB[logName] == null)
                MemoryDB.Instance.GetEventLog(logName);

            // アプリ名一覧を更新、初期選択を「全体」にセット
            this.AppliNames.Clear();
            this.AppliNames.Add("全体");
            var items = MemoryDB.Instance.AppliNames[logName];
            items.ForEach(x => this.AppliNames.Add(x));
            this.AppliNamesSelectedValue = "全体";

            this.SearchData();
        }

        #endregion

        #region AppliNames変更通知プロパティ
        private ObservableCollection<string> _AppliNames;

        public ObservableCollection<string> AppliNames
        {
            get
            { return _AppliNames; }
            set
            {
                if (_AppliNames == value)
                    return;
                _AppliNames = value;
                RaisePropertyChanged();
            }
        }
        #endregion
        #region AppliNamesSelectedValue変更通知プロパティ
        private string _AppliNamesSelectedValue;

        public string AppliNamesSelectedValue
        {
            get
            { return _AppliNamesSelectedValue; }
            set
            {
                if (_AppliNamesSelectedValue == value)
                    return;
                _AppliNamesSelectedValue = value;
                RaisePropertyChanged();
            }
        }
        #endregion
        #region AppliNamesSelectionChangedメソッド

        // 検索処理の実行
        public void AppliNamesSelectionChanged()
        {
            if (this.AppliNamesSelectedValue == "全体")
            {
                this.WholeTabSelected = true;
                this.IndividualTabEnabled = false;
            }
            else
            {
                this.IndividualTabEnabled = true;
            }

            this.SearchData();
        }

        #endregion

        #region InfoChecked変更通知プロパティ
        private bool _InfoChecked;

        public bool InfoChecked
        {
            get
            { return _InfoChecked; }
            set
            {
                if (_InfoChecked == value)
                    return;
                _InfoChecked = value;
                RaisePropertyChanged();
            }
        }
        #endregion
        #region InfoCheckedChangedメソッド

        // 検索処理の実行
        public void InfoCheckedChanged()
        {
            this.SearchData();
        }

        #endregion

        #region WarnChecked変更通知プロパティ
        private bool _WarnChecked;

        public bool WarnChecked
        {
            get
            { return _WarnChecked; }
            set
            {
                if (_WarnChecked == value)
                    return;
                _WarnChecked = value;
                RaisePropertyChanged();
            }
        }
        #endregion
        #region WarnCheckedChangedメソッド

        // 検索処理の実行
        public void WarnCheckedChanged()
        {
            this.SearchData();
        }

        #endregion

        #region ErrorChecked変更通知プロパティ
        private bool _ErrorChecked;

        public bool ErrorChecked
        {
            get
            { return _ErrorChecked; }
            set
            {
                if (_ErrorChecked == value)
                    return;
                _ErrorChecked = value;
                RaisePropertyChanged();
            }
        }
        #endregion
        #region ErrorCheckedChangedメソッド

        // 検索処理の実行
        public void ErrorCheckedChanged()
        {
            this.SearchData();
        }

        #endregion

        // タブページ切り替え関連

        #region WholeTabSelected変更通知プロパティ
        private bool _WholeTabSelected;

        public bool WholeTabSelected
        {
            get
            { return _WholeTabSelected; }
            set
            {
                if (_WholeTabSelected == value)
                    return;
                _WholeTabSelected = value;
                RaisePropertyChanged();
            }
        }
        #endregion
        #region IndividualTabEnabled変更通知プロパティ
        private bool _IndividualTabEnabled;

        public bool IndividualTabEnabled
        {
            get
            { return _IndividualTabEnabled; }
            set
            {
                if (_IndividualTabEnabled == value)
                    return;
                _IndividualTabEnabled = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        // カレンダーからリスト、リストから詳細コントロールへ渡すためのデータ

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
        #region ListViewItemSelectedValue変更通知プロパティ
        private Win32NTLogEventObject _ListViewItemSelectedValue;

        public Win32NTLogEventObject ListViewItemSelectedValue
        {
            get
            { return _ListViewItemSelectedValue; }
            set
            { 
                if (_ListViewItemSelectedValue == value)
                    return;
                _ListViewItemSelectedValue = value;
                RaisePropertyChanged();
            }
        }
        #endregion


        #region 処理

        // コンストラクタ
        public MainModel()
        {
            // 初期化
            this.EventLogNames = new ObservableCollection<string>();
            this.EventLogNamesSelectedValue = "未選択";
            this.AppliNames = new ObservableCollection<string>();
            this.AppliNamesSelectedValue = "全体";
            this.InfoChecked = true;
            this.WarnChecked = true;
            this.ErrorChecked = true;
            this.WholeTabSelected = true;
            this.IndividualTabEnabled = false;

            // ログ名一覧コンボボックスに、ログ一覧をセット
            this.EventLogNames.Add("未選択");
            var items = EventLog.GetEventLogs();
            foreach (var item in items)
            {
                if (item.Log == "Security")
                    continue;
                this.EventLogNames.Add(item.Log);
            }

        }

        // 指定条件で検索を実行（その後、更新処理）
        public void SearchData()
        {
            // 「未選択」なら何もしない
            var logName = this.EventLogNamesSelectedValue;
            if (logName == "未選択")
                return;

            // CalendarModel 側で検索処理をしてもらう
            this.CalendarData?.UpdateDayItems(
                logName,
                this.AppliNamesSelectedValue,
                this.InfoChecked,
                this.WarnChecked,
                this.ErrorChecked);

            // 個別タブページ側にあるグラフの更新
            var items = new ReadOnlyObservableCollection<DateObject>(this.CalendarData.DayItems);
            this.GraphData.UpdatePlotData(items);

            // 選択中のログ内容が変更したので、リストコントロールを更新
            // （続けて疑似クリックした前提）
            // 通常は、SelectionChanged イベント発生後に更新される MainModel/DaySelectedValue プロパティを使うが、このタイミングでは実際にはクリックしていないので null になる。
            // 無理やり実行したいので、【CalendarControl コントロール内に配置している ListView コントロール】にバインドしている CalendarModel/DaySelectedValue プロパティから取得する。
            if (this.CalendarData.DaySelectedValue != null)
            {
                this.DaySelectedValue = this.CalendarData.DaySelectedValue;
                this.DaySelectionChanged();
            }

        }

        // （日表示モード時の）カレンダーの日付選択イベント
        // リストコントロールに、ログ一覧を渡す
        public void DaySelectionChanged()
        {
            // 前回表示データをクリア
            this.ListData.LogItems = null;

            // 準備中の場合、更新しない
            if (this.DaySelectedValue == null || this.DaySelectedValue.EventLogItems == null)
                return;

            // 例えデータがあったとしても、表示結果上 3 つとも 0 件の場合、更新しない
            var b1 = this.DaySelectedValue.InformationCount == 0;
            var b2 = this.DaySelectedValue.WarningCount == 0;
            var b3 = this.DaySelectedValue.ErrorCount == 0;
            if (b1 && b2 && b3)
                return;

            this.ListData.LogItems = 
                new ObservableCollection<Win32NTLogEventObject>(this.DaySelectedValue.EventLogItems);

            // リストコントロールにデータが表示されている場合、そのまま1つ目の項目を選択して詳細データを更新
            // （続けて疑似クリックした前提）
            this.ListData.SelectedIndex = 0;
            this.ListViewItemSelectionChanged();

        }

        // リストコントロールの項目選択イベント
        // 詳細コントロールに、ログ内容を渡す
        public void ListViewItemSelectionChanged()
        {
            // 前回表示データをクリア
            this.DetailData.LogData = null;

            // 準備中の場合、更新しない
            if (this.ListViewItemSelectedValue == null)
                return;

            this.DetailData.LogData = this.ListViewItemSelectedValue;
        }

        #endregion


    }
}
