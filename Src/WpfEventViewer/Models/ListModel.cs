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
    public class ListModel : NotificationObject
    {

        #region LogItems変更通知プロパティ
        private ObservableCollection<Win32NTLogEventObject> _LogItems;

        public ObservableCollection<Win32NTLogEventObject> LogItems
        {
            get
            { return _LogItems; }
            set
            { 
                if (_LogItems == value)
                    return;
                _LogItems = value;
                RaisePropertyChanged();
            }
        }
        #endregion
        #region SelectedIndex変更通知プロパティ
        private int _SelectedIndex;

        public int SelectedIndex
        {
            get
            { return _SelectedIndex; }
            set
            { 
                if (_SelectedIndex == value)
                    return;
                _SelectedIndex = value;
                RaisePropertyChanged();
            }
        }
        #endregion
        
        public ListModel()
        {
            this.LogItems = new ObservableCollection<Win32NTLogEventObject>();
        }



    }
}
