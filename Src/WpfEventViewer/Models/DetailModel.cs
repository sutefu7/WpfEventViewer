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
    public class DetailModel : NotificationObject
    {

        #region LogData変更通知プロパティ
        private Win32NTLogEventObject _LogData;

        public Win32NTLogEventObject LogData
        {
            get
            { return _LogData; }
            set
            { 
                if (_LogData == value)
                    return;
                _LogData = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        public DetailModel()
        {

        }


    }
}
