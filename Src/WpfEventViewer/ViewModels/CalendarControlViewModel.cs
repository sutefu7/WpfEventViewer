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

using WpfEventViewer.Models;

namespace WpfEventViewer.ViewModels
{
    public class CalendarControlViewModel : ViewModel
    {

        #region CalendarData変更通知プロパティ
        private CalendarModel _CalendarData;

        public CalendarModel CalendarData
        {
            get
            { return _CalendarData; }
            set
            { 
                if (_CalendarData == value)
                    return;
                _CalendarData = value;
                RaisePropertyChanged();
            }
        }
        #endregion
        
        public CalendarControlViewModel()
        {
            this.CalendarData = new CalendarModel();
        }

        public void Initialize()
        {
        }

    }
}
