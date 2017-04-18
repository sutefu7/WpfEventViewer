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
    public class DetailControlViewModel : ViewModel
    {

        #region DetailData変更通知プロパティ
        private DetailModel _DetailData;

        public DetailModel DetailData
        {
            get
            { return _DetailData; }
            set
            { 
                if (_DetailData == value)
                    return;
                _DetailData = value;
                RaisePropertyChanged();
            }
        }
        #endregion
        
        public DetailControlViewModel()
        {
            this.DetailData = new DetailModel();
        }

        public void Initialize()
        {
        }

    }
}
