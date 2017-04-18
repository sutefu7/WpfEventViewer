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
    public class GraphControlViewModel : ViewModel
    {

        #region GraphData変更通知プロパティ
        private GraphModel _GraphData;

        public GraphModel GraphData
        {
            get
            { return _GraphData; }
            set
            { 
                if (_GraphData == value)
                    return;
                _GraphData = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        public GraphControlViewModel()
        {
            this.GraphData = new GraphModel();
        }

        public void Initialize()
        {
        }
    }
}
