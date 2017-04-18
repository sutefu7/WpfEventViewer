using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Management; // WMI 経由でイベントログ取得
using System.Diagnostics; // EventLog

namespace WpfEventViewer.Models
{
    public class MemoryDB
    {
        // シングルトン
        private static MemoryDB _Instance;

        public static MemoryDB Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new MemoryDB();
                return _Instance;
            }
        }
        
        // キー：ログ名、値：イベントログ一覧
        public Dictionary<string, List<Win32NTLogEventObject>> EventLogDB { get; set; } = 
            new Dictionary<string, List<Win32NTLogEventObject>>();

        // キー：ログ名、値：アプリ名
        public Dictionary<string, List<string>> AppliNames { get; set; } =
            new Dictionary<string, List<string>>();

        // 指定ログのログ一覧を取得
        public void GetEventLog(string logName)
        {
            var qy = $@"SELECT * FROM Win32_NTLogEvent WHERE Logfile='{logName}' ";
            var items = new ManagementObjectSearcher(qy)
                .Get()
                .OfType<ManagementObject>()
                .Select(x => new Win32NTLogEventObject(x))
                .OrderBy(x => x.RecordNumber)
                .ThenBy(x => x.TimeGenerated);

            // 更新
            this.EventLogDB[logName] = items.ToList();

            var names = this.EventLogDB[logName]
                .Select(x => x.SourceName)
                .Distinct()
                .OrderBy(x => x);

            // 更新
            this.AppliNames[logName] = names.ToList();

        }

    }
}
