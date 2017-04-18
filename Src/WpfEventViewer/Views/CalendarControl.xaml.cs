using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfEventViewer.Views
{
    /// <summary>
    /// CalendarControl.xaml の相互作用ロジック
    /// </summary>
    public partial class CalendarControl : UserControl
    {
        public CalendarControl()
        {
            InitializeComponent();
        }

        #region 日表示用プロパティとイベント

        // 現在の選択日付プロパティ
        // DaySelectionChanged イベント発生タイミングで更新される
        // 他の View 側で使用する用
        // （妥協）本来は Models/DateObject 型なのだが、参照したくないため object 型渡し・・・orz
        public static readonly DependencyProperty DaySelectedValueProperty =
            DependencyProperty.Register("DaySelectedValue", typeof(object), typeof(CalendarControl), new PropertyMetadata(null));

        public object DaySelectedValue
        {
            get { return GetValue(DaySelectedValueProperty); }
            set { SetValue(DaySelectedValueProperty, value); }
        }

        // 選択日付を変更した時に発行するルーティングイベント
        public static readonly RoutedEvent DaySelectionChangedEvent =
            EventManager.RegisterRoutedEvent("DaySelectionChanged", RoutingStrategy.Bubble, typeof(SelectionChangedEventHandler), typeof(CalendarControl));

        public event SelectionChangedEventHandler DaySelectionChanged
        {
            add { AddHandler(DaySelectionChangedEvent, value); }
            remove { RemoveHandler(DaySelectionChangedEvent, value); }
        }

        // 選択日付の変更イベントを、外部コントロールに発行する
        // 他の View 側で使用する用
        private void ListBox_DaySelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // SelectionChangedEventArgs を丸ごとセットするのではなく、Model 層の DateObject のみセットするように修正
            if (0 < e.AddedItems.Count)
                this.DaySelectedValue = e.AddedItems[0];
            else
                this.DaySelectedValue = null;

            var eventArgs = new SelectionChangedEventArgs(CalendarControl.DaySelectionChangedEvent, e.RemovedItems, e.AddedItems);
            RaiseEvent(eventArgs);
        }

        #endregion

        #region 月表示用プロパティとイベント

        // 現在の選択月プロパティ
        // MonthSelectionChanged イベント発生タイミングで更新される
        // 他の View 側で使用する用
        public static readonly DependencyProperty MonthSelectedValueProperty =
            DependencyProperty.Register("MonthSelectedValue", typeof(int), typeof(CalendarControl), new PropertyMetadata(null));

        public int MonthSelectedValue
        {
            get { return (int)GetValue(MonthSelectedValueProperty); }
            set { SetValue(MonthSelectedValueProperty, value); }
        }

        // 選択月を変更した時に発行するルーティングイベント
        public static readonly RoutedEvent MonthSelectionChangedEvent =
            EventManager.RegisterRoutedEvent("MonthSelectionChanged", RoutingStrategy.Bubble, typeof(SelectionChangedEventHandler), typeof(CalendarControl));

        public event SelectionChangedEventHandler MonthSelectionChanged
        {
            add { AddHandler(MonthSelectionChangedEvent, value); }
            remove { RemoveHandler(MonthSelectionChangedEvent, value); }
        }

        // 選択月の変更イベントを、外部コントロールに発行する
        // 他の View 側で使用する用
        private void ListBox_MonthSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // SelectionChangedEventArgs を丸ごとセットするのではなく、月（int型） のみセットするように修正
            if (0 < e.AddedItems.Count)
                this.MonthSelectedValue = int.Parse(e.AddedItems[0].ToString());
            else
                this.MonthSelectedValue = default(int);

            var eventArgs = new SelectionChangedEventArgs(CalendarControl.MonthSelectionChangedEvent, e.RemovedItems, e.AddedItems);
            RaiseEvent(eventArgs);
        }

        #endregion

        #region 年表示用プロパティとイベント

        // 現在の選択年プロパティ
        // YearSelectionChanged イベント発生タイミングで更新される
        // 他の View 側で使用する用
        public static readonly DependencyProperty YearSelectedValueProperty =
            DependencyProperty.Register("YearSelectedValue", typeof(int), typeof(CalendarControl), new PropertyMetadata(null));

        public int YearSelectedValue
        {
            get { return (int)GetValue(YearSelectedValueProperty); }
            set { SetValue(YearSelectedValueProperty, value); }
        }

        // 選択年を変更した時に発行するルーティングイベント
        public static readonly RoutedEvent YearSelectionChangedEvent =
            EventManager.RegisterRoutedEvent("YearSelectionChanged", RoutingStrategy.Bubble, typeof(SelectionChangedEventHandler), typeof(CalendarControl));

        public event SelectionChangedEventHandler YearSelectionChanged
        {
            add { AddHandler(YearSelectionChangedEvent, value); }
            remove { RemoveHandler(YearSelectionChangedEvent, value); }
        }

        // 選択年の変更イベントを、外部コントロールに発行する
        // 他の View 側で使用する用
        private void ListBox_YearSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // SelectionChangedEventArgs を丸ごとセットするのではなく、年（int型） のみセットするように修正
            if (0 < e.AddedItems.Count)
                this.YearSelectedValue = int.Parse(e.AddedItems[0].ToString());
            else
                this.YearSelectedValue = default(int);

            var eventArgs = new SelectionChangedEventArgs(CalendarControl.YearSelectionChangedEvent, e.RemovedItems, e.AddedItems);
            RaiseEvent(eventArgs);
        }

        #endregion

    }
}
