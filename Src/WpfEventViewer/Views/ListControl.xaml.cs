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
    /// ListControl.xaml の相互作用ロジック
    /// </summary>
    public partial class ListControl : UserControl
    {
        public ListControl()
        {
            InitializeComponent();
        }
        
        #region 項目選択プロパティとイベント

        // 現在の項目選択プロパティ
        // SelectionChanged イベント発生タイミングで更新される
        // 他の View 側で使用する用
        // （妥協）本来は Models/Win32NTLogEventObject 型なのだが、参照したくないため object 型渡し・・・orz
        public static readonly DependencyProperty SelectedValueProperty =
            DependencyProperty.Register("SelectedValue", typeof(object), typeof(ListControl), new PropertyMetadata(null));

        public object SelectedValue
        {
            get { return GetValue(SelectedValueProperty); }
            set { SetValue(SelectedValueProperty, value); }
        }

        // 選択日付を変更した時に発行するルーティングイベント
        public static readonly RoutedEvent SelectionChangedEvent =
            EventManager.RegisterRoutedEvent("SelectionChanged", RoutingStrategy.Bubble, typeof(SelectionChangedEventHandler), typeof(ListControl));

        public event SelectionChangedEventHandler SelectionChanged
        {
            add { AddHandler(SelectionChangedEvent, value); }
            remove { RemoveHandler(SelectionChangedEvent, value); }
        }

        // 変更イベントを、外部コントロールに発行する
        // 他の View 側で使用する用
        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // SelectionChangedEventArgs を丸ごとセットするのではなく、Model 層の Win32NTLogEventObject のみセットするように修正
            if (0 < e.AddedItems.Count)
                this.SelectedValue = e.AddedItems[0];
            else
                this.SelectedValue = null;

            var eventArgs = new SelectionChangedEventArgs(ListControl.SelectionChangedEvent, e.RemovedItems, e.AddedItems);
            RaiseEvent(eventArgs);
        }

        #endregion

    }
}
