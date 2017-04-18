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
    public class ListControlViewModel : ViewModel
    {

        #region ListData変更通知プロパティ
        private ListModel _ListData;

        public ListModel ListData
        {
            get
            { return _ListData; }
            set
            { 
                if (_ListData == value)
                    return;
                _ListData = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        public ListControlViewModel()
        {
            this.ListData = new ListModel();
        }

        public void Initialize()
        {
        }
    }
}
