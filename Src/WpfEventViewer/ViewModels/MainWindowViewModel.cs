using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

using Livet;
using Livet.Commands;
using Livet.Messaging;
using Livet.Messaging.IO;
using Livet.EventListeners;
using Livet.Messaging.Windows;

using WpfEventViewer.ViewModels;
using WpfEventViewer.Models;
using System.Reflection;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Diagnostics;

namespace WpfEventViewer.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {

        #region CalendarVM変更通知プロパティ
        private CalendarControlViewModel _CalendarVM;

        public CalendarControlViewModel CalendarVM
        {
            get
            { return _CalendarVM; }
            set
            { 
                if (_CalendarVM == value)
                    return;
                _CalendarVM = value;
                RaisePropertyChanged();
            }
        }
        #endregion
        #region ListVM変更通知プロパティ
        private ListControlViewModel _ListVM;

        public ListControlViewModel ListVM
        {
            get
            { return _ListVM; }
            set
            { 
                if (_ListVM == value)
                    return;
                _ListVM = value;
                RaisePropertyChanged();
            }
        }
        #endregion
        #region DetailVM変更通知プロパティ
        private DetailControlViewModel _DetailVM;

        public DetailControlViewModel DetailVM
        {
            get
            { return _DetailVM; }
            set
            { 
                if (_DetailVM == value)
                    return;
                _DetailVM = value;
                RaisePropertyChanged();
            }
        }
        #endregion
        #region GraphVM変更通知プロパティ
        private GraphControlViewModel _GraphVM;

        public GraphControlViewModel GraphVM
        {
            get
            { return _GraphVM; }
            set
            { 
                if (_GraphVM == value)
                    return;
                _GraphVM = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region ViewData変更通知プロパティ
        private MainModel _ViewData;

        public MainModel ViewData
        {
            get
            { return _ViewData; }
            set
            { 
                if (_ViewData == value)
                    return;
                _ViewData = value;
                RaisePropertyChanged();
            }
        }
        #endregion
        
        // 初期化
        public void Initialize()
        {
            // CalendarControl 用の VM を初期化
            this.CalendarVM = new CalendarControlViewModel();

            // ListControl 用の VM を初期化
            this.ListVM = new ListControlViewModel();

            // DetailControl 用の VM を初期化
            this.DetailVM = new DetailControlViewModel();

            // GraphControl 用の VM を初期化
            this.GraphVM = new GraphControlViewModel();

            // やり取り処理があるため、Model 層のデータを相互参照させる
            // MainModel → 各モデルへ
            this.ViewData = new MainModel()
            {
                CalendarData = this.CalendarVM.CalendarData,
                ListData = this.ListVM.ListData,
                DetailData = this.DetailVM.DetailData,
                GraphData = this.GraphVM.GraphData,
            };

            // CalendarModel → MainModel へ
            this.CalendarVM.CalendarData.ViewData = this.ViewData;

        }
    }
}
